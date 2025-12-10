function solution() {
    const microElements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    const recipes = {
        apple: {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2
        },
        lemonade: {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20
        },
        burger: {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            carbohydrate: 0,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };

    const actions = {
        restock: (micro, quantity) => {
            microElements[micro] += quantity;
            return 'Success';
        },
        prepare: (recipe, quantity) => {
            const product = recipes[recipe];
            const requiredProtein = product.protein * quantity;
            const requiredCarbs = product.carbohydrate * quantity;
            const requiredFat = product.fat * quantity;
            const requiredFlavour = product.flavour * quantity;
            
            if (requiredProtein > microElements.protein) {
                return `Error: not enough protein in stock`;
            }

            if (requiredCarbs > microElements.carbohydrate) {
                return `Error: not enough carbohydrate in stock`;
            }

            if (requiredFat > microElements.fat) {
                return `Error: not enough fat in stock`;
            }

            if (requiredFlavour > microElements.flavour) {
                return `Error: not enough flavour in stock`;
            }

            microElements.protein -= requiredProtein;
            microElements.carbohydrate -= requiredCarbs;
            microElements.fat -= requiredFat;
            microElements.flavour -= requiredFlavour;
            return 'Success';
        },
        report: () => `protein=${microElements.protein} carbohydrate=${microElements.carbohydrate} fat=${microElements.fat} flavour=${microElements.flavour}`
    };

    return function(instructions) {
        const [command, item, quantity] = instructions.split(' ').filter(inst => inst);
        
        return actions[command](item, Number(quantity));
    }
}

let manager = solution();
console.log(manager("restock flavour 50"));
console.log(manager("prepare lemonade 4"));
console.log(manager("report"));

// apple = 1 carb 2 flavor
// lemonade = 10 carb 20 flav
// burger = 5 card 7 fat 3 flav
// eggs = 5 prot 1 fat 1 flav
// turkey = 10 prot 10 carb 10 fat 10 flav