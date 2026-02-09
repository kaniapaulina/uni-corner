# --------------------------------------------------------------------------
# Temat: Ćwiczenia 3 - Wczytywanie danych i operacje na ramkach danych
# --------------------------------------------------------------------------

# --- Zadanie 1: Operacje na pliku market.csv
dane <- read.csv(file = "market.csv", header = TRUE, sep = ",")

# (a-b)
print(nrow(dane))
print(sum(dane$cena * dane$ilosc))

# (c)
print(sort(table(dane$nazwa), decreasing = TRUE)[1:3])

# (d)
dane$obrot <- dane$cena * dane$ilosc
obrot_spolki <- sort(tapply(dane$obrot, dane$nazwa, sum), decreasing = TRUE)
print(obrot_spolki[1:3])

# --------------------------------------------------------------------------
# --- Zadanie 2: Dane EuroStat (crim_just_sex)
d2 <- read.csv(file = "crim_just_sex.csv")

# (a)
print(sum(is.na(d2)))

# (b)
dd2 <- d2[d2$geo == "Poland" & d2$sex == "Total" & d2$unit == "Number", ]
print(mean(dd2$OBS_VALUE, na.rm = TRUE))
print(sd(dd2$OBS_VALUE, na.rm = TRUE))

# (c-d)
par(mfcol = c(2, 1))
hist(d2$OBS_VALUE[d2$unit == "Number"], freq = FALSE, main = "Histogram przestępstw")
boxplot(d2$OBS_VALUE[d2$unit == "Number"], horizontal = TRUE, main = "Boxplot")
par(mfcol = c(1, 1))

# (e)
library(reshape2)
tabela_przest <- dcast(d2, geo ~ sex, value.var = "OBS_VALUE", fun.aggregate = sum, na.rm = TRUE)

# --------------------------------------------------------------------------
# --- Zadanie 3: Notowania złota (stooq)
danezloto <- read.csv("https://stooq.pl/q/d/l/?s=xaupln&f=20240101&t=20251001&i=d")

# (a-b)
danezloto$Data <- as.Date(danezloto$Data)
print(class(danezloto$Data))
print(head(danezloto))
print(tail(danezloto, 10))

# (c)
library(zoo)
danezloto$YM <- as.yearmon(danezloto$Data)
srednie_zloto <- aggregate(Zamkniecie ~ YM, data = danezloto, FUN = mean)
print(srednie_zloto[order(srednie_zloto$YM), ])

# --------------------------------------------------------------------------
# --- Zadanie 4: Szeregi czasowe - WIG20
d4 <- read.csv("https://stooq.pl/q/d/l/?s=wig20&f=20240101&t=20251001&i=m")
wig20_ts <- ts(d4$Zamkniecie, start = c(2024, 1), frequency = 12)

plot(wig20_ts, col = "red", lwd = 2, main = "WIG20: Notowania miesięczne")
abline(v = floor(time(wig20_ts)), col = "lightgrey", lty = "dotted")
wig20_moving_avg <- stats::filter(wig20_ts, rep(1/6, 6), sides = 2)
lines(wig20_moving_avg, col = "darkblue", lty = "dashed", lwd = 2)

# --------------------------------------------------------------------------
# --- Zadanie 6: Biblioteka quantmod i Yahoo Finance
library(quantmod)
getSymbols(c("^GSPC", "AAPL"), src = 'yahoo', from = "2024-01-02", to = "2025-06-02")

# (a)
print(all(index(GSPC) == index(AAPL)))
print(mean(Cl(AAPL)))