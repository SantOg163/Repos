using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    internal class Car
    {
        public string Name;
        public int Speed;
        public Car()
        {
            Name = "Sam";
            Speed = 120;
        }
        // Здесь currSpeed получает стандартное значение для типа int (0) .
        public Car(string pn)
        {
            Name = pn;
            // Позволяет вызывающему коду установить полное состояние объекта Саг.
        }
        public Car(string pn, int cs)
        {
            Name = pn;
            Speed = cs;
        }
        public void PrintState() => Console.WriteLine($"{Name} едет со скоростью: {Speed} км/ч");
        public void SpeedUp(int delta) => Speed += delta;
    }
    class Motorcycle
    {
        public int driverlntensity;
        public string Name;
        public void SetDriverName(string name)
        {
            Name = name;
        }
        public void PopAWheely()
        {
            for (int i = 0; i <= driverlntensity; i++)
                Console.WriteLine("Yeeeeeee Haaaaaeewww! ");
        }
        // Вернуть стандартный конструктор, который будет
        // устанавливать все члены данных в стандартные значения,
        // Связывание конструкторов в цепочку.
        public Motorcycle() 
        { 
            Console.WriteLine("Внутри стандартного конструктора");
        }
        public Motorcycle(int intensity)
        : this(intensity, "") 
        {
            Console.WriteLine("Внутри конструктора , принимающего int");
        }
        public Motorcycle(string name)
        : this(0, name) 
        {
            Console.WriteLine("Внутри конструктора , принимающего string");
        }
        // Это 'главный' конструктор, выполняющий всю реальную работу,
        public Motorcycle(int intensity=0, string name="")
        {
            Console.WriteLine("Внутри главного конструктора");
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverlntensity = intensity;
            Name = name;
        }
        static void MakeSomeBikes()
        {
            // driverName = driverlntensity = 0
            Motorcycle ml = new Motorcycle();
            Console.WriteLine("Name= {0}, Intensity= {1}",
            ml.Name, ml.driverlntensity);
            // driverName = ’’Tiny", driverlntensity = 0
            Motorcycle m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name= {0}, Intensity= {1}",
            m2.Name, m2.driverlntensity);
            // driverName = driverlntensity = 7
            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine("Name= {0}, Intensity^ {1}",
            m3.Name, m3.driverlntensity);
        }
    }
}

