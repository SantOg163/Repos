using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTypeViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                // Предложить ввести имя типа
                Console.Write("or enter Q to quit: ");
                // или Q для завершения.
                // Получить имя типа.
                string typeName = Console.ReadLine();
                // Пользователь желает завершить программу?
                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                // Попробовать отобразить информацию о типе.
                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    Listlnterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can’t find type"); // He удается найти тип.
                }
            } while (true);
        }
        // Просто ради полноты картины,
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("Base class is: {0}", t.BaseType);
            // Базовый класс
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            // Абстрактный?
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            // Запечатанный?
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            // Обобщенный?
            Console.WriteLine("Is type a class type? {0}", t.IsClass); // Класс?
            Console.WriteLine();
        }
        // Отобразить имена методов в типе,
        static void ListMethods(Type t)
        {
            MethodInfo[] mi = t.GetMethods();
            var methodNames = from n in t.GetMethods() select n;
            foreach (var name in methodNames)
                Console.WriteLine("->{ 0} ", name);
            Console.WriteLine();

        }
        // Отобразить имена полей в типе,
        static void ListFields(Type t)
        {
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
                Console.WriteLine("->" + name);
            Console.WriteLine();
        }
        // Отобразить имена свойств в типе,
        static void ListProps(Type t)
        {
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }
        // Отобразить имена интерфейсов, которые реализует тип.
        static void Listlnterfaces(Type t)
        {
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("->"+ i .Name) ;
        }

    }
}
