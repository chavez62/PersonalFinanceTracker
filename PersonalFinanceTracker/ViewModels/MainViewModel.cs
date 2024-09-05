using PersonalFinanceTracker.Models;
using System.Collections.ObjectModel;
using System.Linq;

public class MainViewModel : BaseViewModel
{
    private readonly FinanceContext _context;
    public ObservableCollection<Expense> Expenses { get; set; }

    public MainViewModel()
    {
        _context = new FinanceContext();
        _context.Database.EnsureCreated();
        LoadExpenses();
    }

    private void LoadExpenses()
    {
        Expenses = new ObservableCollection<Expense>(_context.Expenses.ToList());
        OnPropertyChanged(nameof(Expenses));
    }

    // Methods to Add, Update, and Delete expenses will go here
    public void AddExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        _context.SaveChanges();
        LoadExpenses();
    }
    public void DeleteExpense(Expense expense)
    {
        _context.Expenses.Remove(expense);
        _context.SaveChanges();
        LoadExpenses();
    }


}
