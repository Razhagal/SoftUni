document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const questionSections = document.querySelectorAll('.question');
    questionSections.forEach(element => {
        element.addEventListener('click', onAnswerClick);
    });

    const correctAsnwers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let correctAnswersCount = 0;
    let currentAnswerIndex = 0;

    function onAnswerClick(e) {
        if (e.target.classList.contains('quiz-answer')) {
            const selectedAnswer = e.target.textContent;
            
            if (selectedAnswer == correctAsnwers[currentAnswerIndex]) {
                correctAnswersCount++;
            }

            e.currentTarget.classList.toggle('hidden');
            if (currentAnswerIndex < correctAsnwers.length - 1) {
                currentAnswerIndex++;
                questionSections[currentAnswerIndex].classList.toggle('hidden');
            } else {
                const resultElement = document.createElement('p');
                if (correctAnswersCount == correctAsnwers.length) {
                    resultElement.textContent = 'You are recognized as top JavaScript fan!';
                } else if (correctAnswersCount == 1) {
                    resultElement.textContent = `You have ${correctAnswersCount} right answer`;
                } else {
                    resultElement.textContent = `You have ${correctAnswersCount} right answers`;
                }

                document.querySelector('#results').appendChild(resultElement);
            }
        }
    }
}