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

namespace MensErgerJeNiet
{
    /// <summary>
    /// Interaction logic for SpelRegels.xaml
    /// </summary>
    public partial class SpelRegels : Page
    {
        public SpelRegels()
        {
            InitializeComponent();
        }

        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            Home homePage = new Home();
            NavigationService.Navigate(homePage);
        }
    }
}
