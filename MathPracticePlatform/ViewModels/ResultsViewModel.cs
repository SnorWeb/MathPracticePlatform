using MathPracticePlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public string _eindscore;
        public string _foutenLijst;
        public string _resterendeTijd;
        public int Score { get; }
        public List<string> FoutenOefeningen { get;}
        public string ResterendeTijd { get; }


        public string EindScore
        {
            get => _eindscore;
            set => SetProperty(ref _eindscore, value);
        }

        public string FoutenLijst
        {
            get => _foutenLijst;
            set => SetProperty(ref _foutenLijst, value);
        }


        public ICommand ButtonBackCommand { get; }
        public ICommand ButtonRestartCommand { get; }

        public ResultsViewModel(List<string> foutenOefeningen, int score, int resterendeTijd)
        {
            FoutenOefeningen = foutenOefeningen;
            Score = score;
            ResterendeTijd = TimeSpan.FromSeconds(resterendeTijd).ToString(@"mm\:ss");

            ButtonBackCommand = new RelayCommand(GoBack);
            ButtonRestartCommand = new RelayCommand(Restart);

            AddContent();
        }

        private void Restart(object obj)
        {
            CustomNavigationService.Instance.Navigate(new ExercisePage());
        }

        private void GoBack(object obj)
        {
            CustomNavigationService.Instance.Navigate(new MainPage());
        }

        private void AddContent()
        {
            EindScore = $"Je hebt {Score} op 20 in tijd van: {ResterendeTijd}" ;

            if (FoutenOefeningen != null)
            {
                foreach (var fout in FoutenOefeningen)
                {
                    FoutenLijst += fout + "\n";
                }
            }
            else
            {
                FoutenLijst = "Geen fouten gemaakt!";
            }
        }
    }
}
