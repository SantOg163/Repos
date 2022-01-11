using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal class OverloadingAdd
    {
        static void Main(string[] args)
        {
            //вызов int Add
            Console.WriteLine(Add(10, 10));
            
            //вызов long Add
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));

            //вызов double Add
            Console.WriteLine(Add(4.5, 4.5));

            Console.ReadKey();
        }
        //Перегруженный метод Add
        static int Add(int x, int y)
        {return x + y;}
        static double Add(double x, double y)
        {return x + y; }
        static long Add(long x, long y)
        {return x + y;}
}
}
