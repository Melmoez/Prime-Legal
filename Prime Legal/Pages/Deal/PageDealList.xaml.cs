﻿using Prime_Legal.DataFolder;
using Prime_Legal.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace Prime_Legal.Pages.Deal
{
    /// <summary>
    /// Логика взаимодействия для PageDealList.xaml
    /// </summary>
    public partial class PageDealList : Page
    {
        Client client;
        string fn;
        DataFolder.Deal deal;
        DataFolder.Deal dealing;
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
            CBRenovationEdit.ItemsSource = DataClass.GetContext().Renovation.ToArray();
            CBRoomEdit.ItemsSource = DataClass.GetContext().Room.ToArray();
            CBTypeDealEdit.ItemsSource = DataClass.GetContext().TypeDeal.ToArray();
            LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();

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
            try
            {


                DataFolder.Deal dealer = LBUser.SelectedItem as DataFolder.Deal;
                DataContext = dealer;
                dealing = dealer;
                if (dealer.Client.IdTypeClient == 1)
                {
                    TbDate.SelectedDate = DateTime.Now;
                    SPfizEdit.Visibility = Visibility.Visible;
                    SPurEdit.Visibility = Visibility.Collapsed;
                }
                else if (dealer.Client.IdTypeClient == 2)
                {
                    SPfizEdit.Visibility = Visibility.Collapsed;
                    SPurEdit.Visibility = Visibility.Visible;
                }
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
                    DataClass.GetContext().Deal.Remove(LBUser.SelectedItem as DataFolder.Deal);
                    DataClass.GetContext().SaveChanges();

                    LBUser.ItemsSource = DataClass.GetContext().Deal.ToList();
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

                dealing.Photo = File.ReadAllBytes(fn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фотографиия не была выбрана, Установленна стандартраная фотография", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
                    Company company;
                    client.IdTypeClient = 2;
                    DataClass.GetContext().Passport.Add(new Passport() { Serial = TbSerialUR.Text, Number = TBNumberUR.Text });
                    DataClass.GetContext().Adress.Add(new Adress() { Name = TBAddressUR.Text });
                    company = DataClass.GetContext().Company.Add(new Company() { Name = TbNameUR.Text, BIK = Convert.ToInt64(TBBIKUR.Text), INN = Convert.ToInt64(TBINNUR.Text), RS = Convert.ToInt64(TBRSUR.Text) });
                    c = TbFnameUR.Text;
                    d = TbLNameUR.Text;
                    client.IdCompany = company.Id;
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
                DataClass.GetContext().State.Add(state);
                DataClass.GetContext().SaveChanges();

                DataClass.context = null;
                deal = new DataFolder.Deal();
                DataContext = deal;
                try
                {
                    deal.Photo = File.ReadAllBytes(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Фотографиия не была выбрана, Установленна стандартраная фотография", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                deal.IdState = DataClass.GetContext().State.FirstOrDefault(s => s.CadastralNumber == a).Id;
                deal.IdClient = DataClass.GetContext().Client.FirstOrDefault(clie => clie.FName == c && clie.LName == d).Id;
                deal.IdTypeDeal = DataClass.GetContext().TypeDeal.FirstOrDefault(td => td.Name == b).Id;
                deal.IdStaff = ActionWindowClass.staffUser.Id;
                deal.DateCreate = DateTime.Now;
                DataClass.GetContext().Deal.Add(deal);
                DataClass.GetContext().SaveChanges();
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

        private void BtnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Create OpenFileDialog 
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLoadImageEdit_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
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

        private void LBUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageDealDouble(LBUser.SelectedItem as DataFolder.Deal));
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LBUser.ItemsSource = DataClass.GetContext().Deal.Where(s => s.State.CadastralNumber.StartsWith(TbSearch.Text)).ToArray();
        }

    }
}
