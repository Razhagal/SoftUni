document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('#input input[type="submit"]').addEventListener('click', generateFurnitures);
    document.querySelector('#shop input[type="submit"]').addEventListener('click', onBuyBtnClick);

    function generateFurnitures(e) {
        e.preventDefault();

        const furnituresList = JSON.parse(e.target.parentElement.querySelector('textarea').value);
        const resultTableBody = document.querySelector('#shop table tbody');

        for (const itemData of furnituresList) {
            const imgCell = document.createElement('td');
            imgCell.innerHTML = `<img src="${itemData.img}">`;
            
            const nameCell = document.createElement('td');
            nameCell.innerHTML = `<p>${itemData.name}</p>`;
            
            const priceCell = document.createElement('td');
            priceCell.innerHTML = `<p>${itemData.price}</p>`;
            
            const factorCell = document.createElement('td');
            factorCell.innerHTML = `<p>${itemData.decFactor}</p>`;
            
            const checkboxCell = document.createElement('td');
            checkboxCell.innerHTML = '<input type="checkbox" />';
            
            const newRowElement = document.createElement('tr');
            newRowElement.appendChild(imgCell);
            newRowElement.appendChild(nameCell);
            newRowElement.appendChild(priceCell);
            newRowElement.appendChild(factorCell);
            newRowElement.appendChild(checkboxCell);

            resultTableBody.appendChild(newRowElement);
        }
    }

    function onBuyBtnClick(e) {
        e.preventDefault();

        const selectedFurnitureRows = document.querySelectorAll('#shop table tbody tr:has(input[type="checkbox"]:checked)');
        console.log(selectedFurnitureRows);
        if (selectedFurnitureRows.length > 0) {
            const selectedFurnitures = [];

            selectedFurnitureRows.forEach(item => {
                selectedFurnitures.push({
                    name: item.children[1].innerText,
                    price: Number(item.children[2].innerText),
                    decFact: Number(item.children[3].innerText)
                });
            });
            
            console.log(selectedFurnitures);

            const names = selectedFurnitures.map(f => f.name);
            const totalPrice = selectedFurnitures.reduce((sum, current) => {
                return sum + current.price;
            }, 0)
            const averageDecFactor = selectedFurnitures.reduce((sum, current) => {
                return sum + current.decFact;
            }, 0) / selectedFurnitures.length;

            let result = `Bought furniture: ${names.join(', ')}\nTotal price: ${totalPrice}\nAverage decoration factor: ${averageDecFactor}`;
            document.querySelector('#shop textarea').value = result;
        }
    }
}