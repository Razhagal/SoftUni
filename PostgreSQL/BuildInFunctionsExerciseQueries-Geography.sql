-- CREATE OR REPLACE VIEW view_river_info AS
-- SELECT
-- 	CONCAT_WS(' ', 'The river', r.river_name, 'flows into the', r.outflow, 'and is', r.length, 'kilometers long.') AS "River Information"
-- FROM rivers AS r
-- ORDER BY r.river_name


-- CREATE OR REPLACE VIEW view_continents_countries_currencies_details AS
-- SELECT
-- 	CONCAT(cont.continent_name, ': ', cont.continent_code) AS continent_details,
-- 	CONCAT(c.country_name, ' - ', c.capital, ' - ', c.area_in_sq_km, ' - km2') AS country_information,
-- 	CONCAT(curr.description, ' (', curr.currency_code,')') AS "currencies"
-- FROM countries AS c
-- JOIN continents AS cont
-- 	ON c.continent_code = cont.continent_code
-- JOIN currencies AS curr
-- 	ON c.currency_code = curr.currency_code
-- ORDER BY
-- 	country_information,
-- 	"currencies"


-- ALTER TABLE countries
-- ADD COLUMN capital_code CHAR(2);
-- UPDATE countries
-- SET capital_code = LEFT(capital, 2);


-- SELECT
-- 	SUBSTRING(description, 5, LENGTH(description))
-- FROM currencies


-- SELECT
-- 	-- regexp_substr("River Information", '([0-9]{1,4})')
-- 	SUBSTRING("River Information", '([0-9]{1,4})') AS river_length
-- FROM view_river_info


-- SELECT
-- 	REPLACE(mountain_range, 'a', '@') AS replace_a,
-- 	REPLACE(mountain_range, 'A', '$') AS replace_A
-- FROM mountains


-- SELECT
-- 	capital,
-- 	TRANSLATE(capital, 'áãåçéíñóú', 'aaaceinou') AS translated_name
-- FROM countries


-- SELECT
-- 	continent_name,
-- 	LTRIM(continent_name) AS "trim"
-- FROM continents


-- SELECT
-- 	continent_name,
-- 	RTRIM(continent_name) AS "trim"
-- FROM continents


-- SELECT
-- 	LTRIM(peak_name, 'M') AS left_trim,
-- 	RTRIM(peak_name, 'm') AS right_trim
-- FROM peaks


-- SELECT
-- 	CONCAT_WS(' ', m.mountain_range, p.peak_name) AS mountain_information,
-- 	LENGTH(CONCAT_WS(' ', m.mountain_range, p.peak_name)) AS characters_length,
-- 	BIT_LENGTH(CONCAT_WS(' ', m.mountain_range, p.peak_name)) AS bits_of_a_tring
-- FROM mountains AS m
-- JOIN peaks AS p
-- 	ON p.mountain_id = m.id


-- SELECT
-- 	population,
-- 	LENGTH(CAST(population AS VARCHAR)) AS length
-- FROM countries


-- SELECT
-- 	peak_name,
-- 	LEFT(peak_name, 4) AS positive_left,
-- 	LEFT(peak_name, -4) AS negative_left 
-- FROM peaks


-- SELECT
-- 	peak_name,
-- 	RIGHT(peak_name, 4) AS positive_right,
-- 	RIGHT(peak_name, -4) AS negative_right 
-- FROM peaks


-- UPDATE countries
-- SET iso_code = UPPER(LEFT(country_name, 3))
-- WHERE iso_code IS NULL


-- UPDATE countries
-- SET country_code = REVERSE(LOWER(country_code))


-- SELECT
-- 	CONCAT(elevation, ' ', REPEAT('-', 3), REPEAT('>', 2), ' ', peak_name) AS "Elevation -->> Peak Name"
-- FROM peaks
-- WHERE elevation >= 4884