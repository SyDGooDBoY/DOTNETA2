using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DOTNETA2.Controller;
using DOTNETA2.Enum;

namespace DOTNETA2
{
    public partial class UserControlReport : UserControl
    {
        private TransactionController tc = new TransactionController();
        //Check if the loading marker has been loaded
        private bool loading = false;
        public UserControlReport()
        {
            InitializeComponent();
        }

        private void UserControlReport_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        public void LoadReport()
        {
            loading = true;
            //Fill in the years with data into the drop-down box.
            List<int> years = tc.GetAvailableYears();
            comboBox1.Items.Clear();
            foreach (int year in years)
            {
                comboBox1.Items.Add(year);
            }
            comboBox1.SelectedItem = DateTime.Now.Year;

            
            //Fill in the English month into the drop-down box
            comboBox2.Items.Clear();
            for (int m = 1; m <= 12; m++)
            {
                comboBox2.Items.Add(CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(m));
            }
            comboBox2.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            loading = false;
            UpdateTitle();
        }

        private void LoadCategoryChart()
        {
            Dictionary<Category, decimal> data = tc.GetRecordByYearAndMonth((int)comboBox1.SelectedItem, comboBox2.SelectedIndex + 1, Enum.Type.Expense);
            //When there is no valid data, display the hint label.
            if (data.Count>0)
            {
                label14.Visible = false;
            }
            else
            {
                label14.Visible = true;
            }
            
            chart1.Series[0].Points.Clear();
            //label style
            chart1.Series[0].Label = "#AXISLABEL";
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0]["PieLabelStyle"] = "Outside";
            chart1.Series[0]["PieLineColor"] = "Gray";
            chart1.Series[0].SmartLabelStyle.Enabled = true;
            chart1.Series[0].SmartLabelStyle.MaxMovingDistance = 200;
            //fill into data
            foreach (var d in data)
            {
                chart1.Series[0].Points.AddXY(d.Key.ToString(), d.Value);
            }

        }

        //update Report title label
        private void UpdateTitle()
        {
            if (comboBox1.SelectedItem == null)
                return;
            var year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1; // 1..12
            string monthName = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            label1.Text = $"Monthly Expense Report — {monthName} {year}";
            LoadCategoryChart();
            
            //When the title is updated, reset the category details simultaneously.
            label13.Text   = "—";
            label12.Text = "—";
            label11.Text   = "—";
            label10.Text = "A$0.00";
            label9.Text = "0%";
        }
        //Monitor the update of the dropdown list
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateTitle();
        }

        //Monitor the update of the dropdown list
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateTitle();
        }

        //Implement the click function for the pie chart
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = chart1.HitTest(e.X, e.Y);
            if (hit.ChartElementType != ChartElementType.DataPoint || hit.PointIndex < 0) return;
            var pt = chart1.Series[0].Points[hit.PointIndex];
            string categoryName = pt.AxisLabel;
            UpdateCategoryDetails(categoryName);
        }
        
        //Update category details
        private void UpdateCategoryDetails(string categoryName)
        {
            //Read the year and month from the page
            int year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1;
            var category = (DOTNETA2.Enum.Category)System.Enum.Parse(
                typeof(DOTNETA2.Enum.Category),
                categoryName
            );
            
            var list = tc.GetTransactionsByCategory(new DateTime(year,month,1), DOTNETA2.Enum.Type.Expense,  category);

            //Initialization display when no valid data is available
            if (list == null || list.Count == 0)
            {
                label13.Text   = categoryName;
                label12.Text = "—";
                label11.Text   = "—";
                label10.Text = "A$0.00";
                label9.Text = "0%";
                return;
            }

            //Maximum single transaction + Total amount + Proportion
            var largest = list.OrderByDescending(t => t.Amount).First();
            decimal totalInCat = list.Sum(t => t.Amount);

            // The total amount for this month
            var all = tc.GetRecordByYearAndMonth(year, month, DOTNETA2.Enum.Type.Expense);
            decimal monthTotal = all.Values.Sum();
            decimal share = monthTotal > 0 ? totalInCat / monthTotal : 0;

            // 3) Update UI
            label13.Text   = categoryName;
            label12.Text = $"A${largest.Amount:N2}";
            label11.Text   = $"{largest.Date:yyyy-MM-dd}";
            label10.Text = $"A${totalInCat:N2}";
            label9.Text = $"{share:P1}";
        }
    }
}
