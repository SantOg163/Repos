using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal class Emp
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("1111111111111111111111111111111111111111111111111111111111111111111111111111111",23,350000,17);

            emp.Display();
            emp.Name = "Alba";
            Console.WriteLine(emp.Name);
            Console.ReadKey();
        }
    }
}
