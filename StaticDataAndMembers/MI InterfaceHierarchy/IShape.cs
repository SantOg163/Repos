using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_InterfaceHierarchy
{
    internal interface IShape : IPrintable, IDrawable
    {
    }
    interface IPrintable
    {
        void Print();
        void Draw();
    }
    interface IDrawable
    {
        void Draw();
    }
}
