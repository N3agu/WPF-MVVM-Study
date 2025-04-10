using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private int _navigationColumn;
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider) {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<CustomerItemViewModel> Customers{ get; } = new(); // read only property

        public CustomerItemViewModel? SelectedCustomer { 
            get => _selectedCustomer;
            set {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }

        public int NavigationColumn
        {
            get => _navigationColumn;
            set
            {
                _navigationColumn = value;
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

        internal void Add() {
            Customer? customer = new Customer { FirstName = "New" };
            CustomerItemViewModel? viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        internal void MoveNavigation()
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0; // If it's 0 becomes 2, else 0
        }
    }
}
