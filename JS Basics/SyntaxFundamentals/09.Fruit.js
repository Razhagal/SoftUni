function calculateFruitPrice(fruitName, weight, pricePerKilogram) {
    const weightInKilograms = weight / 1000;
    const totalPriceForFruits = weightInKilograms * pricePerKilogram;

    console.log(`I need $${totalPriceForFruits.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruitName}.`);
}

calculateFruitPrice('apple', 1563, 2.35);