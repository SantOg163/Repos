using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DefaultAppDomainApp();
            ListAHAssembliesInAppDomain();
            Console.ReadKey();
        }
        static void DefaultAppDomainApp()
        {
            // Получить доступ к домену приложения для текущего потока.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Вывести разнообразные статистические данные об этом домене.
            Console.WriteLine("Имя домена: " + defaultAD.FriendlyName);
            Console.WriteLine("ID: " + defaultAD.Id);
            Console.WriteLine("Является ли стандартным: " + defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Базовый каталог: " + defaultAD.BaseDirectory);
        }
        static void ListAHAssembliesInAppDomain()
        {
            // Получить доступ к домену приложения для текущего потока.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Извлечь все сборки, загруженные в стандартный домен приложения.
            var loadedAssemblies = from a in defaultAD.GetAssemblies() orderby a.GetName().Name select a;
            Console.WriteLine("Default name: " + defaultAD.FriendlyName);
            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0} ", a.GetName().Name); // Имя
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version); // Версия
            }
        }
        static void InitDAD()
        {
            // Эта логика будет выводить имя любой сборки, загруженной
            //в домен приложения после его создания.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) => Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);  
        }
    }
}
