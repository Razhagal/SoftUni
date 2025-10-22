function extractWordsStartingWithHash(inputText) {
    const extractedWords = inputText.match(/#\b[A-Za-z]+\b/g);
    for (let i = 0; i < extractedWords.length; i++) {
        console.log(extractedWords[i].slice(1));
    }
}

extractWordsStartingWithHash('The symbol # is known #variously in English-speaking #regions as the #number sign');