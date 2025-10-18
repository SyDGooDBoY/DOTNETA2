namespace DOTNETA2
{
    partial class UserControlDashboard
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label2 = new Label();
            panelBalance = new FlowLayoutPanel();
            lblBalanceTitle = new Label();
            lblBalanceValue = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblIncomeTitle = new Label();
            lblIncomeValue = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblExpenseTitle = new Label();
            lblExpenseValue = new Label();
            panel1.SuspendLayout();
            panelBalance.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(0, 71, 160);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-15, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(991, 67);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(61, 25);
            label2.Name = "label2";
            label2.Size = new Size(257, 24);
            label2.TabIndex = 0;
            label2.Text = "Welcome to Dashboard";
            // 
            // panelBalance
            // 
            panelBalance.BackColor = SystemColors.ActiveCaption;
            panelBalance.Controls.Add(lblBalanceTitle);
            panelBalance.Controls.Add(lblBalanceValue);
            panelBalance.Location = new Point(61, 129);
            panelBalance.Name = "panelBalance";
            panelBalance.Padding = new Padding(12);
            panelBalance.Size = new Size(165, 73);
            panelBalance.TabIndex = 3;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.Anchor = AnchorStyles.Top;
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalanceTitle.Location = new Point(15, 15);
            lblBalanceTitle.Margin = new Padding(3);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(74, 20);
            lblBalanceTitle.TabIndex = 0;
            lblBalanceTitle.Text = "Balance:";
            lblBalanceTitle.Click += lblBalanceTitle_Click;
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.Anchor = AnchorStyles.None;
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Location = new Point(95, 16);
            lblBalanceValue.Margin = new Padding(3);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(43, 17);
            lblBalanceValue.TabIndex = 1;
            lblBalanceValue.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(lblIncomeTitle);
            flowLayoutPanel1.Controls.Add(lblIncomeValue);
            flowLayoutPanel1.Location = new Point(323, 129);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(12);
            flowLayoutPanel1.Size = new Size(165, 73);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // lblIncomeTitle
            // 
            lblIncomeTitle.Anchor = AnchorStyles.Top;
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncomeTitle.Location = new Point(15, 15);
            lblIncomeTitle.Margin = new Padding(3);
            lblIncomeTitle.Name = "lblIncomeTitle";
            lblIncomeTitle.Size = new Size(70, 20);
            lblIncomeTitle.TabIndex = 0;
            lblIncomeTitle.Text = "Income:";
            // 
            // lblIncomeValue
            // 
            lblIncomeValue.Anchor = AnchorStyles.None;
            lblIncomeValue.AutoSize = true;
            lblIncomeValue.Location = new Point(91, 16);
            lblIncomeValue.Margin = new Padding(3);
            lblIncomeValue.Name = "lblIncomeValue";
            lblIncomeValue.Size = new Size(43, 17);
            lblIncomeValue.TabIndex = 1;
            lblIncomeValue.Text = "label1";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel2.Controls.Add(lblExpenseTitle);
            flowLayoutPanel2.Controls.Add(lblExpenseValue);
            flowLayoutPanel2.Location = new Point(579, 129);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(12);
            flowLayoutPanel2.Size = new Size(165, 73);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.Anchor = AnchorStyles.Top;
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpenseTitle.Location = new Point(15, 15);
            lblExpenseTitle.Margin = new Padding(3);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(73, 20);
            lblExpenseTitle.TabIndex = 0;
            lblExpenseTitle.Text = "Expense:";
            // 
            // lblExpenseValue
            // 
            lblExpenseValue.Anchor = AnchorStyles.None;
            lblExpenseValue.AutoSize = true;
            lblExpenseValue.Location = new Point(94, 16);
            lblExpenseValue.Margin = new Padding(3);
            lblExpenseValue.Name = "lblExpenseValue";
            lblExpenseValue.Size = new Size(43, 17);
            lblExpenseValue.TabIndex = 1;
            lblExpenseValue.Text = "label1";
            // 
            // UserControlDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panelBalance);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            Name = "UserControlDashboard";
            Size = new Size(933, 625);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBalance.ResumeLayout(false);
            panelBalance.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private FlowLayoutPanel panelBalance;
        private Label lblBalanceTitle;
        private Label lblBalanceValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblIncomeTitle;
        private Label lblIncomeValue;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblExpenseTitle;
        private Label lblExpenseValue;
    }
}
