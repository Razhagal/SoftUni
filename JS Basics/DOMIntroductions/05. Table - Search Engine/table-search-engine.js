function solve() {
    const allRows = document.querySelectorAll('table.container tbody tr');
    const searchedText = document.querySelector('#searchField').value.toLowerCase();
    
    if (searchedText == '') return;

    allRows.forEach(row => {
        row.classList.remove('select');

        [...row.children].forEach(td => {
            if (td.textContent.toLowerCase().includes(searchedText)) {
                row.classList.add('select');
            }
        })
    });
}