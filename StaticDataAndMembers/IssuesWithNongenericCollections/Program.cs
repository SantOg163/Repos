using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithNongenericCollections
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            // Этот объект List<> может хранить только объекты Person.
            List<Person> people = new List<Person>();
            people.Add(new Person("SanT","OG",23));
            Console.WriteLine(people[0]);
            // Этот объект Listo может хранить только целые числа.
            List<int> morelnts = new List<int>();
            morelnts.Add(10);
            morelnts.Add(2);
            int sum = morelnts[0] + morelnts[1];

        }
        static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (int).
            int myInt = 25;
            // Упаковать int в ссылку на object,
            object boxedInt = myInt;
            // Распаковать ссылку обратно в int
            int unboxedInt = (int)boxedInt;
        }

    }
}
