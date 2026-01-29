# Zadanie 1
# Uczestnik rzuca monetą, dopóki nie wyrzuci pięciu orzełków pod rząd, co oznacza wygraną.
# Skoro rzucamy DO SKUTKU, to prawdopodobieństwo wygranej zawsze wynosi 1 (czyli 100%).
p_wygrana_1 <- 1
print(p_wygrana_1)

# -------------------------------------------------

# Zadanie 2
# 4 kości (6-ścienne). Wynik = (A+B+C) - D. 
# Przegrana, jeśli wynik jest podzielny przez 4, ale pierwiastek sześcienny z wyniku NIE jest liczbą całkowitą
x <- expand.grid(A=1:6, B=1:6, C=1:6, D=1:6)
wynik <- x$A + x$B + x$C - x$D

czy_podzielny_4 <- (wynik %% 4 == 0)
czy_pierwiastek_int <- (wynik == 1 | wynik == 8 | wynik == 27 | wynik == 0 | wynik == -1)

przegrane_losy <- sum(czy_podzielny_4 & !czy_pierwiastek_int)
p_przegrana_2 <- (przegrane_losy / nrow(x)) * 100
round(p_przegrana_2, 2)

# -------------------------------------------------

# Zadanie 3
# Treść: Losowanie 11 liter bez zwracania. Wygrana = palindrom.
# Bez zwracania nie da się ułożyć palindromu z 11 różnych liter (musiałyby być pary) czyli Wynik to po prostu 0
p_wygrana_3 <- 0
print(p_wygrana_3)

# -------------------------------------------------

# Zadanie 4
# Losowanie 4 liter ze zwracaniem. Wygrana = palindrom.
p_wygrana_4 <- (26 * 26) / (26^4) * 100
round(p_wygrana_4, 2)

# -------------------------------------------------

# Zadanie 5
# 5 rzutów kością 20-ścienną. Wygrana, jeśli (D+E) > (A+B+C).
kostki <- expand.grid(A=1:20, B=1:20, C=1:20, D=1:20, E=1:20)
suma_abc <- kostki$A + kostki$B + kostki$C
suma_de <- kostki$D + kostki$E

wygrane_5 <- sum(suma_de > suma_abc)
p_wygrana_5 <- (wygrane_5 / nrow(kostki)) * 100
round(p_wygrana_5, 2)

# -------------------------------------------------

# Zadanie 6
# Wygrana 5%, Przegrana 83%, Dalej 12%. Prawdopodobieństwo całkowite wygranej.
p_wygrana_6 <- (0.05 / (0.05 + 0.83)) * 100
round(p_wygrana_6, 2)

# -------------------------------------------------

# Zadanie 7
# Rzucamy monetą 15 razy. Przegrywamy, jeśli w ciągu 15 rzutów 
set.seed(123)
n_prob <- 100000
wygrane_7 <- 0

for(i in 1:n_prob) {
  rzuty <- sample(c("O", "R"), 15, replace=TRUE)
  ciag <- paste(rzuty, collapse="")

  if(grepl("OOO", ciag) & grepl("RRR", ciag)) {
    wygrane_7 <- wygrane_7 + 1
  }
}

p_wygrana_7 <- (wygrane_7 / n_prob) * 100
p_wygrana_7