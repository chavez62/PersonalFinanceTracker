using LiveCharts;
using LiveCharts.Wpf;
using PersonalFinanceTracker.Models;
using System.Collections.ObjectModel;
using System.Linq;

public class MainViewModel : BaseViewModel
{
    private readonly FinanceContext _context;
    public ObservableCollection<Expense> Expenses { get; set; }
    public SeriesCollection ExpenseSeries { get; set; }

    // Add the TotalAmount property
    public decimal TotalAmount => Expenses?.Sum(expense => expense.Amount) ?? 0;

    public MainViewModel()
    {
        _context = new FinanceContext();
        _context.Database.EnsureCreated();
        LoadExpenses();
        LoadChart();
    }

    private void LoadExpenses()
    {
        Expenses = new ObservableCollection<Expense>(_context.Expenses.ToList());
        Expenses.CollectionChanged += (s, e) => OnPropertyChanged(nameof(TotalAmount)); // Update when expenses change
        OnPropertyChanged(nameof(Expenses));
        OnPropertyChanged(nameof(TotalAmount)); // Ensure TotalAmount is updated
        LoadChart();
    }

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

    private void LoadChart()
    {
        ExpenseSeries = new SeriesCollection();

        var categories = Expenses.GroupBy(e => e.Category)
                                 .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount) });

        foreach (var category in categories)
        {
            ExpenseSeries.Add(new PieSeries
            {
                Title = category.Category,
                Values = new ChartValues<decimal> { category.Total },
                DataLabels = true
            });
        }

        OnPropertyChanged(nameof(ExpenseSeries));
    }
}
