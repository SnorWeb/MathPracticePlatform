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
using MathPracticePlatform.Services;

namespace MathPracticePlatform.Views
{
    /// <summary>
    /// Interaction logic for GameDiscriptionPage.xaml
    /// </summary>
    public partial class GameDiscriptionPage : Page
    {
        public GameDiscriptionPage(string description, Action startGameAction, Action backToMainMenuAction)
        {
            InitializeComponent();
            
            DataContext = new GameDescriptionViewModel(description, startGameAction, backToMainMenuAction);
        }
    }
}
