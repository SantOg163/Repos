using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("SanT",300,5);
            myAutos[1] = new Car("Alba", 250, 2);
            myAutos[2] = new Car("IRAKES", 200, 3);
            myAutos[3] = new Car("RZA", 600, 4);
            myAutos[4] = new Car("Shaq", 300, 1);
            Array.Sort(myAutos, new PetNameComparer());
            foreach(Car c in myAutos)
                Console.WriteLine(c.CarID+" - "+c.Name);
            Console.ReadKey();
        }
    }
}
