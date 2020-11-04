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

namespace _410ShopManagement._401UC
{
    /// <summary>
    /// Interaction logic for CloseButton.xaml
    /// </summary>
    public partial class AppInteractButton : UserControl
    {
        public AppInteractButton()
        {
            InitializeComponent();
        }

        public MaterialDesignThemes.Wpf.PackIconKind Icon
        {
            get { return icon.Kind; }
            set { icon.Kind = value; }
        }

        //EventClick below will be defined by the owner form 
        public event RoutedEventHandler Click;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //If form defined Click event, we will use that Click event
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
