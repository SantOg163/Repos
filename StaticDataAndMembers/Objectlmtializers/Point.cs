using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectlmtializers
{
    enum PointColor
    { LightBlue, BloodRed, Gold}
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }
        public Point() { }
        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }
        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }
        public void Display()
        {
            Console.WriteLine($"[{X} \t {Y}]");
            Console.WriteLine("Цвет точки: " + Color);
        }
    }
}
