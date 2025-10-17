// File: Advise.cs
// Purpose: Self-contained "Advise" feature (no changes to existing files)

using System;
using System.Collections.Generic;
using System.Linq;
using DOTNETA2.Enum;        // Category enum
using DOTNETA2.Entity;      // Transaction model (implicitly referenced)
using DOTNETA2.Server;      // TransactionService
using TxType = DOTNETA2.Enum.Type;  // Alias to avoid conflict with System.Type

namespace DOTNETA2.Advise
{
    // Simple severity levels for UI display
    public enum AdviceSeverity { Info, Warning, Critical }

    // Lightweight DTO to render advice items
    public class AdviceItem
    {
        public AdviceSeverity Severity { get; set; }
        public string Title { get; set; } = "";
        public string Why { get; set; } = "";
        public string Action { get; set; } = "";
    }

    // Rule-based, deterministic advise engine
    public class AdviseService
    {
        private readonly TransactionService _tx;

        // Tunable thresholds
        private const int    BASELINE_MONTHS = 3;      // look back N months
        private const decimal SPIKE_PCT      = 0.30m;  // >= +30% vs baseline
        private const decimal SPIKE_MIN_ABS  = 50m;    // and +$50 at least
        private const decimal SAVINGS_OK     = 0.10m;  // <10% monthly savings => warn
        private const int    STREAK_WARN     = 10;     // >10 consecutive spend days

        public AdviseService(TransactionService tx) => _tx = tx;

        /// <summary>
        /// Produce up to 5 actionable suggestions for a given (year, month).
        /// </summary>
        public List<AdviceItem> Generate(int year, int month)
        {
            var res = new List<AdviceItem>();

            res.AddRange(Rule_CategorySpikeVsBaseline(year, month));  // uses GetRecordByYearAndMonth:contentReference[oaicite:1]{index=1}
            res.AddRange(Rule_TopSpenders(year, month));              // uses GetRecordByYearAndMonth:contentReference[oaicite:2]{index=2}

            var sr = Rule_SavingsRate(year, month);                   // uses GetMonthlyRecords:contentReference[oaicite:3]{index=3}
            if (sr != null) res.Add(sr);

            var streak = Rule_SpendingStreak(year, month);            // uses GetAllTransactions:contentReference[oaicite:4]{index=4}
            if (streak != null) res.Add(streak);

            return res.Take(5).ToList();
        }

        // ---------- RULE 1: Category spike vs baseline (last 3 months) ----------
        private IEnumerable<AdviceItem> Rule_CategorySpikeVsBaseline(int year, int month)
        {
            var items = new List<AdviceItem>();
            var thisMonth = _tx.GetRecordByYearAndMonth(year, month, TxType.Expense); // cat->amount:contentReference[oaicite:5]{index=5}
            if (thisMonth.Count == 0) return items;

            var prev = PreviousMonths(year, month, BASELINE_MONTHS);

            // Average baseline per category across previous months
            var baseline = new Dictionary<Category, decimal>();
            foreach (var (y, m) in prev)
            {
                var mDict = _tx.GetRecordByYearAndMonth(y, m, TxType.Expense);        // :contentReference[oaicite:6]{index=6}
                foreach (var kv in mDict)
                {
                    if (!baseline.ContainsKey(kv.Key)) baseline[kv.Key] = 0m;
                    baseline[kv.Key] += kv.Value;
                }
            }
            if (prev.Count > 0)
            {
                foreach (var k in baseline.Keys.ToList())
                    baseline[k] = baseline[k] / prev.Count;
            }

            foreach (var kv in thisMonth.OrderByDescending(k => k.Value))
            {
                var cat = kv.Key;
                var cur = kv.Value;
                var avg = baseline.TryGetValue(cat, out var b) ? b : 0m;
                if (avg <= 0) continue; // no baseline → skip

                var diff  = cur - avg;
                var pctUp = diff / avg;

                if (diff >= SPIKE_MIN_ABS && pctUp >= SPIKE_PCT)
                {
                    items.Add(new AdviceItem
                    {
                        Severity = AdviceSeverity.Warning,
                        Title    = $"Spike in {cat}",
                        Why      = $"{cat} is up {pctUp:P0} this month (+{diff:C}).",
                        Action   = $"Set a soft cap for {cat} around {(avg * 1.1m):C}–{(avg * 1.2m):C} next month."
                    });
                }
            }
            return items;
        }

        // ---------- RULE 2: Top spenders this month ----------
        private IEnumerable<AdviceItem> Rule_TopSpenders(int year, int month)
        {
            var items = new List<AdviceItem>();
            var byCat = _tx.GetRecordByYearAndMonth(year, month, TxType.Expense);     // :contentReference[oaicite:7]{index=7}
            if (byCat.Count == 0) return items;

            var total = byCat.Values.Sum();
            var top2  = byCat.OrderByDescending(k => k.Value).Take(2);

            foreach (var kv in top2)
            {
                var share = total > 0 ? kv.Value / total : 0m;
                items.Add(new AdviceItem
                {
                    Severity = share >= 0.30m ? AdviceSeverity.Warning : AdviceSeverity.Info,
                    Title    = $"Top expense: {kv.Key} {kv.Value:C}",
                    Why      = $"{kv.Key} accounts for {share:P0} of this month’s outflows.",
                    Action   = $"Trim {kv.Key} by {(kv.Value * 0.10m):C} next month."
                });
            }
            return items;
        }

        // ---------- RULE 3: Savings rate for (year, month) ----------
        private AdviceItem? Rule_SavingsRate(int year, int month)
        {
            var i12 = _tx.GetMonthlyRecords(year, TxType.Income);                     // :contentReference[oaicite:8]{index=8}
            var e12 = _tx.GetMonthlyRecords(year, TxType.Expense);                    // :contentReference[oaicite:9]{index=9}
            var idx = month - 1;
            if (idx < 0 || idx >= 12) return null;

            var income  = i12[idx];
            var expense = e12[idx];
            if (income <= 0) return null; // nothing to assess

            var savings = income - expense;
            var rate    = savings / income;

            if (rate < SAVINGS_OK)
            {
                return new AdviceItem
                {
                    Severity = AdviceSeverity.Warning,
                    Title    = $"Low savings rate ({rate:P0})",
                    Why      = $"Income {income:C} vs Expense {expense:C}. Savings {savings:C}.",
                    Action   = "Aim for 15–20% savings; reduce your largest discretionary category."
                };
            }
            return new AdviceItem
            {
                Severity = AdviceSeverity.Info,
                Title    = $"Healthy savings rate ({rate:P0})",
                Why      = $"Income {income:C}, Expense {expense:C}.",
                Action   = "Maintain habits; consider auto-transfer to savings on payday."
            };
        }

        // ---------- RULE 4: Consecutive-days spending streak ----------
        private AdviceItem? Rule_SpendingStreak(int year, int month)
        {
            var tx = _tx.GetAllTransactions()                                          // :contentReference[oaicite:10]{index=10}
                        .Where(t => t.Type == TxType.Expense)
                        .Where(t => t.Date.Year == year && t.Date.Month == month)
                        .OrderBy(t => t.Date.Date)
                        .ToList();
            if (tx.Count == 0) return null;

            var days = tx.Select(t => t.Date.Date).Distinct().OrderBy(d => d).ToList();
            int best = 1, cur = 1;
            for (int i = 1; i < days.Count; i++)
            {
                if ((days[i] - days[i - 1]).TotalDays == 1) cur++;
                else cur = 1;
                if (cur > best) best = cur;
            }

            if (best > STREAK_WARN)
            {
                return new AdviceItem
                {
                    Severity = AdviceSeverity.Warning,
                    Title    = $"Long spending streak ({best} days)",
                    Why      = "You logged expenses on many consecutive days.",
                    Action   = "Try a no-spend day this week and pre-plan meals/transport."
                };
            }
            return null;
        }

        // ---------- Helpers ----------
        private static List<(int y, int m)> PreviousMonths(int year, int month, int count)
        {
            var res = new List<(int, int)>();
            var d = new DateTime(year, month, 1);
            for (int i = 1; i <= count; i++)
            {
                var p = d.AddMonths(-i);
                res.Add((p.Year, p.Month));
            }
            return res;
        }
    }
}

//use example:
// var txService = new DOTNETA2.Server.TransactionService();
// var advise    = new DOTNETA2.Features.AdviseService(txService);
// var tips      = advise.Generate(DateTime.Now.Year, DateTime.Now.Month);
// // bind tips to a ListView/DataGridView in your Advise UI

