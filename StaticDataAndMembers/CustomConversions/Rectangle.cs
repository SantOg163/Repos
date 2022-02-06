using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int width, int height)
        {
            Width = width; Height = height;
        }
        public override string ToString() => $"Width: {Width}, Height: {Height}";
        public void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        //Square неявно преобразовывается в Rectangle
        public static implicit operator Rectangle(Square square)=> new Rectangle(square.Length, square.Length);
    }
}
