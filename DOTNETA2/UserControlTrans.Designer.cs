namespace DOTNETA2
{
    partial class UserControlTrans
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
            panelContent = new Panel();
            dgvTransactions = new DataGridView();
            panelTop = new Panel();
            btnDelete = new Button();
            btnAdd = new Button();
            cmbTypeFilter = new ComboBox();
            panel1.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 71, 160);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 66);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(61, 25);
            label2.Name = "label2";
            label2.Size = new Size(258, 24);
            label2.TabIndex = 0;
            label2.Text = "Welcome to Transaction";
            label2.Click += label2_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvTransactions);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 66);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(941, 572);
            panelContent.TabIndex = 3;
            // 
            // dgvTransactions
            // 
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(61, 144);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(818, 336);
            dgvTransactions.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnDelete);
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(cmbTypeFilter);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 66);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(941, 100);
            panelTop.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(700, 41);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(260, 43);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Location = new Point(112, 41);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(121, 25);
            cmbTypeFilter.TabIndex = 0;
            cmbTypeFilter.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // UserControlTrans
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelTop);
            Controls.Add(panelContent);
            Controls.Add(panel1);
            Name = "UserControlTrans";
            Size = new Size(941, 638);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Panel panelContent;
        private DataGridView dgvTransactions;
        private Panel panelTop;
        private Button btnDelete;
        private Button btnAdd;
        private ComboBox cmbTypeFilter;
    }
}
