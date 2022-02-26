using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedPrinting
{
    // Все методы класса Printer теперь безопасны к потокам
    [Synchronization]
    internal class Printer : ContextBoundObject
    {
        // Маркер блокировки
        private object ThreadLock = new object();
        public void PrintNumbers()
        {
            // Использовать маркер блокировки,
            lock(ThreadLock)
            {
                // Вывести информацию о потоке.
                Console.WriteLine("Имя потока: "+Thread.CurrentThread.Name);

                //вывести числа
                Console.WriteLine("Числа: ");
                for (int i = 0; i < 10; i++)
                {
                    // Приостановить поток на случайный период времени.
                    Random random = new Random();
                    Thread.Sleep(1000 * random.Next(5));
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }

        }
    }
}
