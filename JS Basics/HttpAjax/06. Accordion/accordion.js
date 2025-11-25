function solution() {
    const articlesParent = document.querySelector('#main');
    let accordionPrefab;

    loadArticlePrefab(getArticleTitles);

    function loadArticlePrefab(onLoadDone) {
        getExternalAccordionNode(result => {

            const parser = new DOMParser();
            const externalDoc = parser.parseFromString(result, "text/html");
            const externalNode = externalDoc.querySelector('.accordion');
            accordionPrefab = externalNode;

            onLoadDone();
        });
    }

    function getArticleTitles() {
        getTitles(result => {
            Object.values(result).forEach(articleTitle => {
                createArticleElement(articleTitle, accordionPrefab, articlesParent);
            });
        });
    }
}

solution();

function createArticleElement(data, prefab, parent) {
    const newArticleTitleElement = prefab.cloneNode(true);

    newArticleTitleElement.querySelector('.head span').textContent = data.title;

    const expandButton = newArticleTitleElement.querySelector('.head button');
    expandButton.id = data._id;
    expandButton.addEventListener('click', onExpandArticleClick);

    const contentDiv = newArticleTitleElement.querySelector('.extra');
    contentDiv.classList.add('content');
    contentDiv.classList.remove('extra');

    getArticleData(data._id, result => {
        contentDiv.querySelector('p').textContent = result.content;
    });

    parent.append(newArticleTitleElement);
}

function onExpandArticleClick(e) {
    const parentContainer = e.target.closest('.accordion');

    const contentDiv = parentContainer.querySelector('.content');
    contentDiv.classList.toggle('extra');

    e.target.textContent = contentDiv.classList.contains('extra') ? 'More' : 'Less';
}

async function getTitles(onSuccess) {
    try {
        const result = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}

async function getArticleData(id, onSuccess) {
    try {
        const result = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}

async function getExternalAccordionNode(onSuccess) {
    try {
        const result = await fetch('article.html');
        const html = await result.text();
        onSuccess(html);
    } catch (error) {
        console.log(error);
    }
}