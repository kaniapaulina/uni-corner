# ======================================================
# Ekonometria
# Laboratoria 1 - 02.03.2026
# ======================================================

library(dplyr)

# ======================================================
# ===== Zadanie 1 =====
# ======================================================
# Zależność wprost proporcjonalna
# Budujemy model idealny - zależność jest sztywna, każda osoba w rodzinie zjada dokładnie jedną pomarańcze plus jedną zapasowa

set.seed(111)
data <- data.frame(
  family_size = rpois(50, 3)
) %>% mutate(oranges = family_size+1) # ilość pomarańcz = ilość osób w rodzinie + dzika pomarańcza

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")
cor(data$family_size, data$oranges)

# ======================================================
# ===== Zadanie 2 =====
# ======================================================
# wprowadzam trochę losowości - ludzie mają różne preference
# 0 - nie lubi pomarańczy z prawdopodobieństwem 30%
# 1 - chce 1 pomarańcze z prawdopodobieństwem 50%
# 2 - chce 2 pomarańcze z prawdopodobieństwem 20%

get_preference = function(family_size){
  sapply(family_size, function(x) {
    sum(sample(c(0, 1, 2), size = x, replace = T, prob = c(0.3, 0.5, 0.2)))
  })
}

set.seed(123)
data <- data %>% mutate(oranges = get_preference(family_size+1))

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")

cor(data$family_size, data$oranges)

# y = a + bx + e
# Metoda najmniejszych kwadratow: 
# (y - a - bx)^2 -> min

# teoretyczna prognoza: rodzina kupi tyle pomarańczy co członków + 1
data$y_drop = data$family_size + 1

# e - błedy, reszty (residuals), czyli tyle pomarańczy ile rodzina faktycznie zakupiłą
data$e = data$oranges - data$y_drop

# suma do kwadratu, by bledy przeciwnych znakow sie nie eliminowały 
sum(data$e^2)

# MNK - model w którym oranges zależą od family_size
model <- lm(oranges ~ family_size, data)

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")
abline(a=model$coefficients[1], b=model$coefficients[2], col="green")

sum(model$residuals^2)

summary(data)
summary(model)

# t = (m - m0)/S*sqrt(n) ~ tS(n-1) (rozkład t-Studenta, test istotności)
print(1.0823/0.3473) # Estimate/Std. Error
# Interpretacja: Jeśli wynik tego dzielenia (t-value) jest duży (zazwyczaj powyżej 2), to znaczy, że wpływ zmiennej jest "silniejszy" niż szum informacyjny. Oznacza to, że wielkość rodziny istotnie statystycznie wpływa na liczbę pomarańczy.

# Współczynnik determinacji: R^2 (R-Squared) - uzasadnia jaki procent zmienności Twojego y (pomarańczy) udało się wyjaśnić za pomocą x (wielkości rodziny).
# Im bliżej 1, tym model lepiej opisuje rzeczywistość

# Test Łącznej istotności wszystkich zmiennych: F-Statistic
# Interpretacja: Patrzysz na wartość p-value przy statystyce F. Jeśli jest mniejsza niż 0.05, to twój model ma sens i wnosi jakąś informację

# ======================================================
# ===== Zadanie 3 =====
# ======================================================
# wyprzedaż:
# wersja I (liniowa): jeśli jest wyprzedaż, ludzie biorą jedną pomarańczę więcej
# wersja II: interakcyjna - więcej pomarańczy na każdego kupującego

set.seed(456)
# na 70% nie ma wyprzedaży, na 30% jest 
data$sale = sample(c(0, 1), 50, replace = T, prob = c(0.7, 0.3))

# Wersja I: 
# Addytywna: wyprzedaż to stały bonus, każdy kupuje o jedną pomarańcze wiecej
data$oranges = get_preference(data$family_size+1) + data$sale

model <- lm(oranges ~ . -y_drop -e, data) # kropka to wszystkie zmienne minus tych których nie używamy
model <- lm(oranges ~ family_size+sale, data)
model <- lm(oranges ~ -1 +  family_size, data)

summary(model) #o jeden czlonek rodziny wiecej -> o .96 wieksze zakupy

# Wersja II
# Mnożnik: Im wieksza rodzina tym wieksza reakcja na wyprzedaz
# y = a + bx + cz + e
data$oranges = get_preference(data$family_size + 1)*( 1+ data$sale)

model <- lm(oranges ~ family_size*sale, data)
summary(model) 
#z kazda osoba wiecej w rodzinie mamy o 0.75 zakupow wiecej a gdy jest wyprzedaz to o 0.86
# Wspolczynnik interakcji jest dodatni, przy wyprzedazy duze rodziny kupują agresynwiej pomarancze

model <- lm(oranges ~ family_size+sale, data)
summary(model)

# Wspołliniowość (Collinearity) - gdy jedna zmienna jest kombinacją innej
data$z = 4 + 3*data$family_size
model <- lm(oranges ~ family_size + sale + z, data)
summary(model) # NA - pelna wspolliniowosc, nie da sie tego obliczyc

data$z = 4 + 3*data$family_size + rnorm(50, 0.5)
model <- lm(oranges ~ family_size + sale + z, data)
summary(model)

# ======================================================
# ===== Zadanie 4 =====
# ======================================================
set.seed(789)
#czy temperatura wplywa na to czy ludzie kupuja pomarancze

data$temp = rnorm(50, 15, 5)

model <- lm(oranges ~ family_size*sale + temp, data)
summary(model)$coefficients[3,4] #p-value

# SYMULACJA "Błędu I Rodzaju" - Zadanie do samodzielnej pracy tzw. eksperyment Monte Carlo
# Błąd I Rodzaju (False Positive): odrzucasz hipotezę zerową, mimo że jest ona prawdziwa. Innymi słowy: twierdzisz, że coś działa, podczas gdy to tylko zbieg okoliczności.
# P-hacking - Jeśli będziesz testował wystarczająco dużo zmiennych, to czysta matematyka gwarantuje, że w końcu któraś z nich "wyjdzie" jako istotna

# symulacja 1000 razy
# losowanie zmiennej niepowiązanej z y
# estymacja modelu
# liczymy ile razy p-value tej zmiennej było mniejsze niż 5%

count <- 0
for(i in 1:1000) {
  a <- sample(1:100, 50)
  model <- lm(oranges ~ family_size + a, data)
  # czy "a" jest istotne
  if(summary(model)$coefficients[3,4]<0.05) {
    count <- count + 1
  }
}
print(count)
#Skoro zmienna a jest losowa, to powinna być nieistotna.
# Jednak przy progu istotności 5% ($0.05$), statystycznie w 50 na 1000 przypadków (5%) p-value wyjdzie Ci mniejsze niż 0.05 czystym przypadkiem.
#Wniosek: Jeśli badacz testuje 20 bzdurnych zmiennych, jedna z nich prawdopodobnie "wyjdzie" jako istotna. To zjawisko nazywa się p-hackingiem.

# ======================================================
# ===== Zadanie 5 =====
# ======================================================

# Regresja pozorna (zalezne od trendow czasowych) - Spurious Regression
# Tworzysz dwie zmienne x i y, które nie mają ze sobą NIC wspólnego, ale obie mają tzw. trend (ich wartość w danym momencie zależy od wartości poprzedniej: 0.9*[i-1]).

count <- 0
for(j in 1:1000) {
  x <- vector()
  y <- vector()
  
  x[1] = 1
  y[1] = 1
  
  for(i in 2:200) {
    # AR(1) - Autoregresja rzedu 1
    x[i] = 0.9*x[i-1] + rnorm(1)
    y[i] = 0.9*y[i-1] + rnorm(1)
  }
  
  model <- lm(y ~ x)
  if(summary(model)$coefficients[2,4] < 0.05) count <- count + 1
}
count

#Wniosek: Korelacja nie oznacza przyczynowości. Dwie rzeczy mogą wydawać się powiązane tylko dlatego, że obie zmieniają się w czasie, Test t-Studenta w przypadku szeregów czasowych z trendem drastycznie zawodzi

# wykres
x <- vector()
y <- vector()

x[1] = 1
y[1] = 1

for(i in 2:200) {
  x[i] = 0.9*x[i-1] + rnorm(1)
  y[i] = 0.9*y[i-1] + rnorm(1)
}

plot(x, type="l")

