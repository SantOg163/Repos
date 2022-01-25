using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    internal class Garage : IEnumerable
    {

        // System.Array уже реализует IEnumerator!
        private Car[] carArray = new Car[4];
        // При запуске заполнить несколькими объектами Саг.
        public Garage()
        {
            carArray[0] = new Car("SanT", 300);
            carArray[1] = new Car("Alba", 250);
            carArray[2] = new Car("Zip", 70);
            carArray[3] = new Car("RZA", 400);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Возвратить IEnumerator объекта массива,
            return carArray.GetEnumerator();
        }
    }
}
