using System.Windows;
using Market.Core.Models;

namespace Market.Ui.Pages.Admin;

public partial class AddUser : Window
{
    public User User { get; set; } = new User()
    {
        Login = "",
        Email = "",
        FIO = "",
        Password = "",
        Role = Roles.Admin
    };
    
    
    public AddUser()
    {
        InitializeComponent();
    }
}