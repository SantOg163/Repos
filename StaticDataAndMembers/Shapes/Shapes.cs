using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract internal class Shapes
    {
        public string PetName { get; set; }
        public Shapes(string name = "NoName")
        { PetName = name; }
        public virtual void Draw()
        { Console.WriteLine("’Inside Shape . Draw () "); }
    }
}
