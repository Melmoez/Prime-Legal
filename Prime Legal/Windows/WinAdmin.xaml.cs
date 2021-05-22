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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prime_Legal.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinAdmin.xaml
    /// </summary>
    public partial class WinAdmin : Window
    {
        public WinAdmin()
        {
            InitializeComponent();
            BtnClose.Click += (sender, e) => { ActionWindowClass.CloseStateButton(); };
            BtnMinimize.Click += (sender, e) => { ActionWindowClass.MinimizedStateButton(this); };
            DoubleAnimation buttonAnimation = new DoubleAnimation();
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Collapsed;
            BtnCloseMenu.Visibility = Visibility.Visible;

            DoubleAnimation GridMenuOpen = new DoubleAnimation();
            DoubleAnimation LineMenuOpen = new DoubleAnimation();
            GridMenuOpen.From = GridHamburger.ActualWidth;
            LineMenuOpen.From = RectangleMenu.ActualWidth;
            GridMenuOpen.To = 376;
            LineMenuOpen.To = 356;
            LineMenuOpen.Duration = TimeSpan.FromSeconds(0.1);
            GridMenuOpen.Duration = TimeSpan.FromSeconds(0.1);
            RectangleMenu.BeginAnimation(Rectangle.WidthProperty, LineMenuOpen);
            GridHamburger.BeginAnimation(Grid.WidthProperty, GridMenuOpen);
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Visible;
            BtnCloseMenu.Visibility = Visibility.Collapsed;

            DoubleAnimation GridMenuClose = new DoubleAnimation();
            DoubleAnimation LineMenuClose = new DoubleAnimation();
            GridMenuClose.From = GridHamburger.ActualWidth;
            LineMenuClose.From = RectangleMenu.ActualWidth;
            GridMenuClose.To = 70;
            LineMenuClose.To = 47;
            LineMenuClose.Duration = TimeSpan.FromSeconds(0.1);
            GridMenuClose.Duration = TimeSpan.FromSeconds(0.1);
            RectangleMenu.BeginAnimation(Rectangle.WidthProperty, LineMenuClose);
            GridHamburger.BeginAnimation(Grid.WidthProperty, GridMenuClose);
        }
    }
}
