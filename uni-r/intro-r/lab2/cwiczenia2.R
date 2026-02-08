  # Paulina Kania

# ---------------------
# ---------------------

# zadanie 1
set.seed(111)

cs <- seq(0.5,60, length.out=101)
cp <- seq(356,480, length.out=101)
odp <- sample(c("tak", "nie", "nie_wiem"), 101, replace=TRUE, prob=c(.5,.3,.2))
wynik <- rnorm(101, mean=65, sd=15)
pun <- runif(101,0,200)
gr <- sample(1:4, 101, replace=TRUE)

length(cs)
length(cp)
typeof(cs)
typeof(cp)

# ---------------------
# ---------------------

# zadanie 2

A <- matrix(sample(-20:20,200, replace=TRUE),nrow=20)
A
print(colSums(A))
print(rowMeans(A))
print(rowSums(A)[seq(2,20,by=2)])
#print(rowSUms(A[seq(1,20,by=2,)]))
print(apply(A,2,max))
print(apply(A,1,sd))
print(apply(A[1:20 %% 2==1,],1,var))
print(apply(A,1,prod))

# ---------------------
# ---------------------

# zadanie 3

wm <- sample(2:10,10,replace=T)
m <- sample(8:12,10,replace=T)
s <- sample(1:4,10,T)
i <- 1
x <-list()
for(i in 1:10) {
  x[[i]]<- matrix(rnorm(wm[i]*wm[i],m[i],s[i]),nrow=wm[i])
}

print(lapply(x,dim))
print(sapply(x,dim))

print(det(x[[1]]))
print(sapply(x[c(1,3)],det))
# podpunkt c samodzielnie

# ---------------------
# ---------------------

# zadanie 4
dane <- data.frame(cs=cs,cp=cp,odp=odp,wynik=wynik,pun=pun, gr=gr)
print(head(dane,10))
dim(dane)

# zadanie 5
dane$daty <- seq(as.Date("2025-07-06"), as.Date("2025-10-14"), by="day")
print(head(dane,10))

# zadanie 6 samodzielnie??
wiersz <- list(.52, 358.5, "nie", 75, 199.2, 4, as.Date("2025-10-16"))
dane[102,] <-wiersz
print(tail(dane, 5))

# zadanie 7
dane[dane$odp=="nie_wiem",]
dane[dane$wynik>60,]
print(dane[dane$odp == "nie_wiem" & dane$wynik>60,])
subset(dane, odp == "nie_wiem" & wynik>60, select=c(wynik,pun))

# zadanie 8
print(aggregate(cs~gr, data=dane,mean))

# zadanie 9 samodzielnie

# zadanie 10
library (reshape2)
?dcast
print(dcast(dane, gr~odp, mean,value.var = "pun"))


#duplikaty
dane[103,] <- wiersz
dane[104,] <- wiersz
dane[105,] <- wiersz
sum(duplicated(dane)==FALSE)