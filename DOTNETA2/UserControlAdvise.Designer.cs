namespace DOTNETA2
{
    partial class UserControlAdvise
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// Designer support — keep consistent with your other UserControls
        /// (header panel + filter panel + main content), like Report/Trans:contentReference[oaicite:6]{index=6}:contentReference[oaicite:7]{index=7}.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 71, 160);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(781, 76);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(32, 32);
            label1.Name = "label1";
            label1.Size = new Size(209, 27);
            label1.TabIndex = 0;
            label1.Text = "Spending Advice";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(781, 66);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(544, 18);
            button1.Name = "button1";
            button1.Size = new Size(98, 29);
            button1.TabIndex = 4;
            button1.Text = "Analyze";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(360, 21);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(144, 25);
            comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(95, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 25);
            comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 22);
            label3.Name = "label3";
            label3.Size = new Size(53, 17);
            label3.TabIndex = 1;
            label3.Text = "Month :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 22);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 0;
            label2.Text = "Year :";
            // 
            // listBox1
            // 
            listBox1.Location = new Point(13, 154);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(756, 327);
            listBox1.TabIndex = 2;
            // 
            // UserControlAdvise
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UserControlAdvise";
            Size = new Size(781, 505);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
    }
}
