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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
