using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathPracticePlatform.ViewModels;
using MathPracticePlatform.Views;
using MathPracticePlatform.Services;

namespace MathPracticePlatform.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnVermenigvuldigen_Click(object sender, RoutedEventArgs e)
        {
            string description = "Maak de 20 vermenigvuldigingen binnen de 3 minuten.\nVeel succes!";
            CustomNavigationService.Instance.Navigate(new GameDiscriptionPage(
                description, 
                StartMultiplicationGame, 
                () => CustomNavigationService.Instance.Navigate(new MainPage())
                ));
        }

        
        private void StartMultiplicationGame()
        {
            System.Windows.MessageBox.Show("Spel gestart");
        }

        private void btnOpties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opties");
        }

        private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
