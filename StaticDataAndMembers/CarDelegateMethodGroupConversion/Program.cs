using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
{
    internal class Program
    {
        public static void CallMe(string s)
        { Console.WriteLine(s); }
        public static void T(string t)
        { Console.WriteLine(t); }
        static void Main(string[] args)
        {
            Car cl = new Car("s",120,50);
            // Зарегистрировать простое имя метода.
            cl.RegisterWithCarEngine(CallMeHere);
            for (int i = 0; i < 6; i++)
                cl.Accelerate(20);
            // Отменить регистрацию простого имени метода.
            cl.UnRegisterWithCarEngine(CallMeHere);
            // Уведомления больше не поступают!
            for (int i = 0; i < 6; i++)
                cl.Accelerate(20);
            Console.ReadKey();
        }
        static void CallMeHere(string msg)
        {
            Console.WriteLine(" = > Message from Car: {0}", msg);
        }
    }
}
