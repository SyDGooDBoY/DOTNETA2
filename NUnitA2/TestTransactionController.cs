using DOTNETA2.Controller;
using DOTNETA2.Entity;
using DOTNETA2.Enum;
using DOTNETA2.Server;
using DOTNETA2.Advise;
using Type = DOTNETA2.Enum.Type;

namespace NUnitA2;

[TestFixture]
public class TestTransactionController
{
    private TransactionController transactionController = new TransactionController();

    [Test]
    public void Test_AddTransaction()
    {
        transactionController.AddTransaction(new DateTime(2025, 10, 4, 4, 24, 34), Type.Expense, Category.OtherExpense,
            (decimal)110.5);
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
            transactionController.GetRecordByYearAndMonth(2025, 10, Type.Expense);
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