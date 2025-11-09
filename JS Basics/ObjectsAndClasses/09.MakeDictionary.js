function makeDictionaryOfTerms(termsJsonArr) {
    const dictionary = {};
    for (const termJson of termsJsonArr) {
        const parsedTerm = JSON.parse(termJson);
        for (const termKey in parsedTerm) {
            dictionary[termKey] = parsedTerm[termKey];
        }
    }

    // const orderedDictionary = Object.keys(dictionary)
    //     .sort()
    //     .reduce((obj, key) => {
    //         obj[key] = dictionary[key];
    //         return obj;
    //     }, {});

    const orderedDictionary = Object.entries(dictionary)
        .sort((a, b) => a[0].localeCompare(b[0]));

    orderedDictionary.forEach((term) => console.log(`Term: ${term[0]} => Definition: ${term[1]}`));
}

makeDictionaryOfTerms([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
);