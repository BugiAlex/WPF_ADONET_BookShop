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

namespace Book_Shop
{
    
    public partial class MainWindow : Window
    {
         public MainWindow()
        {
            InitializeComponent();
            
            MainViewModel mwm = new MainViewModel();
            this.DataContext = mwm;
        }

        private void Clic_Registration(object sender, RoutedEventArgs e)
        {
            RegistrationWinsow rW = new RegistrationWinsow();
            rW.DataContext = this.DataContext;
            rW.Show();
        }

        private void Clic_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
