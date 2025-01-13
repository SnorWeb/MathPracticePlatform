using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPracticePlatform.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public string _eindscore;
        public string _foutenLijst;
        public int Score { get; }
        public List<string> FoutenOefeningen { get;}

        public string Eindscore
        {
            get => _eindscore;
            set => SetProperty(ref _eindscore, value);
        }

        public string FoutenLijst
        {
            get => _foutenLijst;
            set => SetProperty(ref _foutenLijst, value);
        }

        public ResultsViewModel(List<string> foutenOefeningen, int score)
        {
            FoutenOefeningen = foutenOefeningen;
            Score = score;
            AddContent();
        }

        private void AddContent()
        {
            Eindscore = $"Je hebt {Score} op 20";

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
