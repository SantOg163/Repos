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

namespace WpfStyles
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstStyles.Items.Add("PurpleButton");
            lstStyles.Items.Add("Bpurple");
            lstStyles.Items.Add("GrowingButtonStyle"); 
            lstStyles.Items.Add("BasicControlStyle");

        }

        private void comboStyles_Changed(object sender, SelectionChangedEventArgs e)
        {
            // Получить имя стиля, выбранное в окне со списком.
            var currentStyle = (Style)TryFindResource(lstStyles.SelectedItem);
            if (currentStyle == null)
                return;
            // Установить стиль для типа кнопки.
            btnStyle.Style = currentStyle;
        }
    }
}
