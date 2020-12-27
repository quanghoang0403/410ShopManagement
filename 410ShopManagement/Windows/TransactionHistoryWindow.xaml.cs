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
using BLL;

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for TransactionHistoryWindow.xaml
    /// </summary>
    public partial class TransactionHistoryWindow : Window
    {
        _401UC.iNotifier notify = new _401UC.iNotifier();
        BillDetailWindow billDetailWnd = new BillDetailWindow();

        List<TempHistory> histories;
        bool isHistoryLvSorted = false;
        CollectionView collectionView;
        string savedIdBill;

        public TransactionHistoryWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            datePkr.Text = DateTime.Now.ToShortDateString();

            histories = new List<TempHistory>();
            histories.Add(new TempHistory()
            {
                Order = histories.Count,
                idBill = 1, 
                NameOfStaff = "Van A",
                Date = "90",
                totalBill = 99
            }); 
            histories.Add(new TempHistory()
            {
                Order = histories.Count,
                idBill = 2,
                NameOfStaff = "QWE",
                Date = "84",
                totalBill = 11
            });
            histories.Add(new TempHistory()
            {
                Order = histories.Count,
                idBill = 152,
                NameOfStaff = "asdasdasdas",
                Date = "asdasdasdasdsad",
                totalBill = 67
            });
            historyLv.ItemsSource = histories;
            historyLv.SelectedValuePath = "idBill";
            historyLv.SelectionChanged += HistoryLv_SelectionChanged;
            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(historyLv.ItemsSource);
        }

        class TempHistory
        {
            public int Order { get; set; }
            public int idBill { get; set; }
            public string NameOfStaff { get; set; }
            public string Date { get; set; }
            public int totalBill { get; set; }
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
                savedIdBill = historyLv.SelectedValue.ToString();
                billDetailWnd.idBillTbl.Text = savedIdBill;
                billDetailWnd.ShowDialog();
            }
            else
                savedIdBill = "";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
