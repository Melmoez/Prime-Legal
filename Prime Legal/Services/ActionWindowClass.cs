using Prime_Legal.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Prime_Legal.Services
{
    class ActionWindowClass
    {
        static public void CloseStateButton()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно желаете выйти?",
                "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        static public void MinimizedStateButton(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        static public void WindowTransition(Window current, Window newWindow)
        {
            current.Close();
            newWindow.Show();
        }
        public static Frame MainFrame { get; set; }
        public static User UserTransition { get; set; }
        public static Window CurrentWindow { get; set; }
    }
}
