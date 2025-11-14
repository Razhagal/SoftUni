function solve() {
    const input = document.querySelector('#inputs textarea').value;
    
    const restaurants = [];
    const parsedRestaurantsData = JSON.parse(input);

    for (const restaurantData of parsedRestaurantsData) {
        const [restaurantName, workers] = restaurantData.split(' - ');
        if (!restaurants.hasOwnProperty(restaurantName)) {
            restaurants[restaurantName] = {
                name: restaurantName,
                workers: [],
                averageSalary: 0
            };
        }

        const workersData = workers.split(', ').filter(worker => worker);
        for (const worker of workersData) {
            const [workerName, salary] = worker.split(' ');

            restaurants[restaurantName].workers.push({
                name: workerName,
                salary: Number(salary)
            });
        }
    }

    Object.keys(restaurants).forEach(key => {
        const totalSalary = restaurants[key].workers
            .reduce((sum, current) => {
                return sum + current.salary;
            }, 0);
            
        restaurants[key].averageSalary = (totalSalary / restaurants[key].workers.length).toFixed(2);
        restaurants[key].workers.sort((a, b) => b.salary - a.salary);
    });

    const sortedRestaurants = Object.values(restaurants)
        .sort((a, b) => b.averageSalary - a.averageSalary);

    const bestRestaurant = sortedRestaurants[0];
    document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary} Best Salary: ${bestRestaurant.workers[0].salary.toFixed(2)}`;
    
    let bestRestaurantWorkers = '';
    for (const worker of bestRestaurant.workers) {
        bestRestaurantWorkers = bestRestaurantWorkers.concat(`Name: ${worker.name} With Salary: ${worker.salary} `);
    }

    bestRestaurantWorkers = bestRestaurantWorkers.trim();

    document.querySelector('#workers p').textContent = bestRestaurantWorkers;
}