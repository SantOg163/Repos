using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp
{
    internal class Emp
    {
        static void Main(string[] args)
        {
            object emp = new Manager();
            GivePromotion((Manager)emp);
            object[] mass = new object[4];
            mass[0] = new Hexagon();
            mass[1] = new Hexagon();
            mass[2] = null;
            mass[3] = "str";
            foreach(object i in mass)
            {
                Hexagon h = i as Hexagon;
                if (h == null)
                    Console.WriteLine("h");  
                else
                    h.Draw();
            }
            Console.ReadKey();
        }
        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} was promoted!", emp.Name);
            switch (emp)
            { 
                case SalesPerson s:
                    Console.WriteLine($"name: {emp.Name} sales: {s.SalesNumber}");
                    break;
                case Manager m:
                    Console.WriteLine($"name: {emp.Name} options: {m.StockOptions}");
                    break;

            }
        }
        class Hexagon : Object
        {
            public void Draw()
            { Console.WriteLine("Drawing a Hexagon"); }
        }
    }
}
