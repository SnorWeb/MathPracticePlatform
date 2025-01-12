using MathPracticePlatform.Services;
using MathPracticePlatform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPracticePlatform.Services;
using System.Windows.Input;
using System.Windows;

namespace MathPracticePlatform.ViewModels
{
    public class ExercisePageViewModel : BaseViewModel
    {
        private string _timerDisplay;
        private string _huidigeOefening;
        private string _userAntwoord;

        private int _correctAntwoord;
        private int _aantalOefeningen;
        private int _score;
        private int _fouten;

        private TimerService _timerService;
        private readonly RandomNumberService _randomNumberService;

        public string TimerDisplay
        {
            get => _timerDisplay;
            set => SetProperty(ref _timerDisplay, value);
        }

        public string HuidigeOefening
        {
            get => _huidigeOefening;
            set => SetProperty(ref _huidigeOefening, value);
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand ControleerAntwoordCommand { get; }

        public ExercisePageViewModel()
        {
            //instance of the timer service
            _timerService = new TimerService(180, isCountDown: true);
            _timerService.TimeUpdated += UpdatTimerDispclay;
            _timerService.TimerFinished += OnTimerFinished;
            _timerService.Start();

            //instance of the exercise service
            _randomNumberService = new RandomNumberService();
            


            NavigateBackCommand = new RelayCommand(GoBack);
            ControleerAntwoordCommand = new RelayCommand(ControleerAntwoord);

            GenereerNieuweOefening();
        }

        private void GenereerNieuweOefening()
        {
            int getal1 = _randomNumberService.GetRandomNumber(0, 10);
            int getal2 = _randomNumberService.GetRandomNumber(0, 10);

            _correctAntwoord = getal1 * getal2;
            HuidigeOefening = $"{getal1} X {getal2}";
        }

        private void ControleerAntwoord()
        {
            if (int.TryParse(_userAntwoord, out int antwoord))
            {
                if (antwoord == _correctAntwoord)
                {
                    MessageBox.Show("Correct!");
                }
                else
                {
                    MessageBox.Show("Fout!");
                }
            }

            GenereerNieuweOefening();
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
