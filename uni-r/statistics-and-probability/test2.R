# Zadanie 1
# Wykonaj 500 razy następującą symulację: losujesz 10 liczb naturalnych z przedziału 1 do 100, następnie 9 liczb spośród wylosowanych wcześniej dziesięciu, 8 spośród tych dziewięciu itd., aż do wylosowania jednej liczby. (Wykorzystaj losowanie BEZ zwracania, w którym prawdopodobieństwo dla każdej liczby jest równe). Zsumuj wszystkie liczby z tych dziesięciu losowań. Narysuj histogram empiryczny sum. Opisz rozkład, biorąc pod uwagę jego średnią, rozproszenie, asymetrię i kurtozę.
set.seed(1)
symulacje <- replicate(500, {
  liczby <- sample(1:100, 10, replace = FALSE)
  suma <- sum(liczby)
  for(i in 9:1) {
    liczby <- sample(liczby, i, replace = FALSE)
    suma <- suma + sum(liczby)
  }
  suma
})

hist(symulacje, breaks = 30, main = "Histogram sum", xlab = "Suma", ylab = "Częstość")
mean(symulacje)
sd(symulacje)
library(moments)
skewness(symulacje)
kurtosis(symulacje)

# -----------------------------------------------------------

# Zadanie 2
# Narysuj dystrybuantę rozkładu Poissona o odchyleniu standardowym równym 2.
set.seed(2)
x <- 0:15
dystrybuanta <- ppois(x, 4)
plot(x, dystrybuanta, type = "s", main = "Dystrybuanta Poissona (lambda=4)", lwd=2)

# ----------------------------------------------------------

# Zadanie 3
# W pewnej grze uczestnik siedem razy kręci kołem ruletki, podzielonej na cztery równe obszary o różnych kolorach (czerwony, zielony, niebieski i żółty). Które z tych zdań są prawdziwe?
# a. prawdopodobieństwo wylosowania czerwonego pola przynajmniej 3 razy jest większe niż 30%
# b. na 90% uczestnik przynajmniej raz wylosuje kolor żółty
# c. prawdopodobieństwo wylosowania cztery razy tego samego koloru jest mniejsze niż prawdopodobieństwo wylosowania przynajmniej jeden raz każdego koloru
# d. jeśli uczestnik wylosował kolor zielony za każdym razem, to na 99% ta ruletka jest źle wyważona/niesprawiedliwa
set.seed(3)
# a
(1 - pbinom(2, 7, 0.25)) > 0.30 
# b
(1 - dbinom(0, 7, 0.25)) >= 0.90
# c
p_4_same <- 4 * dbinom(4, 7, 0.25)
p_all_colors <- 8400 / 4^7 
p_4_same < p_all_colors
# d
dbinom(7, 7, 0.25) < 0.01

# --------------------------------------------------------

# Zadanie 4
# Załóżmy, że wśród graczy piłki nożnej, wzrost zawodników można przybliżyć rozkładem N(175, 8), a wśród graczy koszykówki N(190, 5). Gdybyśmy mieli zgadywać dyscyplinę na podstawie wzrostu, od jakich wartości powinniśmy zaliczać zawodnika do koszykarzy? (tzn. od jakiej wartości wzrostu prawdopodobieństwo należenia do koszykarzy jest wyższe, niż do piłkarzy). Znajdź tę wartość z dokładnością do 1 cm.
wzrost <- seq(170, 195, by = 0.01)
f_pilkarz <- dnorm(wzrost, 175, 8)
f_koszykarz <- dnorm(wzrost, 190, 5)
prog <- wzrost[which(f_koszykarz > f_pilkarz)[1]]
round(prog)

# --------------------------------------------------------

# Zadanie 5
# Dla ilu procent piłkarzy metoda z zadania 4 dałaby błędny wynik? [podaj w procentach, nie w ułamku, z zaokrągleniem do dwóch miejsc po przecinku. Np. 0,25 oznacza 0,25%, a nie 25%]
p_blad <- (1 - pnorm(183, 175, 8)) * 100
round(p_blad, 2)

# --------------------------------------------------------

# Zadanie 6
# Jaki jest minimalny wzrost, przy którym mamy $70\%$ szans, że trafiliśmy na koszykarza? [Podaj z dokładnością do centymetra]
wzrost_szerszy <- seq(160, 210, by = 0.1)
f_p <- dnorm(wzrost_szerszy, 175, 8)
f_k <- dnorm(wzrost_szerszy, 190, 5)
szansa_kosz <- f_k / (f_k + f_p)
wynik_6 <- wzrost_szerszy[which(szansa_kosz >= 0.70)[1]]
round(wynik_6)