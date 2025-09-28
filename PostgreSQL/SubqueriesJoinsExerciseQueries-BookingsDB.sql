-- SELECT
-- 	CONCAT_WS(' ', a.address, a.address_2) AS apartment_address,
-- 	b.booked_for AS nights
-- FROM apartments AS a
-- JOIN bookings AS b
-- 	ON a.booking_id = b.booking_id
-- ORDER BY a.apartment_id


-- SELECT
-- 	a.name,
-- 	a.country,
-- 	b.booked_at::date
-- FROM apartments AS a
-- LEFT JOIN bookings AS b
-- 	ON a.booking_id = b.booking_id
-- LIMIT 10


-- SELECT
-- 	b.booking_id,
-- 	b.starts_at::date,
-- 	b.apartment_id,
-- 	CONCAT_WS(' ', c.first_name, c.last_name) AS customer_name
-- FROM bookings AS b
-- RIGHT JOIN customers AS c
-- 	ON b.customer_id = c.customer_id
-- ORDER BY customer_name
-- LIMIT 10


-- SELECT
-- 	b.booking_id,
-- 	a."name" AS apartment_owner,
-- 	a.apartment_id,
-- 	CONCAT_WS(' ', c.first_name, c.last_name) AS customer_name
-- FROM bookings AS b
-- FULL JOIN apartments AS a
-- 	ON b.booking_id = a.booking_id
-- FULL JOIN customers AS c
-- 	ON b.customer_id = c.customer_id
-- ORDER BY
-- 	b.booking_id,
-- 	apartment_owner,
-- 	customer_name


-- SELECT
-- 	b.booking_id,
-- 	c.first_name
-- FROM bookings AS b
-- CROSS JOIN customers AS c
-- ORDER BY c.first_name


-- SELECT
-- 	b.booking_id,
-- 	b.apartment_id,
-- 	c.companion_full_name
-- FROM bookings AS b
-- JOIN customers AS c
-- 	ON b.customer_id = c.customer_id
-- WHERE b.apartment_id IS NULL


-- SELECT
-- 	b.apartment_id,
-- 	b.booked_for,
-- 	c.first_name,
-- 	c.country
-- FROM bookings AS b
-- JOIN customers AS c
-- 	ON b.customer_id = c.customer_id
-- WHERE c.job_type LIKE 'Lead'


-- SELECT
-- 	COUNT(*)
-- FROM bookings AS b
-- JOIN customers AS c
-- 	ON b.customer_id = c.customer_id
-- WHERE c.last_name LIKE 'Hahn'


-- SELECT
-- 	a."name",
-- 	SUM(b.booked_for)
-- FROM apartments AS a
-- JOIN bookings AS b
-- 	ON a.apartment_id = b.apartment_id
-- GROUP BY a."name"
-- ORDER BY a."name"


-- SELECT
-- 	a.country,
-- 	COUNT(b.booking_id) AS booking_count
-- FROM bookings AS b
-- JOIN apartments AS a
-- 	ON b.apartment_id = a.apartment_id
-- WHERE b.booked_at > '2021-05-18 07:52:09.904+03' AND b.booked_at < '2021-09-17 19:48:02.147+03'
-- GROUP BY a.country
-- ORDER BY booking_count DESC