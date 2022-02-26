using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Использовать 1 или 2 потока?");
            string threadCount = Console.ReadLine();

            // Назначить имя текущему потоку.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Вывести информацию о потоке.
            Console.WriteLine("Имя потока: " + primaryThread.Name);

            // Создать рабочий класс.
            Printer printer = new Printer();
            switch(threadCount)
            {
                case "1":
                    printer.PrintNumbers();
                    break;
                case "2":
                    // Создать поток.
                    Thread backGroundThread = new Thread(new ThreadStart(printer.PrintNumbers));
                    backGroundThread.Name = "Secondary";
                    backGroundThread.Start();
                    break;
                default:
                    Console.WriteLine("Неподходязий вариант (переход к 1)");
                    goto case "1";
            }
            // Выполнить некоторую дополнительную работу.
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }
    }
}
