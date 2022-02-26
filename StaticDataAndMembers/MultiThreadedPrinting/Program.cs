using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedPrinting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            // Создать 10 потоков, которые указывают на один и тот же метод того же самого объекта.
            Thread[] threads = new Thread[10];
            for(int i = 0; i < threads.Length; i++)
                threads[i] = new Thread(new ThreadStart(printer.PrintNumbers)) 
                {Name = $"Поток {i}" };
            // Теперь запустить их все.
            foreach(Thread thread in threads)
                thread.Start();
            Console.ReadKey();
        }
    }
}
