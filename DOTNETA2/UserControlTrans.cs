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
        private int id=-1;//The id of the transaction that needs to be modified
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

            //Align the amounts to the right and apply currency formatting.
            dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "C";
            
            //Modification of dataGridView style
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        
        //Save button 
        private void button1_Click(object sender, EventArgs e)
        {
            //Get data from page
            var date = dateTimePicker1.Value;
            var type = (DOTNETA2.Enum.Type)comboBox1.SelectedItem;
            var category = (DOTNETA2.Enum.Category)comboBox2.SelectedItem;
            var amount = numericUpDown1.Value;
            if (amount <= 0)
            {
                MessageBox.Show("Amount must be greater than 0.");
                return;
            }
            
            //Determine whether it is a new addition or an update.
            if (id <0)
            {
                //new addition
                tc.AddTransaction(date, type, category, amount);
                MessageBox.Show("Successful added!");
            }
            else
            {
                // update
                tc.UpdataTransaction(id, date, type, category, amount);
                id = -1;
                button1.Text = "Save";
                MessageBox.Show("Successfully update!");
            }
            Reset();//Reset page
            LoadAllTransactions();
        }

        //Reset button
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //Reset page content
        private void Reset()
        {
            dateTimePicker1.Value = DateTime.Today;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            button1.Text = "Save";
            id = -1;
        }

        //Load data into the DataGridView
        private void LoadAllTransactions()
        {
            dataGridView1.Rows.Clear(); //Clear old data
            var list = tc.ShowTransactions(); // Get data from database
            var au = new CultureInfo("en-AU");
            //Fill in the data
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

        //Delete button
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

        //Edit button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.");
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            id = Convert.ToInt32(r.Cells["Id"].Value);//Obtain the id of the selected record
            Transaction? transaction = tc.ShowOneTransaction(id);
            if (transaction==null)
            {
                MessageBox.Show("The selected record is invalid.");
                return;
            }
            
            //Write the data back to the editing area
            dateTimePicker1.Value = transaction.Date;
            comboBox1.SelectedItem = System.Enum.Parse<DOTNETA2.Enum.Type>(transaction.Type.ToString());
            comboBox2.SelectedItem=System.Enum.Parse<DOTNETA2.Enum.Category>(transaction.Category.ToString());
            numericUpDown1.Value = transaction.Amount;
            button1.Text = "Update";
        }
    }
}
