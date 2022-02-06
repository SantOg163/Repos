using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    internal class Car
    {
        // Данные состояния,
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Исправен ли автомобиль?
        private bool carIsDead;
        // Конструкторы класса,
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // 1. Определить тип делегата.
        public delegate void CarEngineHandler(string msgForCaller);
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;


        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                //if(Exploded != 0)
                    Exploded?.Invoke("Sorry, this car is dead...");
            }
            else
                CurrentSpeed += delta;
            // Автомобиль почти сломан?
            if (MaxSpeed - CurrentSpeed == 10 )
                AboutToBlow?.Invoke("Почти сломалась");// AboutToBlow != null
            if (CurrentSpeed > MaxSpeed)
                carIsDead = true;
            else
                Console.WriteLine("CurrentSpeed = " + CurrentSpeed);
        }
    }
}
