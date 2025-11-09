function getFlightSchedule(inputFlightsData) {
    const allFlights = [];
    for (const flightData of inputFlightsData[0]) {
        // const [flight, destination] = flightData.split(' ');
        const flight = flightData.substring(0, flightData.indexOf(' '));
        const destination = flightData.substring(flightData.indexOf(' ') + 1);
        allFlights[flight] = {
            Destination: destination,
            Status: ''
        };
    }

    for (const flightData of inputFlightsData[1]) {
        const [flight, status] = flightData.split(' ');
        if (allFlights.hasOwnProperty(flight)) {
            allFlights[flight].Status = status;
        }
    }

    const flightStatus = inputFlightsData[2][0];
    let result = {};
    if (flightStatus === 'Ready to fly') {
        Object.entries(allFlights)
            .forEach(flight => {
                if (flight[1].Status === '') {
                    flight[1].Status = flightStatus;
                }
            });

        result = Object.entries(allFlights)
            .map((flight) => flight[1])
            .filter(flight => flight.Status === flightStatus);
    } else {
        result = Object.entries(allFlights)
            .map((flight) => flight[1])
            .filter(flight => flight.Status === flightStatus);
    }
    
    result.forEach(flight => {
        console.log(flight);
    });
}

getFlightSchedule([
    ['WN269 Delaware',
    'FL2269 Oregon',
    'WN498 Las Vegas',
    'WN3145 Ohio',
    'WN612 Alabama',
    'WN4010 New York',
    'WN1173 California',
    'DL2120 Texas',
    'KL5744 Illinois',
    'WN678 Pennsylvania'],
    ['DL2120 Cancelled',
     'WN612 Cancelled',
     'WN1173 Cancelled',
     'SK430 Cancelled'],
    ['Cancelled']]
);

// getFlightSchedule([['WN269 Delaware',
//     'FL2269 Oregon',
//     'WN498 Las Vegas',
//     'WN3145 Ohio',
//     'WN612 Alabama',
//     'WN4010 New York',
//     'WN1173 California',
//     'DL2120 Texas',
//     'KL5744 Illinois',
//     'WN678 Pennsylvania'],
//     ['DL2120 Cancelled',
//      'WN612 Cancelled',
//      'WN1173 Cancelled',
//      'SK330 Cancelled'],
//     ['Ready to fly']]
//  );