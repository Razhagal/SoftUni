function solve() {
	const splitInputSentences = document.querySelector('#input').value
		.trim()
		.split('.')
		.filter(t => t);


	let formattedResult = '';
	let currentParagraphSentences = '';
	splitInputSentences.forEach((sentence, index) => {
		currentParagraphSentences = currentParagraphSentences.concat(sentence.trim() + '.')

		if ((index + 1) % 3 == 0) {
			// Should create new paragraph
			formattedResult = formattedResult.concat(`<p>${currentParagraphSentences}</p>`);
			currentParagraphSentences = '';
		} else if (index == splitInputSentences.length - 1) {
			formattedResult = formattedResult.concat(`<p>${currentParagraphSentences}</p>`);
		}
	});

	document.querySelector('#output').innerHTML = formattedResult;
}