
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
            Employee.BenefitPackage.BenefictPackLevel packLevel = Employee.BenefitPackage.BenefictPackLevel.Platinum;
            Manager manager = new Manager();
            manager.GiveBonus(10000);
            manager.Display();
            Console.ReadKey();
        }
    }
}
