using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSenalize
{
    [Serializable]
    internal class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
}
