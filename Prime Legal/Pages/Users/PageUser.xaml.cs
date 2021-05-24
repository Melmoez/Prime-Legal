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

namespace Prime_Legal.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
            LBUser.ItemsSource = DataClass.GetContext().User.OrderBy(u => u.Login).ToArray();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(LBUser.SelectedIndex.ToString());
        }
    }
}
