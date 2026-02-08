
# Paulina Kania 09.10.2025

# - - - - - - - - - - - -
#zad1
a1<-c(55,22,1:200,13)
b1<-rep(c(4,6,3),10)
c1<-rep(3:9,each=3)
d1<-seq(-5,5,length.out=100)

set.seed(111)
e1<-sample(1:99,30)

#replace - by mogl kilkukrotnie wyliczyc ta sama liczbe
f1<-sample(c(0,1),99,replace=T, prob=c(0.3,0.7))

print()

class()
typeof()
length()
sum()
mean()
quantile()
sd() #odchylenie standardowe
quantile(x)[4]-quantile(x)[2] #rozstep miedzykwartylny
mad(x)
sd(x)/sqrt(length(x))
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad2
(x<-sample(0:9,150,replace=T))
(y<-sample(0:9,150,replace=T))

a2<-exp(x)*cos(y)
print(a2)

b2<-y[1:149]-x[2:150]
print(b2)

c2<-sin(y[1:149])/cos(x[2:150])
print(c2)
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad3
x<-c(10:100)
a3<-x^3+4*x^2
print(sum(a3))

i<-rep(1:20, each=5)
j<-c(1:5)

b3<-sum((2^i/i+3^j/j))
print(b3)
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad4
x<-sample(0:99,60)
y<-sample(0:99,60)

print(y[y>60])
print(which(y>60))
print(x[y>60])

m<-mean(x)
print(c(sqrt(abs(x-m))))

print(sort(y))
print(x[order(y)])

i<-seq(1,60,b=3)
print(y[i])
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad5
x<-sample(10:100,60)
print(any(x>90))
print(all(x>85))
print(sum(x>90))
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad6
x<-c(1,seq(2,38,by=2))
x
y<-seq(1,39,by=2)
y
print(sum(cumprod(x/y)))
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad7
x<-runif(500,3,5)
y<-rnorm(500) #standard: 0,1
print(mean(x))
print(mean(y))
print(sd(y))
print(var(y))

hist(x)
hist(y, col="lightblue", border="purple")
hist(x, col="lightblue", border="purple", breaks=21)
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad9
napis<-c( "Katedra", "Informatyki", "Biznesowej", "i", "Inżynierii", "Zarządzania", "WZ", "AGH", 2022)
print(length(napis))
print(class(napis))
print(sapply(napis,nchar))
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad10
x<-c(2,3,5)
y<-c("aa", "bb", "cc", "dd", "ee")
z<-c(TRUE, FALSE, TRUE, FALSE, FALSE)
l1<-list(x=x,y=y,z=z)
print(l1[[2:3]])
print(l1[2])
print(l1[-2])
print(names(l1))
names(l1)<-c("V1","V2","V3")
print(names(l1))
print(l1$V1)
l1$V4<-c(1:10)
print(l1)
# - - - - - - - - - - - -
# - - - - - - - - - - - -
# - - - - - - - - - - - -
#zad11
l1<-lapply(1:6,runif,min=2,max=8)
l1
l2<-lapply(1:6,runif,min=2,max=8)
l2
#mapply do reszty zadanka