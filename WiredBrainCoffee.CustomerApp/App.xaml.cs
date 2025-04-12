using System.Windows;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.ViewModel;

namespace WiredBrainCoffee.CustomerApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow? mainWindow = new MainWindow(new MainViewModel(
                new CustomerViewModel(new CustomerDataProvider()),
                new ProductViewModel()));
            mainWindow.Show();
        }
    }
}
