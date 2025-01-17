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
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        public ResultsPage(List<string> foutenOefeningen, int score, int overgeblevenTijd)
        {
            InitializeComponent();
            DataContext = new ResultsViewModel(foutenOefeningen, score, overgeblevenTijd);
        }
    }
}
