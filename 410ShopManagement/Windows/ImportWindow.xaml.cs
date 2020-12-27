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
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        CreateProductWindow createProductWnd = new CreateProductWindow();
        public ImportWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            importDateTbl.Text = DateTime.Now.ToShortDateString();
            //importDateTbl.Text = DateTime.Now.ToShortTimeString();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchProductNameTxb.Text != "" &&
                importQuantityTxb.Text != "")
            {
                if (!InputTester.IsANumber(importQuantityTxb.Text, 4))
                {
                    notify.Text = "Quantity Textbox inserted incorrect format";
                    notify.ShowDialog();
                    return;
                }

                _401UC.ImportUnit unit = new _401UC.ImportUnit();
                unit.Margin = new Thickness(15, 20, 15, 20);
                unit.productNameTbl.Text = searchProductNameTxb.Text;
                unit.productQuantityTbl.Text = importQuantityTxb.Text;
                unit.RemoveUnitBtn.Tag = reviewPanel.Children.Count.ToString();
                unit.RemoveUnitBtn.Click += WrapUnitCloseButton_Click;
                reviewPanel.Children.Add(unit);

                searchProductNameTxb.Text = "";
                importQuantityTxb.Text = "";
            }
            else
            {
                notify.Text = "Please fill all the insert boxes";
                notify.ShowDialog();
            }
        }

        private void WrapUnitCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Button unit = sender as Button;
            reviewPanel.Children.RemoveAt(Convert.ToInt32(unit.Tag));

            //1 bug if remove by tag
            //solution: review old codes of Student Management
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void CreateProductButton_Click(object sender, RoutedEventArgs e)
        {
            createProductWnd.ShowDialog();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
