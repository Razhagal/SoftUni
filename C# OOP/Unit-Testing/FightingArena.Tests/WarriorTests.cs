using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior defaultWarrior;
        private string defaultWarriorName = "Gosho";
        private int defaultWarriorDamage = 10;
        private int defaultWarriorHP = 50;

        [SetUp]
        public void Setup()
        {
            defaultWarrior = new Warrior(defaultWarriorName, defaultWarriorDamage, defaultWarriorHP);
        }

        [Test]
        public void WarriorConstructorCreatesValidWarrior()
        {
            Assert.AreEqual(defaultWarrior.Name, defaultWarriorName, "Warrior Name doesn't match!");
            Assert.AreEqual(defaultWarrior.Damage, defaultWarriorDamage, "Warrior Damage doesn't match!");
            Assert.AreEqual(defaultWarrior.HP, defaultWarriorHP, "Warrior Health doesn't match!");
        }

        [Test]
        public void CreateWarriorWithoutNameShouldThrowArgumentException()
        {
            Assert.That(() => new Warrior(" ".Trim(), defaultWarriorDamage, defaultWarriorHP), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void CreateWarriorNullNameShouldThrowArgumentException()
        {
            Assert.That(() => new Warrior(null, defaultWarriorDamage, defaultWarriorHP), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void CreateWarriorWithZeroDamageShouldThrowArgumentException()
        {
            Assert.That(() => new Warrior(defaultWarriorName, 0, defaultWarriorHP), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void CreateWarriorWithNegativeDamageShouldThrowArgumentException()
        {
            Assert.That(() => new Warrior(defaultWarriorName, -5, defaultWarriorHP), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void CreateWarriorWithNegativeHealthShouldThrowArgumentException()
        {
            Assert.That(() => new Warrior(defaultWarriorName, defaultWarriorDamage, -5), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackWithLowHealthShouldThrowInvalidOperationException()
        {
            defaultWarrior = new Warrior(defaultWarriorName, defaultWarriorDamage, 1);
            Warrior opponent = new Warrior("Gogo", 20, 50);

            Assert.That(() => defaultWarrior.Attack(opponent), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackOtherWarriorWithLowHealthShouldThrowInvalidOperationException()
        {
            Warrior opponent = new Warrior("Gogo", 20, 1);
            
            Assert.That(() => defaultWarrior.Attack(opponent), Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackOtherWarriorWithStrongDamageShouldThrowInvalidOperationException()
        {
            Warrior opponent = new Warrior("Gogo", 200, 50);

            Assert.That(() => defaultWarrior.Attack(opponent), Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackOtherWarriorShouldDecreaseMyHealthByHisDamage()
        {
            Warrior opponent = new Warrior("Gogo", 10, 50);
            int initialHealth = defaultWarrior.HP;

            defaultWarrior.Attack(opponent);

            Assert.AreEqual(defaultWarrior.HP, initialHealth - opponent.Damage);
        }

        [Test]
        public void AttackOtherWarriorWithMoreDamageThanHisHealthShouldDropHisHpToZero()
        {
            defaultWarrior = new Warrior(defaultWarriorName, 100, defaultWarriorHP);
            Warrior opponent = new Warrior("Gogo", 10, 50);

            defaultWarrior.Attack(opponent);

            Assert.AreEqual(opponent.HP, 0);
        }

        [Test]
        public void AttackOtherWarriorShouldDecreaseHisHealthByMyDamage()
        {
            Warrior opponent = new Warrior("Gogo", 10, 50);
            int initialHealth = opponent.HP;

            defaultWarrior.Attack(opponent);

            Assert.AreEqual(opponent.HP, initialHealth - defaultWarrior.Damage);
        }
    }
}