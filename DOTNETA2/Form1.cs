using System.Globalization;
using DOTNETA2.Controller;
using DOTNETA2.Entity;

namespace DOTNETA2;

public partial class Form1 : Form
{
    private TransactionController t = new TransactionController();
    public Form1()
    {
        InitializeComponent();
       
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        InitListView();
    }
    
    private void InitListView()
    {
        transactionListView.Columns.Add("Date", 300);
        transactionListView.Columns.Add("Type", 120);
        transactionListView.Columns.Add("Category", 150);
        transactionListView.Columns.Add("Amount", 120);
        LoadTransactions();
    }
    
    private void LoadTransactions()
    {
        
        var au = new CultureInfo("en-AU");
        foreach (Transaction t in t.ShowTransactions())
        {
            var item = new ListViewItem($"{t.Date:yyyy-MM-dd HH:mm:ss}");
            item.SubItems.Add(t.Type.ToString());
            item.SubItems.Add(t.Category.ToString());
            item.SubItems.Add(t.Amount.ToString("C",au));
            transactionListView.Items.Add(item);
        }
    }
}