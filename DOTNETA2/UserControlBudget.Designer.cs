namespace DOTNETA2
{
    partial class UserControlBudget
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();   // Clear
            this.button1 = new System.Windows.Forms.Button();   // Save
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();     // Amount
            this.label3 = new System.Windows.Forms.Label();     // Month
            this.label2 = new System.Windows.Forms.Label();     // Year
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUsage = new System.Windows.Forms.Label();
            this.labelRemain = new System.Windows.Forms.Label();
            this.labelSpent = new System.Windows.Forms.Label();
            this.labelBudget = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();     // Usage
            this.label7 = new System.Windows.Forms.Label();     // Remaining
            this.label6 = new System.Windows.Forms.Label();     // Spent
            this.label4 = new System.Windows.Forms.Label();     // Budget
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // panel1 (Header)
            //
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.title);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1562, 139);
            this.panel1.TabIndex = 0;
            //
            // title
            //
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.title.Location = new System.Drawing.Point(72, 50);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(248, 31);
            this.title.TabIndex = 0;
            this.title.Text = "Monthly Budget Plan";
            //
            // panel2 (Filters)
            //
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1562, 120);
            this.panel2.TabIndex = 1;
            //
            // button2 (Clear)
            //
            this.button2.Location = new System.Drawing.Point(1338, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 53);
            this.button2.TabIndex = 7;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Clear_Click);
            //
            // button1 (Save)
            //
            this.button1.Location = new System.Drawing.Point(1153, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Save_Click);
            //
            // numericUpDown1 (Budget amount)
            //
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numericUpDown1.Location = new System.Drawing.Point(867, 41);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(230, 38);
            this.numericUpDown1.TabIndex = 5;
            //
            // comboBox2 (Month)
            //
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(494, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(230, 39);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            //
            // comboBox1 (Year)
            //
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(145, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(230, 39);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            //
            // label5 (Amount)
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "Amount";
            //
            // label3 (Month)
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Month :";
            //
            // label2 (Year)
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Year :";
            //
            // groupBox1 (Summary)
            //
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.labelUsage);
            this.groupBox1.Controls.Add(this.labelRemain);
            this.groupBox1.Controls.Add(this.labelSpent);
            this.groupBox1.Controls.Add(this.labelBudget);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(26, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1508, 560);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            //
            // Labels (values)
            //
            this.labelBudget.AutoSize = true; this.labelBudget.Location = new System.Drawing.Point(240, 90); this.labelBudget.Text = "$0.00";
            this.labelSpent.AutoSize = true;  this.labelSpent.Location = new System.Drawing.Point(240, 160); this.labelSpent.Text  = "$0.00";
            this.labelRemain.AutoSize = true; this.labelRemain.Location = new System.Drawing.Point(240, 230); this.labelRemain.Text = "$0.00";
            this.labelUsage.AutoSize = true;  this.labelUsage.Location = new System.Drawing.Point(240, 300); this.labelUsage.Text  = "0%";
            //
            // Labels (captions)
            //
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(80, 90);  this.label4.Text = "Budget:";
            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(80, 160); this.label6.Text = "Spent:";
            this.label7.AutoSize = true; this.label7.Location = new System.Drawing.Point(80, 230); this.label7.Text = "Remaining:";
            this.label8.AutoSize = true; this.label8.Location = new System.Drawing.Point(80, 300); this.label8.Text = "Usage:";
            //
            // progressBar1
            //
            this.progressBar1.Location = new System.Drawing.Point(84, 380);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1370, 40);
            this.progressBar1.TabIndex = 9;
            //
            // UserControlBudget
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlBudget";
            this.Size = new System.Drawing.Size(1562, 921);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.Label labelSpent;
        private System.Windows.Forms.Label labelRemain;
        private System.Windows.Forms.Label labelUsage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
