function add(sum = 0) {
    function accumulator(num) {
        sum += num;
        return accumulator;
    }

    accumulator.toString = () => String(sum);
    return accumulator;
}

console.log(add(3)(4).toString());