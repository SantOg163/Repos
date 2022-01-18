using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExpceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("SanT",76);
            myCar.Radio(true);
            myCar.Accelerate(300);
            Console.ReadKey();
        }
    }
}
