using MathPracticePlatform.Services;
using MathPracticePlatform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPracticePlatform.Services;
using System.Windows.Input;

namespace MathPracticePlatform.ViewModels
{
    public class ExercisePageViewModel : BaseViewModel
    {
        private string _timer;
        private string _huidigeOefening;
        private string _userAntwoord;

        private int _aantalOefeningen;
        private int _score;
        private int _fouten;

        public ICommand NavigateBackCommand { get; }

        public ExercisePageViewModel()
        {
            NavigateBackCommand = new RelayCommand(GoBack);
        }

        private void GoBack()
        {
            CustomNavigationService.Instance.Navigate(new MainPage());
        }
    }
}
