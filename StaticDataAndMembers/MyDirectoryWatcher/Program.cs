﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDirectoryWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Установить путь к каталогу, за которым нужно наблюдать.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
                // Указать цели наблюдения.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
                // Следить только за текстовыми файлами.
                watcher.Filter = "*.txt";
                // Добавить обработчики событии.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                // Начать наблюдение за каталогом.
                watcher.EnableRaisingEvents = true;
                // Ожидать от пользователя команду завершения программы.
                Console.WriteLine(@"Press 'q' to quit app.");
                while (Console.Read() != 'q') ;

            }
        }
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Сообщить о действии изменения, создания или удаления файла.
            Console.WriteLine("File : {0} {1}!", e.FullPath, e.ChangeType);
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Сообщить о действии переименования файла.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}