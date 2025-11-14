function solve() {
    let inputNumber = Number(document.querySelector('#input').value);

    const convertTo = document.querySelector('#selectMenuTo').value;
    let result = '';
    if (convertTo === 'binary') {
        result = (inputNumber >>> 0).toString(2);
    } else if (convertTo === 'hexadecimal') {
        result = inputNumber.toString(16).toUpperCase();
    }
    
    document.querySelector('#result').value = result;
}