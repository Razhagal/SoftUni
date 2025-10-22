function splitPascalCaseText(inputText) {
    const resultWords = [];
    let currentWord = inputText[0];

    for (let i = 1; i < inputText.length; i++) {
        const currentChar = inputText[i];

        if (currentChar === currentChar.toUpperCase()) {
            resultWords.push(currentWord);
            currentWord = currentChar;
        } else {
            currentWord += currentChar;
        }
    }

    resultWords.push(currentWord);
    console.log(resultWords.join(', '));
}

splitPascalCaseText('SplitMeIfYouCanHaHaYouCantOrYouCan');