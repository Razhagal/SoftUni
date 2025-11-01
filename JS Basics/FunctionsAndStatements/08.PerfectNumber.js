function checkIfPerfect(inputNumber) {
    let sum = 0;

    for (let i = 1; i <= inputNumber / 2; i++) {
        if (inputNumber % i == 0) {
            sum += i;
        }
    }

    if (sum == inputNumber) {
        console.log('We have a perfect number!');
    } else {
        console.log('It\'s not so perfect.');
    }
}

checkIfPerfect(28);