function washCar(washCommandsArr) {
    let cleanAmount = 0;
    for (let i = 0; i < washCommandsArr.length; i++) {
        switch (washCommandsArr[i]) {
            case 'soap':
                cleanAmount += 10;
                break;
            case 'water':
                cleanAmount += cleanAmount * 0.2;
                break;
            case 'vacuum cleaner':
                cleanAmount += cleanAmount * 0.25;
                break;
            case 'mud':
                cleanAmount -= cleanAmount * 0.1;
                break;
        }
    }

    console.log(`The car is ${cleanAmount.toFixed(2)}% clean.`);
}

washCar(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);