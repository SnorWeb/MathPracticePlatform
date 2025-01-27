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
        private string _fout;


        private Uri _gifsource;

        public Uri GifSource
        {
            get => _gifsource;
            set => SetProperty(ref _gifsource, value);
        }

        public string Fout
        {
            get => _fout;
            set => SetProperty(ref _fout, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public int Score { get; }
        public List<string> FoutenOefeningen { get;}
        public string ResterendeTijd { get; }
        public bool IsTimeUp {  get; }

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

        public ResultsViewModel(List<string> foutenOefeningen, int score, int resterendeTijd,ExerciseType exerciseType, bool isTimeUp)
        {
            FoutenOefeningen = foutenOefeningen;
            Score = score;
            ResterendeTijd = TimeSpan.FromSeconds(resterendeTijd).ToString(@"mm\:ss");
            _exerciseType = exerciseType;
            IsTimeUp = isTimeUp;

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

        //Zorg dat de titel goed komt. Volgens mij wordt de bool vanop de vorige pagina niet goed doorgegeven.
        private void AddContent()
        {
            EindScore = $"Je hebt {Score} op 20 in een tijd van: {ResterendeTijd}" ;

            if (FoutenOefeningen != null)
            {
                Fout = "Fouten: ";
                foreach (var fout in FoutenOefeningen)
                {
                    FoutenLijst += fout + "\n";
                }
            }
            if (Score == 20)
            {
                Fout = "";
                GifSource = new Uri("pack://application:,,,/Resources/GIF/fuegos-fired.gif");
            }
        }

        private void CreateTitle()
        {
            if (IsTimeUp)
            {
                Title = "Tijd is op!";
                EindScore = $"Je hebt {Score} op 20.";
            }
            else
            {
                GradeTitle();
            }
        }

        private void GradeTitle()
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
