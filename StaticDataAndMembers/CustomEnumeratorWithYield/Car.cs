using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    internal class Car
    {
        // Константа для представления максимальной скорости,
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } 
        public string Name { get; set; }

        //He вышел ли автомобиль из строя?
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
    }
}
