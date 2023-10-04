using PeopleApp.Models;
using PeopleApp.Repository;

namespace PeopleApp 
{
    public class Program 
    {
        public static void Main()
        {
            string inputFirstname;
            string inputAge;
            ConsoleKey go;

            PeopleRepository repository = new PeopleRepository();

            Console.WriteLine("Programme People");

            do 
            {
                try 
                {
                    Console.WriteLine("Entrez un prénom : ");

                    inputFirstname = Console.ReadLine() ?? "";

                    Console.WriteLine("Entrez un âge : ");

                    inputAge = Console.ReadLine() ?? "";

                    if(int.TryParse(inputAge, out int age)) 
                    {
                        Person p = new Person(inputFirstname, age);
                        repository.Add(p);
                        Console.WriteLine(p.Firstname + " ajouté !");
                    }
                    else 
                    {
                        throw new InvalidDataException("L'âge doit être un nombre entier.");
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    Console.Write("Ajouter une autre personne ? (Y/n) ");
                    go = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }
            while(go == ConsoleKey.Y || go == ConsoleKey.Enter);

            Console.WriteLine("IL y a " + repository.Count() + " personnes dans la base de données");
            Console.WriteLine("Programme terminé. Appuyez sur n'importe quelle touche pour fermer.");
            Console.ReadLine();
        }
    }
}

