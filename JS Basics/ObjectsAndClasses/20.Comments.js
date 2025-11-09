function storeUserAndCommentsData(inputDataArr) {
    const users = {};
    const articles = {};

    for (const inputEntry of inputDataArr) {
        if (inputEntry.startsWith('user')) {
            const userName = inputEntry.split('user ').filter(u => u)[0];
            users[userName] = {};
        } else if (inputEntry.startsWith('article')) {
            const articleName = inputEntry.split('article ').filter(a => a)[0];
            if (!articles.hasOwnProperty(articleName)) {
                articles[articleName] = {
                    comments: []
                };
            }
        } else {
            const [partOne, partTwo] = inputEntry.split(': ');
            const [userName, articleName] = partOne.split(' posts on ');
            
            if (!users.hasOwnProperty(userName) ||
                !articles.hasOwnProperty(articleName)) {
                continue;
            }

            const [title, content] = partTwo.split(', ');
            articles[articleName].comments.push({
                title: title,
                content: content,
                user: userName
            });
        }
    }

    Object.values(articles).forEach(articleValue => {
        articleValue.comments.sort((a, b) => a.user.localeCompare(b.user));
    });

    const sortedArticles = Object.entries(articles)
        .sort((a, b) => b[1].comments.length - a[1].comments.length)
        .reduce((newObj, [key, value]) => {
            newObj[key] = value;
            return newObj;
        }, {});

    Object.entries(sortedArticles).forEach(article => {
        console.log(`Comments on ${article[0]}`);
        article[1].comments.forEach(comment => {
            console.log(`--- From user ${comment.user}: ${comment.title} - ${comment.content}`);
        });
    })
}

storeUserAndCommentsData([
    'user aUser123',
    'someUser posts on someArticle: NoTitle, stupidComment',
    'article Books',
    'article Movies',
    'article Shopping',
    'user someUser',
    'user uSeR4',
    'user lastUser',
    'uSeR4 posts on Books: I like books, I do really like them',
    'uSeR4 posts on Movies: I also like movies, I really do',
    'someUser posts on Shopping: title, I go shopping every day',
    'someUser posts on Movies: Like, I also like movies very much']);