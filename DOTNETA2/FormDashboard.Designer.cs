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
            panel1 = new System.Windows.Forms.Panel();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel2 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            labelTime = new System.Windows.Forms.Label();
            timerTime = new System.Windows.Forms.Timer(components);
            userControlDashboard1 = new DOTNETA2.UserControlDashboard();
            userControlTrans1 = new DOTNETA2.UserControlTrans();
            userControlAdvise1 = new DOTNETA2.UserControlAdvise();
            userControlBudget1 = new DOTNETA2.UserControlBudget();
            userControlReport1 = new DOTNETA2.UserControlReport();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)71)), ((int)((byte)160)));
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Location = new System.Drawing.Point(-8, -29);
            panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(476, 1160);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)224)), ((int)((byte)224)), ((int)((byte)224)));
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            button5.ForeColor = System.Drawing.Color.White;
            button5.Image = ((System.Drawing.Image)resources.GetObject("button5.Image"));
            button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button5.Location = new System.Drawing.Point(4, 956);
            button5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(482, 164);
            button5.TabIndex = 7;
            button5.Text = "Report";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)224)), ((int)((byte)224)), ((int)((byte)224)));
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            button4.ForeColor = System.Drawing.Color.White;
            button4.Image = ((System.Drawing.Image)resources.GetObject("button4.Image"));
            button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.Location = new System.Drawing.Point(6, 775);
            button4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(482, 188);
            button4.TabIndex = 6;
            button4.Text = "Budget";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)224)), ((int)((byte)224)), ((int)((byte)224)));
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Image = ((System.Drawing.Image)resources.GetObject("button3.Image"));
            button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.Location = new System.Drawing.Point(6, 605);
            button3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(482, 171);
            button3.TabIndex = 5;
            button3.Text = "Advise";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)224)), ((int)((byte)224)), ((int)((byte)224)));
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Image = ((System.Drawing.Image)resources.GetObject("button2.Image"));
            button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.Location = new System.Drawing.Point(4, 450);
            button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(484, 170);
            button2.TabIndex = 4;
            button2.Text = "Transaction";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            button1.ForeColor = System.Drawing.Color.White;
            button1.Image = ((System.Drawing.Image)resources.GetObject("button1.Image"));
            button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.Location = new System.Drawing.Point(6, 284);
            button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(482, 186);
            button1.TabIndex = 3;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
            pictureBox1.Location = new System.Drawing.Point(138, 103);
            pictureBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(262, 255);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new System.Drawing.Point(480, 5);
            panel2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1548, 106);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)71)), ((int)((byte)160)));
            label2.Location = new System.Drawing.Point(500, 4);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(531, 55);
            label2.TabIndex = 2;
            label2.Text = "Daily Expenses Tracker";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new System.Drawing.Point(1930, 20);
            labelTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(138, 31);
            labelTime.TabIndex = 3;
            labelTime.Text = "HH:MM:SS";
            // 
            // timerTime
            // 
            timerTime.Tick += timerTime_Tick;
            // 
            // userControlDashboard1
            // 
            userControlDashboard1.Location = new System.Drawing.Point(472, 60);
            userControlDashboard1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            userControlDashboard1.Name = "userControlDashboard1";
            userControlDashboard1.Size = new System.Drawing.Size(1654, 1056);
            userControlDashboard1.TabIndex = 4;
            // 
            // userControlTrans1
            // 
            userControlTrans1.Location = new System.Drawing.Point(472, 60);
            userControlTrans1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            userControlTrans1.Name = "userControlTrans1";
            userControlTrans1.Size = new System.Drawing.Size(1654, 1056);
            userControlTrans1.TabIndex = 5;
            // 
            // userControlAdvise1
            // 
            userControlAdvise1.Location = new System.Drawing.Point(472, 60);
            userControlAdvise1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            userControlAdvise1.Name = "userControlAdvise1";
            userControlAdvise1.Size = new System.Drawing.Size(1654, 1056);
            userControlAdvise1.TabIndex = 7;
            // 
            // userControlBudget1
            // 
            userControlBudget1.Location = new System.Drawing.Point(472, 60);
            userControlBudget1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            userControlBudget1.Name = "userControlBudget1";
            userControlBudget1.Size = new System.Drawing.Size(1654, 1056);
            userControlBudget1.TabIndex = 8;
            // 
            // userControlReport1
            // 
            userControlReport1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
            userControlReport1.Location = new System.Drawing.Point(472, 60);
            userControlReport1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            userControlReport1.Name = "userControlReport1";
            userControlReport1.Size = new System.Drawing.Size(1654, 1056);
            userControlReport1.TabIndex = 9;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2126, 1120);
            Controls.Add(userControlReport1);
            Controls.Add(userControlBudget1);
            Controls.Add(userControlAdvise1);
            Controls.Add(userControlTrans1);
            Controls.Add(userControlDashboard1);
            Controls.Add(labelTime);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Daily Expenses Tracker";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
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