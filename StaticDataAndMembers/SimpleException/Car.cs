using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
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
                    Exception ex = new Exception(Name + " превысел допустимую скорость");
                    ex.HelpLink = "https://animego.org/anime/voleybol-2-258";
                    ex.Data.Add("TimeStamp", $"Машина сломалоась {DateTime.Now}");
                    ex.Data.Add("Cause", "Вы можете пойти пешкоом");
                    throw ex;
                }
                else
                    Console.WriteLine("=>CurrentSpeed: " + CurrentSpeed);
            }
        }
    }
}
