# Paulina Kania 

# -
# zadanie 1
set.seed(11)
n <- sample(seq(5,29, by=2), 1, replace=F)
B <- matrix(0, nrow=n, ncol=n)
diag(B) <- 1:n
indeks <- cbind(1:n, n:1)
B[indeks] <- 1:n
print(B) #odp

# -
# zadanie 2
set.seed(41)
C <- matrix(runif(50,2,5), nrow=5, ncol=10)
D <- matrix(runif(50,2,5), nrow=5, ncol=10)
CTD <- t(C) %*% D
print(CTD) #odp
CDT <- tcrossprod(C, D)
print(CDT) #odp

# -
# zadanie 3
x <- as.vector(c(C,D))
set.seed(40)
indeks <- sample(length(x),20,replace=F)
x[indeks] <- NA
print(mean(x, na.rm = TRUE)) #odp
print(sd(x, na.rm = TRUE)) #odp

# -
# zadanie 4
m1 <- outer(0:9, 0:9, function(i, j) (i + j) %% 10)
m2 <- outer(0:8, 0:8, function(i, j) (i - j) %% 9)
print(m1) #odp
print(m2) #odp

# -
# zadanie 5
set.seed(31)
G <- matrix(sample(-20:20, 200, replace = TRUE), 20, 10)
print(G) #odp
#print(t(apply(G, 1, function(x) sort(x, decreasing = TRUE)[1:2])))
sortG <- t(apply(G, 1, sort, decreasing=T))
print(sortG[,1:2]) #odp

# -
# zadanie 6
set.seed(31)
E <- matrix(sample(1:10, 60, replace=T), nrow=6, ncol=10)
suma <- colSums(E)
razem <- outer(suma, suma, "+")
pary <- which(razem > 75, arr.ind = T)
ColPar <- cbind(pary[, "row"], pary[, "col"])
colnames(ColPar) <- c("K1", "K2")
print(ColPar) #odp
uniqPar <- ColPar[ColPar[, "K1"] < ColPar[, "K2"], , drop = FALSE]
print(uniqPar) #odp

# -
# zadanie 7
set.seed(27)
x <- sample(20:27, 200, replace = T)
print(x) #odp
y <- character(20)
wiek <- x <= 22
y[wiek] <- sample(c("lic", "inż."), sum(wiek), replace = T, prob = c(.4, .6))
y[!wiek] <- sample(c("mgr", "mgr inż."), sum(!wiek), replace = T, prob = c(.3, .7))
print(y) #odp
z <- sample(c("Kraków", "Warszawa", "Katowice", "Rzeszów", "Częstochowa"), 200, replace = T)
print(z) #odp
dane.stud <- data.frame(
  wiek = x, 
  wykształcenie = y, 
  adres = z)
print(dane.stud) #odp

# -
# zadanie 8
print(nrow(dane.stud[complete.cases(dane.stud),])) #odp
print(sum(!duplicated(dane.stud))) #odp
print(table(dane.stud$wiek)) #odp

# -
# zadanie 9
print(subset(dane.stud, wiek > 20 & adres %in% c("Kraków", "Warszawa"), select = c("wiek", "adres"))) #odp
print(subset(dane.stud, wiek > 20 & adres %in% c("Kraków", "Warszawa"))) #odp

#zad10
library(gridExtra)
agg <- aggregate(wiek ~ adres + wykształcenie, dane.stud, mean)
agg$wiek <- round(agg$wiek, 2)
wide <- reshape(agg, idvar = "wykształcenie", timevar = "adres", direction = "wide")
colnames(wide) <- gsub("wiek.", "", colnames(wide))
rownames(wide) <- wide$wykształcenie
wide$wykształcenie <- NULL
grid.table(wide)

#zad11
set.seed(23)
lista1 <- lapply(1:6, runif, min=2, max=8)
print(lista1) #odp

#zad12
lista2 <-   lapply(1:6, runif, min=2, max=8)
sum_list <- mapply("+", lista1, lista2)
print(lista2) #odp
print(sum_list) #odp