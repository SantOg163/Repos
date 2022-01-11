using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMathClass my = new MyMathClass();
            Console.WriteLine(MyMathClass.PI);
            Console.ReadKey();
        }
        class MyMathClass
        {
            public static readonly double PI;
            static MyMathClass()
            {
                PI=16;
            }
        }
    }
}
