function showLoadingBar(inputProgress) {

    const currentProgress = inputProgress / 10;
    const progressBar = `[${'%'.repeat(currentProgress)}${'.'.repeat(10 - currentProgress)}]`;
    
    if (currentProgress == 10) {
        // completed
        console.log('100% Complete!');
        console.log(progressBar);
    } else {
        console.log(`${inputProgress}% ${progressBar}`);
        console.log('Still loading...');
    }
}

showLoadingBar(30);