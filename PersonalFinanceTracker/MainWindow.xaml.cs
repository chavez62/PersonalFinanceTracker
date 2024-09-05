using PersonalFinanceTracker.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PersonalFinanceTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;

            if (viewModel != null)
            {
                // Create a new Expense object from user input
                if (decimal.TryParse(AmountInput.Text, out decimal amount))
                {
                    var newExpense = new Expense
                    {
                        Category = CategoryInput.Text,
                        Amount = amount,
                        Date = DateInput.SelectedDate ?? DateTime.Now,
                        Description = DescriptionInput.Text
                    };

                    // Add the expense using ViewModel method
                    viewModel.AddExpense(newExpense);

                    // Clear inputs after adding
                    CategoryInput.Clear();
                    AmountInput.Clear();
                    DescriptionInput.Clear();
                    DateInput.SelectedDate = null;
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;

            if (viewModel != null)
            {
                // Access the selected item from the DataGrid
                var selectedExpense = ExpensesDataGrid.SelectedItem as Expense;

                if (selectedExpense != null)
                {
                    // Call the ViewModel method to delete the selected expense
                    viewModel.DeleteExpense(selectedExpense);
                }
                else
                {
                    MessageBox.Show("Please select an expense to delete.", "Delete Expense", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

    }
}
