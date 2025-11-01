function printDNAHelix(dnaLength) {
    const pairs = ['AT', 'CG', 'TT', 'AG', 'GG'];
    
    // This will work with any width of the helix
    const helixWidth = 6;
    const symbolsPerRow = helixWidth - 2; // 2 symbols reserved for the pair;
    
    let rowIndex = 0;
    let isWidening = true;
    for (let i = 0; i < dnaLength; i++) {
        const pairsCycle = Math.floor(i / pairs.length);
        const pairIndex = i - (pairsCycle * pairs.length);

        const symbolOne = pairs[pairIndex][0];
        const symbolTwo = pairs[pairIndex][1];

        const starsCount = symbolsPerRow - (rowIndex * 2);
        const dashesCount = symbolsPerRow - starsCount;

        console.log(`${'*'.repeat(starsCount / 2)}${symbolOne}${'-'.repeat(dashesCount)}${symbolTwo}${'*'.repeat(starsCount / 2)}`)

        if (starsCount == symbolsPerRow) {
            isWidening = true;
        } else if (starsCount == 0) {
            isWidening = false;
        }

        rowIndex = isWidening ? rowIndex += 1 : rowIndex -= 1;
    }

    // width = 6
    // symbols count = width - 2 = 4
    // **SS** - 0 - stars = 4 - (0 * 2) / dashes = symbols - stars
    // *S--S* - 1 - stars = 4 - (1 * 2)
    // S----S - 2 - stars = 4 - (2 * 2)
    // *S--S* - 3
    // **SS** - 4
}

printDNAHelix(10);