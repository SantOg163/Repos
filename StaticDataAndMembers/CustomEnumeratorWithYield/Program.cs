using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            //вывод массива
            foreach (Car car in garage)
                Console.WriteLine(car.Name);
            //в обратном порядке
            foreach (Car car in garage.GetTheCars(true))
                Console.WriteLine(car.Name);
            Console.ReadKey();
        }
    }
}
