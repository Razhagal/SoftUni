function getHeroesData(heroesDataArr) {
    const heroes = [];

    for (const heroData of heroesDataArr) {
        const heroDataSplit = heroData.split(' / ').filter(item => item);
        heroes.push({
           name: heroDataSplit[0],
           level: heroDataSplit[1],
           inventory: heroDataSplit[2] 
        });
    }

    heroes.sort((heroA, heroB) => heroA.level - heroB.level);

    for (const hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.inventory}`);
    }
}

getHeroesData(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword', 'Hes / 1 / Desolator, Sentinel, Antara']);