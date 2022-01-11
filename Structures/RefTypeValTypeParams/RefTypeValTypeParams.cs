using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    internal class RefTypeValTypeParams
    {
        static void Main(string[] args)
        {
            Person alba = new Person("Alba", 22);
            alba.Display();
            SendAPersonByValue(alba);
            alba.Display();
            Person sam = new Person("Sam", 18);
            sam.Display();
            SendAPersonByReference(ref sam);
            sam.Display();
            Console.ReadKey();
        }

        static void SendAPersonByReference(ref Person p)
        { 
            // Изменить некоторые данные в р.
            p.PersonAge = 555;
            // р теперь указывает на новый объект в куче!
            p = new Person("SanT", 999);
        }

        static void SendAPersonByValue(Person p)
        {
            // Изменить значение возраста в р
            p.PersonAge = 17;
            p = new Person("Sam", 18);
        }

        class Person
        {
            public string PersonName;
            public int PersonAge;
            // Конструкторы.
            public Person(string Name, int age)
            {
                PersonName = Name;
                PersonAge = age;
            }

            public void Display()
            { Console.WriteLine($"Имя = {PersonName} Возраст = {PersonAge}"); }
        }
    }
}
