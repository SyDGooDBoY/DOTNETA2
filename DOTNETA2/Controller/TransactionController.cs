using DOTNETA2.Entity;
using DOTNETA2.Enum;
using DOTNETA2.Server;
using Type = DOTNETA2.Enum.Type;

namespace DOTNETA2.Controller;

public class TransactionController
{
    private TransactionService service= new TransactionService();
    
    
    //Display all transaction records
    public List<Transaction> ShowTransactions() => service.GetAllTransactions();

    
    //Keep records of income or Expense
    public void AddTransaction(DateTime date,Enum.Type type,Category category,decimal amount)
    {
        Transaction transaction = new Transaction(date, type, category, amount);
        service.AddTransaction(transaction);
    }
    
    //Delete the  record by TransactionID
    public void DeleteTransaction(int id) => service.DeleteTransaction(id);

    //Calculate the balance of all expenses and all income
    public decimal GetBalance() => service.GetBalance();

    //Filter transaction by type
    public List<Transaction> GetTransactionsByType(Enum.Type type) => service.GetTransactionsByType(type);
    
    //get total income
    public decimal GetTotalIncome() => service.GetTotalIncome();

    //get total expense
    public decimal GetTotalExpense() => service.GetTotalExpense();
    
    //Return the total monthly expenditure for the specified year
    public List<decimal> GetMonthlyRecords(int year,Type type) => service.GetMonthlyRecords(year,type);
    
    //Return the expenditures by category for the specified month and year
    public Dictionary<Category, decimal> GetRecordByYearAndMonth(int year, int month,Type type) =>
        service.GetRecordByYearAndMonth(year,month,type);
    
    //Return the transaction record by category
    public Dictionary<Category, decimal> GetRecordByType(Type type) =>
        service.GetRecordByType(type);

    //Return to the year with available data
    public List<int> GetAvailableYears() => service.GetAvailableYears();

    //
    public List<Transaction> GetRecentTransactions(int count) => service.GetRecentTransactions(count);

    //Return the record corresponding to the maximum amount of expenditure/income in the specified category
    public Transaction GetLargestByTypeAndCategory(Type type, Category category) =>
        service.GetLargestByTypeAndCategory(type, category);
}