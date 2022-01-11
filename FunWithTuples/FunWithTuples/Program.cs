using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string, int, string) value = ("a", 5, "c");
            var values = ("a", 5, "c");
            Console.WriteLine($"First item: {values.Item1}");
            Console.WriteLine($"Second item: {values.Item2}");
            Console.WriteLine($"Third item: {values.Item3}");
            //присваивание имен
            (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
            var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
            Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
            Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}");
            // Система обозначений ItemX по-прежнему работает!
            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"Stnng is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");
            Point p = new Point(7, 5);
            var pointValues = p.Deconstruct;
            Console.WriteLine($"X is: { pointValues.posx}") ;
            Console.WriteLine($"Y is: { pointValues.posy}");
            Console.ReadKey();
        }
        static void FillTheseValues(out string a, out int b, out string c)
        {
            a = "a";
            b = 5;
            c = "c";
        }
        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }
        struct Point
        {
            // Поля структуры,
            public int X;
            public int Y;
            // Специальный конструктор,
            public Point(int posx, int posy)
            { X = posx; Y = posy; }
            public(int posx,int posy) Deconstruct => (X,Y);
        }
    }
}
