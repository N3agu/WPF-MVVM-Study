using System.Threading.Tasks;
using WiredBrainCoffee.CustomerApp.Command;

namespace WiredBrainCoffee.CustomerApp.ViewModel {
    public class MainViewModel : ViewModelBase {
        private ViewModelBase _selectedViewModel;

        public MainViewModel(CustomerViewModel customerViewModel, ProductViewModel productViewModel) {
            CustomerViewModel = customerViewModel;
            ProductViewModel = productViewModel;
            SelectedViewModel = CustomerViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public ViewModelBase SelectedViewModel {
			get => _selectedViewModel;
			set {
				_selectedViewModel = value;
				RaisePropertyChanged();
			}
		}

        public DelegateCommand SelectViewModelCommand { get; }
        public CustomerViewModel CustomerViewModel { get; }
        public ProductViewModel ProductViewModel { get; }
        public async override Task LoadAsync() {
            if(SelectedViewModel is not null) {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter) {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
