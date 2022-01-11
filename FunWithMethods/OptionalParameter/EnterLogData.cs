using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameter
{
    internal class EnterLogData
    {
        static void Main(string[] args)
        {
            EnterLogData1("Данные не найдены");
            EnterLogData1("Данные о финансах не найдены", "Финансовый директор");
            Console.ReadKey();
        }
        static void EnterLogData1(string message, string owner = "Программист")
        {
            Console.Beep();
            Console.WriteLine("Ошибка: " + message);
            Console.WriteLine("Причина ошибки: "+owner);
        }
    }
}
