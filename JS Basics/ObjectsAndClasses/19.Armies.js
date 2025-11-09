function storeArmyData(armyDataArr) {
    const leaders = {};

    for (const armyDataRow of armyDataArr) {
        if (armyDataRow.endsWith('arrives')) {
            const leaderName = armyDataRow.split('arrives')[0].trim();
            leaders[leaderName] = {
                army: [],
                totalArmiesCount: 0
            };
        } else if (armyDataRow.includes(':')) {
            const [leaderName, armyData] = armyDataRow.split(': ');
            if (leaders.hasOwnProperty(leaderName)) {
                const [armyName, armyCount] = armyData.split(', ');
                leaders[leaderName].army.push({
                    name: armyName,
                    count: Number(armyCount)
                });
                
                leaders[leaderName].totalArmiesCount += Number(armyCount);
            }
        } else if (armyDataRow.includes('+')) {
            const [armyName, increasedCount] = armyDataRow.split(' + ');
            Object.values(leaders).forEach(leader => {
                let armyFound = false;
                leader.army.forEach(army => {
                    if (army.name === armyName) {
                        army.count += Number(increasedCount);
                        armyFound = true;
                    }
                });

                if (armyFound) {
                    leader.totalArmiesCount += Number(increasedCount);
                }
            });
        } else if (armyDataRow.endsWith('defeated')) {
            const defeatedLeader = armyDataRow.split('defeated')[0].trim();
            if (leaders.hasOwnProperty(defeatedLeader)) {
                delete leaders[defeatedLeader];
            }
        }
    }

    Object.values(leaders).forEach(leaderArmies => {
        leaderArmies.army.sort((a, b) => b.count - a.count);
    });
    
    const sortedLeaders = Object.entries(leaders)
        .sort((a, b) => b[1].totalArmiesCount - a[1].totalArmiesCount)
        .reduce((obj, [key, value]) => {
            obj[key] = value;
            return obj;
        }, {});

    Object.entries(sortedLeaders).forEach(leaderKvP => {
        console.log(`${leaderKvP[0]}: ${leaderKvP[1].totalArmiesCount}`);
        leaderKvP[1].army.forEach(army => {
            console.log(`>>> ${army.name} - ${army.count}`);
        });
    });
}

storeArmyData([
    'Rick Burr arrives',
    'Fergus: Wexamp, 30245',
    'Rick Burr: Juard, 50000',
    'Findlay arrives',
    'Findlay: Britox, 34540',
    'Wexamp + 6000',
    'Juard + 1350',
    'Britox + 4500',
    'Porter arrives',
    'Porter: Legion, 55000',
    'Legion + 302',
    'Rick Burr defeated',
    'Porter: Retix, 3205']);