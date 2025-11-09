function saveBookshelf(inputDataArr) {
    const shelves = {};

    for (const inputEntry of inputDataArr) {
        if (inputEntry.includes('->')) {
            const [shelfId, shelfGenre] = inputEntry.split(' -> ');
            if (!shelves.hasOwnProperty(shelfId)) {
                shelves[shelfId] = {
                    id: shelfId,
                    genre: shelfGenre,
                    books: []
                };
            }
        } else {
            const [bookTitle, authorAndGenre] = inputEntry.split(': ');
            const [authorName, bookGenre] = authorAndGenre.split(', ');

            const genreShelf = Object.values(shelves).filter(shelf => shelf.genre === bookGenre)[0];
            if (genreShelf !== undefined) {
                genreShelf.books.push({
                    title: bookTitle,
                    author: authorName
                })
            }
        }
    }

    const sortedShelves = Object.values(shelves)
        .sort((a, b) => b.books.length - a.books.length);

    sortedShelves.forEach(s => {
        console.log(`${s.id} ${s.genre}: ${s.books.length}`);

        s.books.sort((a, b) => a.title.localeCompare(b.title));
        s.books.forEach(b => {
            console.log(`--> ${b.title}: ${b.author}`);
        });
    });
}

saveBookshelf([
    '1 -> history',
    '1 -> action',
    'Death in Time: Criss Bell, mystery',
    '2 -> mystery',
    '3 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery',
    'Hurting Secrets: Dustin Bolt, action',
    'Future of Dawn: Aiden Rose, sci-fi',
    'Lions and Rats: Gabe Roads, history',
    '2 -> romance',
    'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi',
    'Pilots of Stone: Brook Jay, history'
]);