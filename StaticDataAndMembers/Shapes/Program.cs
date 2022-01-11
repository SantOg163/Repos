using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shapes[] myShapes = {new Hexagon(), new Circle (), new Hexagon("Mick" ) ,new Circle("Beth"), new Hexagon("Linda" )};
            // Пройти в цикле по всем элементам и взаимодействовать
            //с полиморфным интерфейсом,
            foreach (Shapes s in myShapes)
            {
                s.Draw();
            }
            // Здесь вызывается метод Draw(), определенный в классе ThreeDCircle. 
            ThreeDCircle о = new ThreeDCircle();
            о.Draw();
            // Здесь вызывается метод Draw(), определенный в родительском классе!
            ((Circle)о).Draw();

            Console.ReadKey();
        }
    }
}
