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
using MathPracticePlatform.Models;
using System.Security.Permissions;
using System.Windows.Media;
using MathPracticePlatform.Styles;

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
        private int _overgeblevenTijd;
        private int _timeLimit;

        private bool _isFocusd;
        private bool _isTimeUp;

        private Brush _textboxForeground;

        private List<string> _fouteOefeningen = new List<string>();

        private TimerService _timerService;
        private readonly RandomNumberService _randomNumberService;
        private readonly ExerciseType _exerciseType;
        private readonly AudioService _audioService;


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

        public int OvergeblevenTijd
        {
            get => _overgeblevenTijd;
            set => SetProperty(ref _overgeblevenTijd, value);
        }

        public int TimeLimit
        {
            get => _timeLimit;
            set => SetProperty(ref _timeLimit, value);
        }

        private bool IsFocused
        {
            get => _isFocusd;
            set => SetProperty(ref _isFocusd, value);
        }

        public bool IsTimeUp
        {
            get => _isTimeUp;
            set => SetProperty(ref _isTimeUp, value);
        }

        public List<string> FoutenOefeningen
        {
            get => _fouteOefeningen;
            set => SetProperty(ref _fouteOefeningen, value);
        }

        public Brush TextboxForeground
        {
            get => _textboxForeground;
            set => SetProperty(ref _textboxForeground, value);
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand ControleerAntwoordCommand { get; }

        public ExercisePageViewModel(ExerciseType exerciseType)
        {
            TimeLimit = GlobalState.Instance.TimeLimit;

            //instance of the timer service
            _timerService = new TimerService(TimeLimit, isCountDown: true);
            _timerService.TimeUpdated += UpdatTimerDispclay;
            _timerService.TimerFinished += NavigateToNextPage;
            _timerService.Start();

            //instance of the exercise service
            _randomNumberService = new RandomNumberService();

            _exerciseType = exerciseType;

            _audioService = new AudioService();

            TextboxForeground = Brushes.White;

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
            
            if (_exerciseType == ExerciseType.Multiplication)
            {
                GenerateMultiplication();
            }
            else
            {
                GenerateDivision();
            }

        }

        private void GenerateDivision()
        {
            
            var (dividend, divisor) = _randomNumberService.GenerateDivisionExercise(1, 10);

            _correctAntwoord = dividend / divisor; 
            HuidigeOefening = $"{dividend} : {divisor}";
        }

        private void GenerateMultiplication()
        {
            int getal1 = _randomNumberService.GetRandomNumber(0, 10);
            int getal2 = _randomNumberService.GetRandomNumber(0, 10);

            _correctAntwoord = getal1 * getal2;
            HuidigeOefening = $"{getal1} X {getal2}";
        }

        private async void ControleerAntwoord()
        {

            if (int.TryParse(_userAntwoord, out int antwoord))
            {
                if (antwoord == _correctAntwoord)
                {
                    TextboxForeground = Brushes.Green;
                    _audioService.PlaySound("Resources/Sounds/correct.mp3");
                    Score++;
                }
                else
                {
                    TextboxForeground = Brushes.Red;
                    _audioService.PlaySound("Resources/Sounds/wrong.mp3");
                    Fouten++;
                    _fouteOefeningen.Add($"{HuidigeOefening} = {_correctAntwoord}");
                }
            }
            else
            {
                TextboxForeground = Brushes.Red;
                _audioService.PlaySound("Resources/Sounds/wrong.mp3");
                Fouten++;
                _fouteOefeningen.Add($"{HuidigeOefening} = {_correctAntwoord} (verkeerde input)");
            }

            await ResetForegroundAfterDelay();

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

        private async Task ResetForegroundAfterDelay()
        {
            await Task.Delay(200);
            TextboxForeground = Brushes.White;
        }

        private void NavigateToNextPage()
        {

            CalculateRemainingTime();
            Application.Current.Dispatcher.Invoke(() =>
            {
                CustomNavigationService.Instance.Navigate(new ResultsPage(FoutenOefeningen, Score, OvergeblevenTijd, _exerciseType, IsTimeUp));
            });
            IsTimeUp = false;
        }

        private void CalculateRemainingTime()
        {
           if (_timerService.GetRemainingTime() >= 0)
            {
                OvergeblevenTijd = TimeLimit - _timerService.GetRemainingTime();
            }
            else
            {
                OvergeblevenTijd = 0;
                IsTimeUp = true;
            }
        }

        private void UpdatTimerDispclay(int timeInSeconds)
        {
            TimerDisplay = TimeSpan.FromSeconds(timeInSeconds).ToString(@"mm\:ss");
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
