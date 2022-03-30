using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfNotifications.Models
{
    internal class Inventory : INotifyPropertyChanged
    {
        public bool IsChanged { get; set; }
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
