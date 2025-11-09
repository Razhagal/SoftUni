function getMovies(moviesCommands) {
    const movies = {};

    for (const command of moviesCommands) {
        if (command.includes("addMovie")) {
            const movieName = command.split("addMovie ").filter(item => item)[0];
            movies[movieName] = { name: movieName };
        } else if (command.includes("directedBy")) {
            const commandSplit = command.split(" directedBy ").filter(item => item);
            const movieName = commandSplit[0];
            const directorName = commandSplit[1];

            if (movies.hasOwnProperty(movieName)) {
                movies[movieName].director = directorName;
            }
        } else if (command.includes("onDate")) {
            const commandSplit = command.split(" onDate ").filter(item => item);
            const movieName = commandSplit[0];
            const date = commandSplit[1];

            if (movies.hasOwnProperty(movieName)) {
                movies[movieName].date = date;
            }
        }
    }

    for (const movieName in movies) {
        const movie = movies[movieName];
        if (!movie.hasOwnProperty("director") || !movie.hasOwnProperty("date")) {
            continue;
        }
        
        console.log(JSON.stringify(movies[movieName]));
    }
}

getMovies(
    ['addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen']
);