using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateBindingApp
{
    // Это приложение будет загружать внешнюю сборку и
    // создавать объект, используя позднее связывание,
    internal class Program
    {
        static void Main(string[] args)
        {
            // Попробовать загрузить локальную копию CarLibrary.
            Assembly asm = null;
            try
            {
                asm = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (asm != null)
                CreateUsingLateBinding(asm);
            Console.ReadKey();
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа Minivan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Создать экземпляр MiniVan на лету.
                object obj = Activator.CreateInstance(miniVan);
                // Получить информацию о TurboBoost.
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                // Вызвать метод (null означает отсутствие параметров).
                mi.Invoke(obj, null);
                Console.WriteLine(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить описание метаданных для типа SportsCar
                Type sport = asm.GetType("CarLibrary.SportCar");
                // Создать объект типа SportsCar.
                object obj = Activator.CreateInstance(sport);
                // Вызвать метод TurnOnRadio() с аргументами.
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
