function checkIfPasswordIsValid(inputPass) {
    
    const isCorrectLength = inputPass.length >= 6 && inputPass.length <= 10;
    const digitsMatchResult = inputPass.match(/[0-9]/g);
    let digitsCount = 0;
    if (digitsMatchResult !== null) {
        digitsCount = digitsMatchResult.length;
    }
    
    const lettersAndDigitsRegex = /^[a-zA-Z\d]+$/g;
    const isOnlyDigitsAndLetters = lettersAndDigitsRegex.test(inputPass);

    if (isCorrectLength && digitsCount >= 2 && isOnlyDigitsAndLetters) {
        console.log('Password is valid');
    } else {
        if (!isCorrectLength) {
            console.log('Password must be between 6 and 10 characters');
        }

        if (!isOnlyDigitsAndLetters) {
            console.log('Password must consist only of letters and digits');
        }

        if (digitsCount < 2) {
            console.log('Password must have at least 2 digits');
        }
    }
}

checkIfPasswordIsValid('Pa$s$s');