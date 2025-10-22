function printNthElement(inputArray, step) {
    const resultArr = [];
    for (let i = 0; i < inputArray.length; i+=step) {
        resultArr.push(inputArray[i]);
    }

    return resultArr;
}

printNthElement(['5', '20', '31', '4', '20'], 2);