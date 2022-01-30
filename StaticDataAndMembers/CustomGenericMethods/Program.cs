using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 15;
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.ReadKey();
        }
    }
}
