using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfViewModel.Models;
using System.Windows.Input;

namespace WpfViewModel.cmds
{
    public class ChangeColorCommand : CommandBase
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public override bool CanExecute(object parameter) => (parameter as Inventory) != null;

        public override void Execute(object parameter) => ((Inventory)parameter).Color = "Pink";
    }
}
