function toggle() {
    const accordionContentNode = document.querySelector('#extra');
    if (accordionContentNode.style.display === '' ||
        accordionContentNode.style.display === 'none') {
            document.querySelector('#extra').style.display = 'block';
            document.querySelector('.button').textContent = 'Less';
    } else {
        document.querySelector('#extra').style.display = 'none';
        document.querySelector('.button').textContent = 'More';
    }
}