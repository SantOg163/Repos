using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
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
        //2. Определить переменную-член этого типа делегата.
        private CarEngineHandler listOfHandlers;
        // 3. Добавить регистрационную функцию для вызывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (listOfHandlers == null)
                listOfHandlers = methodToCall;
            else
                listOfHandlers += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        // 4. Реализовать метод Accelerate () для обращения к списку
        // вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    Console.WriteLine("Car is dead");
            }
            else
                CurrentSpeed += delta;
            // Автомобиль почти сломан?
            if(MaxSpeed - CurrentSpeed == 10 && listOfHandlers != null)
                Console.WriteLine("Почти сломалась");
            if (CurrentSpeed > MaxSpeed)
                carIsDead = true;
            else
                Console.WriteLine("CurrentSpeed = " + CurrentSpeed);
        }
    }
}
