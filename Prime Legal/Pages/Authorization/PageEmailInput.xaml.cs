﻿using Prime_Legal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для PageEmailInput.xaml
    /// </summary>
    public partial class PageEmailInput : Page
    {
        public PageEmailInput()
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
            try
            {
                string Code = RandomClass.Rand(6);
                string a = "melmoes1233@mail.ru";
                var client = new SmtpClient("smtp.mail.ru", 25);
                client.Credentials = new NetworkCredential(a, "Ilyame123");
                client.EnableSsl = true;
                client.Send(a, TbLogin.Text, "Тест", Code);
                RandomClass.Saver = Code;
                ActionWindowClass.MainFrame.Navigate(new PageEmailCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
