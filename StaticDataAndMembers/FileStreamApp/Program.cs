using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\");
            dir.CreateSubdirectory("dir");
            using (FileStream fs = File.Open(@"D:\dir\myMessage.txt", FileMode.Create))
            {
                // Закодировать строку в виде массива байтов.
                string message = "Hello";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(message);
                // Записать byte[] в файл.
                fs.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // Сбросить внутреннюю позицию потока.
                fs.Position = 0;
                // Прочитать byte[] из файла и вывести на консоль.
                Console.Write("Your message as an array of bytes: ");
                for (int i = 0; i < msgAsByteArray.Length; i++)
                    Console.Write(msgAsByteArray[i]);
                // Вывести декодированное сообщение.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(msgAsByteArray));
            }
            Console.ReadKey();
        }
    }
}
