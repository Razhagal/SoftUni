function solution(command) {
    
    const commands = {
        upvote: () => this.upvotes += 1,
        downvote: () => this.downvotes += 1,
        score: () => {
            const greaterValueOfVotes = Math.max(this.upvotes, this.downvotes);
            let obfuscatedUpvotes = this.upvotes;
            let obfuscatedDownvotes = this.downvotes;
            const balance = this.upvotes - this.downvotes;
            const totalVotes = this.upvotes + this.downvotes;

            if (totalVotes > 50) {
                obfuscatedUpvotes += Math.ceil(greaterValueOfVotes * 0.25);
                obfuscatedDownvotes += Math.ceil(greaterValueOfVotes * 0.25);
            }

            let rating = 'new';
            const hotThreshold = totalVotes * 0.66;
            if (totalVotes < 10) {
                rating = 'new';
            } else if (this.upvotes > hotThreshold) {
                rating = 'hot';
            } else if (balance >= 0 && totalVotes > 100) {
                rating = 'controversial';
            } else if (balance < 0) {
                rating = 'unpopular';
            }

            return [obfuscatedUpvotes, obfuscatedDownvotes, balance, rating];
        }
    }

    return commands[command]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (let index = 0; index < 50; index++) {
    solution.call(post, 'downvote');     
}

score = solution.call(post, 'score');
console.log(score);