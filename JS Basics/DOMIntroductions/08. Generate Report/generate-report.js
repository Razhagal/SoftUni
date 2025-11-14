function solve() {
    const checkboxes = document.querySelectorAll('table thead input');
    const dataRows = document.querySelectorAll('table tbody tr');

    const resultData = [];
    dataRows.forEach((row, index) => {
        const data = {};
        checkboxes.forEach((checkbox, checkIndex) => {
            if (checkbox.checked) {
                data[checkbox.name] = row.children[checkIndex].textContent;
            }
        });

        if (Object.keys(data).length > 0) {
            resultData.push(data);
        }
    });

    document.querySelector('#output').textContent = JSON.stringify(resultData);
}