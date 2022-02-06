using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("SanT",300,120);

            // Зарегистрировать обработчики событий.
            car.AboutToBlow += CarAboutToBlow;
            car.AboutToBlow += CarIsAlmostDoomed;

            Car.CarEngineHandler d = CarExploded;
            car.Exploded += d;

            for (int i = 0; i < 10; i++)
                car.Accelerate(40);

            // Удалить метод CarExploded из списка вызовов,
            car.Exploded -= d;

            for (int i = 0; i < 10; i++)
                car.Accelerate(90);

            Console.ReadKey();

            // Зарегистрировать обработчики событий как анонимные методы,
            Car c1 = new Car();
            c1.AboutToBlow += delegate (string s) {Console.WriteLine("Critical Message from Car: {0}", s); };


        }
        public static void CarAboutToBlow(string msg)
        { Console.WriteLine(msg); }
        public static void CarIsAlmostDoomed(string msg)
        { Console.WriteLine("=> Critical Message from Car: {0}", msg); }
        public static void CarExploded(string msg)
        { Console.WriteLine(msg); }
        
    }
}
