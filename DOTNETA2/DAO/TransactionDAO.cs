using DOTNETA2.Entity;
using Microsoft.EntityFrameworkCore;

namespace DOTNETA2.DAO;

public class TransactionDAO
{
    private TransactionContext context =new TransactionContext();
    
    public List<Transaction> GetAll()
    {
        return context.Transactions.OrderByDescending(t => t.Date).ToList();
    }

    public Transaction? GetOne(int id)
    {
        return context.Transactions.AsNoTracking().FirstOrDefault(t => t.Id == id);
    }

    public void Add(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        context.SaveChanges();
    }

    public void Update(Transaction transaction)
    {
        var entity = context.Transactions.Find(transaction.Id);
        if (entity == null) return;
        entity.Date     = transaction.Date;
        entity.Type     = transaction.Type;
        entity.Category = transaction.Category;
        entity.Amount   = transaction.Amount;
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