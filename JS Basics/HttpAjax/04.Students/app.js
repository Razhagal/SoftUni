function attachEvents() {
    document.querySelector('#submit').addEventListener('click', submitNewStudent);

    const inputFirstName = document.querySelector('.inputs input[name="firstName"]');
    const inputLastName = document.querySelector('.inputs input[name="lastName"]');
    const inputFacultyNumber = document.querySelector('.inputs input[name="facultyNumber"]');
    const inputGrade = document.querySelector('.inputs input[name="grade"]');

    const resultsTable = document.querySelector('#results tbody');

    loadAllStudents();

    function createStudentEntry(studentData) {
        const studentRowElement = createElement('tr', {}, resultsTable);
        createElement('td', { textContent: studentData.firstName }, studentRowElement);
        createElement('td', { textContent: studentData.lastName }, studentRowElement);
        createElement('td', { textContent: studentData.facultyNumber }, studentRowElement);
        createElement('td', { textContent: studentData.grade }, studentRowElement);
    }

    function loadAllStudents() {
        getAllStudents(result => {
            Object.values(result).forEach(createStudentEntry);
        })
    }

    function submitNewStudent(e) {
        if (inputFirstName.value == '' || inputLastName.value == '' || inputFacultyNumber.value == '' || inputGrade.value == '') {
            return;
        }

        const newStudent = {
            firstName: inputFirstName.value,
            lastName: inputLastName.value,
            facultyNumber: inputFacultyNumber.value,
            grade: inputGrade.value
        };

        createNewStudent(newStudent, result => {
            createStudentEntry(result);
        });
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

async function getAllStudents(onSuccess) {
    try {
        const result = await fetch('http://localhost:3030/jsonstore/collections/students');
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}

async function createNewStudent(data, onSuccess) {
    const request = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };

    try {
        const result = await fetch('http://localhost:3030/jsonstore/collections/students', request);
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}