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
            DataContext = new MainViewModel();
        }

        private void btnVermenigvuldigen_Click(object sender, RoutedEventArgs e)
        {

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
