using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Car
    {
        // Автоматические свойства! Нет нужды определять поддерживающие поля,
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        // Свойство только для чтения - Допустимо! (только set недопустимо)
        public int MyReadOnlyProp { get; }

        public Car() { }
        public Car(string name, int speed, string color)
        {
            Name = name;
            Speed = speed;
            Color = color;
        }

        public void Display()
        {
            Console.WriteLine("Название: "+ Name);
            Console.WriteLine("Скорость: " + Speed);
            Console.WriteLine("Цвет: " + Color);
        }
    }
}
