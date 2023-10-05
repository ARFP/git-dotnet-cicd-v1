using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleApp.Models;
namespace PeopleApp.Tests;

[TestClass]
public class PersonTest
{
    [TestMethod]
    public void Test_InitialData()
    {
        Person person = new Person("Jack", 20);

        Assert.IsTrue(person.HasFirstname());

        Person person2 = new Person("", 21);

        Assert.IsFalse(person2.HasFirstname());
    }

    [TestMethod]
    public void Test_IsAdult()
    {
        Person person3 = new Person("Jack", 20);

        Assert.IsTrue(person3.IsAdult());

        Person person4 = new Person("Jack", 16);

        Assert.IsFalse(person4.IsAdult());
    }
}