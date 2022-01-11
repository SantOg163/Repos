using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectlmtializers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать объект Point, устанавливая каждое свойство вручную.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.Display();
            // Создать объект Point посредством специального конструктора.
            Point anotherPoint = new Point(20, 20);
            anotherPoint.Display();
            // Создать объект Point, используя синтаксис инициализации объектов.
            Point finalPoint = new Point { X = 30, Y = 30 };
            finalPoint.Display();
            Point point = new Point(PointColor.Gold) { X=90, Y = 90, };
            point.Display();

            Console.ReadKey();
        }
    }
}
