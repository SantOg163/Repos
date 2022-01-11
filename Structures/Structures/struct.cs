using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    internal class structures
    {
        static void Main(string[] args)
        {
            Point myPoint = new Point(50, 60);
            myPoint.Display();
            myPoint.x = 349;
            myPoint.y = 74;
            myPoint.Display();
            myPoint.Increment();
            myPoint.Display();
            Console.ReadKey();
        }

        // Поля структуры
        struct Point
        { 
            public int x;
            public int y;

            //позволяет писать значения в скобках
            public Point(int posx, int posy)
            { x = posx; y = posy; }
            public void Increment()
            { x++; y++; }
            public void Decrement()
            { x--; y--; }
            public void Display()
            { Console.WriteLine($"x = {x} y = {y}"); }
        }
    }
}
