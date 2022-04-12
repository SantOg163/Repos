using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfViewModel.cmds;
using WpfViewModel.Models;


namespace WpfViewModel.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Inventory> Cars = new List<Inventory>();
        public MainWindowViewModel()
        {
            Cars.Add(new Inventory { CarId = 1, Color = "Blue", Make = "Chevy", PetName = "Kit", IsChanged = false});
            Cars.Add(new Inventory { CarId = 2, Color = "Red", Make = "Ford", PetName = "Red Rider", IsChanged = false });
        }
        private ICommand __changeColorCommand = null;
        public ICommand ChangeColorCmd => __changeColorCommand ?? (__changeColorCommand = new ChangeColorCommand());

        public ICommand __addCarCommand = null;
        public ICommand AddCarCmd => __addCarCommand ?? (__addCarCommand = new AddCarCommand());
        private RelayCommandT<Inventory> __deleteCarCommand = null;
        public RelayCommandT<Inventory> DeleteCarCmd => __deleteCarCommand ?? (__deleteCarCommand = new RelayCommandT<Inventory>(DeleteCar, CanDeleteCar));
        private bool CanDeleteCar(Inventory car) => car != null;
        private void DeleteCar(Inventory car) => Cars.Remove(car);
    }
}
