using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider) {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<Customer> Customers{ get; } = new(); // read only property

        public Customer? SelectedCustomer { 
            get => _selectedCustomer;
            set {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task LoadAsync() {
            // Check if data isn't loaded yet
            if (Customers.Any()) {
                return;
            }

            IEnumerable<Customer>? customers = await _customerDataProvider.GetAllAsync();
            if(customers is not null) {
                foreach(Customer? customer in customers) {
                    Customers.Add(customer);
                }
            }
        }

        internal void Add() {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        // The CallerMemberName attribute will automatically pass the CallerMemberName to the method if no argument is specified
        private void RaisePropertyChanged([CallerMemberName]string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
