using Prime_Legal.DataFolder;
using Prime_Legal.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prime_Legal.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        User user;
        public PageUser()
        {
            InitializeComponent();
            
            LBUser.ItemsSource = DataClass.GetContext().User.OrderBy(u => u.Login).ToArray();
            CBRole.ItemsSource = DataClass.GetContext().Role.ToArray();
            CBRoleEdit.ItemsSource = DataClass.GetContext().Role.ToArray();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClass.GetContext().User.Add(user);
                DataClass.GetContext().SaveChanges();
                LBUser.ItemsSource = DataClass.GetContext().User.OrderBy(u => u.Login).ToArray();
            }
            catch (DbEntityValidationException ex)
            {
                string result = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    
                    result += ("Object: " + validationError.Entry.Entity.ToString());
                    result += $"\n";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        result += (err.ErrorMessage + $"\n");
                    }
                }
                MessageBox.Show(result);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBoxResult.Yes ==
                MessageBox.Show("Вы действительно хотите удалить эту запись?", "Вопрос",
                MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    DataClass.GetContext().User.Remove(LBUser.SelectedItem as DataFolder.User);
                    DataClass.GetContext().SaveChanges();

                    LBUser.ItemsSource = DataClass.GetContext().User.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка с подключением к базе данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                DataContext = LBUser.SelectedItem as User;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClass.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            user = new User();
            DataContext = user;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LBUser.ItemsSource = DataClass.GetContext().User.OrderBy(u => u.Login).Where(u => u.Login.StartsWith(TbSearch.Text)).ToArray();
        }
    }
}
