using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Market.Core.Models;
using Market.Core.Service;
using Market.Extentions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Market.Ui.Pages.Admin;

public partial class ProductList : Page
{
    public ObservableCollection<Product> Products { get; set; } = new();
    
    private DatabaseService _databaseService;
    private IHost _host { get; set; }

    public ProductList(DatabaseService databaseService, IHost host)
    {
        _databaseService = databaseService;
        _host = host;
        InitializeComponent();
        Update();
    }

    private void Update()
    {
        Products.Clear();
        Products.AddRange(_databaseService.Products.ToList());
    }


    private void SaveClicked(object sender, RoutedEventArgs e)
    {
        _databaseService.SaveChanges();
        MessageBox.Show("Успешно сохранено");
        Update();
    }

    private void AddProductClicked(object sender, RoutedEventArgs e)
    {
        _host.Services.GetRequiredService<AddProduct>().ShowDialog();
        Update();
    }
}