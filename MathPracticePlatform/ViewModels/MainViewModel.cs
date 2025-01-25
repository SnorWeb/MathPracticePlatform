using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Services;
using MathPracticePlatform.Views;
using MathPracticePlatform.Models;

namespace MathPracticePlatform.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _vermenigvuldiging;
        private string _delen;

        public string Vermenigvuldiging
        {
            get => _vermenigvuldiging;
            set => _vermenigvuldiging = value;
        }

        public string Delen
        {
            get => _delen;
            set => _delen = value;
        }
        public string WelcomeMessage { get; } = "Welkom bij het wiskunde paradijs";

        public ICommand DuplicateManualCommand { get; }
        public ICommand DivideManualCommand { get; }
        public ICommand NavigateToOptionsCommand { get; }

        public  MainViewModel()
        {
            DuplicateManualCommand = new RelayCommand(() => NavigateToManual(ExerciseType.Multiplication));
            DivideManualCommand = new RelayCommand(() => NavigateToManual(ExerciseType.Division));
            NavigateToOptionsCommand = new RelayCommand(() => NavigateToOptions());
        }

        private void NavigateToOptions()
        {
            CustomNavigationService.Instance.Navigate(new OptionPage());
        }

        private void NavigateToManual(ExerciseType exerciseType)
        {
            string description = exerciseType == ExerciseType.Multiplication
                ? "Maak de 20 vermenigvuldigingen binnen de 3 minuten. \nVeel Succes!"
                : "Maak de 20 delingen binnen de 3 minuten. \nVeel succes!";
            CustomNavigationService.Instance.Navigate(new GameDiscriptionPage(
                description,
                exerciseType,
                () => CustomNavigationService.Instance.Navigate(new ExercisePage(exerciseType)),
                () => CustomNavigationService.Instance.Navigate(new MainPage())
                ));
        }
    }
}
