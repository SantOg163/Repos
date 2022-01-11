using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s1 = new SavingsAccount(50);
            Console.WriteLine("Процентная ставка: "+SavingsAccount.GetInterestRate());
            SavingsAccount.SetInterestRate(0.08);
            SavingsAccount s2 = new SavingsAccount(100);
            Console.WriteLine("Процентная ставка: "+SavingsAccount.GetInterestRate());
            Console.ReadKey();
        }
    }
}
