using System;
using MyExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // В int появилась новая отличительная черта!
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();
            // To же и в DataSet!
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();
            //Ив SoundPlayer!
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();
            string s = "";
            s.DisplayDefiningAssembly();
            // Использовать новую функциональность int
            Console.WriteLine("Value of mylnt: {0}", myInt);
            Console.WriteLine("Reversed digits of mylnt: {0}", myInt.ReverseDigits());
            Console.ReadLine();

        }
    }
}
