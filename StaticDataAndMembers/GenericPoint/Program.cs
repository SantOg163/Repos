using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Точка с координатами типа int
            Point<int> PointInt = new Point<int>(10, 15);
            Console.WriteLine("PointInt: " + PointInt);
            PointInt.ResetPoint();
            Console.WriteLine("PointInt: " + PointInt);
            Console.WriteLine();

            // Точка с координатами типа int
            Point<double> PointDouble = new Point<double>(5.4, 3.3);
            Console.WriteLine("PointDouble: " + PointDouble);
            PointDouble.ResetPoint();
            Console.WriteLine("PointDouble: " + PointDouble);

            Console.ReadKey();
        }

        // Обобщенная структура Point,
        public struct Point<T>
        {
            // Обобщенные данные состояния,
            private T xPos { get; set; }
            private T yPos { get; set; }
            // Обобщенный конструктор,
            public Point(T xVal,T yVal)
            {
                xPos = xVal;
                yPos = yVal;
            }
            
            // Обобщенные свойства,
            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }
            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }

            public override string ToString() => $"[{xPos}, {yPos}]";
            // Сбросить поля в стандартные значения
            // для заданного параметра типа,
            public void ResetPoint()
            {
                xPos = default(T);
                yPos = default(T);
            }
        }
    }
}
