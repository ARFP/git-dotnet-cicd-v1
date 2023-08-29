using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleApp.Models;
using PeopleApp.Repository;
namespace PeopleApp.Tests;

[TestClass]
public class RepositoryTest
{
    [TestMethod]
    public void Test_HasItemsOnContruct()
    {
        PeopleRepository repo = new PeopleRepository(); // 3 people inside

        Assert.AreEqual(3, repo.Count());
    }

    [TestMethod]
    public void Test_AddPerson()
    {
        PeopleRepository repo = new PeopleRepository();

        int nbPeople = repo.Count(); 

        bool isAddedTrue = repo.Add(new Person("Jack", 20)); // valid data

        Assert.IsTrue(isAddedTrue);
        
        nbPeople++;

        Assert.AreEqual(nbPeople, repo.Count());
    }

    [TestMethod]
    public void Test_AddPersonNoFirstname()
    {
        PeopleRepository repo = new PeopleRepository();

        int nbPeople = repo.Count();

        bool isAddedNofirstname = repo.Add(new Person("", 20)); // empty firstname (need a least 1 char)

        Assert.IsFalse(isAddedNofirstname);

        Assert.AreEqual(nbPeople, repo.Count());    
    }

    [TestMethod]
    public void Test_AddPersonInvalidAge()
    {
        PeopleRepository repo = new PeopleRepository();

        int nbPeople = repo.Count();

        bool isAddedInvalidAge = repo.Add(new Person("Jack", -1)); // Invalid Age (must be > 0)

        Assert.IsFalse(isAddedInvalidAge);

        Assert.AreEqual(nbPeople, repo.Count());
    }
}