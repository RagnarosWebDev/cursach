using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AdonisUI.Controls;
using Market.Core.Models;
using Market.Core.Service;
using Market.Ui.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace Market
{
    public partial class MainWindow : AdonisWindow
    {
        public UserService UserService { get; }
        private IHost _host;
        private Dictionary<Roles, List<Type>> screens;


        public MainWindow(IHost host)
        {
            InitializeComponent();
            screens = host.Services.GetRequiredService<Dictionary<Roles, List<Type>>>();
            UserService = host.Services.GetRequiredService<UserService>();
            _host = host;
            DataContext = this;
            UserService.PropertyChanged += (_, _) =>
            {
                if (UserService.User != null)
                    GoToScreen(0);
                else
                    Frame.Navigate(_host.Services.GetRequiredService<LoginPage>());
            };

            Frame.Navigated += (_, args) =>
            {
                if (args.Content is Page)
                {
                    Title = ((Page)args.Content).Title;
                }            
            };

            if (!UserService.TryLoadUser())
            {
                Frame.Navigate(host.Services.GetRequiredService<LoginPage>());
                GoToScreen(0);
            }
        }


        private void GoToScreen(int index)
        {
            if (UserService.User == null) return;

            var page = _host.Services.GetRequiredService(screens[UserService.User.Role][index]);
            Frame.Navigate(page);
        }


        private void OnFirstScreenNavigated(object sender, RoutedEventArgs e) => GoToScreen(0);
        private void OnSecondScreenNavigated(object sender, RoutedEventArgs e) => GoToScreen(1);
        private void OnThirdScreenNavigated(object sender, RoutedEventArgs e) => GoToScreen(2);

        private void Logout(object sender, RoutedEventArgs e)
        {
            UserService.Logout();
        }
    }
}