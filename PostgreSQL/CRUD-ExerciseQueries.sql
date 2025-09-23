-- SELECT *
-- FROM cities


-- SELECT
-- 	CONCAT_WS(' ', c."name", c.state) AS cities_information, 
-- 	c.area AS area_km2
-- FROM cities AS c


-- SELECT
-- 	DISTINCT c."name",
-- 	c.area AS area_km2
-- FROM cities AS c
-- ORDER BY c."name" DESC


-- SELECT
-- 	"id",
-- 	CONCAT_WS(' ', e.first_name, e.last_name) AS full_name,
-- 	e.job_title	
-- FROM employees AS e
-- ORDER BY e.first_name
-- LIMIT 50


-- SELECT
-- 	id,
-- 	CONCAT_WS(' ', e.first_name, e.middle_name, e.last_name) AS full_name,
-- 	e.hire_date
-- FROM employees AS e
-- ORDER BY e.hire_date
-- OFFSET 9


-- SELECT
-- 	a.id,
-- 	CONCAT_WS(' ', a.number, a.street) AS address,
-- 	a.city_id
-- FROM addresses AS a
-- WHERE a.id >= 20


-- SELECT
-- 	CONCAT_WS(' ', a.number, a.street) AS address,
-- 	a.city_id
-- FROM addresses AS a
-- WHERE a.city_id % 2 = 0
-- ORDER BY a.city_id


-- SELECT
-- 	p."name",
-- 	p.start_date,
-- 	p.end_date
-- FROM projects AS p
-- WHERE p.start_date >= '2016-06-01 07:00:00' AND p.end_date < '2023-06-04 00:00:00'
-- ORDER BY p.start_date


-- SELECT
-- 	a.number,
-- 	a.street
-- FROM addresses AS a
-- WHERE a.id BETWEEN 50 AND 100 OR a.number < 1000


-- SELECT
-- 	ep.employee_id,
-- 	ep.project_id
-- FROM employees_projects AS ep
-- WHERE ep.employee_id IN (200, 250) AND ep.project_id NOT IN (50, 100)


-- SELECT
-- 	p."name",
-- 	p.start_date
-- FROM projects AS p
-- WHERE p."name" IN ('Mountain', 'Road', 'Touring')
-- LIMIT 20


-- SELECT
-- 	CONCAT_WS(' ', e.first_name, e.last_name) AS full_name,
-- 	e.job_title,
-- 	e.salary
-- FROM employees AS e
-- WHERE e.salary IN (12500, 14000, 23600, 25000)
-- ORDER BY e.salary DESC


-- SELECT
-- 	e.id,
-- 	e.first_name,
-- 	e.last_name
-- FROM employees AS e
-- WHERE e.middle_name IS NULL
-- LIMIT 3


-- INSERT INTO departments(department, manager_id)
-- VALUES
-- 	('Finance', 3),
-- 	('Information Services', 42),
-- 	('Document Control', 90),
-- 	('Quality Assurance', 274),
-- 	('Facilities and Maintenance', 218),
-- 	('Shipping and Receiving', 85),
-- 	('Executive', 109);


-- CREATE TABLE company_chart AS
-- SELECT
-- 	CONCAT_WS(' ', e.first_name, e.last_name) AS full_name,
-- 	e.job_title,
-- 	e.department_id,
-- 	e.manager_id
-- FROM employees AS e


-- UPDATE projects
-- SET end_date = start_date + INTERVAL '5 months'
-- WHERE end_date IS NULL


-- UPDATE employees
-- SET
-- 	salary = salary + 1500,
-- 	job_title = CONCAT_WS(' ', 'Senior', job_title)
-- WHERE hire_date BETWEEN '1998-01-01' AND '2000-01-05'; 


-- DELETE FROM addresses
-- WHERE city_id IN (5, 17, 20, 30)


-- CREATE VIEW "view_company_chart" AS
-- SELECT
-- 	full_name,
-- 	job_title
-- FROM company_chart
-- WHERE manager_id = 184


-- CREATE OR REPLACE VIEW "view_addresses" AS
-- SELECT
-- 	CONCAT_WS(' ', e.first_name, e.last_name) AS full_name,
-- 	e.department_id,
-- 	CONCAT_WS(' ', a.number, a.street) AS address
-- FROM employees AS e
-- JOIN addresses AS a
-- 	ON e.address_id = a.id
-- ORDER BY address


-- ALTER VIEW view_addresses RENAME TO view_employee_addresses_info


-- DROP VIEW IF EXISTS view_company_chart


-- UPDATE projects
-- SET "name" = UPPER("name")


-- CREATE OR REPLACE VIEW view_initials AS
-- SELECT
-- 	LEFT(first_name, 2) AS initial,
-- 	last_name
-- FROM employees
-- ORDER BY last_name


-- SELECT
-- 	p."name",
-- 	p.start_date
-- FROM projects AS p
-- WHERE p."name" LIKE 'MOUNT%'
-- ORDER BY p.id