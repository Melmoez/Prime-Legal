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
            CBUser.ItemsSource = DataClass.GetContext().User.ToList();
            CBPositionEdit.ItemsSource = DataClass.GetContext().Position.ToList();
            CBUserEdit.ItemsSource = DataClass.GetContext().User.ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            staffer = new DataFolder.Staff();
            DataContext = staffer;
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {

            staffing = LBUser.SelectedItem as DataFolder.Staff;
            DataContext = staffing;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataClass.GetContext().Staff.Remove(LBUser.SelectedItem as DataFolder.Staff);
            DataClass.GetContext().SaveChanges();
            LBUser.ItemsSource = DataClass.GetContext().Staff.ToArray();
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staffing.Photo = File.ReadAllBytes(fn);
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
            DataClass.context.Passport.Add(new DataFolder.Passport()
            {
                Serial = TbSerial.Text,
                Number = TBNumber.Text
            });
            staffer.Photo = File.ReadAllBytes(fn);
            DataClass.GetContext().Staff.Add(staffer);
            DataClass.GetContext().SaveChanges();
            LBUser.ItemsSource = DataClass.GetContext().Staff.ToArray();
        }

        private void BtnLoadImageEdit_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
