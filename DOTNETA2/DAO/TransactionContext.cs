using DOTNETA2.Entity;
using Microsoft.EntityFrameworkCore;

namespace DOTNETA2.DAO;

public class TransactionContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string con = "server=localhost;database=finance_db;user=root;password=root;";
            optionsBuilder.UseMySql(con,ServerVersion.AutoDetect(con));
        }
    }
}