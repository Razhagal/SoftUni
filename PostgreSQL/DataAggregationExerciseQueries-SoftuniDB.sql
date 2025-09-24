-- SELECT
-- 	COUNT(CASE e.department_id WHEN 1 THEN 1 END) AS "Engineering",
-- 	COUNT(CASE e.department_id WHEN 2 THEN 1 END) AS "Tool Design",
-- 	COUNT(CASE e.department_id WHEN 3 THEN 1 END) AS "Sales",
-- 	COUNT(CASE e.department_id WHEN 4 THEN 1 END) AS "Marketing",
-- 	COUNT(CASE e.department_id WHEN 5 THEN 1 END) AS "Purchasing",
-- 	COUNT(CASE e.department_id WHEN 6 THEN 1 END) AS "Research and Development",
-- 	COUNT(CASE e.department_id WHEN 7 THEN 1 END) AS "Production"
-- FROM employees AS e


-- UPDATE employees
-- SET salary = salary + 2500,
-- 	job_title = CONCAT_WS(' ', 'Senior', job_title)
-- WHERE hire_date < '2015-01-16';

-- UPDATE employees
-- SET salary = salary + 1500,
-- 	job_title = CONCAT_WS('-', 'Mid', job_title)
-- WHERE hire_date >= '2015-01-16' AND hire_date < '2020-03-04';


-- SELECT
-- 	job_title,
-- 	CASE
-- 		WHEN AVG(salary) > 45800 THEN 'Good'
-- 		WHEN AVG(salary) >= 27500 THEN 'Medium'
-- 		ELSE 'Need Improvement'
-- 	END AS category
-- FROM employees
-- GROUP BY job_title
-- ORDER BY category, job_title


-- SELECT
-- 	project_name,
-- 	CASE
-- 		WHEN start_date IS NULL AND end_date IS NULL THEN 'Ready for development'
-- 		WHEN start_date IS NOT NULL AND end_date IS NULL THEN 'In Progress'
-- 		ELSE 'Done'
-- 	END AS project_status
-- FROM projects
-- WHERE project_name LIKE '%Mountain%'


-- SELECT
-- 	department_id,
-- 	COUNT(*) AS num_employees,
-- 	CASE
-- 		WHEN AVG(salary) > 50000 THEN 'Above average'
-- 		ELSE 'Below average'
-- 	END AS salary_level
-- FROM employees
-- GROUP BY department_id
-- HAVING AVG(salary) > 30000
-- ORDER BY department_id


-- CREATE OR REPLACE VIEW view_performance_rating AS
-- SELECT
-- 	first_name,
-- 	last_name,
-- 	job_title,
-- 	salary,
-- 	department_id,
-- 	CASE
-- 		WHEN salary >= 25000 THEN
-- 			(CASE
-- 				WHEN job_title LIKE 'Senior%' THEN 'High-performing Senior'
-- 				ELSE 'High-performing Employee'
-- 			END)
-- 		ELSE 'Average-performing'
-- 	END AS performance_rating
-- FROM employees


-- CREATE TABLE employees_projects(
-- 	id SERIAL PRIMARY KEY,
-- 	employee_id INT,
-- 	project_id INT,
-- 	CONSTRAINT fk_employee FOREIGN KEY(employee_id) REFERENCES employees(id),
-- 	CONSTRAINT fk_project FOREIGN KEY(project_id) REFERENCES projects(id)
-- );


-- SELECT
-- 	*
-- FROM departments AS d
-- JOIN employees AS e
-- 	ON e.department_id = d.id