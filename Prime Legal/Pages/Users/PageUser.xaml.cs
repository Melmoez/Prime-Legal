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
        User user = new User();
        public PageUser()
        {
            InitializeComponent();
            DataContext = user;
            LBUser.ItemsSource = DataClass.GetContext().User.OrderBy(u => u.Login).ToArray();
            Cbb.ItemsSource = DataClass.GetContext().Role.ToArray();
            CBRole.ItemsSource = DataClass.GetContext().Role.ToArray();


        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(LBUser.SelectedIndex.ToString());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                
                
                DataClass.GetContext().User.Add(user);
                MessageBox.Show(user.Login + user.Password + user.IdRole);
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
    }
}
