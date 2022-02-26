using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получить объект FileStream через File.Create().
            using (FileStream fs = File.Create(@"C:\Test.dat"))
            { }
            // Получить объект FileStream посредством File.Open().
            using (FileStream fs2 = File.Open(@"C:\Test2.dat",
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            { }
            // Получить объект FileStream с правами только для чтения.
            using (FileStream readOnlyStream = File.OpenRead(@"Test3.dat"))
            { }
            // Получить объект FileStream с правами только для записи.
            using (FileStream writeOnlyStream = File.OpenWrite(@"Test4.dat"))
            // Получить объект StreamReader.
            using (StreamReader sreader = File.OpenText(@"C:\boot.ini"))
            { }
            // Получить несколько объектов StreamWriter.
            using (StreamWriter swriter = File.CreateText(@"C:\Test6.txt"))
            { }
            using (StreamWriter swriterAppend = File.AppendText(@"C:\FinalTest.txt"))
            { }

        }
    }
}
