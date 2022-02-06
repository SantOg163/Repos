using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(10,50);
            Console.WriteLine(r);
            r.Draw();
            // Преобразовать г в Square на основе высоты Rectangle.
            Square s = (Square)5;

            Console.WriteLine(s);
            s.Draw();
            Console.WriteLine(s + s);

            Rectangle r2 = s;

            Console.ReadKey();
        }
    }
}
