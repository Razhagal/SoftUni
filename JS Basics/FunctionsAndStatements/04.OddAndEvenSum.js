function calculateOddAndEvenSums(number) {
    let oddSum = 0;
    let evenSum = 0;

    while (number > 0) {

        const currentNum = number % 10;
        if (currentNum % 2 > 0) {
            oddSum += currentNum;
        } else {
            evenSum += currentNum;
        }

        number = Math.floor(number / 10);
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

calculateOddAndEvenSums(3495892137259234);