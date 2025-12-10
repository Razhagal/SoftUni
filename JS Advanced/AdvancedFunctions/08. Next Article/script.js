function getArticleGenerator(articles) {
    this.articles = articles;

    return function() {
        const currentArticle = this.articles.shift();
        if (currentArticle) {
            const newArticle = document.createElement('article');
            newArticle.textContent = currentArticle;

            document.querySelector('#content').append(newArticle);
        }
    }
}