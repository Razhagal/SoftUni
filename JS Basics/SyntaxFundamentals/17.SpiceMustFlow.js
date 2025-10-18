function calculateSpiceExtraction(startYield) {
    let currentDailyYield = startYield;
    const dailyYieldDrop = 10;
    const crewDailyConsumption = 26;
    const crewConsumptionOnMineExhaust = 26;
    let daysCount = 0;
    let totalYield = 0;

    while (currentDailyYield >= 100) {
        
        totalYield += (currentDailyYield - crewDailyConsumption);

        currentDailyYield -= dailyYieldDrop;
        daysCount++;
    }

    if (totalYield >= crewConsumptionOnMineExhaust) {
        totalYield -= crewConsumptionOnMineExhaust;
    }

    console.log(daysCount);
    console.log(totalYield);
}

calculateSpiceExtraction(5);