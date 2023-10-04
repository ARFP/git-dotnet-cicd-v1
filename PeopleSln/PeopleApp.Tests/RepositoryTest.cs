using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleApp.Models;
using PeopleApp.Repository;
using System;

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

        repo.Add(new Person("Jack", 20)); // valid data 

        Person? p = repo.Get("Jack");

        Assert.IsNotNull(p);

        Assert.IsInstanceOfType(p, typeof(Person));

        Assert.AreEqual("Jack", p.Firstname);

        Assert.AreEqual(20, p.Age);

        nbPeople++;

        Assert.AreEqual(nbPeople, repo.Count());        
    }

    [TestMethod]
    public void Test_AddPersonNoFirstname()
    {
        PeopleRepository repo = new PeopleRepository(); 

        int nbPeople = repo.Count(); 

        try
        {
            repo.Add(new Person("", 20)); // empty firstname (need a least 1 char)
        }
        catch
        {
            Person? p = repo.Get("");
            Assert.IsNull(p);
        }

        Assert.AreEqual(nbPeople, repo.Count());    
    }

    [TestMethod]
    public void Test_AddPersonInvalidAge()
    {
        PeopleRepository repo = new PeopleRepository();

        int nbPeople = repo.Count();

        try
        {
            repo.Add(new Person("Léa", -1)); // empty firstname (need a least 1 char)
        }
        catch
        {
            Person? p = repo.Get("Léa");
            Assert.IsNull(p);
        }

        Assert.AreEqual(nbPeople, repo.Count());
    }

    [TestMethod]
    public void Test_AddPersonNoDuplicateAllowed()
    {
        PeopleRepository repo = new PeopleRepository();

        int nbPeople = repo.Count();

        try
        {
            repo.Add(new Person("Léa", 23));
            repo.Add(new Person("Léa", 27));
        }
        catch
        {
            Person? p = repo.Get("Léa");

            Assert.IsNotNull(p);

            Assert.IsInstanceOfType(p, typeof(Person));

            Assert.AreEqual("Léa", p.Firstname);

            Assert.AreEqual(23, p.Age);
        }

        nbPeople++;

        Assert.AreEqual(nbPeople, repo.Count());
    }
}
