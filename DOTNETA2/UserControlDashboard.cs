using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Text;

namespace DOTNETA2
{
    public partial class UserControlDashboard : UserControl
    {

        private Chart chartMonthly;
        public UserControlDashboard()
        {
            InitializeComponent();

            // Load balance on initialization
            LoadBalance();
            //load monthly chart
            CreateMonthlyCart();

        }

        //show balance, income, expense
        private void LoadBalance()
        {
            decimal totalIncome = 3000.00m;
            decimal totalExpense = 3000.00m;
            decimal balance = 3000.00m; // Replace with actual balance retrieval logic

            //change currency format from chinese to au
            var au = new CultureInfoConverter().ConvertFromString("en-AU") as System.Globalization.CultureInfo;
            lblBalanceValue.Text = balance.ToString("C", au);
            lblExpenseValue.Text = totalExpense.ToString("C", au);
            lblIncomeValue.Text = balance.ToString("C", au);
        }

        //monthly chart
        private void CreateMonthlyCart()
        {
            chartMonthly = new Chart { Dock = DockStyle.Fill };

            var area = new ChartArea("Main");
            area.AxisX.Interval = 1;
            area.AxisX.Title = "Day";
            area.AxisY.Title = "Amount";
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisX.MajorGrid.Enabled = false;
            chartMonthly.ChartAreas.Add(area);

            var s = new Series("Expenses")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };
            chartMonthly.Series.Add(s);

            panelMonthlyHost.Controls.Add(chartMonthly);

            // 来点数据~
            LoadMonthlyFixedData();
        }

        private void LoadMonthlyFixedData()
        {
            // 1) 月份：用当前月，或固定到某月（例如 2025-10）
            var monthStart = DateTime.Now;
            // var monthStart = new DateTime(2025, 10, 1); // ← 固定月份时用这行
            int days = DateTime.DaysInMonth(monthStart.Year, monthStart.Month);

            // 2) 你的固定数据：key=日期(1..31), value=金额
            var data = new Dictionary<int, decimal>
    {
        { 1,  23.50m },
        { 3,  60.00m },
        { 5,  18.20m },
        { 12, 95.00m },
        { 18, 40.75m },
        { 22,120.00m },
        { 28, 75.30m }
    };

            var au = new System.Globalization.CultureInfo("en-AU");
            var series = chartMonthly.Series["Expenses"];
            series.Points.Clear();

            bool showAllDays = true; // =false 时只画有数据的天

            if (showAllDays)
            {
                // 画满整月，其它天补 0
                for (int d = 1; d <= days; d++)
                {
                    decimal val = data.TryGetValue(d, out var v) ? v : 0m;
                    int pointIndex = series.Points.AddXY(d.ToString("00"), (double)val);
                    series.Points[pointIndex].ToolTip = $"{monthStart:yyyy-MM}-{d:00}: {val.ToString("C", au)}";
                }
            }
            else
            {
                // 只画有数据的天
                foreach (var kv in data.OrderBy(k => k.Key))
                {
                    int d = kv.Key; decimal val = kv.Value;
                    int pointIndex = series.Points.AddXY(d.ToString("00"), (double)val);
                    series.Points[pointIndex].ToolTip = $"{monthStart:yyyy-MM}-{d:00}: {val.ToString("C", au)}";
                }
            }
        }

        private void lblBalanceTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
