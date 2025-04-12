using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.ViewModel;

namespace WiredBrainCoffee.CustomerApp {
    public partial class App : Application {
        private readonly ServiceProvider _serviceProvider;

        public App() {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        // Contains all the services needed to instantiate the MainWindow
        private void ConfigureServices(ServiceCollection services) {
            services.AddTransient<MainWindow>();
            
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<ProductViewModel>();

            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            MainWindow? mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
