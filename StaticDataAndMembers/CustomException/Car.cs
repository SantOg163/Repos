using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Car
    {
        // Константа для представления максимальной скорости,
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } 
        public string Name { get; set; }

        //He вышел ли автомобиль из строя?
        private bool CarIsDead;
        public Radio theMusicBox = new Radio();

        // Конструкторы
        public Car() { }
        public Car(string name, int speed)
        {
            Name = name;
            CurrentSpeed = speed;

        }

        // Делегировать запрос внутреннему объекту.
        public void Radio(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (CarIsDead)
                Console.WriteLine(Name + "  перегрелся");
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    CarIsDead = true;
                    // Использовать ключевое слово throw для генерации исключения,
                    CarIsDeadExpection ex = new CarIsDeadExpection($"{Name} перегрелся", "Можете пойти пешком", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";
                    throw ex;
                }
                else
                    Console.WriteLine("=>CurrentSpeed: " + CurrentSpeed);
            }
        }
    }
}
