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

namespace _410ShopManagement._401UC
{
    /// <summary>
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();

        public HomeUC()
        {
            InitializeComponent();
        }

        private void product_QAButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MenuListView_QuickAccess(1);
        }

        private void payment_QAButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MenuListView_QuickAccess(2);
        }

        private void import_QAButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MenuListView_QuickAccess(3);
        }

        private void product_QAButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void payment_QAButton_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
