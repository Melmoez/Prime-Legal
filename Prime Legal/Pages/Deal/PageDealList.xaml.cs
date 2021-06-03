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

namespace Prime_Legal.Pages.Deal
{
    /// <summary>
    /// Логика взаимодействия для PageDealList.xaml
    /// </summary>
    public partial class PageDealList : Page
    {
        Client client;
        public PageDealList()
        {
            client = new Client();
            InitializeComponent(); 
            LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
            DataContext = client;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RBfiz.IsChecked == true)
                {
                    client.IdTypeClient = 1;
                    DataClass.GetContext().Passport.Add(new Passport() { Serial = TbSerial.Text, Number = TBNumber.Text });
                    DataClass.GetContext().Client.Add(client);
                    DataClass.GetContext().SaveChanges();
                }
                else if (RBur.IsChecked == true)
                {
                    client.IdTypeClient = 2;
                    DataClass.GetContext().Passport.Add(new Passport() { Serial = TbSerial.Text, Number = TBNumber.Text });
                    DataClass.GetContext().Adress.Add(new Adress() { Name = TBAddressUR.Text });
                    DataClass.GetContext().Company.Add(new Company() { Name = TbNameUR.Text, BIK = Convert.ToInt64(TBBIKUR.Text), INN = Convert.ToInt64(TBINNUR.Text), RS = Convert.ToInt64(TBRSUR.Text) });
                    
                    DataClass.GetContext().Client.Add(client);
                    DataClass.GetContext().SaveChanges();
                }
                LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
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
        private void RBfiz_Checked(object sender, RoutedEventArgs e)
        {
            SPfiz.IsEnabled = true;
        }

        private void RBfiz_Click(object sender, RoutedEventArgs e)
        {
            TbDate.SelectedDate = DateTime.Now;
            SPfiz.Visibility = Visibility.Visible;
            SPur.Visibility = Visibility.Collapsed;
        }

        private void RBur_Click(object sender, RoutedEventArgs e)
        {
            SPfiz.Visibility = Visibility.Collapsed;
            SPur.Visibility = Visibility.Visible;
        }
    }
}
