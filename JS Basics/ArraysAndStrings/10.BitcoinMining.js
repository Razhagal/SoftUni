function calculatePurchasedBitcoinsAmount(minedGoldEachDayArr) {
    const bitcoinPrice = 11949.16;
    const pricePerGoldGram = 67.51;
    const stolenAmount = 0.7;

    let firstBitcoinBoughtDay = 0;
    let accumulatedMoney = 0;
    let totalBitcoinsBought = 0;
    for (let i = 0; i < minedGoldEachDayArr.length; i++) {
        let minedGramsOfGold = minedGoldEachDayArr[i];

        if ((i + 1) % 3 == 0) {
            minedGramsOfGold *= stolenAmount;
        }

        accumulatedMoney += minedGramsOfGold * pricePerGoldGram;
        if (accumulatedMoney >= bitcoinPrice) {
            const bitcoinsBoughtToday = Math.floor(accumulatedMoney / bitcoinPrice);
            totalBitcoinsBought += bitcoinsBoughtToday;

            accumulatedMoney -= (bitcoinsBoughtToday * bitcoinPrice);

            if (firstBitcoinBoughtDay == 0) {
                firstBitcoinBoughtDay = i + 1;
            }
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoinsBought}`);
    if (firstBitcoinBoughtDay > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinBoughtDay}`);
    }
    
    console.log(`Left money: ${accumulatedMoney.toFixed(2)} lv.`);
}

calculatePurchasedBitcoinsAmount([100, 200, 300]);