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
            get { return productName.Text; }
            set { productName.Text = value; }
        }

        public Brush ProductStatus
        {
            get { return productName.Foreground; }
            set { productName.Foreground = value; }
        }

        public string ProductPrice
        {
            get { return productPrice.Text; }
            set { productPrice.Text = value; }
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
