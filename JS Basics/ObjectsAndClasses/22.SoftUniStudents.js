function storeStudents(inputDataArr) {
    const courses = {};

    for (const inputEntry of inputDataArr) {
        if (inputEntry.includes(':')) {
            const [courseName, courseCapacity] = inputEntry.split(': ');
            if (!courses.hasOwnProperty(courseName)) {
                courses[courseName] = {
                    name: courseName,
                    capacity: 0,
                    students: []
                };
            }

            courses[courseName].capacity += Number(courseCapacity);
        } else {
            const [user, secondPart] = inputEntry.split(' with email ');
            const [userMail, courseName] = secondPart.split(' joins ');
            
            if (courses.hasOwnProperty(courseName)) {
                const userName = user.substring(0, user.indexOf('['));
                const credits = Number(user.substring(user.indexOf('[') + 1, user.indexOf(']')));

                if (courses[courseName].students.length < courses[courseName].capacity) {
                    courses[courseName].students.push({
                        username: userName,
                        email: userMail,
                        credits: credits
                    });
                }
            }
        }
    }


    const sortedCourses = Object.values(courses)
        .sort((a, b) => b.students.length - a.students.length);
    
    sortedCourses.forEach(c => {
        console.log(`${c.name}: ${c.capacity - c.students.length} places left`);
        c.students.sort((a, b) => b.credits - a.credits);
        c.students.forEach(s => {
            console.log(`--- ${s.credits}: ${s.username}, ${s.email}`);
        });
    });
}

storeStudents([
    'JavaBasics: 2',
    'user1[25] with email user1@user.com joins C#Basics',
    'C#Advanced: 3',
    'JSCore: 4',
    'user2[30] with email user2@user.com joins C#Basics',
    'user13[50] with email user13@user.com joins JSCore',
    'user1[25] with email user1@user.com joins JSCore',
    'user8[18] with email user8@user.com joins C#Advanced',
    'user6[85] with email user6@user.com joins JSCore',
    'JSCore: 2',
    'user11[3] with email user11@user.com joins JavaBasics',
    'user45[105] with email user45@user.com joins JSCore',
    'user007[20] with email user007@user.com joins JSCore',
    'user700[29] with email user700@user.com joins JSCore',
    'user900[88] with email user900@user.com joins JSCore'
]);