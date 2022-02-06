using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOverCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>()
            {
                new Car { petName = "Henry", Color = "Silver ", Speed = 100, Make = "BMW" },
                new Car { petName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { petName = "Mary", Color = " Black", Speed = 55 , Make = "VW"},
                new Car { petName = "Clunker ", Color = "Rust ", Speed = 5, Make = "Yugo" },
                new Car { petName = "Melvin" , Color = "White ", Speed = 43, Make = "Ford"}
            };
            GetFastCars(cars);
            Console.ReadKey();
        }
        static void GetFastCars(List<Car> cars)
        {
            // Найти в Listo все объекты Car, у которых значение Speed больше 55.
            var fastCars = from c in cars where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{ 0} is going too fast", car.petName);
            }


        }
    }
}
