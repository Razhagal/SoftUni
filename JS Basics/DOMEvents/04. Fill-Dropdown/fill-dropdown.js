document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('input[type="submit"]').addEventListener('click', addDropdownItem);

    function addDropdownItem(e) {
        e.preventDefault();

        const textInput = document.querySelector('#newItemText');
        const valueInput = document.querySelector('#newItemValue');

        const newOptionItem = document.createElement('option');
        newOptionItem.textContent = textInput.value;
        newOptionItem.value = valueInput.value;

        document.querySelector('#menu').appendChild(newOptionItem);

        textInput.value = '';
        valueInput.value = '';
    }
}