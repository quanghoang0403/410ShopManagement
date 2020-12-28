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
using _410ShopManagement.Classes;
using BLL;

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for ShipmentWindow.xaml
    /// </summary>
    public partial class ProductInsightWindow : Window
    {
        //use for editting right product
        public int idProduct;
        //use for refresh productUC
        public bool isEditDone = false;

        //windows
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

            productBasePriceTbl.IsEnabled = true;
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

            productBasePriceTbl.IsEnabled = false;
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

            productPriceTxb.Text = (Convert.ToInt32(basePrice - basePrice * salePercent)).ToString();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmer.Text = "Do you sure to save these changes ?";
            confirmer.ShowDialog();

            if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
            {
                foreach (Product prod in DataField.Instance.products)
                {
                    if (prod.idProduct == idProduct)
                    {
                        #region Product receive new changes
                        prod.nameProduct = productNameTxb.Text;
                        prod.importPrice = Convert.ToInt32(productBasePriceTbl.Text);
                        prod.exportPrice = Convert.ToInt32(productPriceTxb.Text);
                        prod.saleOffset = Convert.ToInt32(saleTxb.Text);
                        prod.material = materialTxb.Text;
                        prod.origin = originalTxb.Text;
                        prod.category = categoryTxb.Text;
                        prod.size = sizeTxb.Text;
                        prod.sex = sexTxb.Text;
                        prod.color = colorTxb.Text;
                        prod.description = descriptionTxb.Text;
                        prod.storageQuantity = Convert.ToInt32(storageTxb.Text);
                        prod.soldQuantity = Convert.ToInt32(soldTxb.Text);
                        prod.cancelQuantity = Convert.ToInt32(cancelledTxb.Text);
                        #endregion
                        break;
                    }
                }

                //for refresh productUC
                isEditDone = true;
                OnOpen();
            }
        }

        private void saleTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productBasePriceTbl.Text == "") return;

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

            productPriceTxb.Text = (Convert.ToInt32(basePrice - basePrice * salePercent)).ToString();
        }

        private void NumberTxb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //only allows number (above QWERTY and right-side numberpad and del,backspace,tab key)
            e.Handled = !InputTester.IsNumberKey(e.Key) && !InputTester.IsDelOrBackspaceOrTabKey(e.Key);
        }

        private void productBasePriceTbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            productPriceTxb.Text = productBasePriceTbl.Text;
        }
    }
}
