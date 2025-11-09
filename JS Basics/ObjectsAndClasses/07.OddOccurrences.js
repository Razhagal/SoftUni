function printOddWordOccurrences(words) {
    const splitWords = words.split(' ')
        .filter(word => word);

    splitWords.forEach((word, index) => {
        splitWords[index] = word.toLowerCase();
    });

    const wordsCounts = new Map();
    for (const word of splitWords) {
        wordsCounts.set(word, (wordsCounts.get(word) || 0) + 1);
    }

    const result = [...wordsCounts]
        .filter(([word, count]) => count % 2 > 0)
        .map(([word]) => word);

    console.log(result.join(' '));
}

printOddWordOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');