function modifyNumber(inputNum) {
    let currentDigitsSum = getDigitsSum(inputNum);
    let currentNumLength = inputNum.toString().length;

    if (currentAverageIsAbove5(currentDigitsSum, currentNumLength)) {
        // Number already has average digits above 5
        console.log(inputNum);
    } else {
        let numbersAddedAmount = 0;
        while (true) {
            currentDigitsSum += 9;
            currentNumLength++;
            numbersAddedAmount++;
            
            if (currentAverageIsAbove5(currentDigitsSum, currentNumLength)) {
                break;
            }
        }

        console.log(`${inputNum}${'9'.repeat(numbersAddedAmount)}`);
    }

    function getDigitsSum(number) {
        let sum = 0;
        while (number > 0) {
            const currentNum = number % 10;
            sum += currentNum;
    
            number = Math.floor(number / 10);
        }

        return sum;
    }

    function currentAverageIsAbove5(currentSum, digitsCount) {
        if (currentSum / digitsCount > 5) {
            return true;
        } else {
            return false;
        }
    }
}

modifyNumber(101);