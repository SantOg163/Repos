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
using WpfCommands.Models;
using WpfCommands.cmds;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace WpfCommands
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
        private ICommand __changeColorCommand = null;
        public ICommand ChangeColorCmd => __changeColorCommand ?? (__changeColorCommand = new ChangeColorCommand());

        public ICommand __addCarCommand = null;
        public ICommand AddCarCmd => __addCarCommand ?? (__addCarCommand = new AddCarCommand());
        private RelayCommandT<Inventory> __deleteCarCommand = null;
        public RelayCommandT<Inventory> DeleteCarCmd => __deleteCarCommand?? (__deleteCarCommand = new RelayCommandT<Inventory>(DeleteCar, CanDeleteCar));
        private bool CanDeleteCar(Inventory car) => car != null;
        private void DeleteCar(Inventory car) => _cars.Remove(car);
    }
}
