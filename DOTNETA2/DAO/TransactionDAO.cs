using DOTNETA2.Entity;

namespace DOTNETA2.DAO;

public class TransactionDAO
{
    private TransactionContext context =new TransactionContext();
    
    public List<Transaction> GetAll()
    {
        return context.Transactions.OrderByDescending(t => t.Date).ToList();
    }

    public void Add(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        context.SaveChanges();
    }

    public void Update(Transaction transaction)
    {
        context.Transactions.Update(transaction);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var t = context.Transactions.Find(id);
        if (t != null)
        {
            context.Transactions.Remove(t);
            context.SaveChanges();
        }
    }
    
}