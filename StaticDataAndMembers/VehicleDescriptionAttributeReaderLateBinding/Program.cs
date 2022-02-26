using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReflectAttributesUsingLateBinding();
            Console.ReadKey();
        }
        static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Загрузить локальную копию сборки AttributedCarLibrary.
                Assembly asm = Assembly.Load("AttributedCarLibrary");
                // Получить информацию о типе VehicleDescriptionAttribute.
                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
                // Получить информацию о типе свойства Description.
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");
                // Получить все типы в сборке.
                var Linq = asm.GetTypes().Select(a => a);
                foreach (var l in Linq)
                {
                    var obj = from a in l.GetCustomAttributes(vehicleDesc, false) select a;
                    // Пройти по каждому VehicleDescriptionAttribute и вывести
                    // описание, используя позднее связывание.
                    foreach (object о in obj)
                    {
                        Console.WriteLine("-> {0}: {1}\n", l.Name, propDesc.GetValue(0, null));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
