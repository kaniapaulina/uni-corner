# ======================================================
# Ekonometria
# Laboratoria 4 - 09.03.2026
# ====================================================== 

# ======================================================
# ===== Zadanie 1 =====
# ======================================================
# Naprawianie modelu, w którym testy diagnostyczne "wybuchły", zadanie na odporne błędy standardowe orazregresje ważoną (wls)

# DIAGNOZOWANIE

library(lmtest)
library(car)
library(randtests)

test_summary <- function(model) {
  r <- model$residuals
  print(vif(model))
  print(shapiro.test(r))
  print(bptest(model))
  print(reset(model))
  print(runs.test(r))
}

model <- lm(sales ~ weekend + beach + rain + exp + temp + flavors, data)
test_summary(model)
# ostatnie trzy testy wzkazują na brak rozrzucenia losowosci liczb, heteroskedastyczność i liniowa postać jest nieoptymalna, model jest lepszy z wyzszymi potęgami

library(corrplot)
corrplot(cor(data))
# dodajemy mniej znaczącą zmienną by porpawić model

model <- lm(sales ~ weekend + beach + rain + exp + temp + flavors + parking, data)
test_summary(model) # niestety dalej słabo wypada model

# Nieliniowe zależności
plot(data$exp, data$sales) #ty zaleznosci, ksztalt wklesły
plot(abs(data$exp-median(data$exp)), data$sales)
plot(abs(data$exp-median(data$exp))^2, data$sales)
plot(abs(data$exp-median(data$exp))^3, data$sales)

model <- lm(sales ~ weekend + beach + rain + I(abs(exp-median(exp))^2) + temp + flavors + parking, data)
test_summary(model) #poprawiony model- rozwiązuje heteroskedastyczność i wspolliniowość z ostatnich testów

# wracamy do poprzedniego modelu z skedastycznościa, błędy odporne
model <- lm(sales ~ weekend + beach + rain + exp + temp + flavors, data)
test_summary(model)

library(sandwich)
coeftest(model)

vcovHC(model)
coeftest(model, vcovHC(model)) # wynik z testu zmodyfikowany tak aby bledy byly odporne

# Regresja ważona - ostatnia metoda na heteroskedastyczność
# do modelu regresji dodajemy wagi
data$e <- model$residuals^2 #wariancja reszt

me <- lm(e ~ weekend + beach + rain + exp + temp + flavors, data)
me$fitted.values
data$w <- me$fitted.values

model <- lm(sales ~ weekend + beach + rain + exp + temp + flavors, data, weights = 1/w)
test_summary(model) # pozbywamy sie heteroskedastycznosci

# ======================================================
# ===== Zadanie 2 =====
# ======================================================

# PROGNOZOWANIE
model <- lm(sales ~ weekend + beach + rain + I(abs(exp-median(exp))^2) + temp + flavors + parking, data)
test_summary(model)

p <- predict(model, newdata = data.frame (
  weekend = 0, beach = 300, rain = 0, exp = 0, temp = 20, flavors = 5, parking = 0
), se.fit = T) #bledy standardowe prognozy

#fit - poprzednia wartosc, se.fit - blad standardowy, df - liczba stopni swobody

# bledy ex ante - prognoza zanim się wydarzy
# Przedzial ufnosci dla prognozy (99%)
l <- p$fit - p$se.fit*qnorm(0.995) #dolny przedzial prognozy
u <- p$fit + p$se.fit*qnorm(0.995) #górny przedzial prognozy

# bledny ex post - sprawdzamy model na danych historycznych
# dzielimy dane na zbiór treningowy i testowy
library(dplyr)
set.seed(333)

train <- data %>% slice_sample(prop = 0.7) #70%
test <- data %>% anti_join(train)

s <- sample(1:400, 400)
data_r <- data[s,]
train <- data_r[1:280,]
test <- data_r[281:400,]

model <- lm(sales ~ weekend + beach + rain + I(abs(exp-median(exp))^2) + temp + flavors + parking, data)

p <- predict(model, newdata = test, se.fit = T)
e <- test$sales - p$fit
hist(e)

# Mean Absolute Error - snredni blad, o ile sztuk srednio sie myli mode;
MAE = mean(abs(e))

# Root MEan Squared Error - karze model za duze pomylki
RMSE = sqrt(mean(e^2)) #bardziej wrazliwy na wartosci odstajace

# Mean ABsolute Percentage Error - jesli MAPE = 5% to model sie myli srednio o 5%
MAPE = mean(abs(e/test$sales))*100 #wyrazone w procentach
    
# dzielimy zbiór na np. 10 części
# za każdym razem jedna z tych części jest zbiorem testowym, a reszta trafia do zbioru treningowego
# estymujemy i prognozujemy
# błedy prognozy


s <- sample(1:400, 400)
data_r <- data[s,]

errors <- data.frame(MAE = NULL, RMSE = NULL, MAPE = NULL)
# alternitevly: MAE <- vector()  

for(i in 1:10) {
  train <- data_r[((i-1)*40):(40*i),]
  test <- data_r %>% anti_join(train)
  
  model <- lm(sales ~ weekend + beach + rain + I(abs(exp-median(exp))^2) + temp + flavors + parking, train)
  
  p <- predict(model, newdata = test, se.fit = T)
  e <- test$sales - p$fit
  
  df <- data.frame(
    MAE <- mean(abs(e)),
    RMSE <- sqrt(mean(e^2)),
    MAPE <- mean(abs(e/test$sales))*100
  )
  
  errors <- rbind(errors, df)
  # MAE[i] <- ...
}

mean(errors$MAPE)





