using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.ViewModel;

namespace WiredBrainCoffee.CustomerApp.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomerView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomerView_Loaded;
        }

        private async void CustomerView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //int column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            //int newColumn = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
            int column = Grid.GetColumn(customerListGrid);

            int newColumn = column == 0 ? 2 : 0; // If it's 0 becomes 2, else 0
            Grid.SetColumn(customerListGrid, newColumn);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }
    }
}
