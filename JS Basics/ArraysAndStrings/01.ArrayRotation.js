function rotateArray(inputArray, numberOfRotations) {
    for (let i = 0; i < numberOfRotations; i++) {
        const current = inputArray.shift();
        inputArray.push(current);
    }

    console.log(inputArray.join(' '));
}

rotateArray([51, 47, 32, 61, 21], 2);