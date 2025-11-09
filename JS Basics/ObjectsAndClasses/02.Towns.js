function getTowns(townsData) {
    const towns = [];
    for (const town of townsData) {
        const townDataSplit = town.split(' | ');
        towns.push({
            town: townDataSplit[0],
            latitude: Number.parseFloat(townDataSplit[1]).toFixed(2),
            longitude: Number.parseFloat(townDataSplit[2]).toFixed(2)
        });
    }

    for (const town of towns) {
        console.log(town);
    }
}

getTowns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);