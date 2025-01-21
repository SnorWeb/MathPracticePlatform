using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using MathPracticePlatform.Models;
using MathPracticePlatform.Services;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class GameDescriptionViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public ExerciseType _exerciseType { get; set; }

        public ICommand StartGameCommand { get;}
        public ICommand BackToMainMenuCommand { get; }

        public GameDescriptionViewModel(string description, ExerciseType exerciseType, Action startGameAction, Action backToMainMenuAction)
        {
            Description = description;
            _exerciseType = exerciseType;
            StartGameCommand = new RelayCommand(_ => NavigationToGame());
            BackToMainMenuCommand = new RelayCommand(_ => backToMainMenuAction?.Invoke());
        }

        private void NavigationToGame()
        {
            CustomNavigationService.Instance.Navigate(new ExercisePage(_exerciseType));
        }
    }
}
