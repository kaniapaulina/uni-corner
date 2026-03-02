# ======================================================
# Ekonometria
# Laboratoria 2 - 02.03.2026
# ======================================================

# ======================================================
# ===== Zadanie 1 =====
# ======================================================
n_days <- 20

set.seed(111)
days <- data.frame(
  day_nr = 1:n_days,
  weekend = sample(c(0, 1), n_days, replace = T, prob = c(5, 2)/7), # czy dzień weekendowy?
  temp = rnorm(n_days, 25, 3), # temperatura
  wind = rlnorm(n_days, 1.5, 1) # prędkość wiatru
)

# deszcz: większe prawdopodobieństwo, gdy temperatura jest niższa
days$rain = sapply(days$temp, function(x) sample(c(0, 1), 1, prob = c(50+x, 50-x)/100)*rpois(1, 5))

set.seed(222)
n_shops = 20

shops = data.frame(
  shop = 1:n_shops,
  exp = rpois(n_shops, 5), # od ilu lat istnieje lodziarnia
  beach = rlnorm(n_shops, 2.5, 1.5)*10, # odległość od plaży
  flavors = rpois(n_shops, 3)+4, # liczba oferowanych smaków
  parking = sample(c(0, 1), n_shops, replace = T) # czy posiada parking
)

# lodziarnie przy plaży nie mają parkingów
shops$parking = ifelse(shops$beach < 200, 0, shops$parking)

shops$price = ifelse(shops$beach < 200, 7, 6) + sample(c(-1, 0, 1), n_shops, replace = T) # cena gałki lodów
shops$other = sapply(shops$beach, function(x) rlnorm(1, log(x/50), 0.5)*10) # odległość od innej lodziarni

data <- merge(days, shops, by = NULL)

# sprzedaż: zależna od temperatury, deszczu, odległości od plaży i konkurencji, ceny, weekendu, renomy i liczby smaków
data$sales <- 2000 + 10*data$temp - 40*data$rain - 0.1*data$beach + 0.05*data$other - 7*data$price +
  30*data$weekend + 5*data$temp*data$weekend +
  10*(data$exp-4)^2 + 5*(data$flavors-7)^2 + rnorm(400, 0, 50)

data <- data[,-c(1, 6)] # usuwam niepotrzebne zmienne

# ===== krok 1: przeglad danych
summary(data)
boxplot(data$wind)

# ===== krok 2: przegląd zależności między zmiennymi
cor(data)

install.packages("corrplot")
library(corrplot)

corrplot(cor(data))

plot(as.factor(data$exp), data$sales)

pairs(data) #wykresy rozrzutu
