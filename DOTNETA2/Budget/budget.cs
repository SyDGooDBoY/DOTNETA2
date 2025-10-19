using System.Text.Json;

namespace DOTNETA2.Budget
{
    /// Represents a monthly budget record for a given year and month.
    public class BudgetRecord
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Limit { get; set; }
    }

    /// Handles reading and writing of budget data to a local JSON file.
    public static class BudgetManager
    {
        // Path to the local storage file (budgets.json) located in the app's base directory.
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "budgets.json");

        /// Internal data structure for serialization and deserialization.
        private class Store
        {
            public List<BudgetRecord> Items { get; set; } = new();  // List of all budget records
        }

        /// Loads the current list of budget records from the JSON file.
        /// If the file does not exist or is invalid, returns an empty Store.
        private static Store Load()
        {
            try
            {
                // If file doesn’t exist, return empty list
                if (!File.Exists(FilePath)) return new Store();

                // Read JSON content
                var json = File.ReadAllText(FilePath);

                // Deserialize JSON into Store object; return empty if failed
                return string.IsNullOrWhiteSpace(json) ? new Store()
                    : (JsonSerializer.Deserialize<Store>(json) ?? new Store());
            }
            catch
            {
                // In case of any exception (file access, JSON error), return empty list
                return new Store();
            }
        }

        /// Saves the current Store (budget list) back to the JSON file.
        private static void Save(Store store)
        {
            // Serialize object into human-readable JSON format
            var json = JsonSerializer.Serialize(store, new JsonSerializerOptions { WriteIndented = true });

            // Overwrite the file with new data
            File.WriteAllText(FilePath, json);
        }

        /// Retrieves the budget limit for a specific year and month.
        /// Returns 0 if no record is found.
        public static decimal GetBudget(int year, int month)
        {
            var s = Load();  // Load all budgets
            var rec = s.Items.Find(x => x.Year == year && x.Month == month); // Find matching record
            return rec?.Limit ?? 0m;  // Return found limit or 0 if not found
        }

        /// Sets or updates the budget amount for a specific year and month.
        /// If a record already exists, its limit is updated; otherwise, a new one is added.
        public static void SetBudget(int year, int month, decimal amount)
        {
            var s = Load();  // Load all budgets
            var rec = s.Items.Find(x => x.Year == year && x.Month == month);  // Search for an existing record

            if (rec == null)
            {
                // No record found — create a new one
                s.Items.Add(new BudgetRecord { Year = year, Month = month, Limit = amount });
            }
            else
            {
                // Record exists — update the limit value
                rec.Limit = amount;
            }

            // Save updated data back to file
            Save(s);
        }
    }
}
