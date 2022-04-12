using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCommands.Models;
using System.Collections.ObjectModel;

namespace WpfCommands.cmds
{
    internal class AddCarCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => parameter != null && parameter is ObservableCollection<Inventory>;
        public override void Execute(object parameter)
        {
            if(parameter is ObservableCollection<Inventory> cars)
            {
                var maxCount = cars?.Max(x => x.CarId) ?? 0;
                cars?.Add(new Inventory() { CarId = ++maxCount, Color = "White", Make = "Lambo", PetName = "Chief" });
            }
        }
    }
}
