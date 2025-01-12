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
        private string _timerDisplay;
        private string _huidigeOefening;
        private string _userAntwoord;

        private int _aantalOefeningen;
        private int _score;
        private int _fouten;

        private TimerService _timerService;

        public string TimerDisplay
        {
            get => _timerDisplay;
            set => SetProperty(ref _timerDisplay, value);
        }

        public ICommand NavigateBackCommand { get; }

        public ExercisePageViewModel()
        {
            //instance of the timer service
            _timerService = new TimerService(5, isCountDown: true);
            _timerService.TimeUpdated += UpdatTimerDispclay;
            _timerService.TimerFinished += OnTimerFinished;

            //start the timer
            _timerService.Start();

            NavigateBackCommand = new RelayCommand(GoBack);
        }

        private void UpdatTimerDispclay(int timeInSeconds)
        {
            TimerDisplay = TimeSpan.FromSeconds(timeInSeconds).ToString(@"mm\:ss");
        }

        private void OnTimerFinished()
        {
            CustomNavigationService.Instance.Navigate(new ResultsPage());
        }

        private void GoBack()
        {
            CustomNavigationService.Instance.Navigate(new MainPage());
        }


    }
}
