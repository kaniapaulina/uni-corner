# 📚 Notatki — Bazy Danych SQL (AGH)

> Kompletne notatki z laboratoriów 8.1–8.5 oraz 9, oparte na materiałach wykładowych i rozwiązanych zadaniach.

---

## Spis treści

1. [Lab 8.1 — Selekcja, projekcja, funkcje wierszowe](#lab-81--selekcja-projekcja-funkcje-wierszowe)
2. [Lab 8.2 — Operacje teoriomnogościowe](#lab-82--operacje-teoriomnogościowe)
3. [Lab 8.3 — Połączenia (JOIN)](#lab-83--połączenia-join)
4. [Lab 8.4 — Funkcje agregujące i grupowanie](#lab-84--funkcje-agregujące-i-grupowanie)
5. [Lab 8.5 — Podzapytania](#lab-85--podzapytania)
6. [Lab 9 — DDL: CREATE, INSERT, UPDATE, DELETE, DROP](#lab-9--ddl-create-insert-update-delete-drop)
7. [Ściągawka — najważniejsze funkcje](#ściągawka--najważniejsze-funkcje)

---

## Lab 8.1 — Selekcja, projekcja, funkcje wierszowe

### Podstawowa struktura zapytania SELECT

```sql
SELECT kolumna1, kolumna2, ...   -- co wyświetlamy (projekcja)
FROM tabela                       -- skąd bierzemy dane
WHERE warunek                     -- filtrowanie wierszy (selekcja)
ORDER BY kolumna ASC|DESC;        -- sortowanie
```

---

### Zad. 1 — Filtrowanie wierszy (WHERE + AND)

**Polecenie:** Wyświetlić wszystkich pracowników z Londynu zatrudnionych na stanowisku przedstawiciela handlowego.

```sql
SELECT *
FROM Employees
WHERE City = 'London'
  AND Title = 'Sales Representative';
```

> `AND` — oba warunki muszą być spełnione jednocześnie.

---

### Zad. 2 — Operator IN i sortowanie

**Polecenie:** Wyświetlić wszystkich klientów z USA, Francji, Kanady i Włoch, posortowanych rosnąco według kraju i nazwy.

```sql
SELECT *
FROM Customers
WHERE Country IN ('USA', 'France', 'Canada', 'Italy')
ORDER BY Country ASC, ContactName ASC;
```

> `IN (...)` — skrót dla wielu warunków `OR`. Zamiast `Country = 'USA' OR Country = 'France' OR ...` można użyć `IN`.

---

### Zad. 3 — NULL i IS NOT NULL

**Polecenie:** Wyświetlić klientów, którzy mają faks.

```sql
SELECT *
FROM Customers
WHERE Fax IS NOT NULL;
```

> ⚠️ Nigdy nie używamy `= NULL` ani `!= NULL`. Zawsze `IS NULL` lub `IS NOT NULL`.

---

### Zad. 4 — Funkcja LEN() / LENGTH()

**Polecenie:** Wyświetlić dostawców, których nazwa jest dłuższa niż 10 znaków.

```sql
-- MS SQL Server:
SELECT *
FROM Suppliers
WHERE LEN(CompanyName) > 10;

-- MySQL:
SELECT *
FROM Dostawcy
WHERE LENGTH(NazwaFirmy) > 10;
```

---

### Zad. 5 — Funkcja YEAR()

**Polecenie:** Wyświetlić pracowników urodzonych po 1960 roku.

```sql
SELECT *
FROM Employees
WHERE YEAR(BirthDate) > 1960;
```

> `YEAR(data)` — zwraca rok z daty. Analogicznie: `MONTH()`, `DAY()`.

---

### Zad. 6 — Staż pracy z DATEDIFF()

**Polecenie:** Wyświetlić pracowników i ich staż pracy w latach.

```sql
SELECT LastName, FirstName,
       DATEDIFF(year, HireDate, GETDATE()) AS Staz
FROM Employees;
```

> `DATEDIFF(jednostka, data_od, data_do)` — oblicza różnicę między datami.  
> `GETDATE()` — zwraca aktualną datę i czas (MS SQL Server).  
> Jednostki: `year`, `month`, `day`, `hour`, `minute`.

---

### Zad. 7 — Dzień tygodnia urodzenia

**Polecenie:** Znaleźć pracowników urodzonych w niedzielę (imię i nazwisko w jednej kolumnie).

```sql
-- MS SQL Server (DATENAME):
SELECT FirstName + ' ' + LastName AS [Urodzeni w niedziele]
FROM Employees
WHERE DATENAME(weekday, BirthDate) = 'Sunday';

-- MS SQL Server (DATEPART) — numery dni zależą od ustawień serwera:
SELECT CONCAT(LastName, ' ', FirstName) AS [Urodzeni w niedziele]
FROM Employees
WHERE DATEPART(dw, BirthDate) = 1;  -- 1=niedziela (domyślnie w US)
```

> `DATENAME(weekday, data)` — zwraca nazwę dnia tygodnia jako tekst (bezpieczniejsze).  
> `DATEPART(dw, data)` — zwraca numer dnia (zależy od ustawień serwera `SET DATEFIRST`).  
> `CONCAT(a, b, c)` — łączy ciągi tekstowe.

---

### Zad. 8 — Wiek pracowników

**Polecenie:** Znaleźć pracowników mających mniej niż 60 lat.

```sql
SELECT *
FROM Employees
WHERE DATEDIFF(year, BirthDate, GETDATE()) < 60;
```

---

### Zad. 9 — Operator LIKE z wildcardami

**Polecenie:** Znaleźć klientów, którzy w nazwie mają słowo „Store".

```sql
SELECT *
FROM Customers
WHERE CompanyName LIKE '%Store%';
```

| Wildcard | Znaczenie |
|----------|-----------|
| `%`      | dowolny ciąg znaków (0 lub więcej) |
| `_`      | dokładnie jeden dowolny znak |
| `[A-F]`  | jeden znak z zakresu A–F |
| `[^A-F]` | jeden znak spoza zakresu A–F |

---

### Zad. 10 — LIKE z zakresem znaków

**Polecenie:** Znaleźć klientów, których nazwa zaczyna się na A, B, C, D, E lub F.

```sql
SELECT *
FROM Customers
WHERE CompanyName LIKE '[A-F]%';
```

---

### Zad. 11 — BETWEEN i UPPER()

**Polecenie:** Produkty w cenie 20–40, nazwy dużymi literami.

```sql
SELECT UPPER(ProductName) AS ProductName,
       UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 20 AND 40;
```

> `BETWEEN 20 AND 40` — zakres domknięty (wartości 20 i 40 włącznie).  
> `UPPER(tekst)` — zamienia na wielkie litery. Analogicznie: `LOWER()`.

---

### Zad. 12 — Konkatenacja i UNION

**Polecenie:** Zwroty grzecznościowe: Ms. N. Davolio, Sales Representative.

```sql
SELECT 'Ms. ' + LEFT(FirstName, 1) + '. ' + LastName + ', ' + Title AS ZwrotGrzecznosciowy
FROM Employees
WHERE TitleOfCourtesy IN ('Ms.', 'Mrs.')

UNION

SELECT 'Mr. ' + LEFT(FirstName, 1) + '. ' + LastName + ', ' + Title AS ZwrotGrzecznosciowy
FROM Employees
WHERE TitleOfCourtesy = 'Mr.';
```

> `LEFT(tekst, n)` — zwraca `n` pierwszych znaków.  
> `+` (MS SQL) lub `CONCAT()` — łączenie napisów.  
> `UNION` — łączy wyniki dwóch zapytań, usuwając duplikaty.

---

### Zad. 13 — Adresy e-mail

**Polecenie:** Zbudować adresy e-mail: `n.davolio@zarz.agh.edu.pl`.

```sql
SELECT LOWER(LEFT(FirstName, 1) + '.' + LastName + '@zarz.agh.edu.pl') AS Email
FROM Employees;
```

---

## Lab 8.2 — Operacje teoriomnogościowe

### Operatory zbiorowe

| Operator | Opis |
|----------|------|
| `UNION` | suma zbiorów — łączy wyniki, usuwa duplikaty |
| `UNION ALL` | suma zbiorów — łączy wyniki, zachowuje duplikaty |
| `INTERSECT` | iloczyn zbiorów — wiersze wspólne dla obu zapytań |
| `EXCEPT` (`MINUS` w Oracle) | różnica zbiorów — wiersze z pierwszego, których nie ma w drugim |

> ⚠️ Obie selekcje muszą mieć taką samą liczbę kolumn i zgodne typy danych.

---

### Zad. 1 — UNION

**Polecenie:** Wypisać miasta i państwa klientów i pracowników.

```sql
SELECT City, Country FROM Customers
UNION
SELECT City, Country FROM Employees;
```

---

### Zad. 2 — Różnica zbiorów (NOT IN / EXCEPT)

**Polecenie:** Państwa z klientami, ale bez pracowników.

```sql
-- Wariant z podzapytaniem (NOT IN):
SELECT DISTINCT Country
FROM Customers
WHERE Country NOT IN (SELECT Country FROM Employees);

-- Wariant z EXCEPT:
SELECT DISTINCT Country FROM Customers
EXCEPT
SELECT DISTINCT Country FROM Employees;
```

---

### Zad. 3 — INTERSECT

**Polecenie:** Miasta, w których są zarówno klienci, jak i pracownicy.

```sql
SELECT DISTINCT City FROM Customers
INTERSECT
SELECT DISTINCT City FROM Employees;
```

---

### Zad. 4 — Iloczyn kartezjański (CROSS JOIN)

**Polecenie:** Wszystkie kombinacje nazw produktów i kategorii.

```sql
-- Stara składnia:
SELECT p.ProductName, c.CategoryName
FROM Products p, Categories c;

-- Jawna składnia:
SELECT p.ProductName, c.CategoryName
FROM Products p
CROSS JOIN Categories c;
```

> Iloczyn kartezjański zwraca **każdą kombinację** wierszy z obu tabel. Jeśli tabela A ma 77 wierszy, a B ma 8, wynik ma 77 × 8 = 616 wierszy.

---

### Zad. 5 — Filtrowanie iloczynu kartezjańskiego

**Polecenie:** Produkty z ich kategoriami — przez iloczyn kartezjański z WHERE.

```sql
SELECT p.ProductName, c.CategoryName
FROM Products p, Categories c
WHERE p.CategoryID = c.CategoryID;
```

> Jest to funkcjonalny odpowiednik `INNER JOIN`, ale starsza i mniej czytelna forma.

---

## Lab 8.3 — Połączenia (JOIN)

### Rodzaje złączeń

```
Tabela A    Tabela B
   ●───────────●    INNER JOIN  — tylko pasujące wiersze
   ●───────────○    LEFT JOIN   — wszystkie z A + pasujące z B (NULL gdzie brak)
   ○───────────●    RIGHT JOIN  — wszystkie z B + pasujące z A (NULL gdzie brak)
   ●───────────●
   ○           ○    FULL JOIN   — wszystkie wiersze z obu tabel
```

---

### Zad. 1 — INNER JOIN (podstawowe złączenie)

**Polecenie:** Produkty z nazwami kategorii.

```sql
SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;
```

> `ON` określa warunek łączenia (po jakich kluczach łączymy tabele).  
> Aliasy (`p`, `c`) skracają pisanie.

---

### Zad. 2 — JOIN z filtrowaniem

**Polecenie:** Brazylscy dostawcy i ich produkty.

```sql
SELECT s.CompanyName, p.ProductName
FROM Suppliers s
INNER JOIN Products p ON s.SupplierID = p.SupplierID
WHERE s.Country = 'Brazil';
```

---

### Zad. 3 — Wielokrotny JOIN

**Polecenie:** Dostawcy z USA, ich produkty z kategorii Beverages.

```sql
SELECT s.CompanyName, p.ProductName, c.CategoryName
FROM Suppliers s
INNER JOIN Products p   ON s.SupplierID = p.SupplierID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE s.Country = 'USA'
  AND c.CategoryName = 'Beverages';
```

> Można łączyć dowolną liczbę tabel kolejnymi klauzulami `JOIN`.

---

### Zad. 4 — JOIN z sortowaniem

**Polecenie:** Zamówienia z nazwami klientów, posortowane według nazwy klienta.

```sql
SELECT o.OrderID, o.OrderDate, c.CompanyName
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
ORDER BY c.CompanyName;
```

---

### Zad. 5 — JOIN z filtrem na złączonej tabeli

**Polecenie:** Zamówienia przez Speedy Express.

```sql
SELECT o.OrderID, o.ShippedDate
FROM Orders o
INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
WHERE s.CompanyName = 'Speedy Express';
```

---

### Zad. 6 — Self JOIN (złączenie tabeli ze sobą)

**Polecenie:** Każdy pracownik i jego przełożony.

```sql
SELECT
    p1.FirstName + ' ' + p1.LastName AS Pracownik,
    p2.FirstName + ' ' + p2.LastName AS Przelozony
FROM Employees p1
LEFT JOIN Employees p2 ON p1.ReportsTo = p2.EmployeeID;
```

> **Self JOIN** — ta sama tabela jest używana dwukrotnie z różnymi aliasami (`p1`, `p2`).  
> `LEFT JOIN` — dzięki temu prezes (który nie ma przełożonego, `ReportsTo = NULL`) też pojawi się w wynikach (z `NULL` w kolumnie Przelozony).

---

### Zad. 7 — Spóźnione zamówienia

**Polecenie:** Zamówienia zrealizowane po wymaganym terminie, z liczbą dni opóźnienia.

```sql
SELECT
    o.OrderID,
    c.CompanyName,
    o.RequiredDate,
    o.ShippedDate,
    DATEDIFF(day, o.RequiredDate, o.ShippedDate) AS DniOpoznienia
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE o.ShippedDate > o.RequiredDate
ORDER BY DniOpoznienia DESC;
```

---

### Zad. 8 — Porównanie JOIN vs. iloczyn kartezjański (EXCEPT)

**Polecenie:** Sprawdzić czy wyniki zapytań z `JOIN` i z `WHERE` są identyczne.

```sql
SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID

EXCEPT

SELECT p.ProductName, c.CategoryName
FROM Products p, Categories c
WHERE p.CategoryID = c.CategoryID;
```

> Jeśli wynik `EXCEPT` jest pusty, oba zapytania zwracają identyczne dane (co potwierdzają w tym przypadku).

---

## Lab 8.4 — Funkcje agregujące i grupowanie

### Funkcje agregujące

| Funkcja | Opis |
|---------|------|
| `COUNT(*)` | liczba wierszy |
| `COUNT(kolumna)` | liczba wartości nie-NULL |
| `SUM(kolumna)` | suma |
| `AVG(kolumna)` | średnia arytmetyczna |
| `MAX(kolumna)` | wartość maksymalna |
| `MIN(kolumna)` | wartość minimalna |

### Struktura zapytania z grupowaniem

```sql
SELECT   kolumna_grupująca, FUNKCJA_AGR(kolumna)
FROM     tabela
WHERE    filtr_wierszy_przed_grupowaniem
GROUP BY kolumna_grupująca
HAVING   filtr_po_grupowaniu
ORDER BY ...;
```

> ⚠️ **Kolejność klauzul jest obowiązkowa:** SELECT → FROM → WHERE → GROUP BY → HAVING → ORDER BY.

---

### Zad. 1 — Statystyki cen

**Polecenie:** Maksymalna, minimalna i średnia cena produktów.

```sql
SELECT
    MAX(UnitPrice) AS [Cena maksymalna],
    MIN(UnitPrice) AS [Cena minimalna],
    AVG(UnitPrice) AS Srednia
FROM Products;
```

---

### Zad. 2 — GROUP BY

**Polecenie:** Liczba produktów w poszczególnych kategoriach.

```sql
SELECT
    CategoryID,
    COUNT(*) AS [Liczba produktow]
FROM Products
GROUP BY CategoryID;
```

> Każda kolumna w `SELECT` (poza funkcjami agregującymi) **musi** wystąpić w `GROUP BY`.

---

### Zad. 3 — SUM z GROUP BY

**Polecenie:** Całkowita liczba zamówionych jednostek dla każdego produktu.

```sql
SELECT
    ProductID,
    SUM(Quantity) AS [Calkowita liczba zamowien]
FROM [Order Details]
GROUP BY ProductID;
```

> Tabele z spacjami w nazwie ujmujemy w nawiasy kwadratowe: `[Order Details]`.

---

### Zad. 4 — Wartość zamówień

**Polecenie:** Całkowita wartość zamówień dla każdego produktu.

```sql
SELECT
    ProductID,
    SUM(Quantity * UnitPrice) AS [Calkowita wartosc zamowien]
FROM [Order Details]
GROUP BY ProductID;
```

---

### Zad. 5 — HAVING (filtrowanie po agregacji)

**Polecenie:** Produkty zamawiane łącznie w ilości powyżej 1000, posortowane rosnąco.

```sql
SELECT
    ProductID,
    SUM(Quantity)              AS [Calkowita liczba zamowien],
    SUM(Quantity * UnitPrice)  AS [Calkowita wartosc zamowien]
FROM [Order Details]
GROUP BY ProductID
HAVING SUM(Quantity) > 1000
ORDER BY SUM(Quantity) ASC;
```

> **HAVING vs WHERE:**
> - `WHERE` — filtruje **wiersze przed** grupowaniem
> - `HAVING` — filtruje **grupy po** grupowaniu (może używać funkcji agregujących)

---

### Zad. 6 — GROUP BY z JOIN

**Polecenie:** Liczba produktów w kategoriach — z nazwami kategorii.

```sql
SELECT
    c.CategoryName,
    COUNT(*) AS [Liczba produktow]
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName;
```

---

### Zad. 7 — HAVING z COUNT

**Polecenie:** Dostawcy z co najmniej 3 produktami.

```sql
SELECT
    SupplierID,
    COUNT(*) AS [Liczba produktow]
FROM Products
GROUP BY SupplierID
HAVING COUNT(*) >= 3;
```

---

### Zad. 8 — WHERE + JOIN + GROUP BY

**Polecenie:** Liczba produktów od dostawców z USA.

```sql
SELECT
    s.CompanyName,
    COUNT(*) AS [Liczba produktow]
FROM Products p
INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE s.Country = 'USA'
GROUP BY s.CompanyName;
```

---

### Zad. 9 — WHERE + GROUP BY + HAVING razem

**Polecenie:** Dostawcy z USA z co najmniej 2 produktami.

```sql
SELECT
    s.CompanyName,
    COUNT(*) AS [Liczba produktow]
FROM Products p
INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE s.Country = 'USA'
GROUP BY s.CompanyName
HAVING COUNT(*) >= 2;
```

---

## Lab 8.5 — Podzapytania

Podzapytanie (subquery) to zapytanie `SELECT` zagnieżdżone wewnątrz innego zapytania. Może być:
- **skalarne** — zwraca jedną wartość (używane z `=`, `<`, `>` itp.)
- **wierszowe** — zwraca jeden wiersz (używane z `IN`, `ANY`, `ALL`)
- **tabelaryczne** — zwraca tabelę (używane w `FROM` lub `EXISTS`)
- **skorelowane** — odwołuje się do kolumn zapytania zewnętrznego

---

### Zad. 1 — Podzapytanie skalarne z MAX

**Polecenie:** Najdroższy produkt (nazwa i cena).

```sql
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice = (SELECT MAX(UnitPrice) FROM Products);
```

> Podzapytanie `(SELECT MAX(...) FROM ...)` zwraca jedną wartość — możemy ją porównać przez `=`.

---

### Zad. 2 — Porównanie ze średnią

**Polecenie:** Produkty tańsze od średniej ceny.

```sql
SELECT ProductName
FROM Products
WHERE UnitPrice < (SELECT AVG(UnitPrice) FROM Products);
```

---

### Zad. 3 — Podzapytanie skorelowane

**Polecenie:** Produkty tańsze od średniej w swojej kategorii.

```sql
SELECT p.ProductName, p.UnitPrice, p.CategoryID
FROM Products p
WHERE p.UnitPrice < (
    SELECT AVG(UnitPrice)
    FROM Products
    WHERE CategoryID = p.CategoryID   -- ← odwołanie do zewnętrznego zapytania
);
```

> **Podzapytanie skorelowane** — wykonywane raz dla każdego wiersza zewnętrznego zapytania. `p.CategoryID` pochodzi z zewnątrz.

---

### Zad. 4 — Podzapytanie w SELECT

**Polecenie:** Produkty z ich ceną i globalną średnią ceną obok siebie.

```sql
SELECT
    ProductName,
    UnitPrice,
    (SELECT AVG(UnitPrice) FROM Products) AS [Srednia cena]
FROM Products;
```

> Podzapytanie w klauzuli `SELECT` musi zwracać dokładnie **jedną wartość** (skalar).

---

### Zad. 5 — Podzapytanie w SELECT ze stałym filtrem

**Polecenie:** Produkty z kategorii 1 ze średnią ceną tej kategorii.

```sql
SELECT
    ProductName,
    UnitPrice,
    (SELECT AVG(UnitPrice) FROM Products WHERE CategoryID = 1) AS [Srednia kat. 1]
FROM Products
WHERE CategoryID = 1;
```

---

### Zad. 6 — Operator ALL

**Polecenie:** Produkty droższe od **wszystkich** produktów z kategorii 2.

```sql
SELECT ProductName
FROM Products
WHERE UnitPrice > ALL (
    SELECT UnitPrice
    FROM Products
    WHERE CategoryID = 2
);
```

> `> ALL(podzapytanie)` — wartość musi być większa od **każdej** wartości z podzapytania (czyli większa od maksimum).  
> Analogicznie: `> ANY(...)` — większa od **co najmniej jednej** wartości (czyli większa od minimum).

---

### Zad. 7 — TOP z ORDER BY (zamiast podzapytania)

**Polecenie:** Produkt z największą jednorazowo zamówioną ilością.

```sql
SELECT TOP 1
    p.ProductName,
    od.Quantity
FROM [Order Details] od
INNER JOIN Products p ON od.ProductID = p.ProductID
ORDER BY od.Quantity DESC;
```

> `TOP n` — zwraca pierwsze `n` wierszy po sortowaniu.

---

## Lab 9 — DDL: CREATE, INSERT, UPDATE, DELETE, DROP

DDL (Data Definition Language) — język do tworzenia i modyfikowania struktury bazy danych.

---

### CREATE TABLE — tworzenie tabeli

#### Składnia

```sql
CREATE TABLE nazwa_tabeli
(
    nazwa_kolumny  TYP_DANYCH  [NULL | NOT NULL]
                               [IDENTITY]
                               [DEFAULT wartosc]
                               [CONSTRAINT nazwa PRIMARY KEY | UNIQUE | CHECK(...) | REFERENCES ...],
    ...,
    [CONSTRAINT nazwa PRIMARY KEY (kolumna1, kolumna2, ...)],
    [CONSTRAINT nazwa FOREIGN KEY (kolumna) REFERENCES inna_tabela(kolumna)]
);
```

#### Typy danych (MS SQL Server)

| Kategoria | Typy |
|-----------|------|
| Całkowite | `BIGINT`, `INT`, `SMALLINT`, `TINYINT`, `BIT` |
| Zmiennoprzecinkowe | `DECIMAL(p,s)`, `NUMERIC`, `FLOAT`, `REAL` |
| Pieniężne | `MONEY`, `SMALLMONEY` |
| Tekstowe (ASCII) | `CHAR(n)`, `VARCHAR(n)`, `TEXT` |
| Tekstowe (Unicode) | `NCHAR(n)`, `NVARCHAR(n)`, `NTEXT` |
| Data i czas | `DATETIME`, `SMALLDATETIME` |
| Binarne | `BINARY`, `VARBINARY`, `IMAGE` |

#### Ograniczenia integralnościowe

| Ograniczenie | Opis |
|-------------|------|
| `NULL` / `NOT NULL` | czy dozwolone są wartości puste |
| `DEFAULT wartość` | wartość domyślna, gdy nie podano |
| `IDENTITY` | auto-inkrementacja (tylko jedna kolumna w tabeli) |
| `PRIMARY KEY` | klucz główny — unikalny, nie-NULL |
| `UNIQUE` | unikalny (ale może być NULL) |
| `FOREIGN KEY ... REFERENCES` | klucz obcy — wartości muszą istnieć w innej tabeli |
| `CHECK (warunek)` | zawężenie dziedziny do wartości spełniających warunek |

---

#### Przykład 9.1 — Tabela Kategorie

```sql
CREATE TABLE Kategorie
(
    id_kategorii  INT          NOT NULL  IDENTITY,
    nazwa_kat     NVARCHAR(50) NOT NULL  UNIQUE,
    PRIMARY KEY (id_kategorii)
);
```

- `IDENTITY` — id jest nadawane automatycznie (1, 2, 3, ...)
- `UNIQUE` — dwie kategorie nie mogą mieć tej samej nazwy
- `PRIMARY KEY` — zdefiniowany na poziomie relacji (możliwy też na poziomie kolumny)

---

#### Przykład 9.2 — Tabela Produkty (z kluczem obcym)

```sql
CREATE TABLE Produkty
(
    id_produktu  INT          NOT NULL  IDENTITY  PRIMARY KEY,
    nazwa_prod   NVARCHAR(30) NOT NULL,
    jedn_miary   CHAR(4)      NOT NULL,
    cena         DECIMAL(9,2) NOT NULL  DEFAULT 2500,
    id_kategorii INT          NOT NULL,
    CHECK (jedn_miary IN ('kg', 'szt.', 'm')),
    FOREIGN KEY (id_kategorii) REFERENCES Kategorie(id_kategorii)
);
```

- `PRIMARY KEY` zdefiniowany **na poziomie kolumny**
- `CHECK` — jednostka miary może być tylko `kg`, `szt.` lub `m`
- `FOREIGN KEY` — `id_kategorii` musi istnieć w tabeli `Kategorie`
- `DEFAULT 2500` — jeśli nie podamy ceny, zostanie wstawione 2500

---

#### Zadanie 9.1 — Własny schemat (Pracownicy i JednostkiOrganizacyjne)

```sql
CREATE TABLE JednostkiOrganizacyjne
(
    id_jednostki  INT          NOT NULL  IDENTITY,
    nazwa         NVARCHAR(50) NOT NULL  UNIQUE,
    miasto        NVARCHAR(50) NOT NULL  DEFAULT 'Kraków',
    PRIMARY KEY (id_jednostki)
);

CREATE TABLE Pracownicy
(
    id_pracownika  INT          NOT NULL  IDENTITY,
    imie           NVARCHAR(30) NOT NULL,
    nazwisko       NVARCHAR(50) NOT NULL,
    plec           CHAR(1)      NOT NULL,
    telefon        VARCHAR(15)  NULL,
    pensja         DECIMAL(9,2) NOT NULL  DEFAULT 4000,
    stanowisko     NVARCHAR(50) NOT NULL  DEFAULT 'Specjalista',
    id_szefa       INT          NULL,
    id_jednostki   INT          NOT NULL,
    PRIMARY KEY (id_pracownika),
    CHECK (plec IN ('K', 'M')),
    FOREIGN KEY (id_szefa)     REFERENCES Pracownicy(id_pracownika),
    FOREIGN KEY (id_jednostki) REFERENCES JednostkiOrganizacyjne(id_jednostki)
);
```

---

### INSERT — wstawianie wierszy

#### Składnia

```sql
-- Z listą kolumn (zalecane):
INSERT INTO nazwa_tabeli (kolumna1, kolumna2, ...)
VALUES (wartość1, wartość2, ...);

-- Bez listy kolumn (trzeba podać wszystkie wartości w kolejności):
INSERT INTO nazwa_tabeli
VALUES (wartość1, wartość2, ...);
```

#### Przykłady (Przykład 9.3)

```sql
-- Z listą kolumn — wstawiamy tylko wybraną kolumnę, reszta ma DEFAULT/IDENTITY:
INSERT INTO Kategorie (nazwa_kat)
VALUES (N'Komputery');

-- Bez listy kolumn (IDENTITY jest pomijane):
INSERT INTO Kategorie
VALUES ('Drukarki');

-- DEFAULT jako wartość (używa wartości domyślnej dla ceny = 2500):
INSERT INTO Produkty (nazwa_prod, jedn_miary, cena, id_kategorii)
VALUES (N'IBM', 'szt.', DEFAULT, 1);

-- Bez podawania ceny — zostanie wstawiona wartość domyślna:
INSERT INTO Produkty (nazwa_prod, jedn_miary, id_kategorii)
VALUES ('HP', 'szt.', 1);

-- Pełen wiersz bez listy kolumn:
INSERT INTO Produkty
VALUES ('Apple', 'szt.', 8900, 1);
```

> `N'tekst'` — przedrostek `N` oznacza tekst Unicode (NVARCHAR). Ważne dla polskich znaków.

---

#### Zadanie 9.2 — Dane do własnego schematu

```sql
-- Najpierw jednostki organizacyjne:
INSERT INTO JednostkiOrganizacyjne (nazwa, miasto)
VALUES ('Zarząd', 'Kraków'),
       ('IT', 'Kraków'),
       ('Marketing', 'Wrocław');

-- Pracownicy (najpierw prezes, bo inni odwołują się do niego):
INSERT INTO Pracownicy (imie, nazwisko, plec, telefon, pensja, stanowisko, id_szefa, id_jednostki)
VALUES ('Emil',    'Janas',     'M', '632112233', 25000, 'Prezes',    NULL, 1),
       ('Jan',     'Kowalski',  'M', '632112322', 15800, 'Kierownik', 1,    2),
       ('Jan',     'Nowak',     'M', NULL,         4000, 'Specjalista',2,   2),
       ('Kamil',   'Wieczorek', 'M', '632346733', 14200, 'Kierownik', 1,    3),
       ('Kinga',   'Ostrowska', 'K', '632565656',  4000, 'Asystent',  1,    1),
       ('Justyna', 'Oliwa',     'K', NULL,          DEFAULT, DEFAULT, 2,    2);
```

---

### UPDATE — aktualizacja danych

#### Składnia

```sql
UPDATE nazwa_tabeli
SET kolumna1 = nowa_wartość1,
    kolumna2 = nowa_wartość2
[WHERE warunek];
```

> ⚠️ Bez `WHERE` — aktualizowane są **wszystkie** wiersze!

#### Zadanie 9.4

```sql
-- 1. Podwyżka 10% dla asystentów:
UPDATE Pracownicy
SET pensja = pensja * 1.10
WHERE stanowisko = 'Asystent';

-- 2. Podwyżka o 500 dla podwładnych prezesa (id_szefa = id prezesa = 1):
UPDATE Pracownicy
SET pensja = pensja + 500
WHERE id_szefa = (SELECT id_pracownika FROM Pracownicy WHERE stanowisko = 'Prezes');

-- 3. Zmiana numeru telefonu Jan Kowalski:
UPDATE Pracownicy
SET telefon = '600111222'
WHERE imie = 'Jan' AND nazwisko = 'Kowalski';
```

---

### DELETE — usuwanie wierszy

#### Składnia

```sql
DELETE FROM nazwa_tabeli
[WHERE warunek];
```

> ⚠️ Bez `WHERE` — usuwane są **wszystkie** wiersze (tabela zostaje pusta, ale istnieje dalej)!

#### Zadanie 9.5

```sql
-- 1. Usunięcie specjalistów i asystentów:
DELETE FROM Pracownicy
WHERE stanowisko IN ('Specjalista', 'Asystent');

-- 2. Usunięcie wszystkich pracowników:
DELETE FROM Pracownicy;
```

> ⚠️ Przy usuwaniu z tabel powiązanych kluczami obcymi — najpierw usuwamy rekordy z tabel podrzędnych (lub ustawiamy odpowiednią akcję `ON DELETE`).

---

### DROP TABLE — usuwanie tabeli

#### Składnia

```sql
DROP TABLE nazwa_tabeli;
```

> ⚠️ Usuwa całą tabelę **wraz z danymi** — nieodwracalne!  
> Nie można usunąć tabeli, do której odwołuje się klucz obcy w innej tabeli. Najpierw usuń tabelę podrzędną.

#### Zadanie 9.6

```sql
-- Najpierw Pracownicy (bo mają FK do JednostkiOrganizacyjne):
DROP TABLE Pracownicy;
DROP TABLE JednostkiOrganizacyjne;
```

---

## Ściągawka — najważniejsze funkcje

### Funkcje tekstowe

| Funkcja | Opis | Przykład |
|---------|------|---------|
| `LEN(s)` | długość ciągu | `LEN('abc')` → 3 |
| `LEFT(s, n)` | n znaków od lewej | `LEFT('Nowak', 1)` → `N` |
| `RIGHT(s, n)` | n znaków od prawej | `RIGHT('Nowak', 2)` → `ak` |
| `UPPER(s)` | wielkie litery | `UPPER('abc')` → `ABC` |
| `LOWER(s)` | małe litery | `LOWER('ABC')` → `abc` |
| `CONCAT(a,b,c)` | łączenie ciągów | `CONCAT('A','B')` → `AB` |
| `SUBSTRING(s,start,len)` | wycinek ciągu | `SUBSTRING('Kowalski',1,2)` → `Ko` |

### Funkcje daty

| Funkcja | Opis | Przykład |
|---------|------|---------|
| `GETDATE()` | aktualna data i czas | — |
| `YEAR(d)` | rok z daty | `YEAR('1990-05-01')` → 1990 |
| `MONTH(d)` | miesiąc | `MONTH('1990-05-01')` → 5 |
| `DAY(d)` | dzień | `DAY('1990-05-01')` → 1 |
| `DATEDIFF(unit, d1, d2)` | różnica między datami | `DATEDIFF(year, HireDate, GETDATE())` |
| `DATENAME(part, d)` | nazwa części daty | `DATENAME(weekday, BirthDate)` → `Sunday` |
| `DATEPART(part, d)` | numer części daty | `DATEPART(dw, BirthDate)` → 1 |

### Operatory porównania i wzorce

| Operator | Opis |
|----------|------|
| `=`, `!=` lub `<>` | równy, różny |
| `<`, `>`, `<=`, `>=` | mniejszy, większy |
| `BETWEEN a AND b` | w zakresie (domknięty) |
| `IN (v1, v2, ...)` | należy do zbioru |
| `LIKE 'wzorzec'` | dopasowanie wzorca |
| `IS NULL` / `IS NOT NULL` | sprawdzenie NULL |
| `ALL` | porównanie ze wszystkimi wartościami |
| `ANY` / `SOME` | porównanie z co najmniej jedną wartością |

### Kolejność klauzul SELECT

```sql
SELECT   ...       -- 5. projekcja
FROM     ...       -- 1. źródło danych
JOIN     ...       -- 2. złączenia
WHERE    ...       -- 3. filtrowanie wierszy
GROUP BY ...       -- 4. grupowanie
HAVING   ...       -- 5. filtrowanie grup
ORDER BY ...;      -- 6. sortowanie
```

> Liczby oznaczają logiczną kolejność przetwarzania, nie pisania.

---

*Notatki opracowane na podstawie materiałów laboratoryjnych: Lab8_1, Lab8_2-3, Lab8_4-5, Lab9 (AGH, Zarządzanie)*
