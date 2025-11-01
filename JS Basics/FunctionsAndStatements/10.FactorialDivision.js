function calculateFactorialDivision(firstNum, secondNum) {
    const result = calculateFactorial(firstNum) / calculateFactorial(secondNum);
    console.log(result.toFixed(2));

    function calculateFactorial(number) {
        if (number == 1) {
            return number;
        }

        return number * calculateFactorial(number - 1);
    }
}

calculateFactorialDivision(5, 3);