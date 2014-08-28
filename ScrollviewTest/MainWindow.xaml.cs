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

using System.Windows.Threading;



namespace ScrollviewTest
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = null;
        private int size = 0;
        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int speed = Convert.ToInt32(combox_speed.Text);
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + speed);
            size += speed;
            if (size == 1280)
            {
                dispatcherTimer.Stop();
                size = 0;
            }
               
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Image Img = new Image();
            BitmapImage BitImg = new BitmapImage(new Uri("C:\\Sample Pictures\\bear.jpg"));
            Img.Source = BitImg;

            sp_images.Children.Add(Img);
        }
    }
}
