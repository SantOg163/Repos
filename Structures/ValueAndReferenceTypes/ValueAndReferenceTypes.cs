using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    internal class ValueAndReferenceTypes
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
            Console.WriteLine();
            ValueTypeAssignment();
            Console.ReadKey();

        }

        // Присваивание двух внутренних типов значений дает
        // в результате две независимые переменные в стеке
        static void ValueTypeAssignment()
        {
            Point p1 = new Point(10, 10);
            Point p2 = p1;

            // Вывести значения обеих переменных Point
            p1.Display();
            p2.Display();
            //Изменить p1.X и снова вывести значения переменных.Значение р2.Х не изменилось
            p1.x = 100;
            p1.Display();
            p2.Display();
        }
    }

    // Поля структуры
    class Point
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


