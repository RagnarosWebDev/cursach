using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Market.Core.Models;
using Market.Core.Service;
using Market.Ui.Pages;
using Market.Ui.Pages.Admin;
using Market.Ui.Pages.Worker;
using Microsoft.EntityFrameworkCore;

namespace Market
{
    public partial class App : Application
    {
        private readonly IHost _appHost;

        public App()
        {
            _appHost = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddDbContext<DatabaseService>((options) =>
                        options.UseSqlServer(
                            @"Server=(localdb)\db;Database=M123;Trusted_Connection=True;MultipleActiveResultSets=true"));
                    
                    
                    services.AddSingleton<MainWindow>();

                    services.AddSingleton(new Dictionary<Roles, List<Type>>
                    {
                        {
                            Roles.Admin,
                            [typeof(OrdersList), typeof(UsersList), typeof(ProductList)]
                        },
                        {
                            Roles.Worker,
                            [typeof(WorkerProductList), typeof(OrdersList)]
                        }
                    });
                    
                    services.AddTransient<LoginPage>();
                    services.AddTransient<OrdersList>();
                    services.AddTransient<UsersList>();
                    services.AddTransient<ProductList>();
                    services.AddTransient<WorkerProductList>();

                    services.AddTransient<AddProduct>();
                    services.AddTransient<AddUser>();
                    services.AddTransient<AddOrder>();

                    services.AddSingleton<UserService>();
                    services.AddSingleton<StorageService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _appHost.StartAsync();


            var form = _appHost.Services.GetRequiredService<MainWindow>();
            form.ShowDialog();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _appHost.StopAsync();
            base.OnExit(e);
        }
    }
}