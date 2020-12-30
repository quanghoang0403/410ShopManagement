using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TransactionHistoryWindow.xaml
    /// </summary>
    public partial class TransactionHistoryWindow : Window
    {
        List<ListviewFormatHistory> histories = new List<ListviewFormatHistory>();
        bool isHistoryLvSorted = false;
        CollectionView collectionView;

        //Windows
        _401UC.iNotifier notify = new _401UC.iNotifier();
        BillDetailWindow billDetailWnd = new BillDetailWindow();

        public TransactionHistoryWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            historyLv.SelectionChanged += HistoryLv_SelectionChanged;
        }

        class ListviewFormatHistory
        {
            public int IdBill { get; set; }
            public string NameOfStaff { get; set; }
            public string Date { get; set; }
            public int TotalBill { get; set; }
        }

        public void OnOpen()
        {
            datePkr.Text = DateTime.Now.ToShortDateString();
            histories.Clear();

            foreach (Bill bill in DataField.Instance.bills)
            {
                //get staff name
                string staffName = "";
                foreach (Staff staff in DataField.Instance.staffs)
                {
                    if (bill.idStaff == staff.idStaff)
                    {
                        staffName = staff.nameStaff;
                    }
                }
                histories.Add(new ListviewFormatHistory()
                {
                    IdBill = bill.idBill,
                    NameOfStaff = staffName,
                    Date = bill.exportDate,
                    TotalBill = bill.totalBill
                });
            }
            historyLv.ItemsSource = histories;
            CollectionViewSource.GetDefaultView(historyLv.ItemsSource).Refresh();
            historyLv.SelectedValuePath = "IdBill";
            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(historyLv.ItemsSource);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Giu cai nay lai vi van dung
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            if (isHistoryLvSorted)
            {
                collectionView.SortDescriptions.Clear();
                collectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
            }
            else
            {
                collectionView.SortDescriptions.Clear();
                collectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }
            isHistoryLvSorted = !isHistoryLvSorted;
        }

        private void HistoryLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (historyLv.SelectedValue != null)
            {
                billDetailWnd.idBillTbl.Text = historyLv.SelectedValue.ToString();
                billDetailWnd.idBill = Convert.ToInt32(historyLv.SelectedValue);
                billDetailWnd.OnOpen();
                billDetailWnd.ShowDialog();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            histories.Clear();

            foreach (Bill bill in DataField.Instance.bills)
            {
                if (bill.exportDate == datePkr.Text)
                {
                    //get staff name
                    string staffName = "";
                    foreach (Staff staff in DataField.Instance.staffs)
                    {
                        if (bill.idStaff == staff.idStaff)
                        {
                            staffName = staff.nameStaff;
                        }
                    }
                    histories.Add(new ListviewFormatHistory()
                    {
                        IdBill = bill.idBill,
                        NameOfStaff = staffName,
                        Date = bill.exportDate,
                        TotalBill = bill.totalBill
                    });
                }
            }
            historyLv.ItemsSource = histories;
            CollectionViewSource.GetDefaultView(historyLv.ItemsSource).Refresh();
            historyLv.SelectedValuePath = "IdBill";
        }
    }
}
