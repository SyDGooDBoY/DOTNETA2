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
using DOTNETA2.Entity;
using DOTNETA2.Enum;

namespace DOTNETA2
{
    public partial class UserControlDashboard : UserControl
    {
        private TransactionController tc = new TransactionController();

        public UserControlDashboard()
        {
            InitializeComponent();
        }

        private void LoadListView1()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // 添加列头
            listView1.Columns.Clear();
            listView1.Columns.Add("Date", 280);
            listView1.Columns.Add("Type", 130);
            listView1.Columns.Add("Category", 150);
            listView1.Columns.Add("Amount", 220);

            listView1.Items.Clear();
            var au = new CultureInfo("en-AU");
            foreach (Transaction t in tc.GetRecentTransactions(20))
            {
                var item = new ListViewItem($"{t.Date:yyyy-MM-dd HH:mm:ss}");
                item.SubItems.Add(t.Type.ToString());
                item.SubItems.Add(t.Category.ToString());
                item.SubItems.Add(t.Amount.ToString("C", au));
                listView1.Items.Add(item);
            }
        }
        
        private void LoadCategoryChart()
        {
            Dictionary<Category, decimal> data = tc.GetRecordByYearAndMonth(DateTime.Now.Year, DateTime.Now.Month, Enum.Type.Expense);
            foreach (var d in data)
            {
                Console.WriteLine("key:" + d.Key + "  value:" + d.Value);
            }
            decimal total = data.Values.Sum();
            var groupedData = new Dictionary<string, decimal>();
            decimal othersTotal = 0;
            foreach (var kv in data)
            {
                decimal percent = total == 0 ? 0 : (kv.Value / total * 100);
                if (percent < 5)
                {
                    othersTotal += kv.Value;
                }
                else
                {
                    groupedData[kv.Key.ToString()] = kv.Value;
                }
            }
            if (othersTotal > 0) groupedData["Others"] = othersTotal;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Label="#AXISLABEL\nAUD #VALY{N2}"; 
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0]["PieLabelStyle"] = "Outside";
            chart1.Series[0]["PieLineColor"] = "Gray";
            chart1.Series[0].SmartLabelStyle.Enabled = true;
            chart1.Series[0].SmartLabelStyle.MaxMovingDistance = 200;
            foreach (var d in groupedData)
            {
                Console.WriteLine("key:" + d.Key + "  value:" + d.Value);
                chart1.Series[0].Points.AddXY(d.Key, d.Value);
            }
        }
        
        private void LoadMonthlyChart()
        {
            var data = tc.GetMonthlyRecords(DateTime.Now.Year, Enum.Type.Expense);
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                chart2.Series[0].Points.AddXY(i + 1, data[i]);
            }
            chart2.ChartAreas[0].AxisX.Title = "Month";
            chart2.ChartAreas[0].AxisY.Title = "Expense";
        }

        private void LoadDashboardSummary()
        {
            decimal balance = tc.GetBalance();
            decimal totalIncome = tc.GetTotalIncome();
            decimal totalExpense = tc.GetTotalExpense();
            var au = new CultureInfo("en-AU");
            label5.Text = balance.ToString("C", au);
            label6.Text = totalIncome.ToString("C", au);
            label7.Text = totalExpense.ToString("C", au);
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            LoadDashBoard();
        }

        public void LoadDashBoard()
        {
            LoadMonthlyChart();
            LoadCategoryChart();
            LoadListView1();
            LoadDashboardSummary();
        }
    }
}
