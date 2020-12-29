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

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for BillDetailWindow.xaml
    /// </summary>
    public partial class BillDetailWindow : Window
    {
        public int idBill;
        List<ListviewFormatBillDetail> bills = new List<ListviewFormatBillDetail>();

        public BillDetailWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.5;

        }

        class ListviewFormatBillDetail
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public int Quantity { get; set; }
            public int Sum { get; set; }
        }

        public void OnOpen()
        {
            bills.Clear();
            totalTbl.Text = "0";
            foreach (BillDetail detail in DataField.Instance.billDetails)
            {
                if (idBill == detail.idBill)
                {
                    string nameProd = "";
                    foreach (Product prod in DataField.Instance.products)
                    {
                        if (detail.idProduct == prod.idProduct)
                        {
                            nameProd = prod.nameProduct;
                        }
                    }
                    bills.Add(new ListviewFormatBillDetail()
                    {
                        Name = nameProd,
                        Value = detail.priceProduct,
                        Quantity = detail.quantityProduct,
                        Sum = detail.totalPrice
                    });
                }
            }
            billLv.ItemsSource = bills;
            CollectionViewSource.GetDefaultView(billLv.ItemsSource).Refresh();
            billLv.SelectedValuePath = "Name";

            foreach (ListviewFormatBillDetail bill in bills)
            {
                totalTbl.Text = (Convert.ToInt32(totalTbl.Text) + bill.Sum).ToString();
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
