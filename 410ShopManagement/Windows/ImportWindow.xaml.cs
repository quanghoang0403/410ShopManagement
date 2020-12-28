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
        _401UC.iNotifier notify = new _401UC.iNotifier();
        public List<string> comboboxChild;

        //Windows
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();
        CreateProductWindow createProductWnd = new CreateProductWindow();
        public ImportWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            importDateTbl.Text = DateTime.Now.ToShortDateString();
            //importDateTbl.Text = DateTime.Now.ToShortTimeString();

            comboboxChild = new List<string>()
            { "Fernweh White Jacket", "Fernweh Black Jacket", "Cumeo Black Ring"};
            searchProductNameTxb.ItemsSource = comboboxChild;

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
                unit.productPriceTbl.Text = importQuantityTxb.Text;
                unit.border.ToolTip = (Convert.ToInt32(unit.productQuantityTbl.Text) * Convert.ToInt32(unit.productPriceTbl.Text));
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
            int index = Convert.ToInt32(unit.Tag);
            reviewPanel.Children.RemoveAt(index);

            foreach (UIElement child in reviewPanel.Children)
            {
                _401UC.ImportUnit importUnit = child as _401UC.ImportUnit;
                //tag++ per add. Insert 1, 2, 3, 4,...
                //if remove a child with tag not at the end (exp: 2)
                //Children: 1, 3, 4,...
                //the child with tag 3 will -1 to tag 2 to correct the index
                if (Convert.ToInt32(importUnit.RemoveUnitBtn.Tag) > index)
                {
                    importUnit.RemoveUnitBtn.Tag = (Convert.ToInt32(importUnit.RemoveUnitBtn.Tag) - 1).ToString();
                }
            }
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
            confirmer.Text = "Import products confirm";
            confirmer.ShowDialog();

            if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
            {
                notify.Text = "Import success !!";
                notify.ShowDialog();

                searchProductNameTxb.Text = "";
                importQuantityTxb.Text = "";
                reviewPanel.Children.RemoveRange(0, reviewPanel.Children.Count);

                this.Hide();
            }
        }

        private void importQuantityTxb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //only allows number (above QWERTY and right-side numberpad and del,backspace,tab key)
            e.Handled = !InputTester.IsNumberKey(e.Key) && !InputTester.IsDelOrBackspaceOrTabKey(e.Key);
        }
    }
}
