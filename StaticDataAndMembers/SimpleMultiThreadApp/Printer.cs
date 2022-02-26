using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp
{
    internal class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("->Имя потока: " + Thread.CurrentThread.Name);
            Console.WriteLine("Вывод чисел: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + ", ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
