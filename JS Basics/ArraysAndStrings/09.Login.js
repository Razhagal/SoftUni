function login(inputArr) {
    const user = inputArr[0];
    const userPassword = user.split("").reverse().join("");
    for (let i = 1; i < inputArr.length; i++) {
        const currentPasswordAttempt = inputArr[i];
        if (currentPasswordAttempt === userPassword) {
            console.log(`User ${user} logged in.`);
            return;
        } else {
            if (i == 4) {
                console.log(`User ${user} blocked!`)
                return;
            } else {
                console.log('Incorrect password. Try again.');
            }
        }
    }
}

login(['sunny','rainy','cloudy','sunny','not sunny']);