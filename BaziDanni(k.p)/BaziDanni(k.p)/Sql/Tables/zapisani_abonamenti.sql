CREATE TABLE zapisani_abonamenti(
    N_chlen INTEGER NOT NULL,
    N_grupa INTEGER NOT NULL,
    N_abonament INTEGER NOT NULL,
    Data_zapis DATE,
    CONSTRAINT pk_zapisani_abonamenti PRIMARY KEY (N_chlen, N_grupa, N_abonament),
    CONSTRAINT zapisani_abonamenti_chlen FOREIGN KEY (N_chlen) REFERENCES chlen(N_chlen),
    CONSTRAINT zapisani_abonamenti_grupa FOREIGN KEY (N_grupa) REFERENCES grupa(N_grupa),
    CONSTRAINT zapisani_abonamenti_abonament FOREIGN KEY (N_abonament) REFERENCES abonament(N_abonament)
);
