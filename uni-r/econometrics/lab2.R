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

library(corrplot)
corrplot(cor(data))

plot(as.factor(data$exp), data$sales) #sprzedaż wzgledem kategorii doswiadczenia

pairs(data) #wykresy rozrzutu

model <- lm(sales ~ ., data)
summary(model)

# ===== krok 3: wspolliniowosc
library(car)

vif(model) #problem jesli wieksze niz 5, sygnal alarmowy ze istnieje pewna wspolliniowosc i model nie wie ktorej zmiennej przypisac zasluge za wynik
model <- lm(sales ~ weekend + temp + wind + rain + exp + beach + flavors + parking + price, data)
summary(model)

# przeksztalcenie zmiennej
# I - interpretacja jako ta operacja, wykona to dzialanie a potem wezmie jako zmienna
model <- lm(sales ~ weekend + temp + wind + rain + I((exp-median(exp))^2) + beach + flavors + parking + price, data)
summary(model)


# zmienna kategoryczna
model <- lm(sales ~ weekend + temp + wind + rain + as.factor(exp) + beach + flavors + parking + price, data) #sprawdza dla kazdej kategorii doswiadczenia, jeden rok, dwa lata itd
summary(model)

# Analiza Summary:
# Adjusted R-squared: Używaj wersji "Adjusted" (skorygowanej), gdy porównujesz modele z różną liczbą zmiennych. Jeśli dodasz nową zmienną, a Adjusted R-squared spadnie – wyrzuć ją, model stał się gorszy (przeuczony)
# Istotność zmiennych ($p-value$): Czy po dodaniu interakcji lub kwadratu, inne zmienne przestały być istotne?

# ======================================================
# ===== METODA HELLWIGA
# ======================================================
# czyli jak matematycznie wybrać optymalny zestaw zmiennych które:
# Mają jak najwyższą korelację ze zmienną objaśnianą (sales).
# Mają jak najniższą korelację między sobą (nie dublują informacji).

# rj^2
R0 <- cor(data)[11, -11] #ostatni wiersz bez ostatniej kolumny
R <- cor(data)[-11, -11] #bez ostatniego wierszu i bez ostatniej kolumny (sales)

R0 # wektor korelacji
R # macierz korelacji

expand.grid(c(1:3), c(1:3), c(1:3)) # wszytskie mozliwe kombinacje macierz
comb <- expand.grid(rep(list(c(T, F)), 10)) # gigantyczna macierz prawdy dla kazdej zmiennej
View(comb)

k <- c(1:10)[unlist(comb[500,])]
names(R0)
colnames(data)
names(R0)[k]

dane <- vector()
for(j in 1:1023) { # mk = 1023, jc(1, mk)
  k <- c(1:10)[unlist(comb[j,])] # k - numer kombinacji, np 3, 4 i 10 są TRUE
  H <- 0
  for(i in k) {
    mianownik <- sum(abs(R[k, i])) #korelacja miedzy "i" i "i" jest rowne 1, wiec nie dodaje jedynki
    H <- H + R0[i]^2/mianownik #indywidualna pojemnosc dodana do sumy
  }
  dane[j] <- H
}
H #maksymalna pojemnosc informacyjna
max(dane)

