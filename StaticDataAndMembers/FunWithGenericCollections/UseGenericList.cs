using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    internal class List
    {
        static void UseGenericList()
        {
            // Создать список объектов Person и заполнить его с помощью
            // синтаксиса инициализации объектов и коллекции.
            // Создать список объектов Person и заполнить его с помощью
            // синтаксиса инициализации объектов и коллекции.
            List<Person> people = new List<Person>()
            {
                new Person { FirstName = "Alba", LastName = "OG", Age = 23 },
                new Person { FirstName = "SanT", LastName = "OG", Age = 18 },
            };
            // Вывести количество элементов в списке.
            Console.WriteLine("Items in list: {0}", people.Count);
            // Выполнить перечисление по списку.
            foreach (Person p in people)
                Console.WriteLine(p);
            // Вставить новый объект Person.
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person { FirstName = "RZA", LastName = "", Age = 52 });
            Console.WriteLine("Items in list: {0}", people.Count);
            // Скопировать данные в новый массив.
            Person[] arrayOfPeople = people.ToArray();
            foreach (Person p in arrayOfPeople)
            {
                Console.WriteLine("First Names: {0}", p.FirstName);
            }
        }
    }
}
