function calculator() {
    this.calculate = {
        init: (inputOneId, inputTwoId, resultId) => {
            this.firstNumberInput = document.querySelector(inputOneId);
            this.secondNumberInput = document.querySelector(inputTwoId);
            this.resultField = document.querySelector(resultId);
        },
        add: () => {
            this.resultField.value = Number(this.firstNumberInput.value) + Number(this.secondNumberInput.value);
        },
        subtract: () => {
            this.resultField.value = Number(this.firstNumberInput.value) - Number(this.secondNumberInput.value);
        }
    }
    
    this.calculate.init('#num1', '#num2', '#result');
    return this.calculate;
}