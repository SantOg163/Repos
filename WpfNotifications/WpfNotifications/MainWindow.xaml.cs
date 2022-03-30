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
using WpfNotifications.Models;
using System.Collections.ObjectModel;

namespace WpfNotifications
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IList<Inventory> _cars = new ObservableCollection<Inventory>();
        public MainWindow()
        {
            InitializeComponent();
            _cars.Add(new Inventory { CarId = 1, Make = "Chevy", Color = "Blue", PetName = "Kit", IsChanged = false });
            _cars.Add(new Inventory { CarId = 2, Make = "Ford", Color = "Red", PetName = "Red Rider" });
            cboCars.ItemsSource = _cars;
        }
        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var maxCount = _cars?.Max(x => x.CarId) ?? 0;
            _cars.Add(new Inventory { CarId = ++maxCount, Color = "White", Make = "Ferrari", PetName = "Spider", IsChanged = false });
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            _cars.First(x => x.CarId == ((Inventory)cboCars.SelectedItem)?.CarId).Color = "Pink";
        }
    }
}
