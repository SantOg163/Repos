using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Color
{
    internal class Color
    {
        static void Main(string[] args)
        {
            DisplayFancyMessage(message:"Текст", textColor: ConsoleColor.DarkBlue, backgroundColor: ConsoleColor.Yellow);
            DisplayFancyMessage(message: "HI");
            Console.ReadKey();
        }
        static void DisplayFancyMessage(ConsoleColor textColor= ConsoleColor.DarkBlue, ConsoleColor backgroundColor=ConsoleColor.DarkYellow, string message="Текст" )
        {     
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor OldTextColor = Console.ForegroundColor;
            ConsoleColor OldbackgroundColor = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета.
            Console.ForegroundColor = OldTextColor;
            Console.BackgroundColor = OldbackgroundColor;
        }
    }
}
