-- Процедури за таблица SPORT

CREATE OR REPLACE PROCEDURE proc_delete_sport(
    p_n_sport IN sport.N_sport%TYPE
) AS
BEGIN
    DELETE FROM sport
    WHERE N_sport = p_n_sport;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20011, 'Няма спорт с това ID.');
    END IF;
END;
/

CREATE OR REPLACE PROCEDURE proc_report_members_by_sport AS
BEGIN
    FOR r IN (
        SELECT
            s.N_sport,
            s.Ime_sport,
            COUNT(DISTINCT za.N_chlen) AS broi_chlenove
        FROM sport s
        LEFT JOIN grupa g ON g.N_sport = s.N_sport
        LEFT JOIN zapisani_abonamenti za ON za.N_grupa = g.N_grupa
        GROUP BY s.N_sport, s.Ime_sport
        ORDER BY s.N_sport
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
            'Спорт #' || r.N_sport || ' - ' || r.Ime_sport ||
            ', брой членове: ' || r.broi_chlenove
        );
    END LOOP;
END;
/

CREATE OR REPLACE PROCEDURE proc_chlen_po_sport_refcursor(
    p_sport_name IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT DISTINCT c.N_chlen, c.Ime_chlen, s.Ime_sport
        FROM chlen c
        JOIN trenirovka t ON t.N_chlen = c.N_chlen
        JOIN grupa g ON g.N_grupa = t.N_grupa
        JOIN sport s ON s.N_sport = g.N_sport
        WHERE UPPER(s.Ime_sport) LIKE '%' || UPPER(p_sport_name) || '%'
        ORDER BY c.N_chlen;
END;
/
