using System;
using AttributedCarLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReflectOnAttnbutesUsingEarlyBinding();
            Console.ReadKey();
        }
        static void ReflectOnAttnbutesUsingEarlyBinding()
        {
            // Получить объект Type, представляющий тип Winnebago
            Type t = typeof(Winnebago);
            // Получить все атрибуты Winnebago.
            var Linq = from l in t.GetCustomAttributes(false) select l;
            // Вывести описание.
            foreach(var l in Linq)
                Console.WriteLine("->"+l);
        }
    }
}
