using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ПРИМЕЧАНИЕ: эти объекты идентичны и предназначены
            // для тестирования методов Equals () и GetHashCode() .
            Person p1 = new Person("SanT", "OG", 17);
            Person p2 = new Person("SanT", "OG", 17);
            // Получить строковые версии объектов.
            Console.WriteLine("p1.ToString: {0}", p1.ToString());
            Console.WriteLine("p2.ToString: {0}", p2.ToString());
            // Протестировать переопределенный метод Equals().
            Console.WriteLine("p1 = p2 ?"+Object.Equals(p1,p2));
            // Проверить хеш-коды.
            Console.WriteLine($"Один хеш-код ? {p1.GetHashCode() == p2.GetHashCode()}");
            Console.WriteLine();
            // Изменить возраст p2 и протестировать снова.
            p2.Age = 18;
            Console.WriteLine("p1. ToString () = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2 ?" + p1.Equals(p2));
            Console.WriteLine($"Один хеш-код ? {p1.GetHashCode() == p2.GetHashCode()}");
            Console.ReadKey();
        }
    }
}
