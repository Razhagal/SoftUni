document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('#convert').addEventListener('click', convertDistance);


    function convertDistance(e) {
        const inputValue = Number(document.querySelector('#inputDistance').value);

        if (!isNaN(inputValue)) {
            const fromType = document.querySelector('#inputUnits').value;
            let inputInMeters = 0;
            switch (fromType) {
                case 'km':
                    inputInMeters = inputValue * 1000;
                    break;
                case 'm':
                    inputInMeters = inputValue;
                    break;
                case 'cm':
                    inputInMeters = inputValue / 100;
                    break;
                case 'mm':
                    inputInMeters = inputValue / 1000;
                    break;
                case 'mi':
                    inputInMeters = inputValue * 1609.34;
                    break;
                case 'yrd':
                    inputInMeters = inputValue * 0.9144;
                    break;
                case 'ft':
                    inputInMeters = inputValue * 0.3048;
                    break;
                case 'in':
                    inputInMeters = inputValue * 0.0254;
                    break;
            }

            const toType = document.querySelector('#outputUnits').value;
            let result = 0;
            switch (toType) {
                case 'km':
                    result = inputInMeters / 1000;
                    break;
                case 'm':
                    result = inputInMeters;
                    break;
                case 'cm':
                    result = inputInMeters * 100;
                    break;
                case 'mm':
                    result = inputInMeters * 1000;
                    break;
                case 'mi':
                    result = inputInMeters / 1609.34;
                    break;
                case 'yrd':
                    result = inputInMeters / 0.9144;
                    break;
                case 'ft':
                    result = inputInMeters / 0.3048;
                    break;
                case 'in':
                    result = inputInMeters / 0.0254;
                    break;
            }

            document.querySelector('#outputDistance').value = result;
        }
    }

    // 1 km	1000 m
    // 1 m	    1 m
    // 1 cm	0.01 m
    // 1 mm	0.001 m
    // 1 mi	1609.34 m
    // 1 yrd	0.9144 m
    // 1 ft	0.3048 m
    // 1 in	0.0254 m
}