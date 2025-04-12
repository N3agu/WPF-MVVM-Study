using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomerApp.ViewModel {
    public class MainViewModel : ViewModelBase {
        private readonly CustomerViewModel _customerViewModel;
        private ViewModelBase _selectedViewModel;

        public MainViewModel(CustomerViewModel customerViewModel) {
            _customerViewModel = customerViewModel;
            SelectedViewModel = _customerViewModel;
        }

        public ViewModelBase SelectedViewModel {
			get => _selectedViewModel;
			set {
				_selectedViewModel = value;
				RaisePropertyChanged();
			}
		}

        public async override Task LoadAsync() {
            if(SelectedViewModel is not null) {
                await SelectedViewModel.LoadAsync();
            }
        }
	}
}
