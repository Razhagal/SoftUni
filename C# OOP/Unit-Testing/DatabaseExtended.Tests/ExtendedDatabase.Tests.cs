using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private int defaultDbCapacity = 16;
        private ExtendedDatabase.ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            Person[] setupPersons = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Pesho2"),
                new Person(3, "Pesho3"),
                new Person(4, "Pesho4"),
            };

            db = new ExtendedDatabase.ExtendedDatabase(setupPersons);
        }

        [Test]
        public void InitDatabaseWithMoreThanDefaultCapacityElementsShouldThrowArgumentException()
        {
            int initCap = 17;
            Person[] initPeople = new Person[initCap];
            for (int i = 0; i < initCap; i++)
            {
                initPeople[i] = new Person(i + 1, "Pesho" + i);
            }

            Assert.That(() =>
            {
                db = new ExtendedDatabase.ExtendedDatabase(initPeople);
            }, Throws.ArgumentException);
        }

        [Test]
        public void InitDatabaseWithFivePeopleShouldCreateDbWithCapacityOfFive()
        {
            int initCap = 5;
            Person[] initPeople = new Person[initCap];
            for (int i = 0; i < initCap; i++)
            {
                initPeople[i] = new Person(i + 1, "Pesho" + i);
            }

            db = new ExtendedDatabase.ExtendedDatabase(initPeople);

            Assert.AreEqual(db.Count, 5);
        }

        [Test]
        public void AddPersonToDbShouldAddAndIncreseCapacity()
        {
            int currentCap = db.Count;
            db.Add(new Person(5, "Gosho"));

            Assert.AreEqual(db.Count, currentCap + 1);
        }

        [Test]
        public void AddPersonToFullDatabaseShouldThrowInvalidOperationException()
        {
            Person[] initPeople = new Person[defaultDbCapacity];
            for (int i = 0; i < defaultDbCapacity; i++)
            {
                initPeople[i] = new Person(i + 1, "Pesho" + i);
            }

            db = new ExtendedDatabase.ExtendedDatabase(initPeople);

            Assert.That(() => db.Add(new Person(111, "Gosho")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddPersonWithDuplicateUsernameShouldThrowInvalidOperationException()
        {
            db.Add(new Person(123123, "Gosho"));

            Assert.That(() => db.Add(new Person(321321, "Gosho")), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddPersonWithDuplicateIdShouldThrowInvalidOperationException()
        {
            db.Add(new Person(123123, "Gosho"));

            Assert.That(() => db.Add(new Person(123123, "Gosho2")), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveFromEmptyDbShouldThrowInvalidOperationException()
        {
            db = new ExtendedDatabase.ExtendedDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFromNonEmptyDbShouldDecreaseTheCapacity()
        {
            int currentCap = db.Count;
            db.Remove();

            Assert.AreEqual(db.Count, currentCap - 1);
        }

        [Test]
        public void FindByUsernameShouldReturnFoundPerson()
        {
            Person foundPerson = db.FindByUsername("Pesho");

            Assert.IsNotNull(foundPerson);
        }

        [Test]
        public void FindByUsernameEmptyNameShouldThrowArgumentNullException()
        {
            Assert.That(() => db.FindByUsername(string.Empty), Throws.ArgumentNullException.With.Message.Contains("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameNullNameShouldThrowArgumentNullException()
        {
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException.With.Message.Contains("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameNotFoundShouldThrowInvalidOperationException()
        {
            Assert.That(() => db.FindByUsername("AsdDsa"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdSholdReturnFoundPerson()
        {
            Person foundPerson = db.FindById(1);

            Assert.IsNotNull(foundPerson);
        }

        [Test]
        public void FindByIdNegativeValueShouldThrowArgumentOutOfRangeException()
        {
            Assert.That(() => db.FindById(-1), Throws.Exception.AssignableFrom(typeof(ArgumentOutOfRangeException)).With.Message.Contains("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdNotFoundShouldThrowInvalidOperationException()
        {
            Assert.That(() => db.FindById(1231221), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }
    }
}