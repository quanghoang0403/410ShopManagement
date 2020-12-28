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
using BLL;

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for CancelProductWindow.xaml
    /// </summary>
    public partial class CancelProductWindow : Window
    {
        _401UC.iNotifier notify = new _401UC.iNotifier();
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();
        public CancelProductWindow()
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
            //dien day du
            if (cancelledTxb.Text != "")
            {
                //neu khong phai 1 so <10000 thi return
                if (!InputTester.IsANumber(cancelledTxb.Text, 4))
                {
                    notify.Text = "Cancelled Quantity Textbox inserted incorrect format";
                    notify.ShowDialog();
                    return;
                }

                //SUCCESS CASE: la mot so va <= storage quantity
                if (Convert.ToInt32(cancelledTxb.Text) <= Convert.ToInt32(storageQuantityTbl.Text))
                {
                    confirmer.Text = "Do you sure to save change ?";
                    confirmer.ShowDialog();

                    if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
                    {
                        notify.Text = "Change success !!";
                        notify.ShowDialog();
                        cancelledTxb.Text = "";
                        this.Hide();
                    }
                }
                else
                {
                    notify.Text = "Cancelled Quantity is larger than Storage Quantity";
                    notify.ShowDialog();
                    return;
                }
            }
            else
            {
                notify.Text = "Please fill all the insert boxes";
                notify.ShowDialog();
            }
        }

        private void cancelledTxb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //only allows number (above QWERTY and right-side numberpad and del,backspace,tab key)
            e.Handled = !InputTester.IsNumberKey(e.Key) && !InputTester.IsDelOrBackspaceOrTabKey(e.Key);
        }

    }
}
