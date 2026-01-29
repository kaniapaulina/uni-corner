# Zadanie 1
plik <- read.csv("data_kids.csv") # Wczytanie danych z pliku
girls <- plik[plik$gender == "K", ]
boys <- plik[plik$gender == "M", ]

t.test(girls$age, boys$age)
# Porównanie średniego wieku dziewcząt i chłopców za pomocą testu t-Studenta dla dwóch prób.

# --------------------------------

# Zadanie 2
mean(plik$pullup)
# Obliczenie średniej arytmetycznej liczby podciągnięć (pullup) dla wszystkich dzieci w pliku.

# --------------------------------

# Zadanie 3
# H0: mu = 20
# H1: mu < 20 (mniej niż 20)
test3 <- t.test(plik$run, mu = 20, alternative = "less")
test3$p.value
# Wykonanie jednostronnego testu t-Studenta, aby sprawdzić, czy średni czas biegu jest istotnie mniejszy niż 20.

# --------------------------------

# Zadanie 4
test4 <- t.test(girls$jumps, boys$jumps, conf.level = 0.90)
sz <- test4$conf.int[2] - test4$conf.int[1]
sz
# Wyznaczenie 90-procentowego przedziału ufności dla różnicy średnich w liczbie skoków między płciami i obliczenie jego szerokości.

# --------------------------------

# Zadanie 5
test5 <- var.test(girls$jumps, boys$jumps)
test5$statistic
# Test F (test wariancji) sprawdzający, czy zróżnicowanie liczby skoków u dziewcząt i chłopców jest takie samo.

# --------------------------------

# Zadanie 6
mob_50 <- sum(plik$mobility > 15)
games_50 <- sum(plik$games > 15)

test6 <- prop.test(c(mob_50, games_50), c(nrow(plik), nrow(plik)))
test6$statistic
# Porównanie dwóch proporcji: sprawdzamy, czy odsetek dzieci z mobilnością > 15 różni się od odsetka dzieci z wynikiem w grach > 15.

# --------------------------------

# Zadanie 7
test7 <- t.test(plik$games, conf.level = 0.95)
test7$conf.int
# Wyznaczenie 95-procentowego przedziału ufności dla średniej liczby gier dla całej badanej grupy.

# --------------------------------

# Zadanie 8
age_11 <- plik[plik$age == 11, ]
age_8 <- plik[plik$age == 8, ]
mean(age_11$games)
mean(age_8$games)
t.test(age_11$games, age_8$games, alternative = "greater")
# Porównanie średniej liczby gier u 11-latków i 8-latków (test jednostronny sprawdzający, czy starsze dzieci mają więcej gier).

# --------------------------------

# Zadanie 9
q1 <- quantile(plik$run, 0.25)
q4 <- quantile(plik$run, 0.75)

fastest <- plik[plik$run <= q1, ]
slowest <- plik[plik$run >= q4, ]

test9 <- t.test(fastest$pullup, slowest$pullup, alternative = "greater")
test9$p.value
# Wyodrębnienie 25% najszybszych i 25% najwolniejszych biegaczy, a następnie sprawdzenie, czy najszybsi robią średnio więcej podciągnięć.

# --------------------------------

# Zadanie 10
t.test(plik$pullup, mu = 3, alternative = "less")
# Test t-Studenta dla jednej próby sprawdzający, czy średnia liczba podciągnięć w całej grupie jest mniejsza niż 3.

# --------------------------------

# Zadanie 11
table(plik$gender)
test11 <- prop.test(table(plik$gender), p = 0.5)
test11$p.value
# Test proporcji sprawdzający, czy rozkład płci w pliku jest równomierny (czy chłopców i dziewcząt jest po tyle samo, czyli po 50%).