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

namespace RenderingWithShapes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private enum SelectedShape
        { Circle, Rectangle, Line }
        private SelectedShape _currentShape;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void circleOption_Click(object sender, RoutedEventArgs e)
        {
            _currentShape = SelectedShape.Circle;
        }

        private void rectOption_Click(object sender, RoutedEventArgs e)
        {
            _currentShape = SelectedShape.Rectangle;
        }

        private void lineOption_Click(object sender, RoutedEventArgs e)
        {
            _currentShape= SelectedShape.Line;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shapeToRender = null;
            // Сконфигурировать корректную фигуру для рисования.
            switch (_currentShape)
            {
                case SelectedShape.Circle:
                    shapeToRender = new Ellipse() { Fill = Brushes.MediumPurple, Height = 35, Width = 35 };
                    RadialGradientBrush brush = new RadialGradientBrush();
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF9A69C2"), 1));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("White"), 0.347));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF714D8F"), 0.201));
                    shapeToRender.Fill = brush;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.MediumPurple, Height = 35, Width = 35 };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line()
                    {
                        Stroke = Brushes.MediumPurple,
                        StrokeThickness = 10,
                        X1 = 0,
                        Y1 = 0,
                        X2 = 50,
                        Y2 = 50,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    break;
                default:
                    return;
            }
            Canvas.SetLeft(shapeToRender, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(canvasDrawingArea).Y);
            //нарисовать фигуру
            canvasDrawingArea.Children.Add(shapeToRender);
        }

        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Сначала получить координаты X,Y позиции, где пользователь выполнил щелчок.
            Point pt = e.GetPosition((Canvas)sender);
            // Использовать метод HitTestO класса VisualTreeHelper, чтобы выяснить, щелкнул ли пользователь на элементе внутри Canvas.
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);
            // Если переменная result не равна null, то щелчок произведен на фигуре,
            if(result != null)
                canvasDrawingArea.Children.Remove(result.VisualHit as Shape); // Если переменная result не равна null, то щелчок произведен на фигуре,
        }

        private void flipCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (flipCanvas.IsChecked == true)
            {
                RotateTransform rotate = new RotateTransform(-180);
                canvasDrawingArea.LayoutTransform = rotate;
            }
            else
                canvasDrawingArea.LayoutTransform = null;
        }

        private void flipCanvas_Checked(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
