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
using System.Windows.Media.Animation;

namespace SpinningButtonAnimationApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isSpinning = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!_isSpinning)
            {
                Random rnd = new Random();
                _isSpinning = true;
                // Создать объект DoubleAnimation и зарегистрировать его с событием Completed.
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => _isSpinning = false;
                // Установить начальное и конечное значения.
                dblAnim.From = 0;
                dblAnim.To = 360;
                //На завершение поворота кнопке отводится четыре секунды.
                dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));
                // Создать объект RotateTransform и присвоить его свойству RenderTransform кнопки.
                RotateTransform rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;
                // Выполнить анимацию объекта RotateTransform.
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }

        private void btnSpinner_OnClick(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0
            };
            // После завершения запустить в обратном порядке
            dblAnim.AutoReverse = true;
            btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
        }
    }
}
