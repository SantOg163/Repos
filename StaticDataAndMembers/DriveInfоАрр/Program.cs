using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfоАрр
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать новый файл посредством Filelnfo.Open().
            FileInfo file = new FileInfo(@"C:\Test2.dat");
            using(FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.None))
            {
                //использовать fs
            }
            GetDrivers();
            Console.ReadLine();
        }
        static void GetDrivers()
        {
            // Получить информацию обо всех устройствах.
            DriveInfo[] drivers = DriveInfo.GetDrives();
            //Вывод информации
            foreach (DriveInfo driver in drivers)
            {
                Console.WriteLine("Имя диска: " + driver.Name);
                Console.WriteLine("Тип: " + driver.DriveType);
                // Проверить, смонтировано ли устройство.
                if (driver.IsReady)
                {
                    Console.WriteLine("Свободное пространство: " + driver.TotalFreeSpace);
                    Console.WriteLine("Формат: " + driver.DriveFormat);
                    Console.WriteLine("Тома: " + driver.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
