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

namespace _410ShopManagement
{
    /// <summary>
    /// Interaction logic for GallaryWindow.xaml
    /// </summary>
    public partial class GallaryWindow : Window
    {
        public ImageSource choosedSource;

        public GallaryWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width * 0.63;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height * 0.475;

            ImageBrush brush = new ImageBrush();
            brush = (ImageBrush)firstBtnExp.Background;

            choosedSource = brush.ImageSource;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            ImageBrush brush = new ImageBrush();
            brush = (ImageBrush)button.Background;

            choosedSource = brush.ImageSource;

            this.Hide();
        }
    }
}
