using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterReaderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получить объект StreamWriter и записать строковые данные.(в bin\debug)
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Name: SanT OG");
                writer.WriteLine("Number: 23");
                // Вставить новую строку.
                writer.Write(writer.NewLine);
            }
            using (StreamReader reader = File.OpenText("reminders.txt"))
            {
                string input = null;
                while ((input = reader.ReadLine()) != null)
                    Console.WriteLine(input);
            }
            // Создать объект StringWriter и записать символьные данные в память.
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Name: SanT OG");
                // Получить копию содержимого (хранящегося в строке)
                //и вывести на консоль.
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
                // Получить внутренний объект StringBuilder.
                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!' ".Length);
                Console.WriteLine("-> {0}", sb.ToString());
                // Читать данные из объекта StringWriter.
                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                        Console.WriteLine(input);
                }
            }
                Console.ReadKey();
        }
    }
}
