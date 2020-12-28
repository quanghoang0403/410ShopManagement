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
    /// Interaction logic for ProductPreview.xaml
    /// </summary>
    public partial class ProductPreview : UserControl
    {
        public int idProduct;

        public ProductPreview()
        {
            InitializeComponent();
        }

        public ImageSource ProductImageSource
        {
            get { return productImage.Source; }
            set { productImage.Source = value; }
        }

        public string ProductName
        {
            get { return productNameTbl.Text; }
            set { productNameTbl.Text = value; }
        }

        public Brush ProductStatus
        {
            get { return productNameTbl.Foreground; }
            set { productNameTbl.Foreground = value; }
        }

        public string ProductPrice
        {
            get { return productPriceTbl.Text; }
            set { productPriceTbl.Text = value; }
        }

        public event RoutedEventHandler Click;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
