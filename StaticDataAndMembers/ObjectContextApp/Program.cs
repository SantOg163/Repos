using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectContextApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Объекты при создании будут отображать контекстную информацию.
            SportsCar sport = new SportsCar();
            Console.WriteLine();
            SportsCar sport2 = new SportsCar();
            Console.WriteLine();
            SportsCarTS synchroSport = new SportsCarTS();
            Console.ReadLine();

        }
    }
}
