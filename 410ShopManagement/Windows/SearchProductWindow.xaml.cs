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
    /// Interaction logic for SearchProductWindow.xaml
    /// </summary>
    public partial class SearchProductWindow : Window
    {
        public TransferTag tag;
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public enum TransferTag
        {
            UpdateProduct = 0,
            CancelProduct = 1
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchProductNameTxb.Text != "")
            {
                searchProductNameTxb.Text = "";
                if (tag == TransferTag.UpdateProduct)
                {
                    productInsightWnd.OnOpen();
                    productInsightWnd.ShowDialog();
                }
                else if (tag == TransferTag.CancelProduct)
                {
                    cancelProductWnd.ShowDialog();
                }
            }
            else
            {
                notify.Text = "Please fill the insert box";
                notify.ShowDialog();
            }
        }

    }
}
