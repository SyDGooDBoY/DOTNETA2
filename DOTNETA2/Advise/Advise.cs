using System;
using System.Collections.Generic;
using System.Linq;
using DOTNETA2.Controller;
using DOTNETA2.Enum;
using DOTNETA2.Entity;

namespace DOTNETA2.Advise
{
    public static class SpendingAdvisor
    {
        /// <summary>
        /// Generate simple rule-based advice for a given month.
        /// </summary>
        public static List<string> BuildAdvice(TransactionController tc, int year, int month)
        {
            var tips = new List<string>();

            // 1) Current month category totals
            Dictionary<Category, decimal> catTotals =
                tc.GetRecordByYearAndMonth(year, month, Enum.Type.Expense); // existing API

            decimal monthTotal = catTotals.Values.Sum();
            if (monthTotal <= 0)
            {
                tips.Add("No expense records for the selected month. Keep tracking to receive tailored advice.");
                return tips;
            }

            // 2) Top categories by share
            var topCats = catTotals
                .OrderByDescending(kv => kv.Value)
                .Take(3)
                .ToList();

            foreach (var (cat, amount) in topCats)
            {
                decimal share = amount / monthTotal;
                if (share >= 0.30m)
                {
                    tips.Add($"High concentration: {cat} is {share:P0} of this month’s spending. Consider reducing variable items in this category.");
                }
                else if (share >= 0.20m)
                {
                    tips.Add($"{cat} takes {share:P0}. Set a soft cap (e.g., 10–15% lower next month) and monitor weekly.");
                }
            }

            // 3) Month-over-month spike vs. last 3 months (rolling average)
            decimal last3Avg = GetLastNMonthsAverage(tc, year, month, 3);
            if (last3Avg > 0)
            {
                decimal growth = (monthTotal - last3Avg) / last3Avg;
                if (growth >= 0.2m)
                {
                    tips.Add($"Spending spike: total expenses are {growth:P0} above your 3-month average. Review large or new recurring items.");
                }
                else if (growth <= -0.2m)
                {
                    tips.Add("Good trend: expenses are ≥20% below your 3-month average. Consider moving the surplus to savings.");
                }
            }

            // 4) Transaction patterns within each top category
            foreach (var (cat, amount) in topCats)
            {
                // reuse your existing per-category query API
                var list = tc.GetTransactionsByCategory(new DateTime(year, month, 1), Enum.Type.Expense, cat);
                if (list == null || list.Count == 0) continue;

                // Many small purchases → suggest batching
                int smallCount = list.Count(t => t.Amount < 20);
                if (smallCount >= 10)
                {
                    tips.Add($"{cat}: many small purchases detected (≥10 under $20). Try batching or weekly shopping lists to avoid impulse buys.");
                }

                // One very large purchase → sanity check or installment
                var maxTx = list.OrderByDescending(t => t.Amount).First();
                if (maxTx.Amount >= 0.25m * monthTotal)
                {
                    tips.Add($"{cat}: one large transaction (${maxTx.Amount:N2} on {maxTx.Date:yyyy-MM-dd}). Verify necessity or consider installments.");
                }
            }

            // 5) Generic housekeeping
            if (monthTotal >= 1000 && !topCats.Any(kv => kv.Key.ToString().Contains("Saving")))
                tips.Add("Consider setting an automated monthly transfer to savings right after payday.");

            if (tips.Count == 0)
                tips.Add("Spending looks balanced this month. Keep consistent tracking and consider setting a small saving target.");

            return tips;
        }

        private static decimal GetLastNMonthsAverage(TransactionController tc, int year, int month, int n)
        {
            decimal sum = 0;
            int count = 0;
            var cursor = new DateTime(year, month, 1);

            for (int i = 1; i <= n; i++)
            {
                cursor = cursor.AddMonths(-1);
                var dict = tc.GetRecordByYearAndMonth(cursor.Year, cursor.Month, Enum.Type.Expense);
                decimal total = dict.Values.Sum();
                if (total > 0)
                {
                    sum += total;
                    count++;
                }
            }
            return count > 0 ? sum / count : 0;
        }
    }
}
