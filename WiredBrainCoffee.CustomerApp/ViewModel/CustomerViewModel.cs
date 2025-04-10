using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel
{
    public class CustomerViewModel
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider) {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<Customer> Customers { get; } = new(); // read only property
    
        public async Task LoadAsync()
        {
            // Check if data isn't loaded yet
            if (Customers.Any())
            {
                return;
            }

            IEnumerable<Customer>? customers = await _customerDataProvider.GetAllAsync();
            if(customers is not null)
            {
                foreach(Customer? customer in customers)
                {
                    Customers.Add(customer);
                }
            }
        }
    }
}
