using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomerApp.Data;
using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel {
    public class ProductViewModel : ViewModelBase {
        private readonly IProductDataProvider _productDataProvider;

        public ProductViewModel(IProductDataProvider productDataProvider) {
            _productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> ProductsCollection { get; } = new(); // same as: new ObservableCollection<Product>();
        public override async Task LoadAsync() {
            if (ProductsCollection.Any()) {
                return;
            }

            IEnumerable<Product>? products = await _productDataProvider.GetAllAsync();
            if(products is not null) {
                foreach (Product product in products) {
                    ProductsCollection.Add(product);
                }
            }
        }
    }
}
