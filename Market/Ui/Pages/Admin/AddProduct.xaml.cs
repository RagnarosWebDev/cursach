using System.Windows;
using Market.Core.Models;
using Market.Core.Service;

namespace Market.Ui.Pages.Admin;

public partial class AddProduct : Window
{
    public Product Product { get; set; } = new()
    {
        Name = "",
        Description = "",
        Count = 0,
        Price = 0
    };

    private DatabaseService _databaseService;

    public AddProduct(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        InitializeComponent();
    }

    private void AddProductClicked(object sender, RoutedEventArgs e)
    {
        _databaseService.Products.Add(Product);
        _databaseService.SaveChanges();
        Close();
    }
}