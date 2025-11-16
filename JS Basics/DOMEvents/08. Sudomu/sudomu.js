document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('#solutionCheck .buttons input[type="submit"]').addEventListener('click', quickCheckSudomu);
    document.querySelector('#solutionCheck .buttons input[type="reset"]').addEventListener('click', resetResult);

    function quickCheckSudomu(e) {
        e.preventDefault();

        const allRows = document.querySelectorAll('#solutionCheck table tbody tr');

        const rowsAreValid = areRowsValid(allRows);
        const columnsAreValid = areColumnsValid(allRows);
        console.log(rowsAreValid + " " + columnsAreValid);

        const resultElement = document.querySelector('#check');
        const tableElement = document.querySelector('#solutionCheck table');
        if (rowsAreValid && columnsAreValid) {
            resultElement.textContent = 'Success!';
            tableElement.style.border = '2px solid green';
        } else {
            resultElement.textContent = 'Keep trying...';
            tableElement.style.border = '2px solid red';
        }
    }

    function areRowsValid(tableData) {

        for (let row = 0; row < 3; row++) {
            const numbersInRow = [];
            let isValidRow = true;
            for (let col = 0; col < 3; col++) {
                const currentNum = Number(tableData[row].children[col].children[0].value);

                if (currentNum == 0 || numbersInRow.includes(currentNum)) {
                    isValidRow = false;
                    break;
                }

                numbersInRow.push(currentNum);
            }

            if (!isValidRow) {
                return false;
            }
        }

        return true;
    }

    function areColumnsValid(tableData) {

        for (let col = 0; col < 3; col++) {
            const numbersInColumn = [];
            let isValidColumn = true;
            for (let row = 0; row < 3; row++) {
                const currentNum = Number(tableData[row].children[col].children[0].value);

                if (currentNum == 0 || numbersInColumn.includes(currentNum)) {
                    isValidColumn = false;
                    break;
                }

                numbersInColumn.push(currentNum);
            }

            if (!isValidColumn) {
                return false;
            }
        }

        return true;
    }

    function resetResult() {
        document.querySelector('#check').textContent = '';
        document.querySelector('#solutionCheck table').style.border = '';
    }
}