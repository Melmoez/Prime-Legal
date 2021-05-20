using Prime_Legal.DataFolder;
using Prime_Legal.Services;
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
    /// Логика взаимодействия для PageChangePassword.xaml
    /// </summary>
    public partial class PageChangePassword : Page
    {
        
        public PageChangePassword()
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
            if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                RunError.Text = null;
                RunError.Text = "Пароль не указан";
                TbPassword.BorderBrush = Brushes.OrangeRed;
                
            }
            else if (string.IsNullOrWhiteSpace(TbPasswordConfirm.Text))
            {
                RunError.Text = null;
                RunError.Text = "Пароль не подтвержден";
                TbPasswordConfirm.BorderBrush = Brushes.OrangeRed;
                TbPassword.Clear();
            }
            else if (TbPassword.Text != TbPasswordConfirm.Text)
            {
                RunError.Text = null;
                RunError.Text = "Пароли не совпадают. Повторите попытку.";
                TbPasswordConfirm.BorderBrush = Brushes.OrangeRed;
                TbPassword.Clear();
                TbPasswordConfirm.Clear();
            }
            else
            {
                try
                {
                    User user = ActionWindowClass.UserTransition;
                    user.Password = TbPassword.Text;
                    DataClass.GetContext().SaveChanges();
                    ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
                    ActionWindowClass.MainFrame.Navigate(new PageAuthorization());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
    }
}
