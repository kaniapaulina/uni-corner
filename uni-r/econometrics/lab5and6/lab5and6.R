# ======================================================
# Ekonometria
# Laboratoria 5 & 6 - 16.03.2026
# ====================================================== 

# ======================================================
# ===== Zadanie 1 =====
# ======================================================

# Metode które nie są wprost liniowe

# Przypadek 1 - nasz y będzie zmienna kategoryczną (kategoria 0/1) 

x <- seq(-10, 10, 0.5)
plot(x)

plot(exp(x)/(1+exp(x))) # wartości między 0 a 1
# jesli y jest > 0.5 damy mu klasę 1, jesli nie to 0 - tak prognozujemy y

# beta0 + beta1*x1 + beta2*x2 + ... + e (błąd losowy)
data <- read.csv("D:/uni-corner/uni-r/econometrics/lab5and6/titanic.csv", na.strings = "")[, -c(1, 4, 9, 11)] #bez ID, imienia, biletu, kabiny

summary(data)
# klasa zmienna numeryczna jesli gdy klasa wzrasta to ta przezywalnosc tez czyli zaleznosc liniowa

data$Pclass <- as.factor(data$Pclass)
data$Sex <- as.factor(data$Sex)
data$Embarked <- as.factor(data$Embarked) # :2 - pusty ciąg, przy wczycie danych dodaj na.strings

boxplot(Age ~ Survived, data) #zależność wieku od przeżycia, ciut wiecej osob z wiekszym wiekiem nie przezyli niz przezyli ale nie jest to silna zaleznosc

#glm - generalized linear model, binomial - 0-1 y
model <- glm(Survived ~ ., family = binomial(link = "logit"), data)
summary(model)

exp(-1.189637) #wspolczynnik, jaki jest stosunek pradopodobienstwa y=1, kiedy ktos jest w drugiej klasie w porownaniu do sytuacji bazowej

(exp(-2.637859)-1)*100
(exp(-0.043308)-1)*100 #age, szanse sie zmiejszaja o 4% wzgledem osoby co byla o rok mlodsza

# ======================================================
# ===== Zadanie 2 =====
# ======================================================

set.seed(123)
library(dplyr)

train <- data %>% slice_sample(prop = 0.7)
test <- data %>% anti_join(train)

# glm() - uogolnione modele liniowe
model <- glm(Survived ~ . - Embarked, family = binomial(link = "logit"), train)
summary(model)

# AIC = 457.92 - podobne do R^2, kryterium informacyjne - im mniejsze tym lepsze, w porownaniu do skorygowanego R^2

model <- glm(Survived ~ . - Embarked - Parch - Fare, family = binomial(link = "logit"), train)
summary(model) #zostaly same istotne zmienne

# Prognoza
p <- predict(model, test, type="response")
p <- ifelse(p>0.5, 1, 0)

# ======================================================
# ===== Zadanie 3 =====
# ======================================================

# TABLICA POMYŁEK
# ACC accuracy - ile bylo poprawnych odp / wszystkie obserwacje, odsetek tego co model trafil dobrze
# PPV precision - jaki odsetek predykowanych jedynek jest faktycznie jedynką
# TPR sensitivity, TNR swoistość

p
sum(p, na.rm=TRUE)

#true <- test$Survived
#dead <- sum(ifelse(true==1, 1, 0)) #warunek w warunku

cm <- table(test$Survived, p)

accuracy <- (cm[1,1]+cm[2,2])/sum(cm)
sensitivity <- cm[2,2]/sum(cm[2,])
specifity <- cm[1,1]/sum(cm[1,])
precision <- cm[2,2]/sum(cm[,2])

# ======================================================
# ===== Zadanie 4 =====
# ======================================================

# Funkcja produkcji
# y = a*K^b*L^c
# K - naklady kapitalu/inwestycje
# L - naklady pracy
# a, b, c - parametry elastyczności

# regresja liniowa / linearizowalizacja - funkcji produkcji na model liniowy:
# log(y) = log(a*K^b*L^c)
# log(y) = log(a) + log(K^b) + log(L^c)
# log(y) = log(a) + b*log(K) + c*log(L)
# y' = a' + b*K' + c*L' 
# K', L' - zmienne objasniajace

data <- read.csv("D:/uni-corner/uni-r/econometrics/lab5and6/dane_produkcja.csv")

model <- lm(log(output) ~ log(investments) + log(employees), data)
summary(model)

a <- exp(model$coefficients[1])
# y_dop = 2.55*K^0.94*L^0.06
# mniej więcej zmiana procentowa
# elastyczność produkcji względem czynników - jeden czynnik wzrasta o 1% to produkcja wzrośnie o ten parametr w modelu

# efekty skali - jeśli nakłady wzrosna iles razy to produkcja tez wzrośnie tez te iles razy - to efekty skali są stałe
# b + c = 1 - stałe efekty
# b + c > 1 - rosnące
# b + c < 1 - malejące

# y(K,L) = a*K^b*L^c
# y(2K,2L) = a*(2K)^b(2L)^c
# y(2K,2L) = a*2^b*K^b*2^c*L^c
# y(2K,2L) = 2^(b+c)*a*K^b*L^c
# y(2K,2L) = 2^(b+c)*y(K,L)
# jesli b+c=1 to Y(2K,2L) = 2*y(K,L)

library(car)
# linearHypothesis - test statystyczny sprawdzający, czy suma parametrów istotnie różni się od jedności. Jeśli p > 0.05, przyjmujemy, że mamy stałe efekty skali
linearHypothesis(model, "log(investments) + log(employees) = 1") # hipoteza zerowa
# nie odrzucamy H0 - efekty skali sa stałe

linearHypothesis(model, "log(employees) = 0.05") #czy ten parametr jest istotnie różny od 0.05

# ======================================================
# ===== Zadanie 5 =====
# ======================================================


# szeregi czasowe

# Prognozujemy sprzedaż w czasie, biorąc pod uwagę fakt, że dzisiejsza sprzedaż zależy od tej sprzed tygodnia (autokorelacja) oraz od trendu.


library(dplyr)
data <- read.csv("H:\\Ekonometria\\dane3.csv") %>% group_by(week) %>% 
  summarise(
    sales = sum(units_sold),
    price = mean(price_unit),
    promo = mean(promo_rate),
    is_holiday_week = mean(is_holiday_week),
    is_winter = mean(is_winter)
  )

train <- data[1:120,]
test <- data[121:150,]

model <- lm(sales ~ . -week, train)
summary(model)

# autokorelacja
plot(data$sales, type = "l")
library(lmtest)
dwtest(model) # Chcemy wyniku blisko 2. Jeśli jest blisko 0, mamy dodatnią autokorelację (model nie wyłapał zależności czasowej).

# Stacjonarność: Szereg jest stacjonarny, jeśli jego średnia i wariancja są stałe w czasie. Jeśli masz trend (sprzedaż rośnie z roku na rok), szereg jest niestacjonarny.
# trend
data$week = 1:150
train <- data[1:120,]
test <- data[121:150,]

model <- lm(sales ~ ., train)
summary(model)
dwtest(model) # odrzucam hipoteze o autokorelacji

# autoregresja
model <- lm(sales ~ . + lag(sales), train)
summary(model)
dwtest(model) 
# pozbywamy sie autoregresji

# róznicowanie danych - usuwa trend, czyli pozwala na anlizę danych, które podążają za wyraźnym trendem
plot(diff(data$sales), type = 'l')
# yt - y(t - 1) - aktualny odjąć poprzedni

# stacjonarność - stała wartość oczekiwana i wariancja
install.packages("tseries")
library(tseries)
# Jeśli $p < 0.05$, szereg jest stacjonarny (gotowy do modelu ARIMA)
adf.test(data$sales)
adf.test(diff(data$sales))

# wykresy autokorelacji
pacf(data$sales)
# nasze dane są sorelowane do 3 okresów wstecz - bo te 3 wykraczaja poza te niebieskie linie (przedziały ufności)

# AR I MA
# autoregression integration mean yearly average
# y = B0 + B1*y(t-1) + ... + E + C1*E(t-1) + C2*E(t-2)

model <- arima(data$sales, order = c(3,0,0))
summary(model)
# kryterium informacyjne AIC - im mniejsze tym lepiej

library(forecast)
model <- auto.arima(data$sales, trace = T, stepwise = F, approximation = F, xreg = as.matrix(data[,3:6]))
model
# BIC - kryterium informacyjne
coeftest(model)


model <- auto.arima(train$sales, trace = T, stepwise = F, approximation = F, xreg = as.matrix(train[,4]))
model

# autokorelacja
Box.test(model$residuals)
# nie ma autokorelacji

# prognoza
p <- forecast(model, test$sales, xreg = as.matrix(test[,4]))
p

e <- test$sales-p$mean
MAE <- mean(abs(e))
MAE

data$forecast = c(p$fitted, p$mean)
data$lower = c(rep(NA, 120), p$lower[,1])
data$upper = c(rep(NA, 120), p$upper[,1])

plot(data$sales, type = 'l') # realne dane
lines(data$forecast, col = "red") # dopasowane dane
lines(data$lower, col = "blue") #przedziały ufności
lines(data$upper, col = "blue") #przedziały ufności









