using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    internal class Program<T>
    {
        static void Main(string[] args)
        {
        }
        public static void TraditionalDelegateSyntax()
        {
            // Создать список целочисленных значении.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Теперь использовать лямбда-выражение С#.
            List<int> evenNumbers = list.FindAll(i => i % 2 == 0);

            // Вывести четные числа.
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }
}
