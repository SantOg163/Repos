// Импортировать статические члены классов Console и DateTime.
using static System.Console;
using static System.DateTime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtilityClass
{
    static class TimeUtilClass
    {
        public static void PrintTime()=>WriteLine(Now.ToString());
        public static void PrintDate()=>WriteLine(Today.ToString());
    }
}
