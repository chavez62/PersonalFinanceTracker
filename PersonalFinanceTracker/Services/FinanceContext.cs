using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Models;

public class FinanceContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=finance.db");
    }
}
