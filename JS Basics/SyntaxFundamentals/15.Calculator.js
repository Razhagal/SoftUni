function basicCalc(number1, symbol, number2) {
    let result = 0;
    switch (symbol) {
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '/':
            result = number1 / number2;
            break;
    }

    console.log(result.toFixed(2));
}

basicCalc(25.5, '-', 3);