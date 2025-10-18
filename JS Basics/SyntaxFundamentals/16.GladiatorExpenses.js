function calculateExpenses(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    const helmBreakRounds = 2;
    const swordBreakRounds = 3;
    const shieldBreakRounds = helmBreakRounds + 1 + swordBreakRounds; // Add +1 to helm breaking rounds to align it with sword break rounds
    const armorBreakRounds = shieldBreakRounds * 2;

    const timesHelmBroken = Math.floor(lostFightsCount / helmBreakRounds);
    const timesSwordBroken = Math.floor(lostFightsCount / swordBreakRounds);
    const timesShieldBroken = Math.floor(lostFightsCount / shieldBreakRounds);
    const timesArmorBroken = Math.floor(lostFightsCount / armorBreakRounds);

    // console.log(timesHelmBroken, timesSwordBroken, timesShieldBroken, timesArmorBroken);

    const finalRepairBill = (timesHelmBroken * helmetPrice) + (timesSwordBroken * swordPrice) + (timesShieldBroken * shieldPrice) + (timesArmorBroken * armorPrice);
    console.log(`Gladiator expenses: ${finalRepairBill.toFixed(2)} aureus`);
}

calculateExpenses(23, 12.5, 21.5, 40, 200);