using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFilelO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\");
            dir.CreateSubdirectory("dir");
            FileInfo fi = new FileInfo(@"D:\dir\test.docx"); 
            fi.Create();
            string[] myTask = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox One"};
            // Записать все данные в файл на диске С: 
            File.WriteAllLines(@"tasks.txt", myTask);
            // Прочитать все данные и вывести на консоль
            foreach(string task in File.ReadAllLines(@"tasks.txt"))
                Console.WriteLine(task);
            Console.ReadLine();
        }
    }
}
