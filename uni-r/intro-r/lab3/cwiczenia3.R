# Paulina Kania

# zad1
p <- getwd()
dane <- read.csv(file="market.csv", head=T, sep=",")
str(dane)
print(dim(dane)[1])
print(sum(dane$cena*dane$ilosc))

sort(table(dane$nazwa), decreasing=T)[1:3]

print(sort(table(dane$nazwa))[(length(table(dane$nazwa))-2):length(table(dane$nazwa))])

dane$obrot <- dane$cena*dane$ilosc
x <- sort(tapply(dane$obrot, dane$nazwa, sum))
print(x[(length(x)-2):length(x)])

# zad2
d2 <- read.csv(file="crim_just_sex.csv")
str(d2)
table(d2$unit)
table(d2$sex)

print(sum(is.na(d2)))

table(d2$geo)
dd2 <- d2[d2$geo=="Poland" & d2$sex=="Total", c("unit", "TIME_PERIOD", "OBS_VALUE")]
x <- dd2$OBS_VALUE[dd2$unit=="Number"]
print(mean(x))
print(sd(x))

hist(d2$OBS_VALUE[d2$unit=="Number"])

# zad3
danezloto<- read.csv("https://stooq.pl/q/d/l/?s=xaupln&f=20240101&t=20251001&i=d")
danezloto$Data <- as.Date(danezloto$Data)
print(typeof(danezloto$Data))
str(danezloto)

print(head(danezloto))
print(tail(danezloto,10))

library(zoo)
danezloto$Data<-as.Date(danezloto$Data)
danezloto$YM <- format(danezloto$Data,"%Y-%B",tz = "GMT") # miesiące i rok(cały)
danezloto$M <- format(danezloto$Data,"%B",tz = "GMT")     # nazwy misiecy
danezloto$Y <- format(danezloto$Data,"%y",tz = "GMT")     # rok
# utworzenie średnich miesięcznych
pdane=aggregate(Zamkniecie~YM,data=danezloto, FUN=mean)
# sortowanie średnich według daty
pdane$d <- as.yearmon(pdane$YM, "%Y-%b")
print(pdane[order(pdane$d),1:2])


# zad4
d4 <- read.csv("https://stooq.pl/q/d/l/?s=xaupln&f=20200101&t=20251101&i=m")
str(d4)
wig20=ts(d4$Najwyzszy, start=c(2024,1),frequency=12)
plot(wig20,col="red")
#dodanie linii szarych pionowych
abline(v=floor(time(wig20)),col="lightgrey")
#średnie z sześciu danych (półroczne)
wig20.sr3<-stats::filter(wig20,sides = 2,rep(1,6)/6)
lines(wig20.sr3,col="darkblue",lty="dashed")


library(quantmod)
getSymbols("AAPL", src='yahoo',from=as.Date("2025-01-01"), to=as.Date("2025-10-01"))
mean(AAPL$AAPL.Close)