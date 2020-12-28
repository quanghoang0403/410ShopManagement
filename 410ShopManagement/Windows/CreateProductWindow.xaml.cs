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
using _410ShopManagement.Classes;
using BLL;
using Microsoft.Win32;

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        double salePercent;
        bool choosedImage = false;

        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        _401UC.iNotifierOKCancel confirmer = new _401UC.iNotifierOKCancel();
        GallaryWindow gallaryWnd = new GallaryWindow();

        public CreateProductWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            if (saleTxb.Text == "")
            {
                salePercent = 0;
            }

            findImageBtn.Visibility = Visibility.Visible;
            productImg.Visibility = Visibility.Hidden;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
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
            findImageBtn.Visibility = Visibility.Visible;
            productImg.Visibility = Visibility.Hidden;
            this.Hide();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productBasePriceTbl.Text != "" &&
                productPriceTxb.Text != "" &&
                saleTxb.Text != "" &&
                productNameTxb.Text != "" &&
                materialTxb.Text != "" &&
                originalTxb.Text != "" &&
                categoryTxb.Text != "" &&
                sexTxb.Text != "" &&
                sizeTxb.Text != "" &&
                colorTxb.Text != "" &&
                descriptionTxb.Text != "" &&
                choosedImage)
            {
                confirmer.Text = "Do you sure to create this product ?";
                confirmer.ShowDialog();

                if (confirmer.result == _401UC.iNotifierOKCancel.Result.OK)
                {
                    DataField.Instance.products.Add(new Product()
                    {
                        idProduct = DataField.Instance.products.Count,
                        nameProduct = productNameTxb.Text,
                        imagePath = productImg.Source.ToString().Substring(22), //only get from index 22
                        importPrice = Convert.ToInt32(productBasePriceTbl.Text),
                        exportPrice = Convert.ToInt32(productPriceTxb.Text),
                        saleOffset = Convert.ToInt32(saleTxb.Text),
                        material = materialTxb.Text,
                        origin = originalTxb.Text,
                        category = categoryTxb.Text,
                        sex = sexTxb.Text,
                        size = sizeTxb.Text,
                        color = colorTxb.Text,
                        description = descriptionTxb.Text,
                        storageQuantity = 0,
                        soldQuantity = 0,
                        cancelQuantity = 0
                    });

                    notify.Text = "Create success !!";
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
                    findImageBtn.Visibility = Visibility.Visible;
                    productImg.Visibility = Visibility.Hidden;
                    this.Hide();
                }
            }
            else
            {
                if (!choosedImage)
                {
                    notify.Text = "Please choose an image";
                    notify.ShowDialog();
                }
                else
                {
                    notify.Text = "Please fill all the insert boxes";
                    notify.ShowDialog();
                }
            }
        }

        private void findImageBtn_Click(object sender, RoutedEventArgs e)
        {
            gallaryWnd.ShowDialog();

            findImageBtn.Visibility = Visibility.Hidden;
            productImg.Visibility = Visibility.Visible;

            if (gallaryWnd.choosedSource != null)
            {
                productImg.Source = gallaryWnd.choosedSource;
                choosedImage = true;
            }
        }

        private void saleTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productBasePriceTbl.Text == "") return;

            double basePrice = Convert.ToDouble(productBasePriceTbl.Text);

            if (saleTxb.Text == "")
            {
                salePercent = 0;
            }
            else
            {
                salePercent = Convert.ToDouble(saleTxb.Text) / 100;
            }

            productPriceTxb.Text = (Convert.ToInt32(basePrice - basePrice * salePercent)).ToString();
        }

        private void NumberTxb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //only allows number (above QWERTY and right-side numberpad and del,backspace,tab key)
            e.Handled = !InputTester.IsNumberKey(e.Key) && !InputTester.IsDelOrBackspaceOrTabKey(e.Key);
        }

        private void productBasePriceTbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productBasePriceTbl.Text == "") return;

            double basePrice = Convert.ToDouble(productBasePriceTbl.Text);

            productPriceTxb.Text = (Convert.ToInt32(basePrice - basePrice * salePercent)).ToString();
        }
    }
}
