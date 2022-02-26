using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    internal class Program
    {
        static bool isDone = false;
        static void Main(string[] args)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Поток Main():{0}.", Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() во вторичном потоке.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult a = b.BeginInvoke(10, 20, new AsyncCallback(AddComplete), "Числа сложены");

            // Это сообщение продолжит выводиться до тех пор, пока не будет завершен метод Add() .
            while (!isDone)
            {
                Console.WriteLine("Действие в Main()!");
                Thread.Sleep(1000);
            }
            Console.ReadKey();

        }
        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine("Поток Add (): {0}.", Thread.CurrentThread.ManagedThreadId);
            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            isDone = true;
            return x + y;
        }
        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("Поток AddComplete(): {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Закончен");
            AsyncResult ar = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 20 = " + b.EndInvoke(iar));
            string msg = (string)ar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
