using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private int defaultDbCapacity = 16;
        private Database.Database db;

        [SetUp]
        public void Setup()
        {
            db = db = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void DatabaseConstructorShouldCreateDbWithCorrectCapacity()
        {
            db = new Database.Database(1, 2, 3, 4);
            Assert.AreEqual(db.Count, 4);
        }

        [Test]
        public void DatabaseConstructorShouldCreateAnArrayWithNumbers()
        {
            db = new Database.Database(1, 2, 3, 4);
            int[] dbArr = db.Fetch();
            for (int i = 0; i < dbArr.Length; i++)
            {
                Assert.AreEqual(dbArr[i], i + 1, $"Index {i} is not correct value");
            }
        }

        [Test]
        public void DatabaseCapacityShouldBe16()
        {
            Assert.AreEqual(db.Count, defaultDbCapacity);
        }

        [Test]
        public void AddToNonFullDatabaseShouldIncreaseCountByOne()
        {
            db = new Database.Database(1, 2, 3, 4, 5);
            int currentCount = db.Count;
            db.Add(6);

            Assert.AreEqual(db.Count, currentCount + 1);
        }

        [Test]
        public void AddToFullDatabaseShouldThrowInvalidOperationException()
        {
            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFromNonEmptyDatabaseShouldDecreaseCapacity()
        {
            db.Remove();
            Assert.AreEqual(db.Count, defaultDbCapacity - 1);
        }

        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowInvalidOperationException()
        {
            db = new Database.Database();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FetchShouldReturnArrayWithDatabaseElements()
        {
            var fetchedArr = db.Fetch();
            Assert.AreEqual(fetchedArr.GetType(), typeof(int[]));
        }
    }
}