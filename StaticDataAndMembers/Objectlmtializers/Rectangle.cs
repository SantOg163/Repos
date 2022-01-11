using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectlmtializers
{
    internal class Rectangle
    {
        private Point TopLeft { get; set; } = new Point();
        private Point BottomRight { get; set; } = new Point();
        public void Display()
        {
            Console.WriteLine("[TopLeft: {0}, {1}, {2} BottomRight: {3}, {4}, {5}]", TopLeft.X, TopLeft.Y, TopLeft.Color, BottomRight.X, BottomRight.Y, BottomRight.Color);
        }
        Rectangle myRect = new Rectangle()
        {
            TopLeft = new Point() { X=10, Y=10 },
            BottomRight = new Point() { Y=200, X=200 },
        };
    }
}
