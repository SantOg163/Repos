using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithObservable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Сделать коллекцию наблюдаемой и добавить в нее несколько объектов Person.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person(){FirstName = "SanT", LastName = "OG", Age = 17},
                new Person(){FirstName ="Alba",LastName ="OG",Age = 21},
            };
            // Привязаться к событию CollectionChanged.
            people.CollectionChanged += people_CollectionChanged;
            Console.ReadKey();
        }
        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Действие, которое привело к генерации события: {0}", e.Action);
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Старые элементы");
                foreach(Person p in e.OldItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Новые элементы");
                foreach (Person p in e.NewItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }
    }
}
