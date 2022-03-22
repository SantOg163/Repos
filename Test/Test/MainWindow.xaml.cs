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

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_OnClosed;
            this.Closing += MainWindow_Closing;
            this.MouseMove += MainWindow_MouseMove;
        }
        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ClickMe.Content = e.Key.ToString();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }
        private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Указал ли пользователь /godmode?
            if ((bool)Application.Current.Properties["GodMode"])
                MessageBox.Show("Cheater!");
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Выяснить, на самом ли деле пользователь хочет закрыть окно.
            MessageBoxResult result = MessageBox.Show("Хотите закрыть окно без сохранения?", "MyApp", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            // Если пользователю не желает закрывать окно, то отменить закрытие.
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            MessageBox.Show("see ya");
        }
    }
}
