using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DOTNETA2.Controller;
using DOTNETA2.Advise;   // SpendingAdvisor.BuildAdvice(...)
                         // If your Advise.cs declares a different namespace, adjust this using.
namespace DOTNETA2
{
    public partial class UserControlAdvise : UserControl
    {
        private readonly TransactionController tc = new TransactionController();
        private bool loading = false;

        public UserControlAdvise()
        {
            InitializeComponent();
            this.Load += UserControlAdvise_Load;
        }

        private void UserControlAdvise_Load(object sender, EventArgs e)
        {
            LoadFilters();        // same pattern as Report:contentReference[oaicite:3]{index=3}
            RunAnalysis();        // auto-run current month on first load
        }

        private void LoadFilters()
        {
            loading = true;

            // Year list (same approach as UserControlReport)
            var years = tc.GetAvailableYears();    // already used in Report:contentReference[oaicite:4]{index=4}
            comboBox1.Items.Clear();
            foreach (var y in years) comboBox1.Items.Add(y);
            if (comboBox1.Items.Count == 0) comboBox1.Items.Add(DateTime.Now.Year);
            comboBox1.SelectedItem = DateTime.Now.Year;

            // Month names (Jan..Dec) — consistent with Report’s UI style:contentReference[oaicite:5]{index=5}
            comboBox2.Items.Clear();
            for (int m = 1; m <= 12; m++)
                comboBox2.Items.Add(CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(m));
            comboBox2.SelectedIndex = DateTime.Now.Month - 1;

            loading = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunAnalysis();
        }

        private void RunAnalysis()
        {
            if (loading) return;
            if (comboBox1.SelectedItem == null || comboBox2.SelectedIndex < 0) return;

            int year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1;

            listBox1.Items.Clear();
            try
            {
                // Reuse your Advise engine (rule-based) to generate suggestions
                List<string> tips = SpendingAdvisor.BuildAdvice(tc, year, month);

                if (tips.Count == 0)
                {
                    listBox1.Items.Add("• No advice for the selected month.");
                    return;
                }

                foreach (var t in tips)
                    listBox1.Items.Add("• " + t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to analyze spending: " + ex.Message);
            }
        }
    }
}
