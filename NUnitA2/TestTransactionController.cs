using DOTNETA2.Controller;
using DOTNETA2.Entity;
using DOTNETA2.Enum;
using Type = DOTNETA2.Enum.Type;

namespace NUnitA2;


[TestFixture]
public class TestTransactionController
{
    private TransactionController transactionController =new TransactionController();
    
    [Test]
    public void Test_AddTransaction()
    {
        transactionController.AddTransaction(new DateTime(2025,7,4,4,24,34),Type.Expense,Category.OtherExpense,(decimal)110.5);
    }
    
    [Test]
    public void Test_deleteTransaction()
    {
        transactionController.DeleteTransaction(3);
        Assert.Pass("Setup Successful!");
    }
    
    [Test]
    public void Test_ListAllTransaction()
    {
        List<Transaction> transactions=transactionController.ShowTransactions();
        foreach (Transaction t in transactions)
        {
            TestContext.WriteLine(t.ToString());
        }
    }
    
    [Test]
    public void Test_GetAvailableYears()
    {
        List<int> years=transactionController.GetAvailableYears();
        foreach (int year in years)
        {
            TestContext.WriteLine(year);
        }
    }
    
    [Test]
    public void Test_GetMonthlyRecords()
    {
        List<decimal> monthlyExpenses=transactionController.GetMonthlyRecords(2025,Type.Expense);
        foreach (decimal d in monthlyExpenses)
        {
            TestContext.WriteLine(d.ToString());
        }
    }
    
    [Test]
    public void Test_GetRecordByYearAndMonth()
    {
        Dictionary<Category,decimal> monthlyExpenses=transactionController.GetRecordByYearAndMonth(2025,10,Type.Income);
        foreach (KeyValuePair<Category, decimal> monthlyExpense in monthlyExpenses)
        {
            TestContext.WriteLine(monthlyExpense.ToString());
        }
    }
    
    
        
    [Test]
    public void Test_GetRecentTransactions()
    {
        List<Transaction> transactions=transactionController.GetRecentTransactions(3);
        foreach (Transaction t in transactions)
        {
            TestContext.WriteLine(t.ToString());
        }
    }
    
    
    [Test]
    public void Test_GetLargestByTypeAndCategory()
    {
        Transaction t=transactionController.GetLargestByTypeAndCategory(Type.Income,Category.Bonus);
        TestContext.WriteLine(t.ToString());
    }  
        
}
