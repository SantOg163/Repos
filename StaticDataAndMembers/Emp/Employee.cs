using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp
{
    abstract partial class Employee
    {
        
        // Методы
        public virtual void GiveBonus(float amount)
        { CurrPay += amount; }
        public virtual void Display()
        {
            Console.WriteLine("Имя: " + EmpName);
            Console.WriteLine("ID: " + EmpID);
            Console.WriteLine("Выплата:" + CurrPay);
            Console.WriteLine("Возрат: " + EmpAge);
            Console.WriteLine("SSN: "+empSSN);
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
        public double GetBenefictConst
        {
            get => empBenefits.ComputePayDeduction();
        }
        public BenefitPackage Benefits
        { get => empBenefits;  set => empBenefits = value; }
        public int ID
        {
            get => EmpID;
            set => EmpID = value;
        }
        public float Pay
        {
            get => CurrPay;
            set => CurrPay = value;
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

        internal class BenefitPackage
        {
            // Предположим, что есть другие члены, представляющие
            // медицинские/стоматологические программы и т.д.
            public double ComputePayDeduction()
            {
                return 125.0;
            }
            public enum BenefictPackLevel
            { Standart, Gold, Platinum}
        }

    }
}
