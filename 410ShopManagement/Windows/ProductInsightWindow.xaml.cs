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

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for ShipmentWindow.xaml
    /// </summary>
    public partial class ProductInsightWindow : Window
    {
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();
        public ProductInsightWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            applyBtn.Visibility = Visibility.Collapsed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            editBtn.Visibility = Visibility.Collapsed;
            applyBtn.Visibility = Visibility.Visible;

            saleTxb.IsEnabled = true;
            materialTxb.IsEnabled = true;
            originalTxb.IsEnabled = true;
            categoryTxb.IsEnabled = true;
            sexTxb.IsEnabled = true;
            sizeTxb.IsEnabled = true;
            colorTxb.IsEnabled = true;
            descriptionTxb.IsEnabled = true;
            storageTxb.IsEnabled = true;
            soldTxb.IsEnabled = true;
            cancelledTxb.IsEnabled = true;
        }

        public void OnOpen()
        {
            editBtn.Visibility = Visibility.Visible;
            applyBtn.Visibility = Visibility.Collapsed;

            saleTxb.IsEnabled = false;
            materialTxb.IsEnabled = false;
            originalTxb.IsEnabled = false;
            categoryTxb.IsEnabled = false;
            sexTxb.IsEnabled = false;
            sizeTxb.IsEnabled = false;
            colorTxb.IsEnabled = false;
            descriptionTxb.IsEnabled = false;
            storageTxb.IsEnabled = false;
            soldTxb.IsEnabled = false;
            cancelledTxb.IsEnabled = false;

            double basePrice = Convert.ToDouble(productBasePriceTbl.Text);
            double salePercent;

            if (saleTxb.Text == "")
            {
                salePercent = 0;
            }
            else
            {
                salePercent = Convert.ToDouble(saleTxb.Text) / 100;
            }

            productPriceTxb.Text = (basePrice - basePrice * salePercent).ToString();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmer.Text = "Do you sure to save these changes ?";
            confirmer.ShowDialog();

            if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
            {
                OnOpen();
            }
        }

        private void saleTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double basePrice = Convert.ToDouble(productBasePriceTbl.Text);
            double salePercent;

            if (saleTxb.Text == "")
            {
                salePercent = 0;
            }
            else
            {
                salePercent = Convert.ToDouble(saleTxb.Text) / 100;
            }

            productPriceTxb.Text = (basePrice - basePrice * salePercent).ToString();
        }
    }
}
