function solve() {
    const articlePrefab = getArticlePrefab();

    const newTaskTitleInput = document.querySelector('#task');
    const newTaskDescInput = document.querySelector('#description');
    const newTaskDateInput = document.querySelector('#date');
    const openTasksContainer = document.querySelector('section:nth-child(2) div + div');
    const inProgressTasksContainer = document.querySelector('section:nth-child(3) div + div');
    const completedTasksContainer = document.querySelector('section:nth-child(4) div + div');

    document.querySelector('#add').addEventListener('click', addNewTask);

    function addNewTask(e) {
        e.preventDefault();
        
        if (newTaskTitleInput.value == '' || newTaskDescInput.value == '' || newTaskDateInput == '') {
            return;
        }

        // let newArticleElement = document.createElement('article');
        // newArticleElement.innerHTML =
        // `<h3>JS Advanced Exam</h3>
        // <p>Description To organize the Exam</p>
        // <p>Due Date: 2020.04.14</p>
        // <div class="flex">
        //     <button class="green">Start</button>
        //     <button class="red">Delete</button>
        // </div>`;

        const newArticleElement = articlePrefab.cloneNode(true);
        newArticleElement.querySelector('h3').textContent = newTaskTitleInput.value;
        newArticleElement.querySelector('p').textContent = `Description: ${newTaskDescInput.value}`;
        newArticleElement.querySelector('p + p').textContent = `Due Date: ${newTaskDateInput.value}`;
        newArticleElement.querySelector('button.green').addEventListener('click', onArticleStartClick);
        newArticleElement.querySelector('button.red').addEventListener('click', onDeleteArticleClick);

        openTasksContainer.appendChild(newArticleElement);

        newTaskTitleInput.value = '';
        newTaskDescInput.value = '';
        newTaskDateInput.value = '';
    }

    function onArticleStartClick(e) {
        const openArticle = e.target.closest('article');
        openArticle.remove();

        const finishButton = document.createElement('button');
        Object.assign(finishButton, { textContent: 'Finish', className: 'orange', onclick: onFinishArticleClick });

        openArticle.querySelector('button.green').remove();
        openArticle.querySelector('div.flex').appendChild(finishButton);

        inProgressTasksContainer.appendChild(openArticle);
    }

    function onDeleteArticleClick(e) {
        e.target.closest('article').remove();
    }

    function onFinishArticleClick(e) {
        const inProgressArticle = e.target.closest('article');
        inProgressArticle.remove();

        inProgressArticle.querySelector('div.flex').remove();

        completedTasksContainer.appendChild(inProgressArticle);
    }

    function getArticlePrefab() {
        const template =
    `<article>
        <h3>JS Advanced Exam</h3>
        <p>Description To organize the Exam</p>
        <p>Due Date: 2020.04.14</p>
        <div class="flex">
            <button class="green">Start</button>
            <button class="red">Delete</button>
        </div>
    </article>`;
    
        const parser = new DOMParser();
        const parsedTemplate = parser.parseFromString(template, "text/html");
        return parsedTemplate.querySelector('article')
    }
}