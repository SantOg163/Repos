using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(300, 300, "SanT");
            Point point1 = (Point)point.Clone();
            Console.WriteLine("До обновления: ");
            Console.WriteLine($"point: {point}");
            Console.WriteLine($"point1: {point1}");
            point1.desk.PetName = "Alba";
            Console.WriteLine("После обновления:");
            Console.WriteLine($"point: {point}");
            Console.WriteLine($"point1: {point1}");
            Console.ReadKey();
        }
    }
}
