using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp
{
    // Менеджерам нужно знать количество их фондовых опционов,
    internal class Manager  : Employee
    {
        public Manager() { }
        public int StockOptions { get; set; }
        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numbOfOpts)
        : base(fullName, age, empID, currPay, ssn)
        {
            // Это свойство определено в классе Manager.
            StockOptions = numbOfOpts;
        }
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Кол-во опционов"+StockOptions);
        }
    }
}
