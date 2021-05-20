using Prime_Legal.Pages.Authorization;
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
    /// Логика взаимодействия для WinAuthorization.xaml
    /// </summary>
    public partial class WinAuthorization : Window
    {
        public WinAuthorization()
        {
            InitializeComponent();
            BtnClose.Click += (sender, e) => { ActionWindowClass.CloseStateButton(); };
            BtnMinimize.Click += (sender, e) => { ActionWindowClass.MinimizedStateButton(this); };
            FrameMain.Navigate(new PageAuthorization());
            ActionWindowClass.MainFrame = FrameMain;
        }

        private void GridMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

    }
}
