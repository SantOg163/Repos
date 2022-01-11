using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        // Поля данных.
        private string EmpName;
        private int EmpAge;
        private string empSSN;
        private int EmpID;
        private float currPay;
        // Конструкторы
        public Employee() { }
        public Employee(string Name, int ID, float Pay, int Age)
        {
            if (Name.Length <= 15)
                EmpName = Name;
            else
                Console.WriteLine("Ошибка длина больше 15");
            EmpID = ID;
            currPay = Pay;
            EmpAge = Age;
        }
    }
}
