using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    internal class Program
    {
        delegate void Del(string s, ConsoleColor color, int count);
        static void Main(string[] args)
        {
            Action<string, ConsoleColor, int> action = new Action<string, ConsoleColor, int>(DisplayMessage);
            action("Print to action", ConsoleColor.Blue, 7);
            Func<int,int,int> func = new Func<int,int,int>(Add);
            int c = func(40, 40);
            Console.WriteLine(c); 
            Console.ReadKey();
        }
        public static int Add(int x, int y)
            { return x + y; }
        public static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста консоли.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for(int i = 0; i < printCount; i++)
                Console.WriteLine(msg);
            // Востановить цвет
            Console.ForegroundColor = oldTextColor;
        }
    }
}
