function sortNumbers(numbersArr) {
    const sortedNumbers = numbersArr.toSorted((a, b) => a - b);
    const result = [];
    for (let i = 0; i < sortedNumbers.length / 2; i++) {
        
        result.push(sortedNumbers[i]);
        if (i != sortedNumbers.length - 1 - i) {
            result.push(sortedNumbers[sortedNumbers.length - 1 - i]);
        }
    }
    
    return result;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));