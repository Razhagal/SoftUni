function checkValidity(pointsArr) {
    const x1 = pointsArr[0];
    const y1 = pointsArr[1];
    const x2 = pointsArr[2];
    const y2 = pointsArr[3];

    const result1 = Math.sqrt(Math.pow((0 - x1), 2) + Math.pow((0 - y1), 2));
    const result2 = Math.sqrt(Math.pow((x2 - 0), 2) + Math.pow((y2 - 0), 2));
    const result3 = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

    if (result1 % 1 != 0) {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }

    if (result2 % 1 != 0) {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }

    if (result3 % 1 != 0) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
}

checkValidity([3, 0, 0, 4]);