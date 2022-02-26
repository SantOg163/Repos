using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWithThreads
{
    internal class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("ID потока Main(): " + Thread.CurrentThread.ManagedThreadId);

            // Создать объект AddParams для передачи вторичному потоку.
            AddParams ap = new AddParams(10, 10);
            Thread add = new Thread(new ParameterizedThreadStart(Add));
            add.Start(ap);
            // Ожидать, пока не поступит уведомление!
            waitHandle.WaitOne(); 
            Console.WriteLine("Поток Add завершен");

            Console.ReadKey();
        }
        public static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID потока AddParams: " + Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine($"{ap.a} + {ap.b} = {ap.a + ap.b}");

                // Сообщить другому потоку о том, что работа завершена.
                waitHandle.Set();
            }
        }
    }
    class AddParams
    {
        public int a, b;
        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }
}
