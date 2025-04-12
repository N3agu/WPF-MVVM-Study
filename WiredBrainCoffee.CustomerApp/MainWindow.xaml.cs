using System.Windows;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.ViewModel;

namespace WiredBrainCoffee.CustomerApp {
    public partial class MainWindow : Window {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel) {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            await _viewModel.LoadAsync();
        }
    }
}
