using _410ShopManagement.Classes;
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
    /// Interaction logic for ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        //Windows
        ProductInsightWindow productInsightWnd = new ProductInsightWindow();

        public ProductUC()
        {
            InitializeComponent();

            PanelLoad();
        }

        private void PanelLoad()
        {
            productPanel.Children.Clear();

            foreach (Product prod in DataField.Instance.products)
            {
                ProductPreview preview = new ProductPreview();
                #region Product Preview receive Product Detail to create
                preview.idProduct = prod.idProduct;
                //dun know why )):
                preview.productNameTbl.Text = prod.nameProduct;
                preview.ProductPrice = prod.exportPrice.ToString();
                if (prod.storageQuantity <= 0)
                {
                    preview.ProductStatus = Brushes.Red;
                }
                BitmapImage bimage = new BitmapImage();
                bimage.BeginInit();
                bimage.UriSource = new Uri(prod.imagePath, UriKind.Relative);
                bimage.EndInit();
                preview.productImage.Source = bimage;
                preview.Click += ProductPreview_Click;
                #endregion

                productPanel.Children.Add(preview);
            }
        }

        private void ProductPreview_Click(object sender, RoutedEventArgs e)
        {
            ProductPreview preview = sender as ProductPreview;

            foreach (Product prod in DataField.Instance.products)
            {
                if (prod.idProduct == preview.idProduct)
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
                    break;
                }
            }

            productInsightWnd.idProduct = preview.idProduct;
            productInsightWnd.OnOpen();
            productInsightWnd.ShowDialog();

            if (productInsightWnd.isEditDone)
            {
                //when edit done -> reload
                PanelLoad();
            }
        }
    }
}
