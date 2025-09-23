-- CREATE TABLE bookings_calculation AS
-- SELECT
-- 	booked_for
-- FROM bookings
-- WHERE apartment_id = 93;

-- ALTER TABLE bookings_calculation
-- ADD COLUMN multiplication NUMERIC,
-- ADD COLUMN modulo NUMERIC;

-- UPDATE bookings_calculation
-- SET
-- 	multiplication = booked_for * 50,
-- 	modulo = booked_for % 50;


-- SELECT
-- 	latitude,
-- 	ROUND(latitude, 2) AS round,
-- 	TRUNC(latitude, 2) AS trunc
-- FROM apartments


-- SELECT
-- 	longitude,
-- 	ABS(longitude) AS abs
-- FROM apartments


-- ALTER TABLE bookings
-- ADD COLUMN billing_day TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP

-- SELECT
-- 	TO_CHAR(billing_day, 'DD "Day" MM "Month" YYYY "Year" HH24:MI:SS') AS "Billind Day"
-- FROM bookings


-- SELECT
-- 	EXTRACT(year FROM booked_at) AS "YEAR",
-- 	EXTRACT(month FROM booked_at) AS "MONTH",
-- 	EXTRACT(day FROM booked_at) AS "DAY",
-- 	EXTRACT(hour FROM booked_at AT TIME ZONE 'UTC') AS "HOUR",
-- 	EXTRACT(minute FROM booked_at) AS "MINUTE",
-- 	CEILING(EXTRACT(second FROM booked_at)) AS "SECOND"
-- FROM bookings


-- SELECT
-- 	user_id,
-- 	AGE(starts_at, booked_at) AS "early_birds"
-- FROM bookings
-- WHERE AGE(starts_at, booked_at) > INTERVAL '10 months'


-- SELECT
-- 	companion_full_name,
-- 	email
-- FROM users
-- WHERE
-- 	companion_full_name ILIKE '%aNd%' AND
-- 	email NOT LIKE '%@gmail'


-- ALTER TABLE users
-- ADD COLUMN initials CHAR(2);

-- UPDATE users
-- SET initials = LEFT(first_name, 2); 

-- SELECT
-- 	initials,
-- 	COUNT(initials) AS user_count
-- FROM users
-- GROUP BY initials
-- ORDER BY
-- 	user_count DESC,
-- 	initials


-- SELECT
-- 	SUM(booked_for) AS total_value
-- FROM bookings
-- WHERE apartment_id = 90


-- SELECT
-- 	AVG(multiplication) AS average_value
-- FROM bookings_calculation