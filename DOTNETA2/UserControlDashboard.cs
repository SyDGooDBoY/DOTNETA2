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

        private void LoadListView1()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // 添加列头
            listView1.Columns.Clear();
            listView1.Columns.Add("Date", 130);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Category", 103);
            listView1.Columns.Add("Amount", 90);

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
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Label="#VALX\nAUD #VALY{N2}"; 
            foreach (var d in data)
                chart1.Series[0].Points.AddXY(d.Key.ToString(), d.Value);
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
            LoadMonthlyChart(); // 示例数据：柱状图
            LoadCategoryChart(); // 示例数据：饼状图
            LoadListView1();
            LoadDashboardSummary();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
