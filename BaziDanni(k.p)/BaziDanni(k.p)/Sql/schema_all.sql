-- Един общ DDL файл за създаване на таблиците и връзките между тях.

CREATE TABLE nivo(
    N_nivo INTEGER PRIMARY KEY,
    Ime_nivo VARCHAR2(30) NOT NULL,
    Cvyat VARCHAR2(20)
);

CREATE TABLE den_sedmica(
    N_den INTEGER PRIMARY KEY,
    Den VARCHAR2(20) NOT NULL,
    Cvyat VARCHAR2(20)
);

CREATE TABLE abonament(
    N_abonament INTEGER PRIMARY KEY,
    Period_meseci INTEGER NOT NULL,
    Cena_lv NUMBER(10,2) NOT NULL
);

CREATE TABLE chlen (
    N_chlen INTEGER PRIMARY KEY,
    Ime_chlen VARCHAR2(40) NOT NULL,
    EGN VARCHAR2(10) NOT NULL,
    Telefon VARCHAR2(14),
    Adres VARCHAR2(80)
);

CREATE TABLE sport(
    N_sport INTEGER PRIMARY KEY,
    Ime_sport VARCHAR2(40) NOT NULL,
    Cvyat VARCHAR2(20)
);

CREATE TABLE trenior(
    N_trenior INTEGER PRIMARY KEY,
    Ime_trenior VARCHAR2(100) NOT NULL,
    N_sport INTEGER NOT NULL,
    Telefon_trenior VARCHAR2(14),
    CONSTRAINT trenior_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport)
);

CREATE TABLE grupa(
    N_grupa INTEGER PRIMARY KEY,
    N_sport INTEGER NOT NULL,
    N_nivo INTEGER NOT NULL,
    N_trenior INTEGER NOT NULL,
    CONSTRAINT grupa_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport),
    CONSTRAINT grupa_trenior FOREIGN KEY (N_trenior) REFERENCES trenior(N_trenior),
    CONSTRAINT grupa_nivo FOREIGN KEY (N_nivo) REFERENCES nivo(N_nivo)
);

CREATE TABLE trenirovka(
    N_grupa INTEGER NOT NULL,
    datata DATE NOT NULL,
    chas VARCHAR2(6) NOT NULL,
    N_chlen INTEGER NOT NULL,
    N_den INTEGER NOT NULL,
    CONSTRAINT pk_trenirovka PRIMARY KEY (N_grupa, datata, chas, N_chlen),
    CONSTRAINT trenirovka_grupa FOREIGN KEY (N_grupa) REFERENCES grupa(N_grupa),
    CONSTRAINT trenirovka_chlen FOREIGN KEY (N_chlen) REFERENCES chlen(N_chlen),
    CONSTRAINT trenirovka_den_sedmica FOREIGN KEY (N_den) REFERENCES den_sedmica(N_den)
);

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
