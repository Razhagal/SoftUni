using NUnit.Framework;
using Skeleton;
using Moq;
using System;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroAttackShouldIncreaseExperienceOnKilledTarget()
    {
        IWeapon axe = new Axe(10, 10);
        Hero hero = new Hero("Pesho", axe);
        int dummyExp = 10;
        ITarget dummy = new Dummy(10, dummyExp);

        int initialExp = hero.Experience;
        hero.Attack(dummy);

        Assert.That(hero.Experience, Is.EqualTo(initialExp + dummyExp));
    }

    [Test]
    public void MoqHeroAttackShouldIncreaseExperienceOnKilledTarget()
    {
        var mockWeapon = new Mock<IWeapon>();
        mockWeapon.Setup(w => w.AttackPoints).Returns(10);
        mockWeapon.Setup(w => w.DurabilityPoints).Returns(10);
        mockWeapon.Setup(w => w.Attack(It.IsAny<ITarget>())).Callback((ITarget target) => { target.TakeAttack(10); }); //target.TakeAttack(It.IsAny<int>());
        Hero hero = new Hero("Pesho", mockWeapon.Object);
        int dummyExp = 10;
        ITarget dummy = new Dummy(10, dummyExp);

        int initialExp = hero.Experience;
        hero.Attack(dummy);

        Assert.That(hero.Experience, Is.EqualTo(initialExp + dummyExp));
        //mockWeapon.Verify(w => w.Attack(dummy), Times.Once);
    }
}