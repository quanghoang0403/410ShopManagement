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

namespace _410ShopManagement._401UC
{
    /// <summary>
    /// Interaction logic for iNotifierOKCancel.xaml
    /// </summary>
    public partial class iNotifierOKCancel : Window
    {
        public Result result = Result.Cancel;

        public iNotifierOKCancel()
        {
            InitializeComponent();
        }

        public enum Result { OK, Cancel }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            result = Result.Cancel;
            this.Hide();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            result = Result.OK;
            this.Hide();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            result = Result.Cancel;
            this.Hide();
        }

        public string Text
        {
            get { return textTbl.Text; }
            set { textTbl.Text = value; }
        }

        private void OKBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            OKBdr.Background = Brushes.LightGreen;
        }

        private void OKBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            OKBdr.Background = Brushes.LightBlue;
        }

        private void CancelBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            CancelBdr.Background = Brushes.OrangeRed;
        }

        private void CancelBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            CancelBdr.Background = Brushes.LightBlue;
        }
    }
}
