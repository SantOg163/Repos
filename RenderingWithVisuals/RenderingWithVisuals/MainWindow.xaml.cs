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

namespace RenderingWithVisuals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const int TextFontSize = 30;
            // Создать объект System.Windows.Media.FormattedText
            FormattedText text = new FormattedText("Hello Visual Layer!", new System.Globalization.CultureInfo("en-us"), FlowDirection.LeftToRight,
                new Typeface(this.FontFamily, FontStyles.Italic, FontWeights.DemiBold, FontStretches.UltraExpanded), TextFontSize, Brushes.Green,
                null, VisualTreeHelper.GetDpi(this).PixelsPerDip);
            // Создать объект System.Windows.Media.FormattedText
            DrawingVisual drawingVisual = new DrawingVisual();
            using(DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5), new Rect(5, 5, 450, 100), 20, 20);
            }
            // Динамически создать битовое изображение, используя данные в объекте DrawingVisual.
            RenderTargetBitmap bmp = new RenderTargetBitmap(1000, 100, 100, 90, PixelFormats.Pbgra32);

            bmp.Render(drawingVisual);
            // Установить источник для элемента управления Image.
            myImage.Source = bmp; 
        }
    }
}
