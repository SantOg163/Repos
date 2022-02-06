using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать анонимный тип, представляющий автомобиль.
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            // Вывести на консоль цвет и производителя.
            Console.WriteLine("Му car is а {0} {1}. ", myCar.Color, myCar.Make);
            // Теперь вызвать вспомогательный метод для построения
            // анонимного типа с указанием аргументов.
            BuildAnonType("BMW", "Black", 90);
            Console.ReadLine();

        }
        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
            obj.GetType().Name,
            obj.GetType().BaseType);
            Console.WriteLine("obj .ToStringO == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }

        static void BuildAnonType(string make, string color, int curSp)
        {
            // Построить анонимный тип с применением входных аргументов,
            var car = new { Make = make, Color = color, Speed = curSp };
            // Обратите внимание, что теперь этот тип можно
            // использовать для получения данных свойств!
            Console.WriteLine("You have a { 0} { 1} going { 2} MPH", car.Color, car.Make, car.Speed);
            // Анонимные типы имеют специальные реализации каждого
            // виртуального метода System.Object. Например:
            Console.WriteLine("ToString () == {0}", car.ToString());
        }
        static void EqualityTest()
        {
            {
                // Создать два анонимных класса с идентичными наборами пар "имя-значение",
                var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
                var secondCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

                // Считаются ли они эквивалентными, когда используется Equals()?
                if (firstCar.Color.Equals(secondCar))
                    Console.WriteLine("Тот же самый анонимный объект!"); 
                else
                    Console.WriteLine("He тот же самый анонимный объект"); 

                // Можно ли проверить их эквивалентность с помощью операции ==?
                if (firstCar == secondCar)
                    Console.WriteLine("Тот же самый анонимный объект!");
                else
                    Console.WriteLine("He тот же самый анонимный объект");

                // Имеют ли эти объекты в основе один и тот же тип?
                if (firstCar.GetType().Name == secondCar.GetType().Name)
                    Console.WriteLine("Оба объекта имеют тот же самый тип");
                else
                    Console.WriteLine("Объекты относятся к разным типам");
                // Отобразить все детали.
                Console.WriteLine();
                ReflectOverAnonymousType(firstCar);
                ReflectOverAnonymousType(secondCar);
            }
        }
    } 
}
