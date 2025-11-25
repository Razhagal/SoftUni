function attachEvents() {
    document.querySelector('#submit').addEventListener('click', onPostNewMessage);
    document.querySelector('#refresh').addEventListener('click', refreshMessages);

    const messagesTextArea = document.querySelector('#messages');
    const nameInput = document.querySelector('input[name="author"]');
    const messageContentInput = document.querySelector('input[name="content"]');

    function refreshMessages() {
        messagesTextArea.value = '';

        getAllMessages(result => {
            Object.values(result).forEach(message => {
                createMessageItem(message);
            });
        });
    }

    function onPostNewMessage() {
        if (nameInput.value == '' || messageContentInput.value == '') {
            return;
        }

        const newMsg = {
            author: nameInput.value,
            content: messageContentInput.value,
          };
          
          postNewMessage(newMsg, result => {
            createMessageItem(result);
          });
    }

    function createMessageItem(messageData) {
        const newMessageEntry = `\n${messageData.author}: ${messageData.content}`

        messagesTextArea.value = (messagesTextArea.value + newMessageEntry).trim();
    }
}

attachEvents();

async function getAllMessages(onSuccess) {
    const result = await fetch('http://localhost:3030/jsonstore/messenger');
    const messages = await result.json();
    onSuccess(messages);
}

async function postNewMessage(newMsgBody, onSuccess) {
    const headers = {
        method: 'POST',
        'Content-Type': 'application/json',
        body: JSON.stringify(newMsgBody)
    };

    const result = await fetch('http://localhost:3030/jsonstore/messenger', headers);
    const newMessage = await result.json();
    onSuccess(newMessage);
}