using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вызвать на уровне объекта.
            BitmapImage bit = new BitmapImage();
            bit.Draw();
            bit.DrawUpsideDown();
            bit.DrawInBoundingBox(1,1,1,1);
            IAdvancedDraw draw = bit as IAdvancedDraw;
            // Получить IAdvancedDraw явным образом.
            if (draw != null)
                draw.Draw();
            Console.ReadKey();
        }
        public class BitmapImage : IAdvancedDraw
        {
            public void Draw()
            {
                Console.WriteLine("Draw...");
            }
            public void DrawInBoundingBox(int top, int bottom, int left, int right)
            {
                Console.WriteLine("Drawing in a box...");
            }
            public void DrawUpsideDown()
            {
                Console.WriteLine("Drawing upside down!");
            }
        }
        public interface IDrawable
        {
            void Draw();
        }
        public interface IAdvancedDraw : IDrawable
        {
            void DrawInBoundingBox(int top, int bottom, int left, int right);
            void DrawUpsideDown();
        }
    }
}
