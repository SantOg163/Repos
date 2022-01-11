using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return
{
    internal class Return
    {
        static void Main(string[] args)
        {
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Simple Return");
            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0],
            stringArray[1], stringArray[2]);
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            Console.ReadKey();
        }
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }
        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
    }
}