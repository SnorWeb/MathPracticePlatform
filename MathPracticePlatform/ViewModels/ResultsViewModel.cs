using MathPracticePlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Views;
using MathPracticePlatform.Models;

namespace MathPracticePlatform.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public string _eindscore;
        public string _foutenLijst;
        public string _resterendeTijd;
        public string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public int Score { get; }
        public List<string> FoutenOefeningen { get;}
        public string ResterendeTijd { get; }

        private readonly ExerciseType _exerciseType;

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

        public ResultsViewModel(List<string> foutenOefeningen, int score, int resterendeTijd,ExerciseType exerciseType)
        {
            FoutenOefeningen = foutenOefeningen;
            Score = score;
            ResterendeTijd = TimeSpan.FromSeconds(resterendeTijd).ToString(@"mm\:ss");
            _exerciseType = exerciseType;

            ButtonBackCommand = new RelayCommand(GoBack);
            ButtonRestartCommand = new RelayCommand(Restart);


            AddContent();
            CreateTitle();
        }

        private void Restart(object obj)
        {
            CustomNavigationService.Instance.Navigate(new ExercisePage(_exerciseType));
        }

        private void GoBack(object obj)
        {
            CustomNavigationService.Instance.Navigate(new MainPage());
        }

        private void AddContent()
        {
            EindScore = $"Je hebt {Score} op 20 in een tijd van: {ResterendeTijd}" ;

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

        private void CreateTitle()
        {
            switch (Score)
            {
                case < 5:
                    Title = "Blijven oefenen!";
                    break;
                case < 10:
                    Title = "Jammer, volgende keer beter";
                    break;
                case < 15:
                    Title = "Goed gedaan!";
                    break;
                case < 20:
                    Title = "Sterk bezig, bijna alles goed!";
                    break;
                default:
                    Title = "Ongelooflijk, je hebt alles goed!";
                    break;
            }
        }
    }
}
