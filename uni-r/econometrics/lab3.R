# ======================================================
# Ekonometria
# Laboratoria 3 - 09.03.2026
# ======================================================

# ======================================================
# ===== Zadanie 1 =====
# ======================================================
# Diagnostyka

# Współliniowość:
# e ~ i.i.d independant identical distributions
# autokorelacja - miara zależności liniowej między bieżącymi wartościami szeregu czasowego a ich wartościami z przeszłości
# heteroskedastyczność - niejednorodność wariancji (homoskedastyczność - jednorodność), dla wszytskich obserwacji powinniśmy mieć taką samą skale błedów
# dobór postaci modelu: problem - dopasowanie liniowego modelu gdy rzeczywiście zależność jest nieliniowa, losowość błędów (niedoszacowane), przerwy strukturalne (w naszym zbiorze danych mamy grupy gdzie y w inny sposób zależy od x)
# normalność reszt (niekonieczne założenie)

# Teoretyczny model - sytuacja idealna

model_t <- lm(sales ~ temp*weekend + beach + rain + other + price + I((exp-4)^2) + I((flavors-7)^2), data)
summary(model_t)

# === WSPÓŁLINIOWOŚĆ
library(car)
vif(model_t) # test na wspolliniowosc
# wniosek -> jesli wynik przekracza 5, mozna wywnioskowac wspolliniowosc

# === NORMALNOŚĆ RESZTY
r <- model_t$residuals
shapiro.test(r)
# wniosek -> układ jest pewnie normalny
hist(r)

# === HETEROSKEDASTYCZNOŚĆ - rozpiętość reszt może wzrastać wraz z y, lub je pogrupować -> istnieje wiele testów
plot(model_t$fitted.values, model_t$residuals)
# wniosek -> mniej wiecej ta sama rozpietość reszt jest git, ale gdy się grupuje pojawiają się błędy
plot(model_t) 
# wykres 1: najbardziej odlegle punkty zostaly podpisane
# wykres 2: Q-Q Residuals badanie normalności reszt
# wykres 3: Scale-Location przypadki oddalające się od regresji

library(lmtest)
gqtest(model_t, 0.7) # test Goldfelda-Quanta, na 70%

bptest(model_t) # test Breusch-Pagana, patrzy czy zmienne objasniające mają istotny wplyw na reszty, jesli tak to reszty nie są takie losowe, jesli nie to reszty są niezalezne i mamy doczynienia z heteroskedastycznością

bptest(model_t, ~ wind, data=data) # czy zmienna wind wplywa na reszty - jesli nie to dobrze bo nie uwzgledniamy jej w modelu

# test White'a
data$y_drop = model$fitted.values
bptest(model_t, ~ y_drop + I(y_drop^2) + I(y_drop^3), data=data)

# === LINIOWA POSTAĆ MODELU
# test Ransey'a (RESET)
reset(model_t) # jesli dorzucimy wyzsze potegi w naszym podstawowym modelu lepiej bedzie opisywac y

# test liczby serii - ile mamy takich serii ze bledy wystepują po tej samej stronie (sa ujemne czy dodatnie), jesli model jest dobrze dobrany to beda wsytepowac duzo serii gdyz bledy są losowe i są porozrzucane po obu stronach

library(randtests)
runs.test(r)

# === PRZERWY STRUKTURALNE
# test CHOW - Wikipedia

boxplot(sales ~ exp, data) # wykres pudelkowy, przerwa strukturalna gdzies po środku

# dzielimy na dwie grupy
# liczymy modele
# bierzemy sumy kwadratow bledow
# liczymy statystykę z wzoru testu Chow
# znajdujemy p-value

med <- median(data$exp)
g1 <- data[data$exp<med,]
g2 <- data[data$exp>=med,]

model <- lm(sales ~ temp*weekend + rain + beach + other + price + I((exp-4)^2) + I((flavors-7)^2), data)
model1 <- lm(sales ~ temp*weekend + rain + beach + other + price + I((exp-4)^2) + I((flavors-7)^2), g1)
model2 <- lm(sales ~ temp*weekend + rain + beach + other + price + I((exp-4)^2) + I((flavors-7)^2), g2)

sse <- sum(residuals(model)^2)
sse1 <- sum(residuals(model1)^2)
sse2 <- sum(residuals(model2)^2)

k <- length(model$coefficients) #or length(coef(model))
n1 <- nrow(model1)
n2 <- nrow(model2)

wynik <- ((sse-(sse1+sse2))/k)/((sse1+sse2)/(n1+n2-2*k))
p_val <- 1-pf(wynik, k, n1+n2-2*k)

test_summary <- function(model) {
  r <- model$residuals
  print(vif(model))
  print(shapiro.test(r))
  print(bptest(model))
  print(reset(model))
  print(runs.test(r))
}

test_summary(model_t)

model <- lm(sales ~ temp*weekend + rain + beach + other + price + exp + flavors, data)
summary(model)
test_summary(model)

plot(model$fitted.values, model$residuals)      
plot(model$fitted.values, data$sales)
lines(data$sales, data$sales)

# poprawiamy postać modelu - opcja idealna gdy niektore testy nie są spelnione

# problem z heteroskedastycznością - odporne bledy standardowe
# zmodyfikowana regresja - regresja wazona

