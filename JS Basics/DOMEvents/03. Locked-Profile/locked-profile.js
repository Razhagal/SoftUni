document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const showMoreButtons = document.querySelectorAll('.profile button');

    showMoreButtons.forEach(btn => {
        btn.addEventListener('click', onShowMoreClick);
    });

    function onShowMoreClick(e) {
        const unlockRadioBtn = e.target.parentElement.querySelector('input[id*="Unlock"]');
        if (unlockRadioBtn.checked) {
            const hiddenContent = e.target.parentElement.querySelector('div[id*="HiddenFields"]');
            hiddenContent.classList.toggle('hidden-fields');

            if (hiddenContent.classList.contains('hidden-fields')) {
                e.target.textContent = 'Show more';
            } else {
                e.target.textContent = 'Show less';
            }
        }
    }
}