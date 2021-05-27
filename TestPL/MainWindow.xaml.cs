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

namespace TestPL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void Runtb2_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("");
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BtnGo_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string a = "melmoes1233@mail.ru";
        //        var client = new SmtpClient("smtp.mail.ru", 25);
        //        client.Credentials = new NetworkCredential(a, "Ilyame123");
        //        client.EnableSsl = true;
        //        client.Send(a, TbEmail.Text, "Тест", "sfa");

        //        MessageBox.Show("ОООо Повезло повезло");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //EntityValidationErrors решение
        //    catch (DbEntityValidationException ex)
        //{
        //    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
        //    {
        //        result += ("Object: " + validationError.Entry.Entity.ToString());
        //        result += $"\n";
        //        foreach (DbValidationError err in validationError.ValidationErrors)
        //        {
        //            result += (err.ErrorMessage + $"\n");
        //        }
        //    }
        //    MessageBox.Show(result);
    }
        }