function processCrystals(paramsArr) {
    const desiredThickness = paramsArr[0];

    for (let i = 1; i < paramsArr.length; i++) {
        processCrystal(desiredThickness, paramsArr[i]);
    }

    function processCrystal(targetThickness, crystalThickness) {
        console.log(`Processing chunk ${crystalThickness} microns`);

        let cutAttempts = 0;
        while (crystalThickness / 4 >= targetThickness) {
            crystalThickness /= 4;
            cutAttempts++;
        }

        if (cutAttempts > 0) {
            console.log(`Cut x${cutAttempts}`);

            crystalThickness = Math.floor(crystalThickness);
            console.log('Transporting and washing');
        }

        let lapAttempts = 0;
        while ((crystalThickness - crystalThickness * 0.2) >= targetThickness) {
            crystalThickness -= (crystalThickness * 0.2);
            lapAttempts++;
        }

        if (lapAttempts > 0) {
            console.log(`Lap x${lapAttempts}`);

            crystalThickness = Math.floor(crystalThickness);
            console.log('Transporting and washing');
        }

        let grindAttempts = 0;
        while (crystalThickness - 20 >= targetThickness) {
            crystalThickness -= 20;
            grindAttempts++;
        }

        if (grindAttempts > 0) {
            console.log(`Grind x${grindAttempts}`);

            crystalThickness = Math.floor(crystalThickness);
            console.log('Transporting and washing');
        }

        let etchAttempts = 0;
        while (crystalThickness - 2 >= targetThickness - 1) {
            crystalThickness -= 2;
            etchAttempts++;
        }

        if (etchAttempts > 0) {
            console.log(`Etch x${etchAttempts}`);

            crystalThickness = Math.floor(crystalThickness);
            console.log('Transporting and washing');
        }

        if (crystalThickness < targetThickness) {
            crystalThickness += 1;
            console.log(`X-ray x1`);
        }

        console.log(`Finished crystal ${crystalThickness} microns`);
    }
}

processCrystals([1000, 4000, 8100]);