using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Получить метаданные для типа SimpleMath.
                Type math = asm.GetType("MathLibrary.SimpleMath");
                // Создать объект SimpleMath на лету.
                dynamic obj = Activator.CreateInstance(math);
                // Обратите внимание, насколько легко теперь вызывать метод Add() .
                Console.WriteLine("Result is: {0}", obj.Add(10, 70));

            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
