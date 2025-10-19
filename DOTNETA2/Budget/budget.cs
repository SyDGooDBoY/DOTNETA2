using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DOTNETA2.Budget
{
    public class BudgetRecord
    {
        public int Year { get; set; }
        public int Month { get; set; }  // 1..12
        public decimal Limit { get; set; }
    }

    /// <summary>File-based monthly budget store. Keeps it simple (no DB migration).</summary>
    public static class BudgetManager
    {
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "budgets.json");

        private class Store { public List<BudgetRecord> Items { get; set; } = new(); }

        private static Store Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return new Store();
                var json = File.ReadAllText(FilePath);
                return string.IsNullOrWhiteSpace(json) ? new Store()
                    : (JsonSerializer.Deserialize<Store>(json) ?? new Store());
            }
            catch { return new Store(); }
        }

        private static void Save(Store store)
        {
            var json = JsonSerializer.Serialize(store, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static decimal GetBudget(int year, int month)
        {
            var s = Load();
            var rec = s.Items.Find(x => x.Year == year && x.Month == month);
            return rec?.Limit ?? 0m;
        }

        public static void SetBudget(int year, int month, decimal amount)
        {
            var s = Load();
            var rec = s.Items.Find(x => x.Year == year && x.Month == month);
            if (rec == null)
            {
                s.Items.Add(new BudgetRecord { Year = year, Month = month, Limit = amount });
            }
            else
            {
                rec.Limit = amount;
            }
            Save(s);
        }
    }
}