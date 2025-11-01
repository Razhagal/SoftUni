function addAndSubtract(firstNum, secondNum, thirdNum) {
    console.log(subtract(sum(firstNum, secondNum), thirdNum));

    function sum(firstNum, secondNum) {
        return firstNum + secondNum;
    }
    
    function subtract(firstNum, secondNum) {
        return firstNum - secondNum;
    }
}



addAndSubtract(23, 6, 10);