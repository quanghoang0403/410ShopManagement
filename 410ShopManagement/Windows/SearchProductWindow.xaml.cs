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
    /// Interaction logic for SearchProductWindow.xaml
    /// </summary>
    public partial class SearchProductWindow : Window
    {
        public TransferTag tag;
        public List<string> productNames = new List<string>();

        _401UC.iNotifier notify = new _401UC.iNotifier();
        //Windows
        ProductInsightWindow productInsightWnd = new ProductInsightWindow();
        CancelProductWindow cancelProductWnd = new CancelProductWindow();

        public SearchProductWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

        }

        public enum TransferTag
        {
            UpdateProduct = 0,
            CancelProduct = 1
        }

        public void OnOpen()
        {
            productNames.Clear();
            foreach (Product product in DataField.Instance.products)
            {
                productNames.Add(product.nameProduct);
            }
            searchProductNameTxb.ItemsSource = productNames;

            searchProductNameTxb.Text = "";
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchProductNameTxb.Text != "")
            {
                foreach (Product prod in DataField.Instance.products)
                {
                    if (searchProductNameTxb.Text == prod.nameProduct)
                    {
                        if (tag == TransferTag.UpdateProduct)
                        {
                            #region Receive Product's detail
                            productInsightWnd.productNameTxb.Text = prod.nameProduct;
                            BitmapImage bimage = new BitmapImage();
                            bimage.BeginInit();
                            bimage.UriSource = new Uri(prod.imagePath, UriKind.Relative);
                            bimage.EndInit();
                            productInsightWnd.productImg.Source = bimage;
                            productInsightWnd.productBasePriceTbl.Text = prod.importPrice.ToString();
                            productInsightWnd.productPriceTxb.Text = prod.exportPrice.ToString();
                            productInsightWnd.saleTxb.Text = prod.saleOffset.ToString();
                            productInsightWnd.materialTxb.Text = prod.material;
                            productInsightWnd.originalTxb.Text = prod.origin;
                            productInsightWnd.categoryTxb.Text = prod.category;
                            productInsightWnd.sizeTxb.Text = prod.size;
                            productInsightWnd.sexTxb.Text = prod.sex;
                            productInsightWnd.colorTxb.Text = prod.color;
                            productInsightWnd.descriptionTxb.Text = prod.description;
                            productInsightWnd.storageTxb.Text = prod.storageQuantity.ToString();
                            productInsightWnd.soldTxb.Text = prod.soldQuantity.ToString();
                            productInsightWnd.cancelledTxb.Text = prod.cancelQuantity.ToString();
                            #endregion

                            productInsightWnd.idProduct = prod.idProduct;
                            productInsightWnd.OnOpen();
                            productInsightWnd.ShowDialog();
                            searchProductNameTxb.Text = "";
                            break;
                        }
                        else if (tag == TransferTag.CancelProduct)
                        {
                            #region Receive Product;s detail
                            cancelProductWnd.productNameTxb.Text = prod.nameProduct;
                            BitmapImage bimage = new BitmapImage();
                            bimage.BeginInit();
                            bimage.UriSource = new Uri(prod.imagePath, UriKind.Relative);
                            bimage.EndInit();
                            cancelProductWnd.productImg.Source = bimage;
                            cancelProductWnd.storageQuantityTbl.Text = prod.storageQuantity.ToString();
                            #endregion

                            cancelProductWnd.idProduct = prod.idProduct;
                            cancelProductWnd.ShowDialog();
                            searchProductNameTxb.Text = "";
                            break;
                        }
                    }
                }
            }
            else
            {
                notify.Text = "Please fill the insert box";
                notify.ShowDialog();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            searchProductNameTxb.Text = "";
            this.Hide();
        }

    }
}
