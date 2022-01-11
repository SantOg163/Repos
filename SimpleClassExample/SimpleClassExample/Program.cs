using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Разместить в памяти и сконфигурировать объект Саг
            Car mycar = new Car("SanT", 300);
            mycar.Name = "SanT";
            mycar.Speed = 300; 
            mycar.PrintState();

            for(int i = 0; i < 10; i++)
            {
                mycar.SpeedUp(5);
                mycar.PrintState();
            }

            Motorcycle moto = new Motorcycle();
            moto.SetDriverName("Alba");
            moto.PopAWheely();
            Console.WriteLine(moto.Name);
            Console.ReadKey();
        }
    }
}
