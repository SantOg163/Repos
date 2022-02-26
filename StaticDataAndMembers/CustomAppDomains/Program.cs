using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAppDomains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вывести все сборки, загруженные в стандартный домен приложения.
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.ProcessExit += (o, s) => Console.WriteLine("Стандартный домен приложения выгружен");
            ListAllAssembliesInAppDomain(appDomain);

            MakeNewAppDomain();
            Console.ReadKey();
        }
        static void MakeNewDomain()
        {
            AppDomain defaultAD = AppDomain.CreateDomain("SecondAppDomain");
            // Загрузить CarLibrary.dll в этот новый домен.
            try
            {
                defaultAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ListAllAssembliesInAppDomain(defaultAD);
        }
        static void MakeNewAppDomain()
        {
            // Создать новый домен приложения в текущем процессе.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o,s) => Console.WriteLine("Второй домен выгружен");
            try
            {
                newAD.Load("CarLibrary");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Вывести список всех сборок.
            ListAllAssembliesInAppDomain(newAD);
            // Избавиться от этого домена приложения.
            AppDomain.Unload(newAD);
        }
        static void ListAllAssembliesInAppDomain(AppDomain defaultAD)
        {
            var loadedAssemblies = defaultAD.GetAssemblies().OrderBy(a=>a.GetName().Name);
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n",defaultAD.FriendlyName);
            foreach(var assembly in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", assembly.GetName().Name); // Имя
                Console.WriteLine("-> Version: {0}\n", assembly.GetName().Version) ; //Версия
            }
        }
    }
}
