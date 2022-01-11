using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        
        // Методы
        public void GiveBonus(float amount)
        { currPay += amount; }
        public void Display()
        {
            Console.WriteLine("Имя: " + EmpName);
            Console.WriteLine("ID: " + EmpID);
            Console.WriteLine("Выплата:" + currPay);
            Console.WriteLine("Возрат: " + EmpAge);
        }
        // Свойства
        public string Name
        {
            get { return EmpName; }
            set
            {
                if (value.Length <= 15)
                    EmpName = value;
                else
                    Console.WriteLine("Ошибка длина больше 15");
            }
        }
        public int ID
        {
            get => EmpID;
            set => EmpID = value;
        }
        public float Pay
        {
            get => currPay;
            set => currPay = value;
        }
        public int Age
        {
            get => EmpAge;
            set => EmpAge = value;
        }
        public string SocialSecurityNumber
        {
            get => empSSN;
        }
        
    }
}
