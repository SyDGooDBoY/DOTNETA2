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
        private bool loading = false;
        public UserControlReport()
        {
            InitializeComponent();
        }

        private void UserControlReport_Load(object sender, EventArgs e)
        {
            loading = true;
            //year
            List<int> years = tc.GetAvailableYears();
            comboBox1.Items.Clear();
            foreach (int year in years)
            {
                comboBox1.Items.Add(year);
            }
            comboBox1.SelectedItem = DateTime.Now.Year;

            //month
            comboBox2.Items.Clear();            // 假设 comboBox2 = Month
            for (int m = 1; m <= 12; m++)
            {
                comboBox2.Items.Add(CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(m));
            }
            comboBox2.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            Console.WriteLine("DateTime.Now.Month:" + DateTime.Now.Month);
            loading = false;
            UpdateTitle();

        }

        private void LoadCategoryChart()
        {
            Dictionary<Category, decimal> data = tc.GetRecordByYearAndMonth((int)comboBox1.SelectedItem, comboBox2.SelectedIndex + 1, Enum.Type.Expense);
            if (data.Count>0)
            {
                label14.Visible = false;
            }
            else
            {
                label14.Visible = true;
            }
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Label = "#VALX";
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0]["PieLabelStyle"] = "Outside";
            chart1.Series[0]["PieLineColor"] = "Gray";
            chart1.Series[0].SmartLabelStyle.Enabled = true;
            chart1.Series[0].SmartLabelStyle.MaxMovingDistance = 200;
            foreach (var d in data)
            {
                chart1.Series[0].Points.AddXY(d.Key.ToString(), d.Value);
            }

        }

        private void UpdateTitle()
        {
            var year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1; // 1..12
            Console.WriteLine("comboBox2.SelectedIndex:" + comboBox2.SelectedIndex);
            string monthName = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            label1.Text = $"Monthly Expense Report — {monthName} {year}";
            LoadCategoryChart();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateTitle();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateTitle();
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = chart1.HitTest(e.X, e.Y);
            if (hit.ChartElementType != ChartElementType.DataPoint || hit.PointIndex < 0) return;

            var pt = chart1.Series[0].Points[hit.PointIndex];
            string categoryName = pt.AxisLabel;

            ShowDrilldown(categoryName);
        }
        
        private void ShowDrilldown(string categoryName)
        {
            // 年月取自筛选
            int year = (int)comboBox1.SelectedItem;
            int month = comboBox2.SelectedIndex + 1;
            var category = (DOTNETA2.Enum.Category)System.Enum.Parse(
                typeof(DOTNETA2.Enum.Category),
                categoryName
            );

            // 1) 该类别的全部记录（按你现有接口命名改一下）
            var list = tc.GetTransactionsByCategory(new DateTime(year,month,1), DOTNETA2.Enum.Type.Expense,  category);

            if (list == null || list.Count == 0)
            {
                label13.Text   = categoryName;
                label12.Text = "—";
                label11.Text   = "—";
                label10.Text = "A$0.00";
                label9.Text = "0%";
                return;
            }

            // 2) 最大单笔 + 总额 + 占比
            var largest = list.OrderByDescending(t => t.Amount).First();
            decimal totalInCat = list.Sum(t => t.Amount);

            // 本月总额（已在 LoadReport 里算过，如果你那里有 total，可缓存；这里再取一次也行）
            var all = tc.GetRecordByYearAndMonth(year, month, DOTNETA2.Enum.Type.Expense);
            decimal monthTotal = all.Values.Sum();
            decimal share = monthTotal > 0 ? totalInCat / monthTotal : 0;

            // 3) 更新 UI
            label13.Text   = categoryName;
            label12.Text = $"A${largest.Amount:N2}";
            label11.Text   = $"{largest.Date:yyyy-MM-dd}";
            label10.Text = $"A${totalInCat:N2}";
            label9.Text = $"{share:P1}";
        }
    }
}
