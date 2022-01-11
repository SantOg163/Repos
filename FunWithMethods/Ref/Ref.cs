using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ref
{
    internal class Ref
    {
        static void Main(string[] args)
        {
            string str1 = "A";
            string str2 = "B";
            Console.WriteLine($"Before : {str1} {str2} ");
            SwapStrings(ref str1, ref str2);//s1 = str1, s2 = str2
            Console.WriteLine($"After : {str1} {str2} ");
            Console.ReadKey();
        }
        //меняет значения s1 и s2 
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
    }
}
