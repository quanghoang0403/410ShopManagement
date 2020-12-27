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
    /// Interaction logic for CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        _401UC.iNotifier notify = new _401UC.iNotifier();
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();
        public CreateProductWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmer.Text = "Do you sure to save these changes ?";
            confirmer.ShowDialog();

            if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
            {
                notify.Text = "Change success !!";
                notify.ShowDialog();
                productBasePriceTbl.Text = "";
                productPriceTxb.Text = "";
                saleTxb.Text = "";
                productNameTxb.Text = "";
                materialTxb.Text = "";
                originalTxb.Text = "";
                categoryTxb.Text = "";
                sexTxb.Text = "";
                sizeTxb.Text = "";
                colorTxb.Text = "";
                descriptionTxb.Text = "";
                this.Hide();
            }
        }

        private void findImageBtn_Click(object sender, RoutedEventArgs e)
        {

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

        private void productBasePriceTbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            productPriceTxb.Text = productBasePriceTbl.Text;
        }

        private void productBasePriceTbl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //only allows number (above QWERTY and right-side numberpad and del,backspace,tab key)
            e.Handled = !IsNumberKey(e.Key) && !IsDelOrBackspaceOrTabKey(e.Key);
        }

        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDelOrBackspaceOrTabKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab;
        }
    }
}
