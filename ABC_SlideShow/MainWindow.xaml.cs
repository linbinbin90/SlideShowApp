using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Threading.Tasks;
using System.Threading;
using WpfPageTransitions;
using System.IO;

namespace WpfPageTransitionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<UserControl> pages = new Stack<UserControl>();
        int index = 0;
        String[] imagesPath = {"C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg","C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg"};
        public MainWindow()
        {
            InitializeComponent();

            cmbTransitionTypes.ItemsSource = Enum.GetNames(typeof(PageTransitionType));
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            index = (index + 1) % 2;
            String path = imagesPath[index];

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 280;

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(path);
            myBitmapImage.DecodePixelWidth = 280;
            myBitmapImage.EndInit();

            NewPage newPage = new NewPage(myBitmapImage);

            pageTransitionControl.ShowPage(newPage);
        }

        private void cmbTransitionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageTransitionControl.TransitionType = (PageTransitionType)Enum.Parse(typeof(PageTransitionType), cmbTransitionTypes.SelectedItem.ToString(), true);
        }

        

       
    }

}
