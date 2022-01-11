using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseReader dr = new DatabaseReader();
            // Получить значение int из "базы данных"
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
                Console.WriteLine("вывод значения переменной i " + i.Value);
            // вывод значения переменной i
            else
                Console.WriteLine("значение переменной i не определено");
            // значение переменной i не определено
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
                Console.WriteLine("вывод значения переменной b " + b.Value);
            else
                Console.WriteLine("значение переменной b не определено");
            // Если значение, возвращаемое из GetlntFromDatabase(), равно
            // null, то присвоить локальной переменной значение 100.
            int? myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Значение myData: " + myData);
            TesterMethod(null);
            Console.ReadKey();
        }
        class DatabaseReader
        {
            // Поле данных типа, допускающего null,
            public int? numencValue = null;
            public bool? boolValue = true;
            // Обратите внимание на возвращаемый тип, допускающий null,
            public int? GetIntFromDatabase()
            { return numencValue; }
            public bool? GetBoolFromDatabase()
            { return boolValue; }
        }
        static void TesterMethod(string args)
        {
            // Перед доступом к данным массива мы должны проверить его на равенство null!
            if (args != null)
                Console.WriteLine($"You sent me {args.Length} arguments.");
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }

    }
}
