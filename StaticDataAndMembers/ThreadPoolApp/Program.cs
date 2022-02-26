using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            
            // Поставить в очередь метод десять раз.
            for(int i = 0; i < 10; i++)
                ThreadPool.QueueUserWorkItem(workItem, printer);
            Console.ReadKey();
        }
        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
