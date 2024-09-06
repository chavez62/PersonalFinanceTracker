# Personal Finance Tracker

![License](https://img.shields.io/badge/license-MIT-green)  
![Platform](https://img.shields.io/badge/platform-.NET%20WPF-blue)  
![Status](https://img.shields.io/badge/status-active-brightgreen)

## Overview

**Personal Finance Tracker** is a WPF application built using .NET to help users manage their personal finances. It allows users to track expenses, visualize spending by category, and maintain a clear view of their financial situation with easy-to-use features such as adding, deleting, and analyzing expenses through interactive charts.

## Features

- **Add and Delete Expenses**: Easily add new expenses with details like category, amount, date, and description.
- **Expense Visualization**: View your expenses categorized in a PieChart to understand your spending habits better.
- **Real-time Updates**: Automatic updates of totals and charts when expenses are added or removed.
- **Persistent Storage**: Uses a local database to store expenses, ensuring your data is saved between sessions.

## Technologies Used

- **.NET 6 / .NET Core**: The application is built using the .NET framework for Windows Presentation Foundation (WPF).
- **LiveCharts**: Used for rendering dynamic charts and visualizing expense data.
- **Entity Framework Core**: For database management and data persistence.

## Getting Started

### Prerequisites

- [.NET SDK 6 or higher](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or higher (for development)

### Installation

1. **Clone the Repository**:

    ```bash
    git clone https://github.com/yourusername/personal-finance-tracker.git
    cd personal-finance-tracker
    ```

2. **Build the Project**:

    Open the solution file in Visual Studio and build the project to restore dependencies and compile the application.

3. **Run the Application**:

    - Start the application from Visual Studio or using the command line:

      ```bash
      dotnet run
      ```

### Usage

1. **Add Expenses**:
   - Enter the details of your expense (category, amount, date, description) and click "Add Expense".

2. **View Expenses**:
   - See the list of your expenses in the DataGrid. Expenses are saved and loaded from a local database.

3. **Visualize Spending**:
   - The PieChart provides a visual representation of your spending by category, helping you identify your largest expenses.

4. **Delete Expenses**:
   - Select an expense from the list and click "Delete Expense" to remove it from your records.

## Contributing

Contributions are welcome! If you have any ideas, suggestions, or bug reports, please open an issue or submit a pull request.

### To Contribute:

1. **Fork the repository**.
2. **Create a new branch** for your feature or fix:

    ```bash
    git checkout -b feature/YourFeatureName
    ```

3. **Commit your changes**:

    ```bash
    git commit -m "Add your message here"
    ```

4. **Push to the branch**:

    ```bash
    git push origin feature/YourFeatureName
    ```

5. **Screenshot**.
 ![image](https://github.com/user-attachments/assets/6316d1f9-896e-41bd-902b-836e0139e998)


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [LiveCharts](https://lvcharts.net/) for providing charting capabilities.
- [Microsoft](https://dotnet.microsoft.com/) for the .NET framework and development tools.
