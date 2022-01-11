
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    internal class Add
    {
static void Main(string[] args)
        {
            // Передать две переменные по значению,
            int х = 9;
            int у = 10;
            Console.WriteLine("Before call: X: {0}, Y: {1}", х, у);
            Console.WriteLine("Answer is: {0}", Аdd(х, у)) ;
            Console.WriteLine("After call: X: {0}, Y: {1}", х, у);
            Console.ReadLine();

        }
        //По умолчанию аргументы передаются по значению,
        static int Аdd(int x, int y)
        {
            int ans = x + y;
            // Вызывающий код не увидит эти изменения,
            // т.к. модифицируется копия исходных данных,
            x = 10000;
            y = 88888;
            return ans;
        }
    }
}
