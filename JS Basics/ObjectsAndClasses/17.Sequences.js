function storeSequences(sequencesArr) {
    const storedSequences = [];

    const firstSequence = JSON.parse(sequencesArr[0]);
    firstSequence.sort((a, b) => b - a);

    storedSequences.push(firstSequence);

    for (let i = 1; i < sequencesArr.length; i++) {
        const currentSequence = JSON.parse(sequencesArr[i]).sort((a, b) => b - a);
        let isCurrentSequenceUnique = true;

        for (let j = 0; j < storedSequences.length; j++) {
            const previousStoredSequence = storedSequences[j];
            if (JSON.stringify(currentSequence) == JSON.stringify(previousStoredSequence)) {
                isCurrentSequenceUnique = false;
            }
        }

        if (isCurrentSequenceUnique) {
            storedSequences.push(currentSequence);
        }
    }

    storedSequences.sort((a, b) => a.length - b.length);
    storedSequences.forEach(seq => console.log(`[${seq.join(', ')}]`));
}

// storeSequences(["[-3, -2, -1, 0, 1, 2, 3, 4]", "[10, 1, -17, 0, 2, 13]", "[4, -3, 3, -2, 2, -1, 1, 0]"]);
storeSequences(["[7.14, 7.180, 7.339, 80.099]", "[7.339, 80.0990, 7.140000, 7.18]", "[7.339, 7.180, 7.14, 80.099]"]);