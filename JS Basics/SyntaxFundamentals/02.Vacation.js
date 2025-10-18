function calculatePrice(groupCount, groupType, day) {
    let price = 0;
    let discountIndex = 1;
    if (groupType === 'Students') {
        if (day === 'Friday') {
            price = 8.45;
        } else if (day === 'Saturday') {
            price = 9.80;
        } else if (day === 'Sunday') {
            price = 10.46;
        }

        if (groupCount >= 30) {
            discountIndex = 0.85;
        }
    } else if (groupType === 'Business') {
        if (day === 'Friday') {
            price = 10.90;
        } else if (day === 'Saturday') {
            price = 15.60;
        } else if (day === 'Sunday') {
            price = 16;
        }

        if (groupCount >= 100) {
            groupCount -= 10;
        }
    } else if (groupType === 'Regular') {
        if (day === 'Friday') {
            price = 15;
        } else if (day === 'Saturday') {
            price = 20;
        } else if (day === 'Sunday') {
            price = 22.50;
        }

        if (groupCount >= 10 && groupCount <= 20) {
            discountIndex = 0.95;
        }
    }

    let totalPrice = groupCount * price * discountIndex;
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}