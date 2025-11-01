function printMatrix(number) {
    for (let i = 0; i < number; i++) {
        console.log(Array(number).fill(number).join(' '));
    }
}

printMatrix(3);