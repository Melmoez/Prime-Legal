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

namespace Prime_Legal.Pages.Staff
{
    /// <summary>
    /// Логика взаимодействия для PageStaff.xaml
    /// </summary>
    public partial class PageStaff : Page
    {
        DataFolder.Staff staffer;
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
            DataContext = LBUser.SelectedItem as DataFolder.Staff;
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
            DataClass.GetContext().Staff.Add(staffer);
            DataClass.GetContext().SaveChanges();
            LBUser.ItemsSource = DataClass.GetContext().Staff.ToArray();
        }
    }
}
