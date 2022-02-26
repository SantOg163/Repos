using System;
using System.Collections;
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
            OfTypeAsFilter();
            Console.ReadKey();
        }
        static void GetFastCars(List<Car> cars)
        {
            // Трансформировать ArrayList в тип, совместимый c IEnumerable<T>.
            var myCarsEnum = cars.OfType<Car>() ;
            // Создать выражение запроса, нацеленное на совместимый с IEnumerable<T> тип.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
                Console.WriteLine("{0} is going too fast", car.petName);
        }
        static void OfTypeAsFilter()
        {
            // Извлечь из ArrayList целочисленные значения.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var mylnts = myStuff.OfType<int>();
            // Выводит 10, 400 и 8.
            foreach (int i in mylnts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }
    }
}
