CREATE TABLE nivo(
    N_nivo INTEGER PRIMARY KEY,
    Ime_nivo VARCHAR2(30)
    );
    
    
CREATE TABLE den_sedmica(
    N_den INTEGER PRIMARY KEY,
    Den VARCHAR2(20)
    );
    
    
CREATE TABLE abonament(
    Period_meseci INTEGER ,
    Cena_lv INTEGER ,
    N_abonament INTEGER PRIMARY KEY
    );
    
    
CREATE TABLE chlen (
    N_chlen INTEGER PRIMARY KEY,
    Ime_chlen VARCHAR2(40),
    EGN VARCHAR2(10),
    Telefon VARCHAR2(14),
    Adres VARCHAR2(80)
    );
    
    
CREATE TABLE sport(
    N_sport INTEGER PRIMARY KEY,
    Ime_sport VARCHAR2(40)
    );
    
    
CREATE TABLE trenior(
    N_trenior INTEGER PRIMARY KEY,
    Ime_trenior VARCHAR2(100),
    N_sport INTEGER,
    Telefon_trenior VARCHAR2(14),
    constraint trenior_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport)
    );
    
    
CREATE TABLE grupa(
    N_grupa INTEGER PRIMARY KEY,
    N_sport INTEGER,
    N_nivo INTEGER,
    N_trenior INTEGER,
    constraint grupa_sport FOREIGN KEY (N_sport) REFERENCES sport(N_sport),
    constraint grupa_trenior FOREIGN KEY (N_trenior) REFERENCES trenior(N_trenior),
    constraint nivo FOREIGN KEY (N_nivo) REFERENCES nivo(N_nivo)
    );
    
    
CREATE TABLE trenirovka(
    N_grupa INTEGER,
    datata DATE,
    chas VARCHAR(6),
    N_chlen INTEGER,
    N_den INTEGER,
    constraint trenirovka_grupa FOREIGN KEY (N_grupa) REFERENCES grupa(N_grupa),
    constraint trenirovka_chlen FOREIGN KEY (N_chlen) REFERENCES chlen(N_chlen),
    constraint trenirovka_Den_sedmica FOREIGN KEY (N_den) REFERENCES den_sedmica(N_den),
    constraint pk_trenirovka PRIMARY KEY (N_grupa, datata , chas, N_chlen)
    );
    
    
CREATE TABLE zapisani_abonamenti(
    N_chlen INTEGER,
    N_grupa INTEGER,
    N_abonament INTEGER,
    constraint zapisani_abonamenti_chlen FOREIGN KEY (N_chlen) REFERENCES chlen (N_chlen),
    constraint zapisani_abonamenti_grupa FOREIGN KEY (N_grupa) REFERENCES grupa (N_grupa),
    constraint zapisani_abonamenti_abonament FOREIGN KEY (N_abonament) REFERENCES abonament (N_abonament)
    );
    
    
    
    
    INSERT INTO nivo (N_nivo, Ime_nivo) VALUES (1, 'Начинаещи');
    INSERT INTO nivo (N_nivo, Ime_nivo) VALUES (2, 'Напреднали');
    INSERT INTO nivo (N_nivo, Ime_nivo) VALUES (3, 'Експерти');
    INSERT INTO nivo (Ime_nivo) VALUES ('Експертии');
    COMMIT;
    
    
    INSERT INTO den_sedmica (N_den, Den) VALUES (1, 'Понеделник');
    INSERT INTO den_sedmica (N_den, Den) VALUES (2, 'Вторник');
    INSERT INTO den_sedmica (N_den, Den) VALUES (3, 'Сряда');
    INSERT INTO den_sedmica (N_den, Den) VALUES (4, 'Четвъртък');
    COMMIT;
    
    
    INSERT INTO abonament (Period_meseci, Cena_lv, N_abonament) VALUES (1, 30, 1);
    INSERT INTO abonament (Period_meseci, Cena_lv, N_abonament) VALUES (3, 80, 2);
    INSERT INTO abonament (Period_meseci, Cena_lv, N_abonament) VALUES (6, 150, 3);
    INSERT INTO abonament (Period_meseci, Cena_lv, N_abonament) VALUES (12, 280, 4);
    COMMIT;
    
    
    INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres) VALUES (1, 'Иван Иванов', '0120456789', '0878654321', 'гр. София, ул. Княз Борис 12');
    INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres) VALUES (2, 'Георги Стоянов', '9876543210', '0898765432', 'гр. Бургас, ул. Богориди 6');
    INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres) VALUES (3, 'Димитър Добрев', '1357924680', '0887766554', 'гр. Варна, ул. Драгоман 23');
    INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres) VALUES (4, 'Александър Петров', '0850143246', '0877121614', 'гр. Пловдив, ул. Тунджа 5');
    COMMIT;
    
    
    INSERT INTO sport (N_sport, Ime_sport)VALUES (1, 'Футбол');
    INSERT INTO sport (N_sport, Ime_sport)VALUES (2, 'Волейбол');
    INSERT INTO sport (N_sport, Ime_sport)VALUES (3, 'Баскетбол');
    INSERT INTO sport (N_sport, Ime_sport)VALUES (4, 'Плуване');
    COMMIT;
    
    
    INSERT INTO trenior (N_trenior, Ime_trenior, N_sport, Telefon_trenior) VALUES (1, 'Стоян Бояджиев', 4, '0876877887');
    INSERT INTO trenior (N_trenior, Ime_trenior, N_sport, Telefon_trenior) VALUES (2, 'Петър Попов', 3, '0888776554');
    INSERT INTO trenior (N_trenior, Ime_trenior, N_sport, Telefon_trenior) VALUES (3, 'Гергана Кудева', 2, '0878292543');
    INSERT INTO trenior (N_trenior, Ime_trenior, N_sport, Telefon_trenior) VALUES (4, 'Йордан Калоянов', 1, '0896427651');
    COMMIT;
    
    
    INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (1, 1, 1, 1);
    INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (2, 2, 2, 2);
    INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (3, 3, 3, 3);
    INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (4, 4, 3, 4);
    INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (5, 2, 3, 4);
    COMMIT;
    
    
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (1, DATE '2020-12-08', '10:00', 1, 1);
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (3, DATE '2020-12-08', '12:00', 2, 1);
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (4, DATE '2020-12-08', '14:00', 3, 1);
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (2, DATE '2020-12-10', '13:00', 2, 2);
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (3, DATE '2020-12-12', '08:00', 3, 3);
    INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (4, DATE '2020-12-14', '10:00', 4, 4);
    COMMIT;
    
    
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (1, 1, 1);
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (1, 2, 3);
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (2, 2, 2);
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (3, 3, 3);
    INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (4, 4, 4);
    ALTER TABLE zapisani_abonamenti ADD Data_zapis DATE;
    COMMIT;
    
    
UPDATE zapisani_abonamenti
SET Data_zapis = DATE '2020-12-01'
WHERE N_chlen = 1 AND N_grupa = 1 AND N_abonament = 1;

UPDATE zapisani_abonamenti
SET Data_zapis = DATE '2020-12-05'
WHERE N_chlen = 1 AND N_grupa = 2 AND N_abonament = 3;

UPDATE zapisani_abonamenti
SET Data_zapis = DATE '2020-12-10'
WHERE N_chlen = 2 AND N_grupa = 2 AND N_abonament = 2;

UPDATE zapisani_abonamenti
SET Data_zapis = DATE '2020-12-12'
WHERE N_chlen = 3 AND N_grupa = 3 AND N_abonament = 3;

UPDATE zapisani_abonamenti
SET Data_zapis = DATE '2020-12-14'
WHERE N_chlen = 4 AND N_grupa = 4 AND N_abonament = 4;

COMMIT;


-- TRIGERI ZA AUTO INCREMENT

-- SEQUENCE NIVO
CREATE SEQUENCE seq_nivo START WITH 4 INCREMENT BY 1 NOCACHE;

-- TRIGGER NIVO
CREATE OR REPLACE TRIGGER bi_nivo
BEFORE INSERT ON nivo
FOR EACH ROW
BEGIN
  IF :NEW.N_nivo IS NULL THEN
    :NEW.N_nivo := seq_nivo.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE DEN_SEDMICA
CREATE SEQUENCE seq_den_sedmica START WITH 5 INCREMENT BY 1 NOCACHE;

-- TRIGGER DEN_SEDMICA
CREATE OR REPLACE TRIGGER bi_den_sedmica
BEFORE INSERT ON den_sedmica
FOR EACH ROW
BEGIN
  IF :NEW.N_den IS NULL THEN
    :NEW.N_den := seq_den_sedmica.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE ABONAMENT
CREATE SEQUENCE seq_abonament START WITH 5 INCREMENT BY 1 NOCACHE;

-- TRIGGER ABONAMENT
CREATE OR REPLACE TRIGGER bi_abonament
BEFORE INSERT ON abonament
FOR EACH ROW
BEGIN
  IF :NEW.N_abonament IS NULL THEN
    :NEW.N_abonament := seq_abonament.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE CHLEN
CREATE SEQUENCE seq_chlen START WITH 5 INCREMENT BY 1 NOCACHE;

-- TRIGER CHLEN
CREATE OR REPLACE TRIGGER bi_chlen
BEFORE INSERT ON chlen
FOR EACH ROW
BEGIN
  IF :NEW.N_chlen IS NULL THEN
    :NEW.N_chlen := seq_chlen.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE SPORT
CREATE SEQUENCE seq_sport START WITH 5 INCREMENT BY 1 NOCACHE;

-- TRIGER SPORT
CREATE OR REPLACE TRIGGER bi_sport
BEFORE INSERT ON sport
FOR EACH ROW
BEGIN
  IF :NEW.N_sport IS NULL THEN
    :NEW.N_sport := seq_sport.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE TRENIOR
CREATE SEQUENCE seq_trenior START WITH 5 INCREMENT BY 1 NOCACHE;

-- TRIGER TRENIOR
CREATE OR REPLACE TRIGGER bi_trenior
BEFORE INSERT ON trenior
FOR EACH ROW
BEGIN
  IF :NEW.N_trenior IS NULL THEN
    :NEW.N_trenior := seq_trenior.NEXTVAL;
  END IF;
END;
/



-- SEQUENCE GRUPA
CREATE SEQUENCE seq_grupa START WITH 6 INCREMENT BY 1 NOCACHE;

-- TRIGER GRUPA
CREATE OR REPLACE TRIGGER bi_grupa
BEFORE INSERT ON grupa
FOR EACH ROW
BEGIN
  IF :NEW.N_grupa IS NULL THEN
    :NEW.N_grupa := seq_grupa.NEXTVAL;
  END IF;
END;
/



    
--NIVO
INSERT INTO nivo (N_nivo, Ime_nivo) VALUES (5, 'Професионалисти');
UPDATE nivo SET Ime_nivo = 'Експерти' WHERE N_nivo = 5;
DELETE FROM nivo WHERE N_nivo = 5;

--DEN_SEDMICA
INSERT INTO den_sedmica (N_den, Den) VALUES (5, 'Петък');
UPDATE den_sedmica SET Den = 'Събота' WHERE N_den = 5;
DELETE FROM den_sedmica WHERE N_den = 5;

--ABONAMENT
INSERT INTO abonament (Period_meseci, Cena_lv, N_abonament) VALUES (1, 35, 5);
UPDATE abonament SET Period_meseci = 3, Cena_lv = 90 WHERE N_abonament = 5;
DELETE FROM abonament WHERE N_abonament = 5;

--CHLEN
INSERT INTO chlen (N_chlen, Ime_chlen, EGN, Telefon, Adres) VALUES (5, 'Мария Петрова', '1234567890', '0888123456', 'гр. София, ул. Шипка 1');
UPDATE chlen SET Telefon = '0888000000', Adres = 'гр. София, бул. Витоша 10' WHERE N_chlen = 5;
DELETE FROM chlen WHERE N_chlen = 5;

--SPORT
INSERT INTO sport (N_sport, Ime_sport) VALUES (5, 'Тенис');
UPDATE sport SET Ime_sport = 'Плуване (басейн)' WHERE N_sport = 5;
DELETE FROM sport WHERE N_sport = 5;

--TRENIROR
INSERT INTO trenior (N_trenior, Ime_trenior, N_sport, Telefon_trenior) VALUES (5, 'Никола Димитров', 1, '0899000111');
UPDATE trenior SET N_sport = 2, Telefon_trenior = '0899111222' WHERE N_trenior = 5;
DELETE FROM trenior WHERE N_trenior = 5;

--GRUPA
INSERT INTO grupa (N_grupa, N_sport, N_nivo, N_trenior) VALUES (5, 1, 1, 1);
UPDATE grupa SET N_sport = 2, N_nivo = 2, N_trenior = 2 WHERE N_grupa = 5;
DELETE FROM grupa WHERE N_grupa = 5;

--TRENIROVKA
INSERT INTO trenirovka (N_grupa, datata, chas, N_chlen, N_den) VALUES (1, DATE '2020-12-15', '09:00', 1, 2);
UPDATE trenirovka SET chas = '10:00', N_den = 3 WHERE N_grupa = 1 AND datata = DATE '2020-12-15' AND chas = '09:00' AND N_chlen = 1;
DELETE FROM trenirovka WHERE N_grupa = 1 AND datata = DATE '2020-12-15' AND chas = '10:00' AND N_chlen = 1;

--ZAPISANI_ABONAMENTI
INSERT INTO zapisani_abonamenti (N_chlen, N_grupa, N_abonament) VALUES (1, 1, 2);
UPDATE zapisani_abonamenti SET N_abonament = 3 WHERE N_chlen = 1 AND N_grupa = 1 AND N_abonament = 2;
DELETE FROM zapisani_abonamenti WHERE N_chlen = 1 AND N_grupa = 1 AND N_abonament = 3;


--ZAQVKI\SPRAVKI

--TARSENE PO SPORT
SELECT DISTINCT chlen.N_chlen, chlen.Ime_chlen
FROM chlen
JOIN trenirovka ON trenirovka.N_chlen = chlen.N_chlen
JOIN grupa      ON grupa.N_grupa      = trenirovka.N_grupa
JOIN sport      ON sport.N_sport      = grupa.N_sport
WHERE UPPER(sport.Ime_sport) LIKE UPPER('%Футбол%')
ORDER BY chlen.N_chlen ASC;

--TARSENE PO TRENIOR
SELECT DISTINCT chlen.N_chlen, chlen.Ime_chlen
FROM chlen
JOIN trenirovka ON trenirovka.N_chlen = chlen.N_chlen
JOIN grupa      ON grupa.N_grupa      = trenirovka.N_grupa
JOIN trenior    ON trenior.N_trenior  = grupa.N_trenior
WHERE UPPER(trenior.Ime_trenior) LIKE UPPER('%Петър Попов%')
ORDER BY chlen.Ime_chlen ASC;




--PRISASTVIE NA TRENIROVKI
SELECT DISTINCT
  trenirovka.datata,
  trenirovka.chas,
  trenirovka.N_grupa,
  chlen.N_chlen,
  chlen.Ime_chlen
FROM trenirovka
JOIN chlen ON chlen.N_chlen = trenirovka.N_chlen
WHERE trenirovka.datata = DATE '2020-12-08'  
ORDER BY trenirovka.chas, trenirovka.N_grupa, chlen.N_chlen, chlen.ime_chlen;


--ZAPISANI CHLENOVE PO SPORT I GRUPA
SELECT DISTINCT
  sport.Ime_sport,
  grupa.N_grupa,
  COUNT(DISTINCT zapisani_abonamenti.N_chlen) AS broi_chlenove
FROM zapisani_abonamenti
JOIN grupa ON grupa.N_grupa = zapisani_abonamenti.N_grupa
JOIN sport ON sport.N_sport = grupa.N_sport
GROUP BY sport.Ime_sport, grupa.N_grupa
ORDER BY sport.Ime_sport, grupa.N_grupa;



--CHLENOVE, POSESHTAVASHTI POVECHE OT EDNA GRUPA
SELECT
  chlen.N_chlen,
  chlen.Ime_chlen,
  COUNT(DISTINCT zapisani_abonamenti.N_grupa) AS broi_grupi
FROM chlen
JOIN zapisani_abonamenti
  ON zapisani_abonamenti.N_chlen = chlen.N_chlen
GROUP BY chlen.N_chlen, chlen.Ime_chlen
HAVING COUNT(DISTINCT zapisani_abonamenti.N_grupa) > 1
ORDER BY chlen.N_chlen;


--PRIHOD ZA DADEN PERIOD
SELECT
  SUM(abonament.Cena_lv) AS prihodi_lv
FROM zapisani_abonamenti
JOIN abonament ON abonament.N_abonament = zapisani_abonamenti.N_abonament
WHERE zapisani_abonamenti.Data_zapis
      BETWEEN DATE '2020-12-01' AND DATE '2020-12-31';
      
      
      
--TRENIORI I BROQ GRUPI, KOITO VODQT
SELECT
  trenior.N_trenior,
  trenior.Ime_trenior,
  COUNT(*) AS broi_grupi
FROM trenior
JOIN grupa ON grupa.N_trenior = trenior.N_trenior
GROUP BY trenior.N_trenior, trenior.Ime_trenior
ORDER BY broi_grupi DESC, trenior.Ime_trenior;




-- КУРСОРИ

SET SERVEROUTPUT ON;

CREATE OR REPLACE PROCEDURE proc_chlen_po_sport(p_sport_name IN VARCHAR2) AS
BEGIN
  FOR r IN (
    SELECT DISTINCT chlen.N_chlen, chlen.Ime_chlen
    FROM chlen
    JOIN trenirovka ON trenirovka.N_chlen = chlen.N_chlen
    JOIN grupa      ON grupa.N_grupa      = trenirovka.N_grupa
    JOIN sport      ON sport.N_sport      = grupa.N_sport
    WHERE UPPER(sport.Ime_sport) LIKE '%' || UPPER(p_sport_name) || '%'
    ORDER BY chlen.N_chlen
  ) LOOP
    DBMS_OUTPUT.PUT_LINE('Член №' || r.N_chlen || ' - ' || r.Ime_chlen);
  END LOOP;
END;
/


BEGIN
  proc_chlen_po_sport('&sport');
END;
/
















