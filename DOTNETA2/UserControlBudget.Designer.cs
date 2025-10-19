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
            panel1 = new Panel();
            title = new Label();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            progressBar1 = new ProgressBar();
            labelUsage = new Label();
            labelRemain = new Label();
            labelSpent = new Label();
            labelBudget = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 71, 160);
            panel1.Controls.Add(title);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(781, 76);
            panel1.TabIndex = 0;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Century Gothic", 17.25F);
            title.ForeColor = SystemColors.ControlLightLight;
            title.Location = new Point(36, 27);
            title.Margin = new Padding(2, 0, 2, 0);
            title.Name = "title";
            title.Size = new Size(248, 27);
            title.TabIndex = 0;
            title.Text = "Monthly Budget Plan";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 76);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(781, 66);
            panel2.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(669, 19);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(80, 29);
            button2.TabIndex = 7;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Clear_Click;
            // 
            // button1
            // 
            button1.Location = new Point(576, 19);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(80, 29);
            button1.TabIndex = 6;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Save_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(434, 22);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(115, 23);
            numericUpDown1.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(247, 22);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(117, 25);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(72, 22);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 25);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(377, 24);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 2;
            label5.Text = "Amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 24);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 17);
            label3.TabIndex = 1;
            label3.Text = "Month :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 24);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 0;
            label2.Text = "Year :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(labelUsage);
            groupBox1.Controls.Add(labelRemain);
            groupBox1.Controls.Add(labelSpent);
            groupBox1.Controls.Add(labelBudget);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(13, 160);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(754, 307);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Summary";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(42, 208);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(685, 22);
            progressBar1.TabIndex = 9;
            // 
            // labelUsage
            // 
            labelUsage.AutoSize = true;
            labelUsage.Location = new Point(120, 165);
            labelUsage.Margin = new Padding(2, 0, 2, 0);
            labelUsage.Name = "labelUsage";
            labelUsage.Size = new Size(26, 17);
            labelUsage.TabIndex = 10;
            labelUsage.Text = "0%";
            // 
            // labelRemain
            // 
            labelRemain.AutoSize = true;
            labelRemain.Location = new Point(120, 126);
            labelRemain.Margin = new Padding(2, 0, 2, 0);
            labelRemain.Name = "labelRemain";
            labelRemain.Size = new Size(39, 17);
            labelRemain.TabIndex = 11;
            labelRemain.Text = "$0.00";
            // 
            // labelSpent
            // 
            labelSpent.AutoSize = true;
            labelSpent.Location = new Point(120, 88);
            labelSpent.Margin = new Padding(2, 0, 2, 0);
            labelSpent.Name = "labelSpent";
            labelSpent.Size = new Size(39, 17);
            labelSpent.TabIndex = 12;
            labelSpent.Text = "$0.00";
            // 
            // labelBudget
            // 
            labelBudget.AutoSize = true;
            labelBudget.Location = new Point(120, 49);
            labelBudget.Margin = new Padding(2, 0, 2, 0);
            labelBudget.Name = "labelBudget";
            labelBudget.Size = new Size(39, 17);
            labelBudget.TabIndex = 13;
            labelBudget.Text = "$0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 165);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(48, 17);
            label8.TabIndex = 14;
            label8.Text = "Usage:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 126);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(72, 17);
            label7.TabIndex = 15;
            label7.Text = "Remaining:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 88);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 16;
            label6.Text = "Spent:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 49);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 17);
            label4.TabIndex = 17;
            label4.Text = "Budget:";
            // 
            // UserControlBudget
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "UserControlBudget";
            Size = new Size(781, 505);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
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
