using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WiredBrainCoffee.CustomerApp.ViewModel {
    internal class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo {
        private readonly Dictionary<string, List<object>> _errorsByPropertyName = new();
        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && _errorsByPropertyName.ContainsKey(propertyName)
                ? _errorsByPropertyName[propertyName] : Enumerable.Empty<string>();
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs args) {
            ErrorsChanged?.Invoke(this, args);
        }
    }
}
