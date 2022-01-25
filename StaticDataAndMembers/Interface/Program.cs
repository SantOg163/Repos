using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn =
            new System.Data.SqlClient.SqlConnection();
            // Следовательно, все они могут быть переданы методу,
            // принимающему параметр типа ICloneable.
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);
            Console.ReadLine();
        }
        private static void CloneMe(ICloneable c)
        {
            // Клонировать то, что получено, и вывести его имя.
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        }
        public abstract class CloneableType
        {
            // Поддерживать этот "полиморфный интерфейс" могут только производные типы.
            // Классы в других иерархиях не имеют доступа к данному абстрактному члену,
            public abstract object Clone();
        }
    }
}
