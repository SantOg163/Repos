using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Class
    {
        static void Main(string[] args)
        {
            ValueTypeContainingRefType();
            Console.ReadKey();
        }

        static void ValueTypeContainingRefType()
        {

            // Создать первую переменную Rectangle.
            Rectangle r1 = new Rectangle("info", 10, 20, 30, 40);
            // Присвоить новой переменной Rectangle переменную r1
            Rectangle r2 = r1;
            // Изменить некоторые значения в r2.
            r2.ReactInfo.InfoString = "new info";
            r2.RectBottom = 4444;
            // Вывести значения из обеих переменных Rectangle,
            r1.Display();
            r2.Display();
        }

        class ShapeInfo
        {
            public string InfoString;
            public ShapeInfo(string info)
            { InfoString = info; }        
        }

        // Структура Rectangle содержит член ссылочного типа,
        struct Rectangle
        {
            public ShapeInfo ReactInfo;
            public int RectTop, RectLeft, RectBottom, RectRight;
            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                ReactInfo = new ShapeInfo(info);
                RectTop = top; RectBottom = bottom;
                RectLeft = left; RectRight = right;
            }
            public void Display()
            { Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}", ReactInfo, RectTop, RectBottom, RectLeft, RectRight);}
        }
    }
}
