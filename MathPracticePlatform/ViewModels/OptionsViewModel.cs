using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Services;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class OptionsViewModel : BaseViewModel
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => _errorMessage = value;
        }
        public ICommand GoBackCommand { get; }

        public OptionsViewModel() 
        {
            GoBackCommand = new RelayCommand(() => NavigateBack());
            
        }

        private void NavigateBack()
        {
            CustomNavigationService.Instance.GoBack();
        }
    }
}
