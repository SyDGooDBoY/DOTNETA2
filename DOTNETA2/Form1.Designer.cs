namespace DOTNETA2;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        transactionListView = new System.Windows.Forms.ListView();
        SuspendLayout();
        // 
        // transactionListView
        // 
        transactionListView.FullRowSelect = true;
        transactionListView.GridLines = true;
        transactionListView.Location = new System.Drawing.Point(48, 32);
        transactionListView.Name = "transactionListView";
        transactionListView.Size = new System.Drawing.Size(815, 379);
        transactionListView.TabIndex = 0;
        transactionListView.UseCompatibleStateImageBehavior = false;
        transactionListView.View = System.Windows.Forms.View.Details;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1072, 820);
        Controls.Add(transactionListView);
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListView transactionListView;

    #endregion
}