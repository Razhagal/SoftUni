function solve() {
    const inputTextSplit = document.querySelector('#text').value
      .split(' ')
      .filter(el => el);
    const caseToConvertTo = document.querySelector('#naming-convention').value;

    let result = '';
    if (caseToConvertTo === 'Camel Case') {
        result = inputTextSplit[0].toLowerCase();
        result = result.concat(getPascalCaseWords(inputTextSplit, 1));
    } else if (caseToConvertTo === 'Pascal Case') {
        result = result.concat(getPascalCaseWords(inputTextSplit, 0));
    } else {
      result = 'Error!';
    }

    document.querySelector('#result').textContent = result;

    function getPascalCaseWords(wordsArr, startIndex) {
        let result = '';
        for (let i = startIndex; i < wordsArr.length; i++) {
          let currentWord = wordsArr[i].toLowerCase();

          result = result.concat(currentWord.charAt(0).toUpperCase() + currentWord.slice(1));
        }

        return result;
    }
}