﻿using Prime_Legal.Services;
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

namespace Prime_Legal.Pages.Deal
{
    /// <summary>
    /// Логика взаимодействия для PageDealList.xaml
    /// </summary>
    public partial class PageDealList : Page
    {
        public PageDealList()
        {
            InitializeComponent(); 
            LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
