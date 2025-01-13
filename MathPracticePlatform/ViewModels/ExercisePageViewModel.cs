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
        private string _aantalOefeningen;

        private int _correctAntwoord;
        private int _fouten;
        private int _score;
        private int _oefeningTeller;

        private bool _isFocusd;

        private List<string> _fouteOefeningen = new List<string>();

        private TimerService _timerService;
        private readonly RandomNumberService _randomNumberService;

        public string AantalOefeningen
        {
            get => _aantalOefeningen;
            set => SetProperty(ref _aantalOefeningen, value);
        }
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

        public string UserAntwoord
        {
            get => _userAntwoord;
            set => SetProperty(ref _userAntwoord, value);
        }

        public int Fouten
        {
            get => _fouten;
            set => SetProperty(ref _fouten, value);
        }

        public int Score
        {
            get => _score; 
            set => SetProperty(ref _score, value);
        }

        private bool IsFocused
        {
            get => _isFocusd;
            set => SetProperty(ref _isFocusd, value);
        }

        public List<string> FoutenOefeningen
        {
            get => _fouteOefeningen;
            set => SetProperty(ref _fouteOefeningen, value);
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
            StartSpel();
            
        }

        private void StartSpel()
        {
            _oefeningTeller = 0;
            AantalOefeningen = $"0/20";
            Score = 0;
            Fouten = 0;
            _fouteOefeningen.Clear();
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
                    Score++;
                }
                else
                {
                    Fouten++;
                    _fouteOefeningen.Add($"{HuidigeOefening} = {_correctAntwoord}");
                }
            }
            else
            {
                Fouten++;
                _fouteOefeningen.Add($"{HuidigeOefening} = {_correctAntwoord} (verkeerde input)");
            }

            _oefeningTeller++;
            AantalOefeningen = $"{_oefeningTeller}/20";

            if (_oefeningTeller >= 20)
            {
                NavigateToNextPage();
                return;
            }

            GenereerNieuweOefening();
            UserAntwoord = string.Empty;

            IsFocused = false;
            IsFocused = true;
        }

        private void NavigateToNextPage()
        {
            CustomNavigationService.Instance.Navigate(new ResultsPage(FoutenOefeningen, Score));
        }

        private void UpdatTimerDispclay(int timeInSeconds)
        {
            TimerDisplay = TimeSpan.FromSeconds(timeInSeconds).ToString(@"mm\:ss");
        }

        private void OnTimerFinished()
        {
            CustomNavigationService.Instance.Navigate(new ResultsPage(FoutenOefeningen, Score));
        }

        private void GoBack()
        {
            if(MessageBox.Show("Alle voortgang gaat verloren en word niet opgeslagen. Ben je zeker dat je wilt stoppen?", "Waarschuwing", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CustomNavigationService.Instance.Navigate(new MainPage());
            }
                
        }


    }
}
