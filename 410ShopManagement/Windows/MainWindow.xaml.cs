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
        private static MainWindow instance;
        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();

        Windows.LoginWindow loginWindow;

        public MainWindow()
        {
            if (instance == null)
            {
                instance = this;
            }
            InitializeComponent();
            CloseMenuButton.Visibility = Visibility.Collapsed;
        }

        public static MainWindow GetInstance()
        {
            return instance;
        }

        #region Commands Execute
        private void ExitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            confirmer.Text = "Do you sure to quit the application ?";
            confirmer.ShowDialog();

            if(confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
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
                case 3:
                    HomePanel.Children.Clear();
                    HomePanel.Children.Add(new _401UC.StorageUC());
                    break;
                default:
                    break;
            }
        }

        public void MoveCursorMenu(int index)
        {
            MenuChoiceTransitioning.OnApplyTemplate();
            CursorGrid.Margin = new Thickness(0, 60 * index, 0, 0);
        }
        #endregion

        #region App Navigator
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
            //release this instance to create new one
            //if not do this, can GetInstance to the right one
            //exp: login -> click any QuickAccess -> logout -> login -> cant QuickAccess if not create new instance
            instance = null;
            this.Close();
            loginWindow = new Windows.LoginWindow();
            loginWindow.Show();
        }
        #endregion

        #region Other windows use
        //Static func for HomeUC to select items from MainWindow's MenuListView 
        public static void MenuListView_QuickAccess(int index)
        {
            MainWindow.GetInstance().MenuListView.SelectedIndex = index;
        }
        #endregion
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

    public static class InputTester
    {
        public static bool IsAName(string str)
        {
            //is a name without number and less than 40 characters
            try
            {
                Regex rx = new Regex(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ
fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu
UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ\s]{1,40}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //Use for Preview Keydown
        public static bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }

        //Use for Preview Keydown
        public static bool IsDelOrBackspaceOrTabKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab;
        }

        public static bool IsANumber(string str, int maxDigit = 0)
        {
            //is number and less than maxDigit digits
            string pattern = "^[0-9]{1," + maxDigit + "}$";
            try
            {
                Regex rx = new Regex(@pattern);
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsAFloatNumber(string str)
        {
            try
            {
                Regex rx = new Regex(@"^[0-9.]{1,3}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsAClassName(string str)
        {
            //A class name include a-z A-Z 0-9 and less than 4 digits
            try
            {
                Regex rx = new Regex(@"^[a-zA-Z0-9]{1,4}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsADate(string str)
        {
            //A date with DD/MM/YYYY
            try
            {
                Regex rx = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
