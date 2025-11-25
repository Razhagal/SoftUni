function lockedProfile() {
    const profilesContainer = document.querySelector('#main');
    const profilePrefabNode = document.querySelector('.profile');

    // Don't know if I need to clear first
    profilesContainer.replaceChildren();

    getProfiles();

    function getProfiles() {
        getAllProfiles(result => {
            Object.values(result).forEach(profile => {
                // console.log(profile);
                createProfileElement(profile);
            });
        });
    }

    function createProfileElement(profileData) {
        const newProfileNode = profilePrefabNode.cloneNode(true);
        profilesContainer.append(newProfileNode);
        const newNodeIndex = [...profilesContainer.children].indexOf(newProfileNode);

        const radioElements = newProfileNode.querySelectorAll('input[type="radio"]');
        radioElements.forEach(el => el.name = `user${newNodeIndex + 1}Locked`);
        radioElements[0].checked = true;

        const inputUsername = newProfileNode.querySelector('input[name*="Username"]');
        inputUsername.name = `user${newNodeIndex + 1}Username`;
        inputUsername.value = profileData.username;

        const inputEmail = newProfileNode.querySelector('input[name*="Email"]');
        inputEmail.name = `user${newNodeIndex + 1}Email`;
        inputEmail.value = profileData.email;

        const inputAge = newProfileNode.querySelector('input[name*="Age"]');
        inputAge.name = `user${newNodeIndex + 1}Age`;
        inputAge.value = profileData.age;

        const additionalDataDiv = newProfileNode.querySelector('div.user1Username');
        if (radioElements[1].checked) {
            additionalDataDiv.classList.remove('hiddenInfo');
        } else {
            additionalDataDiv.classList.add('hiddenInfo');
        }

        newProfileNode.querySelector('button').addEventListener('click', onProfileShowClick);
    }
}

function onProfileShowClick(e) {
    const profileNode = e.target.parentNode;
    
    const radioElements = profileNode.querySelectorAll('input[type="radio"]');
    const additionalDataDiv = profileNode.querySelector('div.user1Username');
    if (radioElements[1].checked) {
        additionalDataDiv.classList.toggle('hiddenInfo');
        
        if (additionalDataDiv.classList.contains('hiddenInfo')) {
            e.target.textContent = 'Show more';
        } else {
            e.target.textContent = 'Hide it';
        }
    }
}

async function getAllProfiles(onSuccess) {
    try {
        const result = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
        const parsedResult = await result.json();
        onSuccess(parsedResult);
    } catch (error) {
        console.log(error);
    }
}