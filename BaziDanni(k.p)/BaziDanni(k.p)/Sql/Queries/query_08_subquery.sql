-- Справка 8: членове с абонамент над средната цена.
SELECT DISTINCT
    c.N_chlen,
    c.Ime_chlen,
    a.Cena_lv
FROM chlen c
JOIN zapisani_abonamenti za ON za.N_chlen = c.N_chlen
JOIN abonament a ON a.N_abonament = za.N_abonament
WHERE a.Cena_lv > (
    SELECT AVG(a2.Cena_lv)
    FROM abonament a2
)
ORDER BY a.Cena_lv DESC, c.Ime_chlen;
