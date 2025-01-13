using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPracticePlatform.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public int Score { get; }
        public List<string> FoutenOefeningen { get;}

        public ResultsViewModel(List<string> foutenOefeningen, int score)
        {
            FoutenOefeningen = foutenOefeningen;
            Score = score;
        }
    }
}
