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

namespace Prime_Legal.Pages.Deal
{
    /// <summary>
    /// Логика взаимодействия для PageDealDouble.xaml
    /// </summary>
    public partial class PageDealDouble : Page
    {
        public PageDealDouble(DataFolder.Deal deal)
        {
            InitializeComponent();
            DataContext = deal;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionWindowClass.MainFrame.NavigationService.RemoveBackEntry();
            ActionWindowClass.MainFrame.Navigate(new PageDealList());
        }
    }
}
