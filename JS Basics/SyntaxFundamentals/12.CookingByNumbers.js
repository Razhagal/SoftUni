function cook(inputNum, ...args) { //6 parameters which are a number and a list of five operations
    let number = Number(inputNum);

    for (const operation of args) {
        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;
        }

        console.log(number);
    }
}

cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');