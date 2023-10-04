using System.Data;
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
                new Person("Stefany", 37),
                new Person("Camille", 18),
            };
        }

        public int Count()
        {
            return people.Count;
        }

        public Person? Get(string _firstname) 
        {
            return people.FirstOrDefault(p => p.Firstname == _firstname);
        }

        public void Add(Person person)
        {
            if(!person.HasFirstname()) {
                throw new NoNullAllowedException("Le prénom ne peut être vide.");
            }

            if(!person.IsAdult()) {
                throw new InvalidDataException("La personne doit être majeure.");
            }

            if(Get(person.Firstname) != null)
            {
                throw new InvalidDataException("Le prénom existse déjà.");
            }

            people.Add(person);
        }
    }
}
