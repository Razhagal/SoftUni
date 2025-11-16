document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const submitButtons = document.querySelectorAll('input[type="submit"]');
    
    submitButtons.forEach(btn => {
        btn.addEventListener('click', convertTime);
    });

    function convertTime(e) {
        e.preventDefault();

        const targetId = e.target.id;
        switch (targetId) {
            case 'daysBtn':
                const inputDays = Number(document.querySelector('#days-input').value);
                convertAllFromDays(inputDays);
                break;
            case 'hoursBtn':
                const inputHours = Number(document.querySelector('#hours-input').value);
                convertAllFromHours(inputHours);
                break;
            case 'minutesBtn':
                const inputMinutes = Number(document.querySelector('#minutes-input').value);
                convertAllFromMinutes(inputMinutes);
                break;
            case 'secondsBtn':
                const inputSeconds = Number(document.querySelector('#seconds-input').value);
                convertAllFromSeconds(inputSeconds);
                break;
        }
    }

    function convertAllFromDays(days) {
        if (days === '' || days === 0) {
            document.querySelector('#days-input').value = 0;
            document.querySelector('#hours-input').value = 0;
            document.querySelector('#minutes-input').value = 0;
            document.querySelector('#seconds-input').value = 0;
            return;
        }
        
        const hours = days * 24;
        const minutes = hours * 60;
        const seconds = minutes * 60;

        document.querySelector('#hours-input').value = hours.toFixed(2);
        document.querySelector('#minutes-input').value = minutes.toFixed(2);
        document.querySelector('#seconds-input').value = seconds.toFixed(2);
    }

    function convertAllFromHours(hours) {
        if (hours === '' || hours === 0) {
            document.querySelector('#days-input').value = 0;
            document.querySelector('#hours-input').value = 0;
            document.querySelector('#minutes-input').value = 0;
            document.querySelector('#seconds-input').value = 0;
            return;
        }

        const days = hours / 24;
        const minutes = hours * 60;
        const seconds = minutes * 60;

        document.querySelector('#days-input').value = days.toFixed(2);
        document.querySelector('#minutes-input').value = minutes.toFixed(2);
        document.querySelector('#seconds-input').value = seconds.toFixed(2);
    }

    function convertAllFromMinutes(minutes) {
        if (minutes === '' || minutes === 0) {
            document.querySelector('#days-input').value = 0;
            document.querySelector('#hours-input').value = 0;
            document.querySelector('#minutes-input').value = 0;
            document.querySelector('#seconds-input').value = 0;
            return;
        }

        const hours = minutes / 60;
        const days = hours / 24;
        const seconds = minutes * 60;

        document.querySelector('#days-input').value = days.toFixed(2);
        document.querySelector('#hours-input').value = hours.toFixed(2);
        document.querySelector('#seconds-input').value = seconds.toFixed(2);
    }

    function convertAllFromSeconds(seconds) {
        if (seconds === '' || seconds === 0) {
            document.querySelector('#days-input').value = 0;
            document.querySelector('#hours-input').value = 0;
            document.querySelector('#minutes-input').value = 0;
            document.querySelector('#seconds-input').value = 0;
            return;
        }

        const minutes = seconds / 60;
        const hours = minutes / 60;
        const days = hours / 24;

        document.querySelector('#days-input').value = days.toFixed(2);
        document.querySelector('#hours-input').value = hours.toFixed(2);
        document.querySelector('#minutes-input').value = minutes.toFixed(2);
    }
}