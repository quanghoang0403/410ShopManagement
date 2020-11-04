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
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        Windows.LoginWindow loginWindow;

        public MainWindow()
        {
            InitializeComponent();
            CloseMenuButton.Visibility = Visibility.Collapsed;
            minimizeButton.Icon = PackIconKind.WindowMinimize;
            logoutButton.Icon = PackIconKind.Logout;
        }

        #region Commands Execute
        private void ExitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _401UC.iNotifierOKCancel finalConfirmation = new _401UC.iNotifierOKCancel();

            finalConfirmation.Text = "Do you sure to quit the application ?";
            finalConfirmation.ShowDialog();

            if(finalConfirmation.result == _401UC.iNotifierOKCancel.Result.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void LogOutCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Show Login window

            this.Close();
        }
        #endregion

        #region Menu Panel
        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = Visibility.Visible;
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Visible;
            CloseMenuButton.Visibility = Visibility.Collapsed;
        }

        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuListView.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    HomePanel.Children.Clear();
                    HomePanel.Children.Add(new _401UC.HomeUC());
                    break;
                case 1:
                    HomePanel.Children.Clear();
                    HomePanel.Children.Add(new _401UC.ProductUC());
                    break;
                case 2:
                    HomePanel.Children.Clear();
                    HomePanel.Children.Add(new _401UC.PaymentUC());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            MenuChoiceTransitioning.OnApplyTemplate();
            CursorGrid.Margin = new Thickness(0, 60 * index, 0, 0);
        }
        #endregion

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loginWindow = new Windows.LoginWindow();
            loginWindow.Show();
        }
    }

    //Custom Commands for the whole app (in this namespace)
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Escape)
                }
            );
        public static readonly RoutedUICommand LogOut = new RoutedUICommand
            (
                "Logout",
                "Logout",
                typeof(CustomCommands)
            );
        public static readonly RoutedUICommand CloseWindow = new RoutedUICommand
            (
                "CloseWindow",
                "CloseWindow",
                typeof(CustomCommands)
            );
    }
}
