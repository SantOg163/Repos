using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    internal class Car : IComparable
    {
        // Константа для представления максимальной скорости,
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } 
        public string Name { get; set; }
        public int CarID { get; set; }
        //He вышел ли автомобиль из строя?

        // Конструкторы
        public Car() { }

        public Car(string name, int speed, int carID)
        {
            Name = name;
            CurrentSpeed = speed;
            CarID = carID;
        }

        // Реализация интерфейса IComparable.
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
                return CarID.CompareTo(temp.CarID);
            else
                throw new ArgumentException("Параметр - не машина");
        }
        public static IComparer SortByPetName
        {
            get => (IComparer) new PetNameComparer();
        }
    }
    public class PetNameComparer : IComparer
    {
        // Проверить дружественное имя каждого объекта,
        int IComparer.Compare(object x, object y)
        {
            Car c1 = x as Car;
            Car c2 = y as Car;
            if (c1 != null && c2 != null)
                return string.Compare(c1.Name, c2.Name);
            else
                throw new ArgumentException("Параметр - не машина");
        }
    }
}
