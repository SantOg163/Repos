using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_InterfaceHierarchy
{
    internal class Rectangle : IShape
    {
        public int GetNumberOfSides()
        { return 4; }
        void IDrawable.Draw()
        { Console.WriteLine("Draw to IDrawable()..."); }
        void IPrintable.Draw()
        { Console.WriteLine("Draw to IPrintable..."); }
        public void Print()
        { Console.WriteLine("Print..."); }
    }
}
