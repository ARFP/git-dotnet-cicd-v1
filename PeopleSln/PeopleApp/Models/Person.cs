using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApp.Models
{
    public class Person
    {
        private string firstname;
        private int age;

        public string Firstname { get { return firstname; } set { firstname = value; }}

        public int Age { get { return age; } set { age = value; }}

        public Person() : this("John", 18) {}

        public Person(string _firstname, int _age)
        {
            firstname = _firstname;
            age = _age;
        }

        public bool HasFirstname() 
        {
            return !string.IsNullOrEmpty(firstname);
        }

        public bool IsAdult() 
        {
            return age >= 18;
        }
    }
}
