using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string SNN { get; set; } = "";
        public int Age { get; set; }
        public Person() { }
        public Person(string firstName,string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public override string ToString() => $"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]";
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
