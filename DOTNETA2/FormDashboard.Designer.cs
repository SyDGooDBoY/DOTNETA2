namespace DOTNETA2
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            panel1 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            labelTime = new Label();
            timerTime = new System.Windows.Forms.Timer(components);
            userControlDashboard1 = new UserControlDashboard();
            userControlTrans1 = new UserControlTrans();
            userControlAdvise1 = new UserControlAdvise();
            userControlBudget1 = new UserControlBudget();
            userControlReport1 = new UserControlReport();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 71, 160);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-4, -16);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 636);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(2, 524);
            button5.Name = "button5";
            button5.Size = new Size(241, 90);
            button5.TabIndex = 7;
            button5.Text = "Report";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 425);
            button4.Name = "button4";
            button4.Size = new Size(241, 103);
            button4.TabIndex = 6;
            button4.Text = "Budget";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 332);
            button3.Name = "button3";
            button3.Size = new Size(241, 94);
            button3.TabIndex = 5;
            button3.Text = "Advise";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(2, 247);
            button2.Name = "button2";
            button2.Size = new Size(242, 93);
            button2.TabIndex = 4;
            button2.Text = "Transaction";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = SystemColors.ActiveCaption;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(3, 156);
            button1.Name = "button1";
            button1.Size = new Size(241, 102);
            button1.TabIndex = 3;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(58, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 140);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(240, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(774, 58);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 71, 160);
            label2.Location = new Point(250, 2);
            label2.Name = "label2";
            label2.Size = new Size(266, 27);
            label2.TabIndex = 2;
            label2.Text = "Daily Expenses Tracker";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(965, 11);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(70, 17);
            labelTime.TabIndex = 3;
            labelTime.Text = "HH:MM:SS";
            // 
            // timerTime
            // 
            timerTime.Tick += timerTime_Tick;
            // 
            // userControlDashboard1
            // 
            userControlDashboard1.Location = new Point(302, 169);
            userControlDashboard1.Name = "userControlDashboard1";
            userControlDashboard1.Size = new Size(669, 432);
            userControlDashboard1.TabIndex = 4;
            // 
            // userControlTrans1
            // 
            userControlTrans1.Location = new Point(250, 149);
            userControlTrans1.Name = "userControlTrans1";
            userControlTrans1.Size = new Size(801, 453);
            userControlTrans1.TabIndex = 5;
            // 
            // userControlAdvise1
            // 
            userControlAdvise1.Location = new Point(243, 143);
            userControlAdvise1.Name = "userControlAdvise1";
            userControlAdvise1.Size = new Size(817, 469);
            userControlAdvise1.TabIndex = 7;
            // 
            // userControlBudget1
            // 
            userControlBudget1.Location = new Point(240, 143);
            userControlBudget1.Name = "userControlBudget1";
            userControlBudget1.Size = new Size(820, 469);
            userControlBudget1.TabIndex = 8;
            // 
            // userControlReport1
            // 
            userControlReport1.Location = new Point(234, 33);
            userControlReport1.Name = "userControlReport1";
            userControlReport1.Size = new Size(827, 580);
            userControlReport1.TabIndex = 9;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 614);
            Controls.Add(userControlReport1);
            Controls.Add(userControlBudget1);
            Controls.Add(userControlAdvise1);
            Controls.Add(userControlTrans1);
            Controls.Add(userControlDashboard1);
            Controls.Add(labelTime);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Daily Expenses Tracker";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label labelTime;
        private System.Windows.Forms.Timer timerTime;
        private UserControlDashboard userControlDashboard1;
        private UserControlTrans userControlTrans1;
        private UserControlAdvise userControlAdvise1;
        private UserControlBudget userControlBudget1;
        private UserControlReport userControlReport1;
    }
}