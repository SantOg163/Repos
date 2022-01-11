using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp
{
    partial class Employee
    {
        // Поля данных.

        // Производные классы теперь могут иметь прямой доступ к этой информации.
        protected string EmpName;
        protected int EmpAge;
        protected readonly string empSSN;
        protected int EmpID;
        protected float CurrPay;
        protected int CurrPayID;
        protected BenefitPackage empBenefits = new BenefitPackage();
        // Конструкторы
        public Employee() { }
        public Employee(string name, int age, int id, float pay)
        {
            if (name.Length <= 15)
                EmpName = name;
            else
                Console.WriteLine("Ошибка больше 15 символов");
            EmpAge = age;
            EmpID = id;
            CurrPay = pay;
        }
        public Employee(string name, int age, int id, float pay, string ssn)
        : this(name, age, id, pay)
        {
            empSSN = ssn;
        }
    }
}
