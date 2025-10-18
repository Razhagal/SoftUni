function checkSpedForArea(speed, area) {
    let speedLimitForArea = 0;
    if (area === 'motorway') {
        speedLimitForArea = 130;
    } else if (area === 'interstate') {
        speedLimitForArea = 90;
    } else if (area === 'city') {
        speedLimitForArea = 50;
    } else { //residential
        speedLimitForArea = 20;
    }

    if (speed <= speedLimitForArea) {
        console.log(`Driving ${speed} km/h in a ${speedLimitForArea} zone`);
    }
    else {
        const speedAboveLimit = speed - speedLimitForArea;
        let speedingStatus = '';
        if (speedAboveLimit <= 20) {
            speedingStatus = 'speeding';
        } else if (speedAboveLimit <= 40) {
            speedingStatus = 'excessive speeding';
        } else {
            speedingStatus = 'reckless driving';
        }

        console.log(`The speed is ${speedAboveLimit} km/h faster than the allowed speed of ${speedLimitForArea} - ${speedingStatus}`)
    }
}

checkSpedForArea(120, 'interstate');