using System;
using System.Collections.Generic;
using System.Linq;
using DOTNETA2.Controller;
using DOTNETA2.Enum;
using DOTNETA2.Entity;

namespace DOTNETA2.Advise
{
    /// Builds lightweight, rule-based spending tips for a given month.
    /// Relies on TransactionController’s existing summary/query APIs.
    public static class SpendingAdvisor
    {
        /// Generate simple rule-based advice for a given month.
        /// Rules:
        /// 1) Identify top spending categories and warn on high concentration.
        /// 2) Compare total vs. rolling 3-month average to detect spikes/drops.
        /// 3) Inspect patterns inside top categories (many small / one very large).
        /// 4) Add generic saving tips when reasonable.
        public static List<string> BuildAdvice(TransactionController tc, int year, int month)
        {
            var tips = new List<string>();

            // --- 1) Pull category totals for the target month (expenses only) ---
            // Expected: a map of Category -> total amount for that month.
            Dictionary<Category, decimal> catTotals =
                tc.GetRecordByYearAndMonth(year, month, Enum.Type.Expense) ?? new Dictionary<Category, decimal>();

            decimal monthTotal = catTotals.Values.Sum();
            if (monthTotal <= 0m)
            {
                tips.Add("No expense records for the selected month. Keep tracking to receive tailored advice.");
                return tips; // Nothing else to analyze
            }

            // --- 2) Focus on the top 3 categories by spend share ---
            var topCats = catTotals
                .OrderByDescending(kv => kv.Value)
                .Take(3)
                .ToList();

            foreach (var (cat, amount) in topCats)
            {
                // Share of total spend for this category (0..1)
                decimal share = amount / monthTotal;

                // Simple thresholds: >=30% → high concentration, >=20% → noticeable
                if (share >= 0.30m)
                {
                    tips.Add(
                        $"High concentration: {cat} is {share:P0} of this month’s spending. Consider reducing variable items in this category.");
                }
                else if (share >= 0.20m)
                {
                    tips.Add(
                        $"{cat} takes {share:P0}. Set a soft cap (e.g., 10–15% lower next month) and monitor weekly.");
                }
            }

            // --- 3) Month-over-month comparison vs. last 3 months average ---
            decimal last3Avg = GetLastNMonthsAverage(tc, year, month, 3);
            if (last3Avg > 0m)
            {
                decimal growth = (monthTotal - last3Avg) / last3Avg;
                if (growth >= 0.20m)
                {
                    tips.Add(
                        $"Spending spike: total expenses are {growth:P0} above your 3-month average. Review large or new recurring items.");
                }
                else if (growth <= -0.20m)
                {
                    tips.Add(
                        "Good trend: expenses are ≥20% below your 3-month average. Consider moving the surplus to savings.");
                }
            }

            // --- 4) Inspect patterns inside the top categories ---
            foreach (var (cat, _) in topCats)
            {
                // Query all expense transactions for this category in the month.
                var list = tc.GetTransactionsByCategory(new DateTime(year, month, 1), Enum.Type.Expense, cat);
                if (list == null || list.Count == 0) continue;

                // Many small purchases → suggest batching / lists
                int smallCount = list.Count(t => t.Amount < 20m);
                if (smallCount >= 10)
                {
                    tips.Add(
                        $"{cat}: many small purchases detected (≥10 under $20). Try batching or weekly shopping lists to avoid impulse buys.");
                }

                // One very large purchase → advise verification or installments
                var maxTx = list.OrderByDescending(t => t.Amount).First();
                if (maxTx.Amount >= 0.25m * monthTotal)
                {
                    tips.Add(
                        $"{cat}: one large transaction (${maxTx.Amount:N2} on {maxTx.Date:yyyy-MM-dd}). Verify necessity or consider installments.");
                }
            }

            // --- 5) Generic saving nudge (if spending is sizable and no 'Saving' category present) ---
            if (monthTotal >= 1000m &&
                !topCats.Any(kv => kv.Key.ToString().Contains("Saving", StringComparison.OrdinalIgnoreCase)))
            {
                tips.Add("Consider setting an automated monthly transfer to savings right after payday.");
            }

            // Fallback if no rules triggered anything specific
            if (tips.Count == 0)
            {
                tips.Add(
                    "Spending looks balanced this month. Keep consistent tracking and consider setting a small saving target.");
            }

            return tips;
        }

        /// Compute the average total monthly expenses across the previous N months (excluding the target month).
        /// Skips months with zero total to avoid diluting the average.
        private static decimal GetLastNMonthsAverage(TransactionController tc, int year, int month, int n)
        {
            decimal sum = 0m;
            int count = 0;
            var cursor = new DateTime(year, month, 1);

            for (int i = 1; i <= n; i++)
            {
                cursor = cursor.AddMonths(-1);
                var dict = tc.GetRecordByYearAndMonth(cursor.Year, cursor.Month, Enum.Type.Expense)
                           ?? new Dictionary<Category, decimal>();

                decimal total = dict.Values.Sum();
                if (total > 0m)
                {
                    sum += total;
                    count++;
                }
            }

            return count > 0 ? sum / count : 0m;
        }
    }
}