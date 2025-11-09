function countWordOccurrences(wordsArr) {
    const wordsCounts = {};

    const wordsToLookFor = wordsArr[0].split(' ').filter(word => word);
    for (const word of wordsToLookFor) {
        wordsCounts[word] = 0;
    }

    for (let i = 1; i < wordsArr.length; i++) {
        if (wordsCounts.hasOwnProperty(wordsArr[i])) {
            wordsCounts[wordsArr[i]]++;
        }
    }

    const sorted = Object.entries(wordsCounts)
        .sort((a, b) => b[1] - a[1]);

    for (const word of sorted) {
        console.log(`${word[0]} - ${word[1]}`)
    }
}

countWordOccurrences([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
);