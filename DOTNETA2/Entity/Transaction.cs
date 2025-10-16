using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DOTNETA2.Enum;

namespace DOTNETA2.Entity;

public class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Enum.Type Type { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public Transaction(DateTime date,Enum.Type type,Category category,decimal amount)
    {
        this.Date = date;
        this.Type = type;
        this.Category = category;
        this.Amount = amount;
    }

    public override string ToString()
    {
        var au = new CultureInfo("en-AU");
        return $"Id: {Id}, " +
               $"Date: {Date:yyyy-MM-dd HH:mm:ss}, " +
               $"Type: {Type}, " +
               $"Category: {Category}, " +
               $"Amount: {Amount.ToString("C",au)}, ";
    }
}