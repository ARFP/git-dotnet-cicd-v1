using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApp.Models;

namespace PeopleApp.Repository
{
    public class PeopleRepository
    {
        private List<Person> people;


        public PeopleRepository() 
        {
            people = new List<Person>() {
                new Person("Mike", 42),
                new Person("Cindy", 37),
                new Person("Camille", 16),
            };
        }

        public int Count()
        {
            return people.Count;
        }

        public bool Add(Person person)
        {
            if(!string.IsNullOrEmpty(person.Firstname) && person.Age > 0) {
                people.Add(person);
                return true;
            }
            return false;
        }
    }
}