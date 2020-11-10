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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace _410ShopManagement._401UC
{
    /// <summary>
    /// Interaction logic for MenuViewItem.xaml
    /// </summary>
    public partial class MenuViewItem : UserControl
    {
        public MenuViewItem()
        {
            InitializeComponent();
        }

        public PackIconKind IconKind
        {
            get { return icon.Kind; }
            set { icon.Kind = value; }
        }

        public string Text
        {
            get { return text.Text; }
            set { text.Text = value; }
        }
    }
}
