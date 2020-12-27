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
    /// Interaction logic for StorageUC.xaml
    /// </summary>
    public partial class StorageUC : UserControl
    {
        ShipmentWindow shipmentWindow = new ShipmentWindow();
        ImportWindow importWindow = new ImportWindow();

        public StorageUC()
        {
            InitializeComponent();
        }

        private void importBtn_Click(object sender, RoutedEventArgs e)
        {
            importWindow.ShowDialog();
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            shipmentWindow.ShowDialog();
            shipmentWindow.OnOpen();
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
