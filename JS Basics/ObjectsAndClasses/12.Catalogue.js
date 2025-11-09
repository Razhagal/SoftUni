function getSortedStoreProducts(inputProductsArr) {
    const products = {};

    for (const product of inputProductsArr) {
        const [productName, productPrice] = product.split(' : ').filter(element => element);
        const productNameInitial = productName.charAt(0);
        if (!products.hasOwnProperty(productNameInitial)) {
            products[productNameInitial] = [];
        }

        products[productNameInitial].push({
            name: productName,
            price: productPrice
        });
    }

    for (const key in products) {
        products[key].sort((a, b) => a.name.localeCompare(b.name));
    }

    const sortedProducts = Object.entries(products)
        .sort((a, b) => a[0].localeCompare(b[0]));

    for (const productGroup of sortedProducts) {
        console.log(productGroup[0]);
        productGroup[1].forEach(product => {
            console.log(`  ${product.name}: ${product.price}`);
        });
    }
}

getSortedStoreProducts([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
);