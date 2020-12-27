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
    /// Interaction logic for BillDetailWindow.xaml
    /// </summary>
    public partial class BillDetailWindow : Window
    {
        List<TempBill> bills;

        public BillDetailWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.5;

            bills = new List<TempBill>();
            bills.Add(new TempBill()
            {
                Name = "LKP",
                Value = 10,
                Quantity = 1
            });
            bills.Add(new TempBill()
            {
                Name = "PKL",
                Value = 9,
                Quantity = 2
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            bills.Add(new TempBill()
            {
                Name = "KLP",
                Value = 11,
                Quantity = 9
            });
            billLv.ItemsSource = bills;
            billLv.SelectedValuePath = "Name";
        }

        class TempBill
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public int Quantity { get; set; }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
