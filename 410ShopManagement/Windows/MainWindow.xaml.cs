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

        public MainWindow()
        {
            InitializeComponent();
        }

        #region ThemeButton
        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyTheme(theme => theme.SetBaseTheme(DarkModeToggleButton.IsChecked == true ? Theme.Dark : Theme.Light));

            //This with hard-setting Background from Owner make Binding of SearchBar's background works smoother
            if (DarkModeToggleButton.IsChecked == true)
            {
                Brush darkBG = (Brush)Application.Current.Resources["darkBackgroundThemeColor"];
                
                //Setting Docker's panels background to darkBG
            }
            else
            {
                Brush lightBG = (Brush)Application.Current.Resources["backgroundThemeColor"];

                //Setting Docker's panels background to lightBG
            }

            notify.Text = "Change application's theme successfully !";
            notify.ShowDialog();
        }

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
        #endregion

        #region Left Panel

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            notify.Text = "You clicked " + btn.Tag;
            notify.ShowDialog();
        }

        private void FirstTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (FirstTreeView.SelectedItem != null)
            {
                if (((TreeViewItem)e.NewValue).Tag != null)
                {
                    switch (((TreeViewItem)e.NewValue).Tag.ToString())
                    {
                        case "Child 1":
                            notify.Text = "You clicked " + ((TreeViewItem)e.NewValue).Tag.ToString();
                            notify.ShowDialog();
                            break;
                        case "Child 2":
                            notify.Text = "You clicked " + ((TreeViewItem)e.NewValue).Tag.ToString();
                            notify.ShowDialog();
                            break;
                        case "Child 3":
                            notify.Text = "You clicked " + ((TreeViewItem)e.NewValue).Tag.ToString();
                            notify.ShowDialog();
                            break;
                        case "Child 4":
                            notify.Text = "You clicked " + ((TreeViewItem)e.NewValue).Tag.ToString();
                            notify.ShowDialog();
                            break;
                    }

                    //Release selected item
                    ((TreeViewItem)FirstTreeView.SelectedItem).IsSelected = false;
                }
            }
        }
        #endregion

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

            //This is for testing
            Windows.TempWindow temp = new Windows.TempWindow();
            temp.Show();

            this.Close();
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
}
