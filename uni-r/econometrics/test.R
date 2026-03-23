# Kolokwium git

#Zbiór danych zawiera zmienne dotyczące próby 1000 pracowników firmy:
#- salary - wynagrodzenie netto w zł
#- gender - 1 dla mężczyzn, 0 dla kobiet
#- age - liczba lat
#- edu - liczba lat edukacji
#- ang - poziom języka angielskiego, od 1 dla A1 do 6 dla C2
#- experience - liczba lat doświadczenia w zawodzie
#- tech test - liczba punktów zdobyta na teście technicznym podczas rekrutacji (na 100 możliwych)
#- manager - 1 dla osób na stanowisku menadżerskim, 0 w przeciwnym razie
#- position: 1 - staż, 2 - junior, 3 - mid, 4 - senior
#O ile nie jest zaznaczone inaczej w pytaniu, podawaj odpowiedzi numeryczne z dokładnością do 2 miejsc po przecinku.

dane <- read.csv("dane.csv")
head(dane)

dane <- read.csv("dane.csv")[2:10]
head(dane)

# ======================
# ZADANIE 1 - Wyraź zmienną salary w tysiącach zł. Wyestymuj model liniowy, w którym ta zmienna będzie objaśniania przez wszystkie pozostałe zmienne oraz zmienną interakcyjną wieku i stanowiska menadżerskiego. Podaj wartość dopasowaną dla pierwszej obserwacji

dane$salary_k <- dane$salary / 1000
head(dane$salary_k)

model <- lm(salary_k ~ gender + age + edu + ang + experience + tech_test + manager + position + age:manager, data = dane)
summary(model)

model$fitted.values[1] #ODPOWIEDZ
round(model$fitted.values[1], 2)
# 5,14

# =========== 
# ZADANIE 2 - Przetestuj, czy awans o trzy pozycje ma większy wpływ niż zostanie managerem. Podaj wartość statystyki testowej.

library(car)
# 3*position = manager
# 3*position - manager = 0
test <- linearHypothesis(model, "3*position - manager = 0")
test

# ????
test$F
round(test$F[2], 2) # statystyka F
# 0,39

test$`Pr(>F)`
round(test$`Pr(>F)`[2], 2)
# 0,53

f <- test$F[2]
t <- sqrt(f)  # TSTUDENT
round(t, 2)
# 0,63

# ========
# ZADANIE 3 - Podaj prognozowane wynagrodzenie (w tys. zł) dla kobiety na stanowisku menadżerskim i poziom seniorki, która ma 35 lat, 13 lat edukacji i 10 doświadczenia w zawodzie, angielski na poziomie B2, oraz zdobyła 72 punkty w teście technicznym

zad_3 <- data.frame( gender = 0, age = 35, edu = 13, ang = 4, experience = 10, tech_test = 72, manager = 1, position = 4)
prog <- predict(model, zad_3)
round(prog*1000, 2)
# 7127,74

round(prog, 2) # ODPOWIEDZ
# 7,13 - ma być w tys.


# ==================
# ZADANIE 4 - W pewnym teście statystyka F ma wartość 2,0456 i stopnie swobody 2 oraz 988. Znajdź p-value

pval <- pf(2.0456, df1 = 2, df2 = 988, lower.tail = FALSE)
round(pval, 2) # ODPOWIDZ
# 0,13



# ========================
# ZADANIE 5 - Podaj integralną pojemność informacyjną dla drugiej najlepszej kombinacji zmiennych według metody Hellwiga.

dane <- read.csv("dane.csv")[2:10]
head(dane)

ncol(dane) #9

R0 <- cor(dane)[9, -9]
R <- cor(dane)[-9, -9]

ncol(R) #8

comb <- expand.grid(rep(list(c(T, F)), ncol(R)))

H <- rep(NA, nrow(comb))

for(m in 1:nrow(comb)){
  k <- which(as.logical(comb[m,]))
  # k <- c(1:7)unlist(comb[m,])
  if(length(k) > 0){
    H[m] <- 0
    for(i in k){
      suma <- 0
      for(j in k){
        if(i != j) {
          suma <- suma + abs(R[i, j])
        }
      }
      H[m] <- H[m] + (R0[i]^2) / (1 + suma)
    }
  }
}

posortowane <- sort(H, decreasing = TRUE, na.last = TRUE)
posortowane[2]

names(R0)[which(as.logical(comb[which(H == posortowane[2]),]))]

round(posortowane[2],2) #ODP
# 0,39

# ===============
# ZADANIE 6 - Wyestymuj model regresji logistycznej, w którym zmienną objaśnianą jest manager, a objaśniającymi są wszystkie pozostałe zmienne, z wyjątkiem salary. Następnie wyestymuj ten sam model, ale bez zmiennych demograficznych (age i gender). Ile razy większe są szanse zostania menadżerem z każdym kolejnym rokiem doświadczenia?

model_pelny <- glm(manager ~ . - salary, dane, family = binomial)
summary(model_pelny)

model_bez_demo <- glm(manager ~ . - salary - age - gender, dane, family = binomial)
summary(model_bez_demo)

betaexp <- coef(model_pelny)["experience"]
szanse <- exp(betaexp) #o ile sie zwiekszą szanse zostania manadzerem z kazdym rokiem

round(szanse, 2) # ODP
# 1,16




