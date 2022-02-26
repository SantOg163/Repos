using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDelegate
{
    internal class Program
    {
        public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() во вторичном потоке.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult a = b.BeginInvoke(10, 20, null, null);

            // Это сообщение продолжит выводиться до тех пор, пока не будет завершен метод Add() .
            while (!a.AsyncWaitHandle.WaitOne(1000,true))
            {
                Console.WriteLine("Doing more work in Main()!");
            }

            // По готовности получить результат выполнения метода Add().
            int answer = b.EndInvoke(a);
            Console.WriteLine("10 + 20 = " + answer);
            Console.ReadKey();

        }
        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Add () invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
