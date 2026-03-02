# ======================================================
# Ekonometria
# Laboratoria 1 - 02.03.2026
# ======================================================

library(dplyr)

# ======================================================
# ===== Zadanie 1 =====
# ======================================================
# zależność wprost proporcjonalna

set.seed(111)
data <- data.frame(
  family_size = rpois(50, 3)
) %>% mutate(oranges = family_size+1)

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")
cor(data$family_size, data$oranges)

# ======================================================
# ===== Zadanie 2 =====
# ======================================================
# wprowadzam trochę losowości
# 0 - nie lubi pomarańczy z prawdopodobieństwem 30%
# 1 - chce 1 pomarańcze z prawdopodobieństwem 50%
# 2 - chce 2 pomarańcze z prawdopodobieństwem 20%

get_preference = function(family_size){
  sapply(family_size, function(x) {
    sum(sample(c(0, 1, 2), size = x, replace = T, prob = c(0.3, 0.5, 0.2)))
  }
  )
}

set.seed(123)
data <- data %>% mutate(oranges = get_preference(family_size+1))

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")

cor(data$family_size, data$oranges)

# y = a + bx + e
# Metoda najmniejszych kwadratow: (y - a - bx)^2 -> min
data$y_drop = data$family_size + 1
data$e = data$oranges - data$y_drop #błedy
sum(data$e^2)

# MNK
model <- lm(oranges ~ family_size, data)

plot(data$family_size, data$oranges)
abline(a=1, b=1, col="red")
abline(a=model$coefficients[1], b=model$coefficients[2], col="green")

sum(model$residuals^2)

summary(data)
summary(model)

# t = (m - m0)/S*sqrt(n) ~ tS(n-1) (rozkład t-Studenta, test istotności)
1.0823/0.3473 # Estimate/Error

# Współczynnik determinacji: R^2 (R-Squared) - uzasadnia jak model eee idk
# Test Łącznej istotności wszystkich zmiennych: F-Statistic

# ======================================================
# ===== Zadanie 3 =====
# ======================================================
# wyprzedaż:
# wersja I (liniowa): jeśli jest wyprzedaż, ludzie biorą jedną pomarańczę więcej
# wersja II: interakcyjna - więcej pomarańczy na każdego kupującego

set.seed(456)
data$sale = sample(c(0, 1), 50, replace = T, prob = c(0.7, 0.3))

data$oranges = get_preference(data$family_size+1) + data$sale

model <- lm(oranges ~ . -y_drop -e, data) # kropka to wszystkie zmienne minus tych których nie używamy
model <- lm(oranges ~ family_size+sale, data)
model <- lm(oranges ~ -1 +  family_size, data)

summary(model) #o jeden czlonek rodziny wiecej -> o .96 wieksze zakupy

# y = a + bx + cz + e
data$oranges = get_preference(data$family_size + 1)*( 1+ data$sale)

model <- lm(oranges ~ family_size*sale, data)
summary(model) #z kazda osoba wiecej w rodzinie mamy o 0.75 zakupow wiecej a gdy jest wyprzedaz to o 0.86

model <- lm(oranges ~ family_size+sale, data)
summary(model)

# wspołliniowość - gdy jedna zmienna jest kombinacją innej
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

# Zadanie do samodzielnej pracy
# symulacja 1000 razy
# losowanie zmiennej niepowiązanej z y
# estymacja modelu
# liczymy ile razy p-value tej zmiennej było mniejsze niż 5%

# !!! NIEUZYTECZNE ale fajna funkcja
overall_p <- function(my_model) {
  f <- summary(my_model)$fstatistic
  p <- pf(f[1],f[2],f[3],lower.tail=F)
  attributes(p) <- NULL
  return(p)
}

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

# ======================================================
# ===== Zadanie 5 =====
# ======================================================

# regresja pozorna (zalezne od trendow czasowych)

count <- 0
for(j in 1:1000) {
  x <- vector()
  y <- vector()
  
  x[1] = 1
  y[1] = 1
  
  for(i in 2:200) {
    x[i] = 0.9*x[i-1] + rnorm(1)
    y[i] = 0.9*y[i-1] + rnorm(1)
  }
  
  model <- lm(y ~ x)
  if(summary(model)$coefficients[2.4] < 0.05) count <- count + 1
}
count

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

