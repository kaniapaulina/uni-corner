# Paulina Kania

# zadanie 1
a1 <- c(1:20, 19:1)
print(a1) #odp

b1 <- rep(c(4,6,3), length.out=50)
length(b1)
print(b1) #odp

c1 <- rep(c(4, 6, 3), times=c(10,20,30))
length(c1)
print(c1) #odp

d1 <- seq(100,4,-8)
print(d1) #odp

e1 <- 0.1^(seq(3, 36, 3)) * 0.2^(seq(1, 34, 3))
print(e1)  #odp

# --------------------
# --------------------
# --------------------

# zadanie 2
a2 <- paste0(rep(c("A","X"), 15), rep("_",30), 1:30, rep(".",30), rep(c("B","D","F"), 10))
print(a2) #odp

# --------------------
# --------------------
# --------------------

# zadanie 3
set.seed(50)

a3 <- sample(5:15, 100, replace=T)
print(a3) #odp

b3 <- sample(c(LETTERS, letters), 100, replace=T)
print(b3) #odp

# --------------------
# --------------------
# --------------------

# zadanie 4
set.seed(30)
x <- sample(0:999, 250)
y <- sample(0:999, 250)

a4 <- x[1:248] + 2*x[2:249] - y[3:250]
print(a4) #odp

b4 <- sum(exp(-x[2:250])/(x[1:249]+10))
print(b4) #odp

i<-rep(1:20, each=5)
j<-c(1:5)

c4<-sum((i^4/i+3))
print(c4) #odp

# --------------------
# --------------------
# --------------------

# zadanie 5
set.seed(50)
x <- sample(0:999, 500)

a5 <- sum(x%%2 ==0)
print(a5) #odp

b5 <- sum(x %% 2 == 0 & x %% 3 == 0)
print(b5) #odp

c5 <- sum(x<30 | x>70)
print(c5) #odp

# --------------------
# --------------------
# --------------------

# zadanie 6 
napis <- c( "Katedra", "Informatyki", "Biznesowej", "i", "Inżynierii", "Zarządzania",
            "WZ", "AGH", 2022)
xd <- unlist(strsplit(napis, split=""))
a6 <- length(unique(xd))
print(a6) #odp

b6 <- names(which.max(table(xd)))
print(b6) #odp

