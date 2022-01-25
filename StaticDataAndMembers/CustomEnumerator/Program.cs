using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вручную работать с IEnumerator.

            Garage carLot = new Garage();

            foreach(Car car in carLot)
                Console.WriteLine(car.Name+"-"+car.CurrentSpeed);
            Console.ReadKey();
        }
    }
}
