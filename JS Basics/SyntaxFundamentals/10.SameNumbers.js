function isSameNumbersAndSum(number) {
    let sum = 0;
    let isSameDigits = true;
    let previousDigit = number % 10;
    sum += previousDigit;
    number = Math.floor(number / 10);

    while (number > 0) {
        const digit = number % 10;
        sum += digit;
        number = Math.floor(number / 10);

        if (digit != previousDigit) {
            isSameDigits = false;
        }

        previousDigit = digit;
    }

    console.log(isSameDigits);
    console.log(sum);
}

isSameNumbersAndSum(1234);