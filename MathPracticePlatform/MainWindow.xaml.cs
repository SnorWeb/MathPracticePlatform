﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MathPracticePlatform.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MathPracticePlatform.Services;

namespace MathPracticePlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (MainFrame == null)
            {
                MessageBox.Show("MainFrame is null!");
            }
            CustomNavigationService.Instance.Initialize(MainFrame);
            CustomNavigationService.Instance.Navigate(new Views.MainPage());
        }
    }
}
