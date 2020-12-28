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
using MaterialDesignThemes.Wpf;
using BLL;
using _410ShopManagement.Classes;

namespace _410ShopManagement.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //use for notify when insert incorrect info
        bool isLoginSuccess = false;
        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        MainWindow mwd = new MainWindow();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txbUser.Text != "" &&
                txbPassword.Password.ToString() != "")
            {
                foreach (Account acc in DataField.Instance.accounts)
                {
                    if (txbUser.Text == acc.userName)
                    {
                        if (txbPassword.Password.ToString() == acc.password)
                        {
                            //save the account loged-in's id
                            DataField.Instance.idCurrentAccountLogin = acc.idAccount; 
                            isLoginSuccess = true;
                            mwd.Show();
                            this.Close();
                        }
                    }
                }

                if (!isLoginSuccess)
                {
                    txbUser.Text = "";
                    txbPassword.Password = "";
                    txbUser.Focus();
                    notify.Text = "Username or Password was incorrect";
                    notify.ShowDialog();
                }
            }
            else
            {
                notify.Text = "Please fill all the insert boxes";
                notify.ShowDialog();
            }
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
