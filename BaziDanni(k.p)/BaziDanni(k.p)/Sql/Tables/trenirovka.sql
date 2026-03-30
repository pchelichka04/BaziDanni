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
