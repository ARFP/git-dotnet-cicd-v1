namespace PeopleApp.Models
{
    public class Person
    {
        const int MAJORITE = 18;

        public string Firstname { get; private set; }

        public int Age { get; private set; }

        public Person() : this("John", 18) {}

        public Person(string _firstname, int _age)
        {
            Firstname = _firstname;
            Age = _age;
        }

        public bool HasFirstname() 
        {
            return !string.IsNullOrEmpty(Firstname);
        }

        public bool IsAdult() 
        {
            return Age >= MAJORITE;
        }
    }
}
