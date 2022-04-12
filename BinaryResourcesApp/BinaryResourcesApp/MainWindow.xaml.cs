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

namespace BinaryResourcesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BitmapImage> _images = new List<BitmapImage>();
        public int _currentImage;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                //// Загрузить эти изображения во время загрузки окна.
                //_images.Add(new BitmapImage(new Uri($@"{path}\Images\Deer.jpg")));
                //_images.Add(new BitmapImage(new Uri($@"{path}\Images\Dogs.jpg")));
                //_images.Add(new BitmapImage(new Uri($@"{path}\Images\Welcome.jpg")));

                _images.Add(new BitmapImage(new Uri(@"/Images/Deer.jpg", UriKind.Relative)));
                _images.Add(new BitmapImage(new Uri(@"/Images/Dogs.jpg", UriKind.Relative)));
                _images.Add(new BitmapImage(new Uri(@"/Images/Welcome.jpg", UriKind.Relative)));
                // Показать первое изображение в списке.
                ImageHolder.Source = _images[_currentImage];
                MessageBox.Show(ImageHolder.Source.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if(--_currentImage<0)
                _currentImage = _images.Count - 1;
            ImageHolder.Source = _images[_currentImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (++_currentImage >= _images.Count)
                _currentImage = 0;
            ImageHolder.Source = _images[_currentImage];
        }
    }
}
