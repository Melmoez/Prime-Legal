﻿using Prime_Legal.DataFolder;
using Prime_Legal.Services;
using Prime_Legal.Windows;
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
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        Window winAuth = ActionWindowClass.CurrentWindow;
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void BtnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                Runtb.Text = null;
                Runtb2.Inlines.Clear();
                Runtb.Text += "Вы не ввели пароль.";
                Runtb2.Inlines.Add("Забыли пароль?");
                PBPassword.BorderBrush = Brushes.OrangeRed;
            }
            else if (string.IsNullOrWhiteSpace(PBPassword.Password))
            {
                Runtb.Text = null;
                Runtb2.Inlines.Clear();
                Runtb.Text += "Вы не ввели логин.";
                Runtb2.Inlines.Add("Забыли пароль?");
                TbLogin.BorderBrush = Brushes.OrangeRed;
                PBPassword.BorderBrush = Brushes.OrangeRed;
                TbLogin.Clear();
                PBPassword.Clear();
            }
            else
            {
                var user = DataClass.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text);
                if ((user == null) || (user.Password != PBPassword.Password))
                {
                    Runtb.Text = null;
                    Runtb2.Inlines.Clear();
                    Runtb.Text += "Вы ввели неверный логин или пароль.";
                    Runtb2.Inlines.Add("Забыли пароль?");
                    TbLogin.BorderBrush = Brushes.OrangeRed;
                    PBPassword.BorderBrush = Brushes.OrangeRed;
                    TbLogin.Clear();
                    PBPassword.Clear();
                }
                else
                {
                    switch (user.IdRole)
                    {
                        case 1:
                            new WinAdmin().Show();
                            winAuth.Close();
                            break;
                    }
                }

            }
            
        }

        private void Runtb2_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageEmailInput());
        }
    }
}
