function attachEvents() {
    document.querySelector('#btnLoadPosts').addEventListener('click', loadAllPosts);
    document.querySelector('#btnViewPost').addEventListener('click', viewPost);

    const postsDropdownElement = document.querySelector('#posts');
    const selectedPostTitleElement = document.querySelector('#post-title');
    const selectedPostBodyElement = document.querySelector('#post-body');
    const postCommentsListElement = document.querySelector('#post-comments');

    const allPosts = [];

    function createPostOptionEntry(postData) {
        createElement('option', { value: postData.id, textContent: postData.title }, postsDropdownElement);
    }

    function createPostCommentEntry(commentData) {
        createElement('li', { textContent: commentData.text }, postCommentsListElement);
    }

    function loadAllPosts(e) {
        getPosts((result) => {
            Object.values(result).forEach(postData => {
                allPosts.push({ id: postData.id, title: postData.title, content: postData.body });
                createPostOptionEntry(postData);
            });
        });
    }
    
    function viewPost(e) {
        const selectedPost = allPosts[postsDropdownElement.selectedIndex];

        selectedPostTitleElement.textContent = selectedPost.title;
        selectedPostBodyElement.textContent = selectedPost.content;
        postCommentsListElement.innerHTML = '';

        getPostComments(result => {
            Object.values(result).forEach(commentData => {
                if (commentData.postId == selectedPost.id) {
                    createPostCommentEntry(commentData);
                }
            });
        });
    }
}

attachEvents();

async function getPosts(onSuccess) {
    const result = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsData = await result.json();
    onSuccess(postsData);
}

async function getPostComments(onSuccess) {
    const result = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const commentsData = await result.json();
    onSuccess(commentsData);
}

function createElement(tag, properties, container) {
    const element = document.createElement(tag);

    Object.keys(properties).forEach(property => {
        if ( typeof properties[property] === 'object' ) {
            Object.assign( element.dataset, properties[property] );
        } else {
            element[property] = properties[property];
        }
    });

    if ( container ) container.append(element);

    return element;
}