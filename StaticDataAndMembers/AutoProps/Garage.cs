using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Garage
    {
        // Скрытое поддерживающее поле int установлено в О!
        public int NumberOfCars { get; set; } = 1;
        // Скрытое поддерживающее поле Саг установлено в null!
        public Car MyAuto { get; set; } = new Car();
        // Для переопределения стандартных значений, присвоенных скрытым
        // поддерживающим полям, должны использоваться конструкторы,
        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
