using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MathPracticePlatform.Services;
using MathPracticePlatform.Styles;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class OptionsViewModel : BaseViewModel
    {
        private string _errorMessage;
        private string _userInput;

        private int _globalTime;

        public string UserInput
        {
            get => _userInput;
            set {
            _userInput = value;
            OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public int GlobalTime
        {
            get => _globalTime;
            set
            {
                _globalTime = value;
                OnPropertyChanged();
            }
        }
        public ICommand GoBackCommand { get; }
        public ICommand SaveCommand { get; }

        public OptionsViewModel() 
        {

            GoBackCommand = new RelayCommand(() => NavigateBack());
            SaveCommand = new RelayCommand(SaveUserInput);
            
        }

        private void SaveUserInput(object obj)
        {
            if (int.TryParse(UserInput, out int parsedTime) && parsedTime >= 30 && parsedTime <= 180)
            {
                ErrorMessage = string.Empty;
                GlobalTime = parsedTime;
                GlobalState.Instance.TimeLimit = parsedTime;
                MessageBox.Show($"{parsedTime} is opgeslagen");
                UserInput = string.Empty;  
            }
            else 
            {
                ErrorMessage = "Kies een getal tussen de 30 en 180";
                UserInput = string.Empty;
            }
        }

        private void NavigateBack()
        {
            CustomNavigationService.Instance.GoBack();
        }
    }
}
