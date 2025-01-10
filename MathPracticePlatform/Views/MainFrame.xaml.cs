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

namespace MathPracticePlatform.Views
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void btnVermenigvuldigen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vermenigvuldigen");
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
