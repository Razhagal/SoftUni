-- CREATE TABLE IF NOT EXISTS brands(
-- 	id SERIAL PRIMARY KEY,
-- 	"name" VARCHAR(50) NOT NULL UNIQUE
-- );

-- CREATE TABLE IF NOT EXISTS classifications(
-- 	id SERIAL PRIMARY KEY,
-- 	"name" VARCHAR(30) NOT NULL UNIQUE
-- );

-- CREATE TABLE IF NOT EXISTS customers(
-- 	id SERIAL PRIMARY KEY,
-- 	first_name VARCHAR(30) NOT NULL,
-- 	last_name VARCHAR(30) NOT NULL,
-- 	address VARCHAR(150) NOT NULL,
-- 	phone VARCHAR(30) NOT NULL UNIQUE,
-- 	loyalty_card BOOLEAN NOT NULL DEFAULT FALSE
-- );

-- CREATE TABLE IF NOT EXISTS items(
-- 	id SERIAL PRIMARY KEY,
-- 	"name" VARCHAR(50) NOT NULL,
-- 	quantity INT NOT NULL CHECK(quantity >= 0),
-- 	price DECIMAL(12, 2) NOT NULL CHECK(price > 0.00),
-- 	description TEXT,
-- 	brand_id INT NOT NULL REFERENCES brands ON DELETE CASCADE ON UPDATE CASCADE,
-- 	classification_id INT NOT NULL REFERENCES classifications ON DELETE CASCADE ON UPDATE CASCADE
-- );

-- CREATE TABLE IF NOT EXISTS orders(
-- 	id SERIAL PRIMARY KEY,
-- 	created_at TIMESTAMP NOT NULL DEFAULT NOW(),
-- 	customer_id INT NOT NULL REFERENCES customers ON DELETE CASCADE ON UPDATE CASCADE
-- );

-- CREATE TABLE IF NOT EXISTS reviews(
-- 	customer_id INT NOT NULL REFERENCES customers ON DELETE CASCADE ON UPDATE CASCADE,
-- 	item_id INT NOT NULL REFERENCES items ON DELETE CASCADE ON UPDATE CASCADE,
-- 	created_at TIMESTAMP NOT NULL DEFAULT NOW(),
-- 	rating DECIMAL(3, 1) NOT NULL DEFAULT 0.0 CHECK(rating <= 10.0),
-- 	PRIMARY KEY (customer_id, item_id)
-- );

-- CREATE TABLE IF NOT EXISTS orders_items(
-- 	order_id INT NOT NULL REFERENCES orders ON DELETE CASCADE ON UPDATE CASCADE,
-- 	item_id INT NOT NULL REFERENCES items ON DELETE CASCADE ON UPDATE CASCADE,
-- 	quantity INT NOT NULL CHECK(quantity >= 0),
-- 	PRIMARY KEY (order_id, item_id)
-- );


-- INSERT INTO items("name", quantity, price, description, brand_id, classification_id)
-- SELECT
-- 	CONCAT('Item', created_at),
-- 	customer_id,
-- 	(rating * 5),
-- 	NULL,
-- 	item_id,
-- 	(SELECT MIN(item_id) FROM reviews)
-- FROM reviews
-- ORDER BY item_id
-- LIMIT 10


-- UPDATE reviews
-- SET rating = CASE
-- 				WHEN item_id = customer_id THEN 10.0
-- 				WHEN customer_id > item_id THEN 5.5
-- 				ELSE rating
-- 			END;


-- DELETE FROM customers
-- WHERE id NOT IN (SELECT customer_id FROM orders)


-- SELECT
-- 	id,
-- 	last_name,
-- 	loyalty_card
-- FROM customers
-- WHERE loyalty_card = TRUE AND last_name ILIKE '%m%'
-- ORDER BY
-- 	last_name DESC,
-- 	id


-- SELECT
-- 	id,
-- 	TO_CHAR(created_at, 'DD-MM-YYYY') AS created_at,
-- 	customer_id
-- FROM orders
-- WHERE created_at > '01-01-2025' AND customer_id BETWEEN 15 AND 30
-- ORDER BY
-- 	created_at,
-- 	customer_id DESC,
-- 	id
-- LIMIT 5


-- SELECT
-- 	i.name,
-- 	CONCAT(UPPER(b.name), '/', LOWER(c.name)) AS promotion,
-- 	CONCAT('On sale: ', i.description) AS description,
-- 	i.quantity
-- FROM items AS i
-- LEFT JOIN orders_items AS oi
-- 	ON oi.item_id = i.id
-- JOIN brands AS b
-- 	ON b.id = i.brand_id
-- JOIN classifications AS c
-- 	ON c.id = i.classification_id
-- WHERE oi.order_id IS NULL
-- ORDER BY
-- 	i.quantity DESC,
-- 	i.name


-- SELECT
-- 	c.id AS customer_id,
-- 	CONCAT(c.first_name, ' ', c.last_name) AS full_name,
-- 	COUNT(*) AS total_orders,
-- 	CASE
-- 		WHEN c.loyalty_card = TRUE THEN 'Loyal Customer'
-- 		ELSE 'Regular Customer'
-- 	END AS loyalty_status
-- FROM customers AS c
-- JOIN orders AS o
-- 	ON o.customer_id = c.id
-- LEFT JOIN reviews AS r
-- 	ON r.customer_id = c.id
-- WHERE r.customer_id IS NULL
-- GROUP BY c.id
-- ORDER BY
-- 	total_orders DESC,
-- 	customer_id


-- SELECT
-- 	i.name AS item_name,
-- 	ROUND(AVG(r.rating), 2) AS average_rating,
-- 	COUNT(*) AS total_reviews,
-- 	b.name AS brand_name,
-- 	c.name AS classification_name
-- FROM items AS i
-- JOIN reviews AS r
-- 	ON i.id = r.item_id
-- JOIN brands AS b
-- 	ON i.brand_id = b.id
-- JOIN classifications AS c
-- 	ON i.classification_id = c.id
-- GROUP BY i.id, b.name, c.name
-- HAVING COUNT(*) >= 3
-- ORDER BY
-- 	average_rating DESC,
-- 	item_name
-- LIMIT 3


-- CREATE OR REPLACE FUNCTION udf_classification_items_count(classification_name VARCHAR(30))
-- RETURNS VARCHAR
-- AS
-- $$
-- DECLARE
-- 	items_count INT;
-- BEGIN
-- 	SELECT
-- 		COUNT(*) INTO items_count
-- 	FROM items AS i
-- 	JOIN classifications AS c
-- 		ON i.classification_id = c.id
-- 	WHERE c.name = classification_name;

-- 	IF items_count > 0 THEN
-- 		RETURN FORMAT('Found %s items.', items_count);
-- 	ELSE
-- 		RETURN 'No items found.';
-- 	END IF;
-- END;
-- $$
-- LANGUAGE plpgsql;


CREATE OR REPLACE PROCEDURE udp_update_loyalty_status(min_orders INT)
AS
$$
BEGIN
	UPDATE customers
	SET loyalty_card = TRUE
	WHERE id IN (
		SELECT
			c.id
		FROM customers AS c
		JOIN orders AS o
			ON c.id = o.customer_id
		GROUP BY c.id
		HAVING COUNT(*) >= min_orders
	);
END;
$$
LANGUAGE plpgsql;