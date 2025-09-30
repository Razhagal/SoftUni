-- CREATE OR REPLACE FUNCTION fn_full_name(first_name VARCHAR, last_name VARCHAR)
-- RETURNS VARCHAR
-- LANGUAGE plpgsql
-- AS
-- $$
-- BEGIN
-- 	RETURN INITCAP(CONCAT_WS(' ', first_name, last_name));
-- END;
-- $$;


-- CREATE OR REPLACE FUNCTION fn_calculate_future_value(initial_sum INT, yearly_interest_rate DECIMAL, number_of_years INT)
-- RETURNS DECIMAL
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	future_value DECIMAL;
-- BEGIN
-- 	future_value := initial_sum * POWER((1 + yearly_interest_rate), number_of_years);
-- 	RETURN TRUNC(future_value, 4);
-- END;
-- $$;


-- CREATE OR REPLACE FUNCTION fn_is_word_comprised(set_of_letters VARCHAR(50), word VARCHAR(50))
-- RETURNS BOOLEAN
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	processed_set_of_letters VARCHAR(50);
-- 	processed_word VARCHAR(50);
-- 	letter char(1);
-- 	i INT := 1;
-- BEGIN
-- 	processed_set_of_letters := regexp_replace(lower(set_of_letters), '[^a-z]', '', 'g');
-- 	processed_word := regexp_replace(lower(word), '[^a-z]', '', 'g');

-- 	WHILE i <= length(processed_word) LOOP
-- 		letter := substring(processed_word, i, 1);

-- 		IF position(letter IN processed_set_of_letters) = 0 THEN
-- 			RETURN FALSE;
-- 		END IF;

-- 		processed_set_of_letters := overlay(processed_set_of_letters PLACI)
	
-- END;
-- $$;


-- CREATE OR REPLACE PROCEDURE sp_retrieving_holders_with_balance_higher_than(searched_balance NUMERIC)
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	r RECORD;
-- BEGIN
-- 	FOR r IN
-- 		SELECT
-- 			ah.first_name,
-- 			ah.last_name,
-- 			a.account_holder_id,
-- 			SUM(a.balance) AS balance
-- 		FROM accounts a
-- 		JOIN account_holders ah
-- 			ON a.account_holder_id = ah.id
-- 		GROUP BY ah.first_name, ah.last_name, a.account_holder_id
-- 		HAVING SUM(a.balance) > searched_balance
-- 		ORDER BY
-- 			ah.first_name,
-- 			ah.last_name,
-- 			balance
-- 	LOOP
-- 		RAISE NOTICE '% % - %', r.first_name, r.last_name, r.balance;
-- 	END LOOP;
-- END;
-- $$;

-- CALL sp_retrieving_holders_with_balance_higher_than(20000);


-- CREATE OR REPLACE PROCEDURE sp_deposit_money(account_id INT, money_amount NUMERIC(1000, 4))
-- LANGUAGE plpgsql
-- AS $$
-- BEGIN
-- 	IF (SELECT COUNT(id) FROM accounts WHERE id = account_id) != 1 THEN
-- 	ROLLBACK;
-- 	ELSE
-- 		UPDATE accounts
-- 		SET balance = balance + money_amount
-- 		WHERE "id" = account_id;
-- 	END IF;
-- 	COMMIT;
-- END;
-- $$;


-- CREATE OR REPLACE PROCEDURE sp_withdraw_money(account_id INT, money_amount NUMERIC(1000, 4))
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	current_balance NUMERIC(1000, 4);
-- BEGIN
-- 	SELECT balance INTO current_balance
-- 	FROM accounts
-- 	WHERE "id" = account_id;

-- 	IF NOT FOUND THEN
-- 		RAISE NOTICE 'No such account found!';
-- 	ROLLBACK;
-- 	ELSIF current_balance < money_amount THEN
-- 		RAISE NOTICE 'Insufficient balance to withdraw %', money_amount;
-- 	ROLLBACK;
-- 	ELSE
-- 		UPDATE accounts
-- 		SET balance = balance - money_amount
-- 		WHERE "id" = account_id;
-- 	END IF;
-- 	COMMIT;
-- END;
-- $$;




-- CREATE OR REPLACE PROCEDURE sp_withdraw_money(account_id INT, money_amount NUMERIC(1000, 4), INOUT withdraw_successful BOOLEAN)
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	current_balance NUMERIC(1000, 4);
-- BEGIN
-- 	SELECT balance INTO current_balance
-- 	FROM accounts
-- 	WHERE "id" = account_id;

-- 	IF NOT FOUND THEN
-- 		RAISE NOTICE 'No such account found!';
-- 		withdraw_successful = FALSE;
-- 	ELSIF current_balance < money_amount THEN
-- 		RAISE NOTICE 'Insufficient balance to withdraw %', money_amount;
-- 		withdraw_successful = FALSE;
-- 	ELSE
-- 		UPDATE accounts
-- 		SET balance = balance - money_amount
-- 		WHERE "id" = account_id;
-- 		withdraw_successful = TRUE;
-- 	END IF;
-- END;
-- $$;

-- CREATE OR REPLACE PROCEDURE sp_deposit_money(account_id INT, money_amount NUMERIC(1000, 4), INOUT withdraw_successful BOOLEAN)
-- LANGUAGE plpgsql
-- AS $$
-- BEGIN
-- 	IF (SELECT COUNT(id) FROM accounts WHERE id = account_id) != 1 THEN
-- 		withdraw_successful = FALSE;
-- 	ELSE
-- 		UPDATE accounts
-- 		SET balance = balance + money_amount
-- 		WHERE "id" = account_id;
-- 		withdraw_successful = TRUE;
-- 	END IF;
-- END;
-- $$;

-- CREATE OR REPLACE PROCEDURE sp_transfer_money(sender_id INT, receiver_id INT, amount NUMERIC(1000, 4))
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	operation_successful BOOLEAN;
-- BEGIN
-- 	operation_successful := FALSE;

-- 	CALL sp_withdraw_money(sender_id, amount, operation_successful);
-- 	IF operation_successful = FALSE THEN
-- 	ROLLBACK;
-- 	END IF;

-- 	CALL sp_deposit_money(receiver_id, amount, operation_successful);
-- 	IF operation_successful = FALSE THEN
-- 	ROLLBACK;
-- 	END IF;

-- 	COMMIT;
-- END;
-- $$;

-- CALL sp_transfer_money(13, 15, 400.9000);


-- DROP PROCEDURE sp_retrieving_holders_with_balance_higher_than;


-- CREATE TABLE logs(
-- 	id SERIAL PRIMARY KEY,
-- 	account_id INT,
-- 	old_sum DECIMAL(19, 4),
-- 	new_sum DECIMAL(19, 4)
-- );

-- CREATE OR REPLACE FUNCTION trigger_fn_insert_new_entry_into_logs()
-- RETURNS TRIGGER
-- LANGUAGE plpgsql
-- AS $$
-- BEGIN
-- 	IF OLD.balance != NEW.balance THEN
-- 		INSERT INTO logs(account_id, old_sum, new_sum)
-- 		VALUES
-- 			(OLD.id, OLD.balance, NEW.balance);
-- 	END IF;
-- 	RETURN NEW;
-- END;
-- $$;

-- CREATE TRIGGER tr_account_balance_change
-- 	AFTER UPDATE
-- 	ON accounts
-- 	FOR EACH ROW
-- 	-- WHEN OLD.balance != NEW.balance
-- 	EXECUTE FUNCTION trigger_fn_insert_new_entry_into_logs();


-- CREATE TABLE notification_emails(
-- 	id SERIAL PRIMARY KEY,
-- 	recipient_id INT NOT NULL,
-- 	subject TEXT,
-- 	body TEXT
-- );

-- CREATE OR REPLACE FUNCTION trigger_fn_send_email_on_balance_change()
-- RETURNS TRIGGER
-- LANGUAGE plpgsql
-- AS $$
-- DECLARE
-- 	new_subject TEXT;
-- 	new_body TEXT;
-- BEGIN
-- 	new_subject := FORMAT('Balance change for account: %s', OLD.account_id);
-- 	new_body := FORMAT('On %s your balance was changed from %s to %s.', NOW()::DATE, OLD.new_sum, NEW.new_sum);

-- 	INSERT INTO notification_emails(recipient_id, subject, body)
-- 	VALUES
-- 		(OLD.account_id, new_subject, new_body);
-- 	RETURN NEW;
-- END;
-- $$;

-- CREATE TRIGGER tr_send_email_on_balance_change
-- 	AFTER UPDATE
-- 	ON logs
-- 	FOR EACH ROW
-- 	EXECUTE FUNCTION trigger_fn_send_email_on_balance_change();