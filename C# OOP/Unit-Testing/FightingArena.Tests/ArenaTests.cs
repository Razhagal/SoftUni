using FightingArena;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena defaultArena;
        private Warrior testWarrior;

        [SetUp]
        public void Setup()
        {
            defaultArena = new Arena();
            testWarrior = new Warrior("Gogo", 10, 50);
        }

        [Test]
        public void CreateArenaShouldBeEmpty()
        {
            Assert.AreEqual(defaultArena.Count, 0);
        }

        [Test]
        public void EnrollWarriorToArenaShouldCountIt()
        {
            defaultArena.Enroll(testWarrior);

            Assert.AreEqual(defaultArena.Count, 1);
        }

        [Test]
        public void EnrollWarriorShouldAddItToArenaWarriors()
        {
            defaultArena.Enroll(testWarrior);

            Assert.IsTrue(defaultArena.Warriors.FirstOrDefault(w => w.Name.Equals("Gogo")) == testWarrior);
        }

        [Test]
        public void EnrollWarriorWithDuplicateNameShouldThrowInvalidOperationException()
        {
            defaultArena.Enroll(testWarrior);

            Assert.That(() => defaultArena.Enroll(testWarrior), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightEnrolledWarriorsShouldResultInLegitFight()
        {
            Warrior warrior2 = new Warrior("Jojo", 20, 60);
            defaultArena.Enroll(testWarrior);
            defaultArena.Enroll(warrior2);

            int initialWarrior2Hp = warrior2.HP;
            defaultArena.Fight("Gogo", "Jojo");

            Assert.AreEqual(warrior2.HP, initialWarrior2Hp - testWarrior.Damage);
        }

        [Test]
        public void FightMissingAttackerShouldThrowInvalidOperationException()
        {
            string attackerName = "Jojo";
            defaultArena.Enroll(testWarrior);

            Assert.That(() => defaultArena.Fight(attackerName, testWarrior.Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attackerName} enrolled for the fights!"));
        }

        [Test]
        public void FightMissingDefenderShouldThrowInvalidOperationException()
        {
            string defenderName = "Jojo";
            defaultArena.Enroll(testWarrior);

            Assert.That(() => defaultArena.Fight(testWarrior.Name, defenderName), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }
    }
}
