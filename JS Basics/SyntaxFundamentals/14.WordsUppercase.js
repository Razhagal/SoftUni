function wordsToUpper(text) {
    const regex = /[^A-Za-z\d]+/g;
    const result = text
        .split(regex)
        .filter(Boolean)
        .map(word => word.toUpperCase());
    console.log(result.join(', '));
}

wordsToUpper('Hi, how are you?');