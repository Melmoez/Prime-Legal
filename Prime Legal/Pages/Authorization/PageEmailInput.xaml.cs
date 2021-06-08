using Prime_Legal.DataFolder;
using Prime_Legal.Services;
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


                User user = DataClass.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text);
                if (user == null)
                {
                    RunError.Text = null;
                    RunError.Text = "Пользователя с таким логином не существует";
                    TbLogin.BorderBrush = Brushes.OrangeRed;
                }
                else
                {
                    try
                    {
                        string Code = RandomClass.Rand(6);
                        string a = "primelegalestate@mail.ru";
                        var client = new SmtpClient("smtp.mail.ru", 25);
                        client.Credentials = new NetworkCredential(a, "WASD1337");
                        client.EnableSsl = true;
                        client.Send(a, TbLogin.Text, "Код для смены пароля", Code);
                        RandomClass.Saver = Code;
                        ActionWindowClass.MainFrame.Navigate(new PageEmailCode());
                        ActionWindowClass.UserTransition = user;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
