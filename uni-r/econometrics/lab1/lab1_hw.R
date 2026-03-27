#zad1

wartosc_kryt <- qnorm(0.1, lower.tail=TRUE)
wartosc_kryt

p_value <- pnorm(1.6, 0, 1, lower.tail=FALSE)
#lower.tail false <- prawdopodobienstwo prawostronne 

curve(dnorm(x, mean=0, sd=10), -30, 30)
curve(dchisq(x, 5), 0, 20)
curve(x-3, 0, 6)

#zad2
install.packages("psych")
library(psych)

dane_las <- read.csv("lasy_2024.csv", sep = ";", fileEncoding = "UTF-8")
dane_las <-dane_las[,-4]
colnames(dane_las)


describe(dane_las[,3])
colnames(dane_las)[3] = "las_ha"
dane_las$las_ha <- as.numeric(gsub(",", ".", dane_las$las_ha))
options(scipen = 999) 
hist(dane_las$las_ha, col = "darkgreen", main = "Rozkład powierzchni lasów w woj.", 
     xlab = "Powierzchnia [ha]", 
     ylab = "Liczba województw")
options(scipen = 0) 
boxplot(dane_las$las_ha, col = "forestgreen", 
        main = "Powierzchnia lasów",
        ylab = "ha")

#zad3
library(Ecdat)
data("BudgetFood")
head(BudgetFood)

BudgetFood$foodexp = BudgetFood$wfood * BudgetFood$totexp

man <- BudgetFood[which(BudgetFood$sex == "man"), "foodexp"]
woman <- BudgetFood[which(BudgetFood$sex == "woman"), "foodexp"]

summary(man)
summary(woman)
sd(man)
sd(woman)

t.test(man, woman, alternative = "two.sided")
var.test(man, woman, alternative = "two.sided")


library(ggplot2)
ggplot(BudgetFood, aes(x = totexp, y = foodexp))+geom_point()
cor(BudgetFood$totexp, BudgetFood$foodexp)

model <- lm(foodexp ~ totexp, data = BudgetFood)
summary(model)

model <-lm(foodexp ~ ., data=BudgetFood)
summary(model)