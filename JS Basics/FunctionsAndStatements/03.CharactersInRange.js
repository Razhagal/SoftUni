function charactersInRange(firstChar, secondChar) {
    const firstCharValue = firstChar.charCodeAt(0);
    const secondCharValue = secondChar.charCodeAt(0);

    const startCode = Math.min(firstCharValue, secondCharValue) + 1;
    const endCode = Math.max(firstCharValue, secondCharValue) - 1;

    const resultChars = [];
    for (let i = startCode; i <= endCode; i++) {
        resultChars.push(String.fromCharCode(i));
    }

    console.log(resultChars.join(' '));
}

charactersInRange('C', '#');