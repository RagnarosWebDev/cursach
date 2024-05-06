using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Market.Core.Models;
using Market.Core.Service;
using Market.Extentions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Market.Ui.Pages.Admin;

public partial class UsersList : Page
{
    public ObservableCollection<User> Users { get; set; } = new();
    private DatabaseService _databaseService;
    private IHost _host;

    public UsersList(DatabaseService databaseService, IHost host)
    {
        _host = host;
        _databaseService = databaseService;
        InitializeComponent();
        Update();
    }

    private void Update()
    {
        Users.Clear();
        Users.AddRange(_databaseService.Users.ToList());
    }
    
    
    private void SaveClicked(object sender, RoutedEventArgs e)
    {
        _databaseService.SaveChanges();
        MessageBox.Show("Успешно сохранено");
        Update();
    }

    private void AddUsersClicked(object sender, RoutedEventArgs e)
    {
        _host.Services.GetRequiredService<AddUser>().ShowDialog();
        Update();
    }
}