using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basiclnheritance
{
    internal class CarProg
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(300);
            myCar.GetCurrSpeed = 150;
            Console.WriteLine(myCar.GetCurrSpeed+" "+myCar.MaxSpeed);
            Minivan myVan = new Minivan();
            myVan.GetCurrSpeed = 40;
            Console.WriteLine(myVan.GetCurrSpeed);
            Console.WriteLine(myCar.GetCurrSpeed);
            Console.ReadKey();
        }
    }
}
