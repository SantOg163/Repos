using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    internal class Auto
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Name = "Lambo";
            car.Color = "Yellow";
            car.Speed = 300;
            car.Display();
            Garage garage = new Garage();
            garage.MyAuto = car;
            Console.WriteLine("Кол-во машин: "+garage.NumberOfCars);
            Console.WriteLine(garage.MyAuto.Name);
            Console.ReadKey();
        }
    }
}
