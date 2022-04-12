using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCommands.cmds
{
    public class RelayCommand :CommandBase
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExexute;
        public RelayCommand() { }
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExexute) 
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExexute = canExexute;
        }
        public override bool CanExecute(object parameter) => _canExexute == null || _canExexute();
        public override void Execute(object parameter) { _execute(); }
    }
}
