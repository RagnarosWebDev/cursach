using System.Collections.ObjectModel;
using System.Windows.Controls;
using Market.Core.Models;
using Market.Core.Service;
using Market.Extentions;

namespace Market.Ui.Pages.Worker;

public partial class WorkerProductList : Page
{
    public ObservableCollection<Product> Products { get; set; } = new();

    public WorkerProductList(DatabaseService databaseService)
    {
        InitializeComponent();
        Products.AddRange(databaseService.Products.ToList());
    }
}