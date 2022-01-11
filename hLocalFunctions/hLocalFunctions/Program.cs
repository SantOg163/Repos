using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hLocalFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вызов int Add().
            Console.WriteLine(Add(10, 10));
            // Вызов long Add().
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));
            // Вызов double Add().
            Console.WriteLine(Add(4.3, 4.4));
            Console.ReadLine();
        }
        // Перегруженный метод Add().
        static int Add(int x, int y)
        {return x + y;}
        static int AddWrapper(int x, int y)
        {
            // Выполнить здесь проверку достоверности
            return Add();
            int Add()
            {
                return x + y;
            }
        }
        static double Add(double x, double y)
        {return x + y;}
        static long Add(long x, long y)
        {return x + y;}
    }
}
