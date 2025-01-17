﻿using System;
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

namespace MathPracticePlatform.Views
{
    /// <summary>
    /// Interaction logic for ExercisePage.xaml
    /// </summary>
    public partial class ExercisePage : Page
    {
        public ExercisePage()
        {
            InitializeComponent();
            DataContext = new ExercisePageViewModel();
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox?.Focus();
        }
    }
}
