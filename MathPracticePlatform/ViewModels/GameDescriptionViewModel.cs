using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MathPracticePlatform.ViewModels
{
    public class GameDescriptionViewModel : BaseViewModel
    {
        public string Description { get; set; }

        public ICommand StartGameCommand { get;}
        public ICommand BackToMainMenuCommand { get; }

        public GameDescriptionViewModel(string description, Action startGameAction, Action backToMainMenuAction)
        {
            Description = description;
            StartGameCommand = new RelayCommand(_ => startGameAction?.Invoke());
            BackToMainMenuCommand = new RelayCommand(_ => backToMainMenuAction?.Invoke());
        }
    }
}
