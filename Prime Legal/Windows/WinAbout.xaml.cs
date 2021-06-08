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
using System.Windows.Shapes;

namespace Prime_Legal.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinAbout.xaml
    /// </summary>
    public partial class WinAbout : Window
    {
        public WinAbout()
        {
            InitializeComponent();
            BtnClose.Click += (sender, e) => { this.Close(); };
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
