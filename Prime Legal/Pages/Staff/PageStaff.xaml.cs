using Prime_Legal.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Prime_Legal.Pages.Staff
{
    /// <summary>
    /// Логика взаимодействия для PageStaff.xaml
    /// </summary>
    public partial class PageStaff : Page
    {
        DataFolder.Staff staffer;
        DataFolder.Staff staffing;
        string fn;
        public PageStaff()
        {
            InitializeComponent();
            LBUser.ItemsSource = DataClass.GetContext().Staff.ToList();
            CBPosition.ItemsSource = DataClass.GetContext().Position.ToList();
            CBUser.ItemsSource = DataClass.GetContext().User.Where(u =>
                                                        u.Login != u.Staff.FirstOrDefault(emp =>
                                                        emp.User.Login == u.Login)
                                                        .User.Login).ToList();
            CBPositionEdit.ItemsSource = DataClass.GetContext().Position.ToList();
            CBUserEdit.ItemsSource = DataClass.GetContext().User.Where(u =>
                                                        u.Login != u.Staff.FirstOrDefault(emp =>
                                                        emp.User.Login == u.Login)
                                                        .User.Login).ToList();
            TbDate.SelectedDate = DateTime.Now;
            TbDateEdit.SelectedDate = DateTime.Now;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            staffer = new DataFolder.Staff();
            DataContext = staffer;
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                staffing = LBUser.SelectedItem as DataFolder.Staff;
                DataContext = staffing;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    DataClass.GetContext().Staff.Remove(LBUser.SelectedItem as DataFolder.Staff);
                    DataClass.GetContext().SaveChanges();

                    LBUser.ItemsSource = DataClass.GetContext().Staff.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка с подключением к базе данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {

                staffing.Photo = File.ReadAllBytes(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Фотографиия не была выбрана, Установленна стандартраная фотография", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information) ;
                }
                DataClass.GetContext().SaveChanges();
                LBUser.ItemsSource = DataClass.GetContext().Staff.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            DataClass.context.Passport.Add(new DataFolder.Passport()
            {
                Serial = TbSerial.Text,
                Number = TBNumber.Text
            });
                try
                {
                    staffer.Photo = File.ReadAllBytes(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Фотографиия не была выбрана, Установленна стандартраная фотография", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            
            DataClass.GetContext().Staff.Add(staffer);
            DataClass.GetContext().SaveChanges();
            LBUser.ItemsSource = DataClass.GetContext().Staff.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не выбрали аватар для сотрудника. Сотруднику будет присвоен стандартный аватар", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnLoadImageEdit_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                fn = filename;
            }
        }

        private void BtnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                fn = filename;
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LBUser.ItemsSource = DataClass.GetContext().Staff.Where(s => string.Concat(s.LName," ", s.FName, " ", s.MName).StartsWith(TbSearch.Text)).ToArray();
        }
    }
}
