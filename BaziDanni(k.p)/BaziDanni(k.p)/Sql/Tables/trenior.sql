CREATE TABLE trenior(
    N_trenior INTEGER PRIMARY KEY,
    Ime_trenior VARCHAR2(100) NOT NULL,
    N_sport INTEGER NOT NULL,
    Telefon_trenior VARCHAR2(14),
    CONSTRAINT trenior_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport)
);
