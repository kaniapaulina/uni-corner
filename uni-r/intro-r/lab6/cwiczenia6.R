# Paulina Kania
# funkcje

# ----------------------
# ZADANIE 1: minmaxK(x, K)
minmax <- function (x, k=3) {
  stopifnot(is.numeric(x))
  
  if(length(x)<k) {
    return("za krotki element")
  }
  return(c(sort(x)[1:k],sort(x)[(length(x)-k+1):length(x)]))
}

x1 <- sample(1:200, 50, replace=T)
print(minmax(x1, 5))

# ----------------------
# ZADANIE 2: 1Dskn1(x) - Liczba Doskonała
lDsknl <- function(x) {
  y<-c(1:ceiling(x/2))
  if(sum(y[x%%y==0])==x) {
    return(TRUE)
  }
  else {
    return(FALSE)
  }
}
system.time( s <-sum(sapply(c(1:10000),lDsknl)))
which(sapply(c(1:10000),lDsknl))

# -------------------------------
# ZADANIE 3: mynorm(x) - Unitaryzacja
myNorm <- function(x, na.rm=F) {
  if (length(na.omit(x)) == 0) return(x)
  if (max(x, na.rm = na.rm) == min(x, na.rm = na.rm)) return(rep(0, length(x)))
  
  (x - min(x, na.rm = na.rm)) / (max(x, na.rm = na.rm) - min(x, na.rm = na.rm))
}

x3<- sample(1:200, 100, replace=T)
y3<- mynorm(x3, na.rm=T)
min(x3, na.rm=T)
min(y3, na.rm=T)

# ----------------------
# ZADANIE 4: myCorr(x,y) - Korelacje
myCorr <- function(x, y) {
  if (length(x) != length(y)) {
    return("zła długość")
  }
  
  pearson <- cor(x, y, method = "pearson")
  kendall <- cor(x, y, method = "kendall")
  spearman <- cor(x, y, method = "spearman")
  
  return(c(Pearson = pearson, Kendall = kendall, Spearman = spearman))
}
x4 <- runif(100, min = 0, max = 5) 
e4 <- rnorm(100)                    
y4 <- x4 + e4       
myCorr(x4,y4)

# ----------------------
# ZADANIE 5: myStats(x, p)
myStats <- function(x, p) {
  stopifnot(is.numeric(x), p %in% c(0, 1))
  
  if (p == 0) {
    return(c(Mean = mean(x), StdDev = sd(x)))
  } else {
    return(c(Median = median(x), MAD = mad(x)))
  }
}

print(myStats(x1, p = 0))
print(myStats(x4, p = 1))

# ----------------------
# ZADANIE 6: myFun(x) i miejsca zerowe
myFun <- function(x) 10*sin(x)*cos(.5*x^3) + (1/2)*sqrt(abs(x))
uniroot(myFun, c(1,2))
uniroot(myFun, c(6,7))
uniroot(myFun, c(-5,5))

# wszytskie miejsca zerowe
library(rootSolve)

x <- seq(-3,3,.1)
plot(x, myFun(x), type="l", main="10*sin(x)*cos(.5*x^3) + (1/2)*sqrt(abs(x))", cex.main=0.8)
wynik <- uniroot.all(myFun, c(-5,5))
points(wynik, myFun(wynik),col="red", pch=19)

# ----------------------
# ZADANIE 7: myLin(x) - Układ Liniowy
myLin <- function(x) {
  # sprawdzanie dlugosci x
  f1 <- 2*x[1] + 1*x[2] - 2*x[3] + 2
  f2 <- 1*x[1] + 2*x[2] - 2*x[3] - 1
  f3 <- 2*x[1] + 1*x[2] - 1*x[3] + 3
  
  return(c(f1, f2, f3))
}
multiroot(f=myLin, c(1,1,1))
myLin(c(3.00, -3.50, 1.75))

# ----------------------
# ZADANIE 8: myNonLin(x) - Układ Nieliniowy
myNonLin <- function(x) {
  f1 <- 2*x[1] + x[2]^2 - 2*x[3] - 2
  f2 <- x[1]^2 + 2*x[2] - 2*x[3] - 3
  f3 <- 2*x[1] + x[2] - x[3] - 3
  
  return(c(f1, f2, f3))
}
multiroot(f=myNonLin, c(2, 1, 2))

# ----------------------
# ZADANIE 9: myDane(url) - Pobieranie i Normalizacja Danych
library(dplyr)
library(rvest)
library(tidyr)
library(scales)

url<-"https://pl.wikipedia.org/wiki/Lista_najwi%C4%99kszych_przedsi%C4%99biorstw"

MyDane<-function(x)
{
  read_html(x)%>%
    html_nodes("table")%>%
    html_table()->tables
  return(tables)
}

dane<-MyDane(url)
df<-dane[[1]]
colnames(df)

k4<-gsub("[^[:alnum:]]", "", df$`Przychód(mln $)`, perl = TRUE)
k4n<-as.numeric(k4)

k6<-df$`Symbol giełdowy`[!is.na(df$`Symbol giełdowy`)]
k6

remove_outliers <- function(x) {
  if (length(na.omit(x)) == 0) return(numeric(0))
  if (!is.numeric(x)) return(x)
  
  Q1 <- quantile(x, 0.25, na.rm = TRUE)
  Q3 <- quantile(x, 0.75, na.rm = TRUE)
  IQR <- Q3 - Q1
  lower <- Q1 - 1.5 * IQR
  upper <- Q3 + 1.5 * IQR
  
  x[x >= lower & x <= upper]
}

k4nbo <- remove_outliers(k4n)
k4nbo

k4nboNorm<-myNorm(k4nbo, na.rm=F)
k4nboNorm

k7<-df$Siedziba

wstepnie_zrobione<-data.frame(k4nboNorm, k6[4:length(k6)], k7[4:length(k7)])
colnames(wstepnie_zrobione) <-c("k4", "k6", "k7")
wstepnie_zrobione_clean<-wstepnie_zrobione[wstepnie_zrobione$k6 != "", ]
wstepnie_zrobione_clean