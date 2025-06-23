using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    //private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void AxeTestsInit()
    {
        //axe = new Axe(10, 10);
        dummy = new Dummy(10, 10);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        axe.Attack(dummy);

        //Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack");
        Assert.IsTrue(axe.DurabilityPoints.Equals(9), "Axe durability doesn't change after attack");
    }

    [Test]
    public void AxeAttackWithNoDurabilityShouldThrowException()
    {
        Axe axe = new Axe(10, 0);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}