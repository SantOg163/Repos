using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunWithDirectoryType();
            SubDirectory();
            ShowWindowsDirectoryInfо();
            DisplayImageFiles();
            Console.ReadLine();
        }
        static void FunWithDirectoryType()
        {
            // Вывести список всех логических устройств на текущем компьютере.
            string[] drivers = Directory.GetLogicalDrives();//C:\ и D:\
            foreach (string driver in drivers)
                Console.WriteLine(driver);
        }
        static void ShowWindowsDirectoryInfо()
        {
            // Вывести информацию о каталоге.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("Полное имя: " + dir.FullName);
            Console.WriteLine("Имя: " + dir.Name);
            Console.WriteLine("Родительский каталог: " + dir.Parent);
            Console.WriteLine("Время создания: " + dir.CreationTime);
            Console.WriteLine("Атрибуты: " + dir.Attributes);
            Console.WriteLine("Корневой каталог(Root): " + dir.Root);
            Console.WriteLine();
        }
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Получить все файлы с расширением *.jpg.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // Сколько файлов найдено?
            Console.WriteLine("Кол-во файлов .jpg: " + imageFiles.Length);
            // Вывести информацию о каждом файле.
            foreach (FileInfo imageFile in imageFiles)
            {
                Console.WriteLine("Имя файла: " + imageFile.Name);
                Console.WriteLine("Размер файла: " + imageFile.Length + " мб");
                Console.WriteLine("Время создания: " + imageFile.CreationTime);
                Console.WriteLine("Атрибуты: " + imageFile.Attributes);
                Console.WriteLine();
            }
        }
        static void SubDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Repos");
            dir.CreateSubdirectory("DIR");
        }
    }
}
