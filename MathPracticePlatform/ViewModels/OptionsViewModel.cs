using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Services;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class OptionsViewModel : BaseViewModel
    {
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
