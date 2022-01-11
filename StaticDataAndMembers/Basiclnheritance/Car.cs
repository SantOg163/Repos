using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basiclnheritance
{
    internal class Car
    {
        public readonly int MaxSpeed;
        private int currSpeed;
        public Car(int max)
        {
            MaxSpeed = max;
        }
        public Car()
        { MaxSpeed = 55; }
        public int GetCurrSpeed
        {
            get => currSpeed;
            set 
            {
                currSpeed = value;
                if (currSpeed > MaxSpeed)
                    currSpeed = MaxSpeed;
            }
        }
    }
}
