using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Market.Core.Models;
using Market.Core.Service;
using Market.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Market.Ui.Pages.Admin;

public partial class OrdersList : Page
{
    public ObservableCollection<Order> Orders { get; set; } = new();
    private DatabaseService _databaseService;
    private IHost _host;

    public OrdersList(DatabaseService databaseService, IHost host)
    {
        _host = host;
        _databaseService = databaseService;
        InitializeComponent();
        Update();
    }

    public void Update()
    {
        Orders.Clear();
        Orders.AddRange(_databaseService.Orders.Include(e => e.OrderItems).ThenInclude(e => e.Product).ToList());
    }
    
    private void SaveClicked(object sender, RoutedEventArgs e)
    {
        _databaseService.SaveChanges();
        MessageBox.Show("Успешно сохранено");
        Update();
    }

    private void AddOrderClicked(object sender, RoutedEventArgs e)
    {
        _host.Services.GetRequiredService<AddOrder>().ShowDialog();
        Update();
    }
}