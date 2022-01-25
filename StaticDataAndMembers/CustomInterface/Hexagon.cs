using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    internal class Hexagon : Shapes, IPointy
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
        public byte Points 
        {
            get { return 6; }
        }
        static void Draw3D()
        {
            Console.WriteLine("Drawing Hexagon in 3D");
        }
    }
}
