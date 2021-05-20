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

namespace Prime_Legal.Pages.Authorization
{
    /// <summary>
    /// Логика взаимодействия для PageEmailCode.xaml
    /// </summary>
    public partial class PageEmailCode : Page
    {
        public PageEmailCode()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageAuthorization());
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == RandomClass.Saver)
            {
                ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
                ActionWindowClass.MainFrame.Navigate(new PageChangePassword());
            }
            else
            {

                TbLogin.BorderBrush = Brushes.OrangeRed;
                TbLogin.Clear();
            }
        }
    }
}
