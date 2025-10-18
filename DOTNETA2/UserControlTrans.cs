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
using DOTNETA2.Controller;
using DOTNETA2.Entity;

namespace DOTNETA2
{
    public partial class UserControlTrans : UserControl
    {
        private int id;
        private TransactionController tc = new TransactionController();
        public UserControlTrans()
        {
            InitializeComponent();
        }

        private void UserControlTrans_Load(object sender, EventArgs e)
        {
            //input area
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.DataSource = System.Enum.GetValues(typeof(DOTNETA2.Enum.Type));
            comboBox2.DataSource = System.Enum.GetValues(typeof(DOTNETA2.Enum.Category));
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Maximum = 1000000;
            LoadDataGridView1();
            LoadAllTransactions();
        }

        private void LoadDataGridView1()
        {
            //show area
            dataGridView1.Columns.Insert(0, new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Visible = false });
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("Category", "Category");
            dataGridView1.Columns.Add("Amount", "Amount");

            // 让金额列右对齐、带货币格式
            dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "C";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value;
            var type = (DOTNETA2.Enum.Type)comboBox1.SelectedItem;
            var category = (DOTNETA2.Enum.Category)comboBox2.SelectedItem;
            var amount = numericUpDown1.Value;
            if (amount <= 0)
            {
                MessageBox.Show("Amount must be greater than 0.");
                return;
            }
            if (id <0)
            {
                //append record
                tc.AddTransaction(date, type, category, amount);
                MessageBox.Show("Successful update!");
            }
            else
            {
                // update
                tc.UpdataTransaction(id, date, type, category, amount);
                id = -1;
                button1.Text = "Save";
                MessageBox.Show("Successfully added!");
            }
            Reset();
            LoadAllTransactions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            dateTimePicker1.Value = DateTime.Today;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            button1.Text = "Save";
            id = -1;
        }

        private void LoadAllTransactions()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            var list = tc.ShowTransactions(); // 从数据库取所有记录
            var au = new CultureInfo("en-AU");
            foreach (var t in list)
            {
                dataGridView1.Rows.Add(
                    t.Id,
                    t.Date.ToString("yyyy-MM-dd HH:mm"),
                    t.Type.ToString(),
                    t.Category.ToString(),
                    t.Amount.ToString("C", au)
                );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            if (MessageBox.Show("Delete this transaction?", "Confirm",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            tc.DeleteTransaction(id);
            LoadAllTransactions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.");
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            id = Convert.ToInt32(r.Cells["Id"].Value);
            Transaction? transaction = tc.ShowOneTransaction(id);
            if (transaction==null)
            {
                MessageBox.Show("The selected record is invalid.");
                return;
            }

            dateTimePicker1.Value = transaction.Date;
            comboBox1.SelectedItem = System.Enum.Parse<DOTNETA2.Enum.Type>(transaction.Type.ToString());
            comboBox2.SelectedItem=System.Enum.Parse<DOTNETA2.Enum.Category>(transaction.Category.ToString());
            numericUpDown1.Value = transaction.Amount;
            button1.Text = "Update";
        }
    }
}
