using System;
using System.Reflection;
using System.IO; // Для определения FileNotFoundException.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExternalAssemblyReflector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                // Предложить ввести имя сборки
                Console.Write("or enter Q to quit: ");
                // или Q для завершения.
                // Получить имя сборки.
                assemblyName = Console.ReadLine();
                // Пользователь желает завершить программу?
                if (assemblyName.Equals("Q", StringComparison.OrdinalIgnoreCase))//без учета регистра
                    break;
                // Попробовать загрузить сборку,
                try 
                { 
                    asm = Assembly.LoadFrom(assemblyName);
                    DisplayTypesInAsm(asm);
                } 
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                    // Сборка не найдена.
                }
            } while (true);
            
        }
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("-> " + asm.FullName);
            var TypeInAsm = from a in asm.GetTypes() select a;
            foreach(var type in TypeInAsm)
                Console.WriteLine(type);
            Console.WriteLine();
        }
    }
}
