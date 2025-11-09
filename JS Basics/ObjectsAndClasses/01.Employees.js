function getEmployees(employeesNames) {
    const employees = [];
    for (const name of employeesNames) {
        employees.push({
            name: name,
            personal_number: name.length
        });
    }

    for (const employee of employees) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personal_number}`);
    }
}

getEmployees(['Silas Butler','Adnaan Buckley','Juan Peterson','Brendan Villarreal']);