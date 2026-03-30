CREATE TABLE grupa(
    N_grupa INTEGER PRIMARY KEY,
    N_sport INTEGER NOT NULL,
    N_nivo INTEGER NOT NULL,
    N_trenior INTEGER NOT NULL,
    CONSTRAINT grupa_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport),
    CONSTRAINT grupa_trenior FOREIGN KEY (N_trenior) REFERENCES trenior(N_trenior),
    CONSTRAINT grupa_nivo FOREIGN KEY (N_nivo) REFERENCES nivo(N_nivo)
);
