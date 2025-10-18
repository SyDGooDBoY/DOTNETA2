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

namespace DOTNETA2
{
    public partial class UserControlDashboard : UserControl
    {
        public UserControlDashboard()
        {
            InitializeComponent();

            // Load balance on initialization
            LoadBalance();
        }

        //show balance
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

        private void lblBalanceTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
