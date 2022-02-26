using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    internal class Car
    {
        public int Speed { get; set; }
        public string PetName { get; set; }
        public Car() { }
        public Car(string petname, int speed)
        {
            Speed = speed;
            PetName = petname;
        }
        public override string ToString() => $"PetName: {PetName}, Speed: {Speed}";
    }
}
