using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp
{
    // Продавцам нужно знать количество продаж,
    internal class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }
        public SalesPerson() { }
        public SalesPerson(string name, int age, int id, float pay, string ssn, int salesnumber)
            : base(name, age, id, pay, ssn)
        {
            SalesNumber = salesnumber;
        }
        public sealed override void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else if (SalesNumber >= 100 && SalesNumber <= 200)
                salesBonus = 15;
            else 
                salesBonus = 20;
            base.GiveBonus(salesBonus*amount);
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Кол-во продаж: "+SalesNumber);
        }
    }
}
