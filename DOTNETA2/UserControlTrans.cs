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

namespace DOTNETA2
{
    public partial class UserControlTrans : UserControl
    {
        private BindingList<Transaction> _transactions;
        private readonly CultureInfo _au = new CultureInfo("en-AU");
        public UserControlTrans()
        {
            InitializeComponent();
            Load += (_, __) => InitTransactionPage();
        }

        public class Transaction
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Category { get; set; } = "";
            public string Type { get; set; } = ""; // "Income" or "Expense"
            public decimal Amount { get; set; }
            public string Note { get; set; } = "";
        }

        private void InitTransactionPage()
        {
            // 1️⃣ 假数据
            _transactions = new BindingList<Transaction>(new List<Transaction>
            {
                new Transaction { Id=1, Date=DateTime.Now.AddDays(-5), Category="Salary", Type="Income", Amount=3500, Note="Part-time" },
                new Transaction { Id=2, Date=DateTime.Now.AddDays(-4), Category="Groceries", Type="Expense", Amount=80, Note="Coles" },
                new Transaction { Id=3, Date=DateTime.Now.AddDays(-3), Category="Transport", Type="Expense", Amount=20, Note="Bus" },
                new Transaction { Id=4, Date=DateTime.Now.AddDays(-2), Category="Dining", Type="Expense", Amount=45, Note="Dinner" },
                new Transaction { Id=5, Date=DateTime.Now.AddDays(-1), Category="Gift", Type="Income", Amount=200, Note="Birthday" },
            });

            // 2️⃣ 下拉框选项
            cmbTypeFilter.Items.AddRange(new[] { "All", "Income", "Expense" });
            cmbTypeFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndexChanged += (_, __) => ApplyFilter();

            // 3️⃣ DataGridView 设置
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.DataSource = _transactions;

            dgvTransactions.Columns.Clear();
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category" });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type", DataPropertyName = "Type" });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Amount", DataPropertyName = "Amount", DefaultCellStyle = new DataGridViewCellStyle { Format = "C", FormatProvider = _au } });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Note", DataPropertyName = "Note" });

            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.ReadOnly = true;

            // 4️按钮事件
            //btnAdd.Click += (_, __) => AddNewTransaction();
            btnDelete.Click += (_, __) => DeleteSelectedTransaction();
        }

        private void ApplyFilter()
        {
            string filter = cmbTypeFilter.SelectedItem?.ToString() ?? "All";
            if (filter == "All")
            {
                dgvTransactions.DataSource = _transactions;
            }
            else
            {
                var filtered = _transactions.Where(t => t.Type == filter).ToList();
                dgvTransactions.DataSource = new BindingList<Transaction>(filtered);
            }
        }

        private void AddNewTransaction()
        {
            //// 简单弹窗输入
            //using (var form = new AddTransactionForm(_transactions))
            //{
            //    form.ShowDialog();
            //    ApplyFilter();
            //}
        }

        private void DeleteSelectedTransaction()
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.", "Notice");
                return;
            }

            var tx = dgvTransactions.SelectedRows[0].DataBoundItem as Transaction;
            if (tx != null)
            {
                _transactions.Remove(tx);
                ApplyFilter();
            }
        }
    

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
