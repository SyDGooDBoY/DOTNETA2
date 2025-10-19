using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DOTNETA2.Budget;
using DOTNETA2.Controller;

namespace DOTNETA2
{
    public partial class UserControlBudget : UserControl
    {
        private readonly TransactionController tc = new TransactionController();
        private bool loading = false;

        public UserControlBudget()
        {
            InitializeComponent();
            this.Load += UserControlBudget_Load;
        }

        private void UserControlBudget_Load(object sender, EventArgs e)
        {
            LoadBudget();  // expose same pattern as Report.LoadReport():contentReference[oaicite:3]{index=3}
        }

        public void LoadBudget()
        {
            loading = true;

            // Year
            comboBox1.Items.Clear();
            foreach (var y in tc.GetAvailableYears()) comboBox1.Items.Add(y);
            if (comboBox1.Items.Count == 0) comboBox1.Items.Add(DateTime.Now.Year);
            comboBox1.SelectedItem = DateTime.Now.Year;

            // Month
            comboBox2.Items.Clear();
            for (int m = 1; m <= 12; m++)
                comboBox2.Items.Add(CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(m));
            comboBox2.SelectedIndex = DateTime.Now.Month - 1;

            loading = false;
            RefreshStats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            RefreshStats();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            RefreshStats();
        }

        private void button1_Save_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedIndex < 0) return;

            int year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1;
            decimal limit = numericUpDown1.Value;

            if (limit <= 0)
            {
                MessageBox.Show("Budget must be greater than 0.");
                return;
            }

            BudgetManager.SetBudget(year, month, limit);
            MessageBox.Show("Budget saved.");
            RefreshStats(); // also triggers threshold checks
        }

        private void button2_Clear_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        private void RefreshStats()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedIndex < 0) return;

            int year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1;

            // Load budget
            decimal budget = BudgetManager.GetBudget(year, month);
            numericUpDown1.Value = budget <= numericUpDown1.Maximum ? budget : numericUpDown1.Maximum;

            // Get spent (reuse controller the same way Report does):contentReference[oaicite:4]{index=4}
            var dict = tc.GetRecordByYearAndMonth(year, month, DOTNETA2.Enum.Type.Expense);
            decimal spent = dict.Values.Sum();

            // Compute
            decimal remaining = Math.Max(0, budget - spent);
            decimal usage = (budget > 0) ? (spent / budget) : 0m;

            // Update UI
            var au = new CultureInfo("en-AU");
            labelBudget.Text = (budget > 0 ? budget : 0).ToString("C", au);
            labelSpent.Text = spent.ToString("C", au);
            labelRemain.Text = remaining.ToString("C", au);
            labelUsage.Text = (usage > 0 ? usage : 0).ToString("P1", CultureInfo.InvariantCulture);

            // ProgressBar in 0..100
            int pct = (budget > 0) ? (int)Math.Min(100, Math.Round(usage * 100m)) : 0;
            progressBar1.Value = Math.Max(0, Math.Min(100, pct));

            // Threshold alerts (MessageBox style, consistent with Trans UI):contentReference[oaicite:5]{index=5}
            if (budget > 0)
            {
                if (spent >= budget)
                {
                    MessageBox.Show("Alert: You have reached or exceeded your monthly budget.");
                }
                else if (spent >= 0.75m * budget)
                {
                    MessageBox.Show("Heads up: You have used 75% of your monthly budget.");
                }
            }
        }
    }
}
