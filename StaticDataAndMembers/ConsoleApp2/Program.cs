using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\");
            dir.CreateSubdirectory("dir");
            using(FileStream fs = File.Open(@"D:\dir\text.txt", FileMode.Create))
            {
                string bober = "Бобёр";
                byte[] bytes = Encoding.Default.GetBytes(bober);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
