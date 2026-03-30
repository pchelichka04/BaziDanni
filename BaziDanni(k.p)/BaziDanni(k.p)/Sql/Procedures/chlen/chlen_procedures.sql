-- Процедури за таблица CHLEN

CREATE OR REPLACE PROCEDURE proc_upsert_chlen(
    p_n_chlen    IN chlen.N_chlen%TYPE,
    p_ime_chlen  IN chlen.Ime_chlen%TYPE,
    p_egn        IN chlen.EGN%TYPE,
    p_telefon    IN chlen.Telefon%TYPE,
    p_adres      IN chlen.Adres%TYPE
) AS
    v_count NUMBER;
BEGIN
    IF p_ime_chlen IS NULL OR LENGTH(TRIM(p_ime_chlen)) < 3 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Името трябва да е поне 3 символа.');
    END IF;

    IF p_egn IS NULL OR NOT REGEXP_LIKE(p_egn, '^[0-9]{10}$') THEN
        RAISE_APPLICATION_ERROR(-20002, 'ЕГН трябва да е точно 10 цифри.');
    END IF;

    SELECT COUNT(*) INTO v_count FROM chlen WHERE N_chlen = p_n_chlen;

    IF v_count = 0 THEN
        INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres)
        VALUES (p_n_chlen, TRIM(p_ime_chlen), p_egn, p_telefon, p_adres);
    ELSE
        UPDATE chlen
        SET Ime_chlen = TRIM(p_ime_chlen),
            EGN = p_egn,
            Telefon = p_telefon,
            Adres = p_adres
        WHERE N_chlen = p_n_chlen;
    END IF;
END;
/
