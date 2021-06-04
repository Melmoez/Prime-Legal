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
        DataFolder.Deal deal;
        State state;
        string c;
        string d;
        public PageDealList()
        {
            
            InitializeComponent();
            CBTypeState.ItemsSource = DataClass.GetContext().TypeState.ToArray();
            CBRenovation.ItemsSource = DataClass.GetContext().Renovation.ToArray();
            CBRoom.ItemsSource = DataClass.GetContext().Room.ToArray();
            CBTypeDeal.ItemsSource = DataClass.GetContext().TypeDeal.ToArray();
            LBUser.ItemsSource = DataClass.GetContext().Client.ToList();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            client = new DataFolder.Client();
            DataContext = client;
            gridAddClient.Visibility = Visibility.Visible;
            gridAddState.Visibility = Visibility.Collapsed;
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            Client clienter = LBUser.SelectedItem as Client;
            DataContext = clienter;
            if (clienter.IdTypeClient == 1)
            {
                TbDate.SelectedDate = DateTime.Now;
                SPfiz.Visibility = Visibility.Visible;
                SPur.Visibility = Visibility.Collapsed;
            }
            else if (clienter.IdTypeClient == 2)
            {
                SPfiz.Visibility = Visibility.Collapsed;
                SPur.Visibility = Visibility.Visible;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            DataClass.GetContext().SaveChanges();
            LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
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
                    c = TbFname.Text;
                    d = TbLName.Text;
                    DataClass.GetContext().SaveChanges();
                    gridAddClient.Visibility = Visibility.Collapsed;
                    gridAddState.Visibility = Visibility.Visible;
                }
                else if (RBur.IsChecked == true)
                {
                    client.IdTypeClient = 2;
                    DataClass.GetContext().Passport.Add(new Passport() { Serial = TbSerial.Text, Number = TBNumber.Text });
                    DataClass.GetContext().Adress.Add(new Adress() { Name = TBAddressUR.Text });
                    DataClass.GetContext().Company.Add(new Company() { Name = TbNameUR.Text, BIK = Convert.ToInt64(TBBIKUR.Text), INN = Convert.ToInt64(TBINNUR.Text), RS = Convert.ToInt64(TBRSUR.Text) });
                    c = TbFnameUR.Text;
                    d = TbLNameUR.Text;
                    DataClass.GetContext().Client.Add(client);
                    DataClass.GetContext().SaveChanges();
                    gridAddClient.Visibility = Visibility.Collapsed;
                    gridAddState.Visibility = Visibility.Visible;
                }
                LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
                state = new DataFolder.State();
                DataContext = state;
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

        private void BtnNextState_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a;
                string b;
                DataClass.GetContext().Adress.Add(new Adress() { Name = TBAdressState.Text });
                state.IdOwner = DataClass.GetContext().Client.FirstOrDefault(clie => clie.FName == c && clie.LName == d).Id; ;
                a = TBCadastrialNumber.Text;
                b = CBTypeDeal.Text;
                MessageBox.Show(b);
                DataClass.GetContext().State.Add(state);
                DataClass.GetContext().SaveChanges();

                DataClass.context = null;
                deal = new DataFolder.Deal();
                DataContext = deal;
                deal.IdState = DataClass.GetContext().State.FirstOrDefault(s => s.CadastralNumber == a).Id;
                deal.IdClient = DataClass.GetContext().Client.FirstOrDefault(clie => clie.FName == c && clie.LName == d).Id;
                deal.IdTypeDeal = DataClass.GetContext().TypeDeal.FirstOrDefault(td => td.Name == b).Id;
                DataClass.GetContext().Deal.Add(deal);
                DataClass.GetContext().SaveChanges();
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
