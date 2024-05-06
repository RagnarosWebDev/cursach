using System.Collections.ObjectModel;
using System.Windows;
using Market.Core.Models;
using Market.Core.Service;
using Market.Extentions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Ui.Pages;

public partial class AddOrder : Window
{
    private DatabaseService _databaseService;
    public ObservableCollection<OrderItem> OrderItems { get; set; } = new();
    public String FIO { get; set; } = "";
    public String Phone { get; set; } = "";

    public AddOrder(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        InitializeComponent();
        OrderItems.AddRange(databaseService.Products.Select(e => new OrderItem()
        {
            Product = e,
            Count = 1
        }).ToList());
    }

    private void AddOrderClicked(object sender, RoutedEventArgs e)
    {
        List<OrderItem> orderItems = OrderItems.Where(item => item.Count > 0).ToList();

        EntityEntry<Order> order = _databaseService.Orders.Add(new Order()
        {
            FIO = FIO,
            Phone = Phone,
            OrderStatus = OrderStatus.Created,
        });
        _databaseService.SaveChanges();
        foreach (var item in orderItems)
        {
            item.Product.Count -= item.Count;
            _databaseService.OrderItems.Add(new OrderItem()
            {
                Order = order.Entity,
                Count = item.Count,
                Product = item.Product
            });
        }
        _databaseService.SaveChanges();

        
        MessageBox.Show("Заказ успешно добавлен");
        Close();
    }
}