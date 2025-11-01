function checkIntegersIfPalindromes(numbersArr) {
    for (let i = 0; i < numbersArr.length; i++) {
        console.log(checkIfPalindrome(numbersArr[i]));
    }

    function checkIfPalindrome(number) {
        const numberAsString = number.toString();
        for (let i = 0; i < numberAsString.length / 2; i++) {
            if (numberAsString[i] != numberAsString[numberAsString.length - 1 - i]) {
                return false;
            }
        }

        return true;
    }
}

checkIntegersIfPalindromes([32,2,232,1010]);