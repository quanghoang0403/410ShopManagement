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
        }

        private void ProductPreview_Click(object sender, RoutedEventArgs e)
        {
            ProductPreview preview = sender as ProductPreview;
            productInsightWnd.productNameTxb.Text = preview.ProductName;
            productInsightWnd.productBasePriceTbl.Text = preview.ProductPrice;
            productInsightWnd.productImg.Source = preview.ProductImageSource;

            productInsightWnd.OnOpen();
            productInsightWnd.ShowDialog();
        }
    }
}
