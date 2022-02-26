using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWnterReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Открыть средство двоичной записи в файл.
            FileInfo fi = new FileInfo("Binary.txt");
            using(BinaryWriter bw = new BinaryWriter(fi.OpenWrite()))
            {
                // Вывести на консоль тип BaseStream
                // (System.IO.FileStream в этом случае)
                Console.WriteLine("BaseStream: " + bw.BaseStream);
                // Создать некоторые данные для сохранения в файле.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "А, В, C";
                // Записать данные.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            using(BinaryReader br = new BinaryReader(fi.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.ReadKey();
        }
    }
}
