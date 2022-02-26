using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать освобождаемый объект и вызвать метод Dispose ()
            // для освобождения любых внутренних ресурсов.
            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable)
                rw.Dispose();
            Console.ReadLine();
        }
        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);
            // Мягко выражаясь, сбивает с толку!
            // Вызовы этих методов делают одно и то же !
            fs.Close();
            fs.Dispose();
        }
    }
}
