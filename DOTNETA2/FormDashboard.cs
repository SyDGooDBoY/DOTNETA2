using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOTNETA2
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            timerTime.Start();
            this.Load += FormDashboard_Load;
        }

        //load form
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            //usercontrol hide
            
            userControlTrans1.Hide();
            userControlReport1.Hide();
            userControlBudget1.Hide();
            userControlAdvise1.Hide();

            //when open show dashboard
            userControlDashboard1.Show();
            userControlDashboard1.BringToFront();

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show current usercontrol dashboard
            userControlDashboard1.Show();
            userControlDashboard1.BringToFront();
            //hide other usercontrol
            userControlTrans1.Hide();
            userControlReport1.Hide();
            userControlBudget1.Hide();
            userControlAdvise1.Hide();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            //show time on screen
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //show current usercontrol transaction
            userControlTrans1.Show();
            userControlTrans1.BringToFront();

            //hide other usercontrol
            userControlDashboard1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //show current usercontrol advise
            userControlAdvise1.Show();
            userControlAdvise1.BringToFront();

            //hide other usercontrol
            userControlDashboard1.Hide();
            userControlTrans1.Hide();
            userControlReport1.Hide();
            userControlBudget1.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //show current usercontrol budget
            userControlBudget1.Show();
            userControlBudget1.BringToFront();

            //hide other usercontrol
            userControlDashboard1.Hide();
            userControlTrans1.Hide();
            userControlReport1.Hide();
            userControlAdvise1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //show current usercontrol report
            userControlReport1.Show();
            userControlReport1.BringToFront();

            //hide other usercontrol
            userControlDashboard1.Hide();
            userControlTrans1.Hide();
            userControlBudget1.Hide();
            userControlAdvise1.Hide();

        }
    }
}
