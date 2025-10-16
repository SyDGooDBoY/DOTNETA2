using DOTNETA2.DAO;
using DOTNETA2.Entity;
using DOTNETA2.Enum;
using Type = DOTNETA2.Enum.Type;

namespace DOTNETA2.Server;

public class TransactionService
{
    private TransactionDAO dao =new TransactionDAO();
    
    //Obtain all transaction records
    public List<Transaction> GetAllTransactions() => dao.GetAll();

    
    //add a transaction
    public void AddTransaction(Transaction transaction)
    {
        //amount must be >=0
        if (transaction.Amount<=0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }
        dao.Add(transaction);
    }

    //delete transaction by id
    public void DeleteTransaction(int id)
    {
        dao.Delete(id);
    }

    //get total income
    public decimal GetTotalIncome() =>
        dao.GetAll().Where(t => t.Type == Type.Income).Sum(t => t.Amount);

    //get total expense
    public decimal GetTotalExpense() =>
        dao.GetAll().Where(t => t.Type == Type.Expense).Sum(t => t.Amount);

    //get balance
    public decimal GetBalance()=>GetTotalIncome()-GetTotalExpense();

    //Filter transaction by type
    public List<Transaction> GetTransactionsByType(Type type)=>dao.GetAll().Where(t => t.Type == type).ToList();
    
    //Return the total monthly transaction record for the specified year
    public  List<decimal> GetMonthlyRecords(int year,Type type)
    {
        decimal[] monthlyExpenses = new decimal[12];
        List<Transaction> transactions = dao.GetAll();
        var expenses = transactions
            .Where(t => t.Date.Year == year && t.Type ==type);
        foreach (var expense in expenses)
        {
            int month = expense.Date.Month;
            monthlyExpenses[month - 1] += expense.Amount;
        }
        return monthlyExpenses.ToList();
    }
    
    //Return the transaction record by category for the specified month and year
    public Dictionary<Category, decimal> GetRecordByYearAndMonth(int year ,int month,Type type)
    {
        Dictionary<Category, decimal> result = new Dictionary<Category, decimal>();
        
        var filtered = dao.GetAll()
            .Where(t => t.Date.Year == year)
            .Where(t => t.Date.Month == month)
            .Where(t => t.Type == type)
            .Where(t => t.Category != null);
        var grouped = filtered.GroupBy(t => t.Category);
        foreach (var group in grouped)
        {
            result[group.Key] = group.Sum(t => t.Amount);
        }
        return result;
    }
    
    //Return the transaction record by category
    public Dictionary<Category, decimal> GetRecordByType(Type type)
    {
        Dictionary<Category, decimal> result = new Dictionary<Category, decimal>();
        
        var filtered = dao.GetAll()
            .Where(t => t.Type == type)
            .Where(t => t.Category != null);
        var grouped = filtered.GroupBy(t => t.Category);
        foreach (var group in grouped)
        {
            result[group.Key] = group.Sum(t => t.Amount);
        }
        return result;
    }
    
    public List<int> GetAvailableYears()
    {
        List<Transaction> transactions = dao.GetAll();
        
        List<int> years = transactions
            .Select(t => t.Date.Year)
            .Distinct()
            .OrderBy(y => y)
            .ToList();
        return years;
    }

    public List<Transaction> GetRecentTransactions(int count)
    {
        return dao.GetAll().OrderByDescending(t => t.Date)
            .Take(count)
            .ToList();
    }

    //Return the record corresponding to the maximum amount of expenditure/income in the specified category
    public Transaction GetLargestByTypeAndCategory(Type type, Category category)
    {
        return dao.GetAll().Where(t => t.Type == type)
            .Where(t => t.Category == category)
            .OrderByDescending(t => t.Amount)
            .FirstOrDefault();
    }
}