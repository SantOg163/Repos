using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
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
        public IEnumerator GetEnumerator()
        {
            // Это исключение сгенерируется немедленно,
            return actualImplementation();
            // Закрытая функция.
            IEnumerator actualImplementation()
            {
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }

        public IEnumerable GetTheCars(bool returnReversed)
        {
            // Выполнить проверку на предмет ошибок,
            return actualImplementation();
            IEnumerable actualImplementation()
            {
                // Возвратить элементы в обратном порядке,
                if (returnReversed)
                    for (int i = carArray.Length; i != 0; i--)
                        yield return carArray[i - 1];

                // Возвратить элементы в том порядке, в каком они размещены в массиве,
                else
                    foreach (Car с in carArray)
                        yield return с;
            }
        }
    }
}
