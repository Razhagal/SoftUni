function storeProvision(currentStockArr, orderedProductsArr) {
    const products = {};

    for (let i = 0; i < currentStockArr.length; i+=2) {
        products[currentStockArr[i]] = Number.parseInt(currentStockArr[i + 1]);
    }

    for (let i = 0; i < orderedProductsArr.length; i+=2) {
        const productName = orderedProductsArr[i];
        if (products.hasOwnProperty(productName)) {
            products[productName] += Number.parseInt(orderedProductsArr[i + 1]);
        } else {
            products[productName] = Number.parseInt(orderedProductsArr[i + 1]);
        }
    }

    for (const productName in products) {
        console.log(`${productName} -> ${products[productName]}`);
    }
}

storeProvision(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
);