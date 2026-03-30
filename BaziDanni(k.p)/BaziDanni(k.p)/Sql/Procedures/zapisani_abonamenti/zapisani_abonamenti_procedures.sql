-- Процедури за таблица ZAPISANI_ABONAMENTI

CREATE OR REPLACE PROCEDURE proc_register_subscription(
    p_n_chlen     IN zapisani_abonamenti.N_chlen%TYPE,
    p_n_grupa     IN zapisani_abonamenti.N_grupa%TYPE,
    p_n_abonament IN zapisani_abonamenti.N_abonament%TYPE
) AS
BEGIN
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament, Data_zapis)
    VALUES (p_n_chlen, p_n_grupa, p_n_abonament, SYSDATE);

    UPDATE abonament
    SET Cena_lv = Cena_lv
    WHERE N_abonament = p_n_abonament;

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/
