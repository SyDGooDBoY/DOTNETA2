using DOTNETA2.Controller;
using DOTNETA2.Entity;
using DOTNETA2.Enum;
using DOTNETA2.Server;
using DOTNETA2.Advise;
using DOTNETA2.DAO;
using Type = DOTNETA2.Enum.Type;

namespace NUnitA2;

[TestFixture]
public class TestTransactionController
{
    private TransactionController transactionController = new TransactionController();

    [SetUp]
    public void Setup()
    {
        using (var db = new TransactionContext())
        {
            db.Database.EnsureCreated();
        }
    }
    
    [TestCase(2025, 10, 4, 4, 24, 34, Type.Expense, Category.Gift, 110.5)]
    [TestCase(2025, 8, 15, 12, 10, 0, Type.Income, Category.Salary, 200)]
    [TestCase(2025, 7, 1, 9, 0, 0, Type.Expense, Category.Dining, 35.75)]
    public void Test_AddTransaction(int year, int month, int day, int hour, int minute, int second, Type type, Category category, decimal amount)
    {
        var date = new DateTime(year, month, day, hour, minute, second);
        transactionController.AddTransaction(date, type, category, amount);
    }

    [Test]
    public void Test_deleteTransaction()
    {
        transactionController.DeleteTransaction(2);
        Assert.Pass("Setup Successful!");
    }

    [Test]
    public void Test_ListAllTransaction()
    {
        List<Transaction> transactions = transactionController.ShowTransactions();
        foreach (Transaction t in transactions)
        {
            TestContext.WriteLine(t.ToString());
        }
    }

    [Test]
    public void Test_GetAvailableYears()
    {
        List<int> years = transactionController.GetAvailableYears();
        foreach (int year in years)
        {
            TestContext.WriteLine(year);
        }
    }

    [Test]
    public void Test_GetMonthlyRecords()
    {
        List<decimal> monthlyExpenses = transactionController.GetMonthlyRecords(2025, Type.Expense);
        foreach (decimal d in monthlyExpenses)
        {
            TestContext.WriteLine(d.ToString());
        }
    }

    [Test]
    public void Test_GetRecordByYearAndMonth()
    {
        Dictionary<Category, decimal> monthlyExpenses =
            transactionController.GetRecordByYearAndMonth(2025, 8, Type.Expense);
        foreach (KeyValuePair<Category, decimal> monthlyExpense in monthlyExpenses)
        {
            TestContext.WriteLine(monthlyExpense.ToString());
        }
    }


    [Test]
    public void Test_GetRecentTransactions()
    {
        List<Transaction> transactions = transactionController.GetRecentTransactions(3);
        foreach (Transaction t in transactions)
        {
            TestContext.WriteLine(t.ToString());
        }
    }
    


    // [Test]
    // public void Test_Advise_Generate_ForCurrentMonth()
    // {
    //     var tx = new TransactionService();
    //     var adv = new AdviseService(tx);
    //
    //     int year = DateTime.Now.Year;
    //     int month = DateTime.Now.Month;
    //
    //     var tips = adv.Generate(year, month);
    //
    //     TestContext.WriteLine($"Advice for {year}-{month:D2}: {tips.Count} item(s).");
    //     foreach (var t in tips)
    //     {
    //         TestContext.WriteLine($"[{t.Severity}] {t.Title}");
    //         TestContext.WriteLine($"  Why:    {t.Why}");
    //         TestContext.WriteLine($"  Action: {t.Action}");
    //     }
    //
    //     Assert.That(tips, Is.Not.Null);
    // }
    //
    // [Test]
    // public void Test_Advise_Generate_ForSpecificMonth_NoCrashWhenNoData()
    // {
    //     var tx = new TransactionService();
    //     var adv = new AdviseService(tx);
    //
    //     var tips = adv.Generate(2025, 10);
    //
    //     TestContext.WriteLine($"Advice for 2025-10: {tips.Count} item(s).");
    //     foreach (var t in tips)
    //     {
    //         TestContext.WriteLine($"[{t.Severity}] {t.Title}");
    //     }
    //
    //     Assert.That(tips, Is.Not.Null);
    // }
}