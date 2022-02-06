using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtensions
{
    static class MyExtensions
    {      
        // Этот метод позволяет объекту любого типа
        // отобразить сборку, в которой он определен.
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine(obj.GetType().Name+" в сборке "+ Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }
        // Этот метод позволяет любому целочисленному значению изменить порядок
        // следования десятичных цифр на обратный. Например, для 56 возвратится 65.
        public static int ReverseDigits(this int i)
        {
            // Транслировать int в string и затем получить все его символы,
            char[] digits = i.ToString().ToCharArray();
            // Транслировать int в string и затем получить все его символы,
            Array.Reverse(digits);
            // Поместить обратно в строку,
            string newDigits = digits.ToString();
            // Возвратить модифицированную строку как int.
            return Convert.ToInt32(digits);
        }
    }
}
