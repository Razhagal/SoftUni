function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click', loadPhonebookClick);
    document.querySelector('#btnCreate').addEventListener('click', onCreateNewContactClick);

    const phonebookList = document.querySelector('#phonebook');
    const personInputField = document.querySelector('#person');
    const phoneInputField = document.querySelector('#phone');

    function loadPhonebookClick(e) {
        getPhonebook(result => {
            Object.values(result).forEach(contactData => {
                createPhonebookEntry(contactData);
            });
        });
    }

    function onCreateNewContactClick(e) {
        if (personInputField.value == '' || phoneInputField.value == '') return;

        const newContact = {
            person: personInputField.value,
            phone: phoneInputField.value
        };

        createNewContact(newContact, result => {
            personInputField.value = '';
            phoneInputField.value = '';
            phonebookList.replaceChildren();

            loadPhonebookClick();
        });
    }

    function onDeleteContactClick(e) {
        const parentElement = e.target.closest('li');
        deleteContact(parentElement.dataset.id, result => {
            parentElement.remove();
        });
    }

    function createPhonebookEntry(contactData) {
        const entryData = {
            dataset: {
                id: contactData._id
            },
            textContent: `${contactData.person}: ${contactData.phone}`
        }

        const contactElement = createElement('li', entryData, phonebookList);
        createElement('button', { textContent: 'Delete', onclick: onDeleteContactClick}, contactElement);
    }
}

attachEvents();

function createElement(tag, properties, parent) {
    const element = document.createElement(tag);

    Object.keys(properties).forEach(prop => {
        if (typeof(properties[prop]) === 'object') {
            Object.assign(element.dataset, properties[prop]);
        } else {
            element[prop] = properties[prop];
        }
    });

    if (parent) parent.append(element);

    return element;
}

async function getPhonebook(onSuccess) {
    try {
        const result = await fetch('http://localhost:3030/jsonstore/phonebook');
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}

async function createNewContact(data, onSuccess) {
    const request = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };

    try {
        const result = await fetch('http://localhost:3030/jsonstore/phonebook', request);
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}

async function deleteContact(contactId, onSuccess) {
    const request = {
        method: 'DELETE'
    };

    try {
        const result = await fetch(`http://localhost:3030/jsonstore/phonebook/${contactId}`, request);
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}