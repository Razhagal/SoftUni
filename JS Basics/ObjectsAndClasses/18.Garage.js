function storeCars(garagesWithCarsArr) {
    const garage = {};

    for (const garageCarData of garagesWithCarsArr) {
        const [garageNum, carData] = garageCarData.split(' - ');

        if (!garage.hasOwnProperty(garageNum)) {
            garage[garageNum] = [];
        }
        const carDataSplit = carData.split(', ');
        const carObj = {};
        for (let i = 0; i < carDataSplit.length; i++) {
            const [key, value] = carDataSplit[i].split(': ');
            carObj[key] = value;
        }

        garage[garageNum].push(carObj);
    }

    for (const garageNum in garage) {
        console.log(`Garage № ${garageNum}`);

        garage[garageNum].forEach(car => {
            let carString = '--- ';
            carString = carString.concat(
                Object.entries(car)
                    .map((carKeyValuePair) => `${carKeyValuePair[0]} - ${carKeyValuePair[1]}`)
                    .join(', ')
            );

            console.log(carString);
        });
    }
}

storeCars(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi', '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat']);