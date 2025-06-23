using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;

    [SetUp]
    public void DummyTestsSetup()
    {
        axe = new Axe(10, 10);
    }

    [Test]
    public void DummyShouldLooseHealthEqualToWeaponDmgIfAttacked()
    {
        Dummy dummy = new Dummy(20, 10);
        int expectedHpLeft = dummy.Health - axe.AttackPoints;

        axe.Attack(dummy);

        Assert.AreEqual(dummy.Health, expectedHpLeft);
    }

    [Test]
    public void DeadDummyShouldThrowExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(() => dummy.TakeAttack(axe.AttackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyShouldGiveExperience()
    {
        Dummy dummy = new Dummy(0, 10);

        int exp = dummy.GiveExperience();

        Assert.That(exp > 0);
    }

    [Test]
    public void AliveDummyShouldntGiveExperienceShouldThrowException()
    {
        Dummy dummy = new Dummy(1, 10);

        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
