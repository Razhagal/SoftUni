function manageParkingLot(parkingCommandsArr) {
    const carsInParking = new Set();

    for (let i = 0; i < parkingCommandsArr.length; i++) {
        const [command, carNumber] = parkingCommandsArr[i].split(', ').filter(element => element);
        if (command == 'IN') {
            carsInParking.add(carNumber);
        } else if (command == "OUT") {
            carsInParking.delete(carNumber);
        }
    }

    const sortedCars = [...carsInParking].sort();
    if (sortedCars.length > 0) {
        for (const number of sortedCars) {
            console.log(number);
        }
    } else {
        console.log('Parking Lot is Empty')
    }
}

manageParkingLot(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
);