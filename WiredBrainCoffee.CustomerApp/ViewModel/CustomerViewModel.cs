using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WiredBrainCoffee.CustomerApp.Command;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private NavigationSide _navigationSide;
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }

        private CustomerItemViewModel? _selectedCustomer;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider) {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
        }
        public ObservableCollection<CustomerItemViewModel> Customers{ get; } = new(); // read only property

        public CustomerItemViewModel? SelectedCustomer { 
            get => _selectedCustomer;
            set {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public async Task LoadAsync() {
            // Check if data isn't loaded yet
            if (Customers.Any()) {
                return;
            }

            IEnumerable<Customer>? customers = await _customerDataProvider.GetAllAsync();
            if(customers is not null) {
                foreach(Customer? customer in customers) {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        private void Add(object? parameter) {
            Customer? customer = new Customer { FirstName = "New" };
            CustomerItemViewModel? viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

    }
    public enum NavigationSide
    {
        Left,
        Right
    }
}
