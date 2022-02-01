using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    internal class Program
    {
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine(" Message From Car Object ");
            Console.WriteLine("=> {0}", msg);
        }
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> "+ msg.ToUpper());
        }
        static void Main(string[] args)
        {
            // Создать объект Car.
            Car car = new Car("SanT",100,10);
            //есть ДВА метода, которые будут
            // вызываться Саг при отправке уведомлений.
            car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));
            Car.CarEngineHandler c = new Car.CarEngineHandler(OnCarEngineEvent);
            c += OnCarEngineEvent2;
            foreach(Delegate d in c.GetInvocationList())
                Console.WriteLine(d.Method.Name);
            for (int i = 0; i < 6; i++)
                car.Accelerate(20);
            Console.ReadKey();
        }
    }
}
