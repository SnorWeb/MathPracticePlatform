using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathPracticePlatform.Services;
using MathPracticePlatform.Views;

namespace MathPracticePlatform.ViewModels
{
    public class MainViewModel
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

        public  MainViewModel()
        {
            DuplicateManualCommand = new RelayCommand(CreateVermenigvuldigen);
            DivideManualCommand = new RelayCommand(CreateDelen);
        }

        private void CreateDelen(object obj)
        {
            Delen = "Maak de 20 delingen binnen de 3 minuten.\nVeel succes!";
            NavigateToManual(Delen);
        }

        private void CreateVermenigvuldigen(object obj)
        {
            Vermenigvuldiging = "Maak de 20 vermenigvuldigingen binnen de 3 minuten.\nVeel succes!";
            NavigateToManual(Vermenigvuldiging);
        }

        private void NavigateToManual(string obj)
        {
            CustomNavigationService.Instance.Navigate(new GameDiscriptionPage(
                obj,
                () => CustomNavigationService.Instance.Navigate(new ExercisePage()),
                () => CustomNavigationService.Instance.Navigate(new MainPage())
                ));
        }
    }
}
