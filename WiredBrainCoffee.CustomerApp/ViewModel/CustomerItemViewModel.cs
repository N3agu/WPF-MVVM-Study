﻿using WiredBrainCoffee.CustomerApp.Model;

namespace WiredBrainCoffee.CustomerApp.ViewModel
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {
        private readonly Customer _model;
        public CustomerItemViewModel(Customer model) {
            _model = model;
        }

        public int Id => _model.Id;
        public string? FirstName {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_model.FirstName))
                {
                    AddError("Firstname is required"); // Compiler automatically parses the CallerMemberName
                } else
                {
                    ClearErrors(); // Compiler automatically parses the CallerMemberName
                }
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }
    }
}
