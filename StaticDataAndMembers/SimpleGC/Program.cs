using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество байтов, выделенных в куче: "+GC.GetTotalMemory(false));
            // Значения MaxGeneration начинаются c 0, поэтому при выводе добавить 1.
            Console.WriteLine("Количество поколений: " + (GC.MaxGeneration + 1));
            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());
            Console.WriteLine("Поколение refToMyCar: "+ GC.GetGeneration(refToMyCar));
            // Создать большое количество объектов в целях тестирования.
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();
            // Принудительно запустить сборку мусора и ожидать финализации каждого объекта.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Поколение refToMyCar: " + GC.GetGeneration(refToMyCar));
            // Посмотреть, существует ли еще tonsOfObjects[9000].
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects [9000] is: {0}",
                GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");
            // Вывести количество проведенных сборок мусора для разных поколений.
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
            
            Console.ReadKey();
        }
        static void MakeACar()
        {
            // Если myCar - единственная ссылка на объект Саг, то после
            // завершения этого метода объект Саг *может* быть уничтожен.
            Car myCar = new Car();
            myCar = null;
        }
    }
}
