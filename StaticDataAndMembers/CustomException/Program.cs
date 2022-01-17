using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("SanT",90);
            try
            {
                myCar.Accelerate(50);
            }
            catch (CarIsDeadExpection ex)
            { 
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErorTimeStamp);
                Console.WriteLine(ex.CauseOfError);
            }
            Console.ReadKey();
        }
    }
}
