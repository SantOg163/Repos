using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
     public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString() => $"Name: {FirstName} {LastName}, Age: {Age}";
    }
    public class PersonList : IEnumerable
    {
        private ArrayList arPerson = new ArrayList();
        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => (Person)arPerson[pos];
        // Вставка только объектов Person.
        public void AdPerson(Person p) => arPerson.Add(p);
        public void ClearPerson() => arPerson.Clear();
        public int Count => arPerson.Count;
        // Вставка только объектов Person.
        IEnumerator IEnumerable.GetEnumerator() => arPerson.GetEnumerator();
    }
}
