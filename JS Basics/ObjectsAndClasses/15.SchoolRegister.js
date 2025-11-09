function getSchoolRegister(studentsDataArr) {
    const gradesWithStudents = [];
    
    for (const studentData of studentsDataArr) {
        const [namePart, gradePart, averageScorePart] = studentData.split(', ');

        const studentName = namePart.split(': ')[1];
        const nextGrade = Number(gradePart.split(': ')[1]) + 1;
        const averageScore = Number(averageScorePart.split(': ')[1]);

        if (averageScore >= 3) {
            if (!gradesWithStudents.hasOwnProperty(nextGrade)) {
                gradesWithStudents[nextGrade] = {
                    students: []
                }
            }

            gradesWithStudents[nextGrade].students.push({
                name: studentName,
                score: averageScore
            });
        }
    }

    for (const grade in gradesWithStudents) {
        gradesWithStudents[grade].averageGradeScore =
            (gradesWithStudents[grade].students
                .reduce((currentSum, student) => {
                    return currentSum + student.score
                }, 0) / gradesWithStudents[grade].students.length)
                .toFixed(2);


        console.log(`${grade} Grade`);
        console.log(`List of students: ${gradesWithStudents[grade].students.map(student => student.name).join(', ')}`);
        console.log(`Average annual score from last year: ${gradesWithStudents[grade].averageGradeScore}`);
        console.log();
    }
}

getSchoolRegister([
    "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83",
    "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
    "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
    "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
    "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
    "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ]
);