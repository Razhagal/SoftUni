function checkForWord(word, text) {
    const regex = `\\b${word}\\b`;
    const result = text.search(new RegExp(regex, "i"));
    
    if (result > -1) {
        // Found at result index
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

checkForWord('javascript', 'JavaScript is the best programming language');