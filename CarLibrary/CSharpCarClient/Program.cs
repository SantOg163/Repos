using System;
using CarLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCarClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать объект SportsCar.
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();
            // Создать объект MiniVan.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();
            Console.WriteLine("Done . Press any key to terminate");
            Console.ReadLine();

        }
    }
}
