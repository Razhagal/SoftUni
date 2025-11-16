document.addEventListener('DOMContentLoaded', solve);

function solve() {
	document.querySelector('#task-input input[type="submit"]').addEventListener('click', parseInputField);

	function parseInputField(e) {
		e.preventDefault();

		const inputText = document.querySelector('#task-input input[type="text"]').value;
		const inputSplit = inputText.split(', ').filter(item => item);

		const resultContainer = document.querySelector('#content');

		inputSplit.forEach(text => {
			const pElement = document.createElement('p');
			pElement.innerText = text;
			pElement.style.display = 'none';
			
			const newDiv = document.createElement('div');
			newDiv.appendChild(pElement);
			newDiv.addEventListener('click', showInnerContent);

			resultContainer.appendChild(newDiv);
		});
	}

	function showInnerContent(e) {
		e.target.children[0].style.display = 'block';
	}
}