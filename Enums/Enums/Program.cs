using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);
            Console.WriteLine("Тип хранилища для значений перечисления: " + Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine("Тип хранилища для значений перечисления: " + Enum.GetUnderlyingType(typeof(EmpType)));
            Console.WriteLine($"{(byte)emp} - {emp.ToString()} ");//2 - Contractor

            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.DarkBlue;

            EvaluateEnum(emp);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadKey();
        }
        // Перечисления как параметры
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("He желаете ли взамен фондовые опционы?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Вы должно быть шутите");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("Вы уже получаете вполне достаточно");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Очень хорошо, сэр!");
                    break;
            }
        }

        // Этот метод выводит детали любого перечисления
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("Информация о " + e.GetType().Name);
            Console.WriteLine("Тип хранилища для значений перечисления: "+ Enum.GetUnderlyingType(e.GetType()));

            // Получить все пары "имя-значение" для входного параметра
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("Кол-во перечислений: "+enumData.Length);
            // Вывести строковое имя и ассоциированное значение,
            // используя флаг формата D
            for (int i = 0; i < enumData.Length; i++)
                Console.WriteLine("Имя: {0} Значение: {0:D}",enumData.GetValue(i));
        }

        // Специальное перечисление,
        enum EmpType
        {
            Manager,        // = О
            Grunt,          // = 1
            Contractor,     // = 2
            VicePresident   // = 3
        }
        // Значения элементов в перечислении не обязательно должны быть
        // последовательными!

    }
}
