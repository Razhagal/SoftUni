using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car defaultCar;
        private string defaultMake = "Ford";
        private string defaultModel = "Mustang";
        private int defaultFuelConsumption = 10;
        private int defaultFuelCapacity = 60;

        [SetUp]
        public void Setup()
        {
            defaultCar = new Car(defaultMake, defaultModel, defaultFuelConsumption, defaultFuelCapacity);
        }

        [Test]
        public void CarContructorCreatesCarWithValidParameters()
        {
            Assert.AreEqual(defaultCar.Make, defaultMake, "Car Make doesn't match!");
            Assert.AreEqual(defaultCar.Model, defaultModel, "Car Model doesn't match!");
            Assert.AreEqual(defaultCar.FuelConsumption, defaultFuelConsumption, "Car FuelConsumption doesn't match!");
            Assert.AreEqual(defaultCar.FuelCapacity, defaultFuelCapacity, "Car FuelCapacity doesn't match!");
            Assert.AreEqual(defaultCar.FuelAmount, 0, "New Cars should't have fuel!");
        }

        [Test]
        public void CreateCarWithoutMakeShouldThrowArgumentException()
        {
            Assert.That(() => new Car(null, defaultModel, defaultFuelConsumption, defaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void CreateCarWithoutModelShouldThrowArgumentException()
        {
            Assert.That(() => new Car(defaultMake, null, defaultFuelConsumption, defaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void CreateCarNegativeConsumptionShouldThrowArgumentException()
        {
            Assert.That(() => new Car(defaultMake, defaultModel, -1, defaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void CreateCarNegativeFuelCapacityShouldThrowArgumentException()
        {
            Assert.That(() => new Car(defaultMake, defaultModel, defaultFuelConsumption, -1), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void RefuelCarShouldIncreaseFuelAmount()
        {
            double currentFuel = defaultCar.FuelAmount;
            defaultCar.Refuel(5);

            Assert.AreEqual(defaultCar.FuelAmount, currentFuel + 5);
        }

        [Test]
        public void RefuelCarZeroAmountShouldThrowArgumentException()
        {
            Assert.That(() => defaultCar.Refuel(0), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelCarNegativeAmountShouldThrowArgumentException()
        {
            Assert.That(() => defaultCar.Refuel(-1), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelCarMoreFuelShouldNotExceedCapacity()
        {
            defaultCar.Refuel(defaultCar.FuelCapacity + 20);

            Assert.AreEqual(defaultCar.FuelAmount, defaultCar.FuelCapacity, "Fuel Amount cannot exceed Fuel Capacity!");
        }

        [Test]
        public void DriveCarShouldDecreaseFuel()
        {
            defaultCar.Refuel(30);

            double initialCarFuelAmount = defaultCar.FuelAmount;
            defaultCar.Drive(100);

            Assert.IsTrue(defaultCar.FuelAmount < initialCarFuelAmount, "Car Fuel Amount should decrease when driven!");
        }

        public void DriveCarNotEnoughtFuelShouldThrowInvalidOperationException()
        {
            defaultCar.Refuel(5);

            Assert.That(() => defaultCar.Drive(500), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}