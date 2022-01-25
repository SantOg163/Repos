using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Обратиться к свойству Points, определенному в интерфейсе IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine($"Points: {hex.Points}");


            Console.ReadKey();
        }
        // Моделирует способность визуализации типа в трехмерном виде,
        public interface IDraw3D
        {
            void Draw3D();
        }
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }
        static IPointy FindFirstPointyShape(Shapes[] shapes)
        {
            foreach(Shapes s in shapes)
                if(s is IPointy ip)
                    return ip;
            return null;
        }
    }
}
