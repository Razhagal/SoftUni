function revealWords(words, text) {
    const wordsArr = words.split(', ');
    for (let i = 0; i < wordsArr.length; i++) {
        const template = '*'.repeat(wordsArr[i].length);
        text = text.replace(template, wordsArr[i]);
    }

    console.log(text);
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');