-- SELECT
-- 	mc.country_code,
-- 	m.mountain_range,
-- 	p.peak_name,
-- 	p.elevation
-- FROM mountains AS m
-- JOIN mountains_countries AS mc
-- 	ON m.id = mc.mountain_id
-- JOIN peaks AS p
-- 	ON m.id = p.mountain_id
-- WHERE p.elevation > 2835 AND mc.country_code LIKE 'BG'
-- ORDER BY p.elevation DESC


-- SELECT
-- 	mc.country_code,
-- 	COUNT(*) AS mountain_range_count
-- FROM mountains_countries AS mc
-- JOIN mountains AS m
-- 	ON mc.mountain_id = m.id
-- WHERE mc.country_code IN ('US', 'RU', 'BG')
-- GROUP BY mc.country_code
-- ORDER BY mountain_range_count DESC


-- SELECT
-- 	c.country_name,
-- 	r.river_name
-- FROM countries AS c
-- LEFT JOIN countries_rivers AS cr
-- 	ON c.country_code = cr.country_code
-- LEFT JOIN rivers AS r
-- 	ON cr.river_id = r.id
-- WHERE
-- 	c.continent_code = (
-- 		SELECT continent_code
-- 		FROM continents
-- 		WHERE continent_name = 'Africa'
-- 	)
-- ORDER BY c.country_name
-- LIMIT 5


-- SELECT
-- 	MIN(average.average_area) AS min_average_area
-- FROM
-- 	(SELECT
-- 		AVG(cou.area_in_sq_km) AS average_area
-- 	FROM countries AS cou
-- 	GROUP BY cou.continent_code) AS average


-- SELECT
-- 	COUNT(*) AS countries_without_mountains
-- FROM countries AS c
-- LEFT JOIN mountains_countries AS mc
-- 	ON c.country_code = mc.country_code
-- WHERE mc.mountain_id IS NULL


-- CREATE TABLE monasteries(
-- 	id SERIAL PRIMARY KEY,
-- 	monastery_name VARCHAR(255),
-- 	country_code CHAR(2)
-- );

-- INSERT INTO monasteries(monastery_name, country_code)
-- VALUES
-- 	('Rila Monastery "St. Ivan of Rila"', 'BG'),
-- 	('Bachkovo Monastery "Virgin Mary"', 'BG'),
-- 	('Troyan Monastery "Holy Mother''s Assumption"', 'BG'),
-- 	('Kopan Monastery', 'NP'),
-- 	('Thrangu Tashi Yangtse Monastery', 'NP'),
-- 	('Shechen Tennyi Dargyeling Monastery', 'NP'),
-- 	('Benchen Monastery', 'NP'),
-- 	('Southern Shaolin Monastery', 'CN'),
-- 	('Dabei Monastery', 'CN'),
-- 	('Wa Sau Toi', 'CN'),
-- 	('Lhunshigyia Monastery', 'CN'),
-- 	('Rakya Monastery', 'CN'),
-- 	('Monasteries of Meteora', 'GR'),
-- 	('The Holy Monastery of Stavronikita', 'GR'),
-- 	('Taung Kalat Monastery', 'MM'),
-- 	('Pa-Auk Forest Monastery', 'MM'),
-- 	('Taktsang Palphug Monastery', 'BT'),
-- 	('Sümela Monastery', 'TR');

-- ALTER TABLE countries
-- ADD COLUMN three_rivers BOOLEAN DEFAULT FALSE;

-- UPDATE countries
-- SET three_rivers = TRUE
-- WHERE country_code IN
-- 	(SELECT
-- 		country_code
-- 	FROM countries_rivers
-- 	GROUP BY country_code
-- 	HAVING COUNT(*) > 3);

-- SELECT
-- 	m.monastery_name AS monastery,
-- 	c.country_name AS country
-- FROM monasteries AS m
-- JOIN countries AS c
-- 	ON m.country_code = c.country_code
-- WHERE c.three_rivers = FALSE
-- ORDER BY monastery


-- UPDATE countries
-- SET country_name = 'Burma'
-- WHERE country_name LIKE 'Myanmar';

-- INSERT INTO monasteries(monastery_name,country_code)
-- VALUES
-- 	('Hanga Abbey', (SELECT country_code FROM countries WHERE country_name LIKE 'Tanzania')),
-- 	('Myin-Tin-Daik', (SELECT country_code FROM countries WHERE country_name LIKE 'Myanmar'));

-- SELECT
-- 	con.continent_name,
-- 	cou.country_name,
-- 	COUNT(m.monastery_name) AS monasteries_count
-- FROM countries AS cou
-- LEFT JOIN continents AS con
-- 	ON cou.continent_code = con.continent_code
-- LEFT JOIN monasteries AS m
-- 	ON cou.country_code = m.country_code
-- WHERE cou.three_rivers = FALSE
-- GROUP BY cou.country_name, con.continent_name
-- ORDER BY
-- 	monasteries_count DESC,
-- 	cou.country_name


-- SELECT
-- 	tablename,
-- 	indexname,
-- 	indexdef
-- FROM pg_indexes
-- WHERE schemaname LIKE 'public'
-- ORDER BY
-- 	tablename,
-- 	indexname


-- CREATE OR REPLACE VIEW continent_currency_usage AS
-- SELECT
-- 	ranked_currencies.continent_code,
-- 	ranked_currencies.currency_code,
-- 	ranked_currencies.currency_usage
-- FROM (
-- 	SELECT
-- 		c.continent_code,
-- 		c.currency_code,
-- 		COUNT(c.currency_code) AS currency_usage,
-- 		DENSE_RANK () OVER (PARTITION BY c.continent_code ORDER BY COUNT(c.currency_code) DESC) AS currency_usage_rank
-- 	FROM countries AS c
-- 	GROUP BY c.continent_code, c.currency_code
-- 	HAVING COUNT(c.currency_code) > 1
-- ) AS ranked_currencies
-- WHERE ranked_currencies.currency_usage_rank = 1
-- ORDER BY ranked_currencies.currency_usage DESC


SELECT
	peaks_ranking.country_name,
	COALESCE(peaks_ranking.peak_name, '(no highest peak)') AS highest_peak_name,
	COALESCE(peaks_ranking.elevation, 0) AS highest_peak_elevation,
	CASE
		WHEN peaks_ranking.elevation > 0 THEN peaks_ranking.mountain_range
		ELSE ('(no mountain)')
	END AS mountain
FROM (
	SELECT 
		c.country_name,
		p.peak_name,
		p.elevation,
		m.mountain_range,
		DENSE_RANK () OVER (PARTITION BY c.country_name ORDER BY p.elevation DESC) AS ranking
	FROM countries AS c
	LEFT JOIN mountains_countries AS mc
		ON c.country_code = mc.country_code
	LEFT JOIN mountains AS m
		ON mc.mountain_id = m.id
	LEFT JOIN peaks AS p
		ON m.id = p.mountain_id
) AS peaks_ranking
WHERE peaks_ranking.ranking = 1







