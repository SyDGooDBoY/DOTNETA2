using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DOTNETA2.Controller;
using DOTNETA2.Enum;

namespace DOTNETA2
{
    public partial class UserControlDashboard : UserControl
    {
        private Chart chartMonthly;
        private Chart chartCategory;
        private TransactionController tc = new TransactionController();
        
        public UserControlDashboard()
        {
            InitializeComponent();
        }
        
        private void BuildCharts()
        {
            // 用 SplitContainer 上下分区更省心
            chartMonthly = new Chart
            {
                Dock = DockStyle.Top, 
                Height = this.Height / 2
            };
            chartMonthly.ChartAreas.Add(new ChartArea("Main"));
            var s1 = new Series("Monthly Expenses")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Main"
            };
            //修改自动补充0和13的问题
            var area = chartMonthly.ChartAreas["Main"];
            area.AxisX.Minimum = 1;
            area.AxisX.Maximum = 12;
            chartMonthly.Series.Add(s1);
            this.Controls.Add(chartMonthly);
            
            chartCategory = new Chart
            {
                Dock = DockStyle.Bottom,
                Height = this.Height / 2
            };
            chartCategory.ChartAreas.Add(new ChartArea("Main"));
            var s2 = new Series("Category Breakdown")
            {
                ChartType = SeriesChartType.Pie, ChartArea = "Main", IsValueShownAsLabel = true
            };
            chartCategory.Series.Add(s2);
            chartCategory.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Right
            });
            this.Controls.Add(chartCategory);
            
            chartCategory.MouseClick += ChartCategory_MouseClick;
        }

        private void LoadMonthlyChart()
        {
            var data = tc.GetMonthlyRecords(2025, Enum.Type.Expense);
            chartMonthly.Series[0].Points.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                chartMonthly.Series[0].Points.AddXY(i+1, data[i]);
            } 
            chartMonthly.ChartAreas[0].AxisX.Title = "Month";
            chartMonthly.ChartAreas[0].AxisY.Title = "Expense";
        }

        private void LoadCategoryChart()
        {
            Dictionary<Category, decimal> data = tc.GetRecordByYearAndMonth(2025, 10,Enum.Type.Expense);
            chartCategory.Series[0].Points.Clear();
            foreach (var d in data)
                chartCategory.Series[0].Points.AddXY(d.Key.ToString(), d.Value);
        }

        private void ChartCategory_MouseClick(object? sender, MouseEventArgs e)
        {
            var hit = chartCategory.HitTest(e.X, e.Y);
            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                string category = chartCategory.Series[0].Points[hit.PointIndex].AxisLabel;
                // TODO: 调用 _controller.GetMaxExpenseInCategory(year, month, category)
                MessageBox.Show($"Clicked: {category}");
            }
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            BuildCharts(); // 创建控件
            LoadMonthlyChart(); // 示例数据：柱状图
            LoadCategoryChart(); // 示例数据：饼状图
        }
    }
}
