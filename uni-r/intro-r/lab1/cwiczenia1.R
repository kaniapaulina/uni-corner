# --------------------------------------------------------------------------
# Temat: Ćwiczenia 1 - Podstawy języka R (typy danych, wektory i listy)
# --------------------------------------------------------------------------

# --- Zadanie 1: Generowanie wektorów
# (a)
a1 <- c(55, 22, 1:200, 13)

# (b)
b1 <- rep(c(4, 6, 3), times = 10)

# (c)
c1 <- rep(3:9, each = 3)

# (d)
d1 <- seq(-5, 5, length.out = 100)

# (e)
set.seed(111)
e1 <- sample(1:99, 30)

# (f)
f1 <- sample(c(0, 1), 99, replace = TRUE, prob = c(0.3, 0.7))

# --------------------------------------------------------------------------
# --- Zadanie 2: Operacje na wektorach
set.seed(123)
x <- sample(0:9, 150, replace = TRUE)
y <- sample(0:9, 150, replace = TRUE)

# (a)
res2a <- exp(x) * cos(y)

# (b)
# y[2:150] to y2...yn, x[1:149] to x1...xn-1
res2b <- y[2:150] - x[1:149]

# (c)
res2c <- sin(y[1:149]) / cos(x[2:150])

# --------------------------------------------------------------------------
# --- Zadanie 3: Sumy szeregów
# (a)
i_seq <- 10:100
res3a <- sum(i_seq^3 + 4 * i_seq^2)

# (b)
i_vals <- rep(1:20, each = 5)
j_vals <- rep(1:5, times = 20)
res3b <- sum((2^i_vals / i_vals) + (3^j_vals / j_vals))

# --------------------------------------------------------------------------
# --- Zadanie 4: Przeszukiwanie i filtrowanie
set.seed(444)
x <- sample(0:99, 60)
y <- sample(0:99, 60)

# (a-c) 
vals_gt_60 <- y[y > 60]          # Wartości y > 60
idx_gt_60  <- which(y > 60)      # Indeksy y > 60
x_matching <- x[y > 60]          # Elementy x na pozycjach gdzie y > 60

# (d) 
m <- mean(x)
res4d <- sqrt(abs(x - m))

# (e) 
x_sorted_by_y <- x[order(y)]

# (f) co trzeci element
res4f <- y[seq(1, length(y), by = 3)]

# --------------------------------------------------------------------------
# --- Zadanie 5: Funkcje any() i all()
vec5 <- sample(10:100, 60)
has_gt_95 <- any(vec5 > 95)      
all_gt_85 <- all(vec5 > 85)      

# --------------------------------------------------------------------------
# --- Zadanie 6: Skomplikowany szereg
# Obliczanie sumy iloczynów: 1 + 2/3 + (2/3 * 4/5) + ...
nums <- seq(2, 38, by = 2)
dens <- seq(3, 39, by = 2)
res6 <- 1 + sum(cumprod(nums / dens))

# --------------------------------------------------------------------------
# --- Zadanie 7: Rozkłady prawdopodobieństwa i statystyki ---
xu35 <- runif(500, 3, 5)   # Rozkład jednostajny
xn01 <- rnorm(500)         # Rozkład normalny standardowy, N(0,1)

# Statystyki opisowe dla xn01
avg_n   <- mean(xn01)
sd_n    <- sd(xn01)
var_n   <- var(xn01)

# Wizualizacja
par(mfrow = c(1, 2)) #
hist(xu35, col = "lightblue", main = "Histogram: Jednostajny")
boxplot(xn01, col = "lightgreen", main = "Boxplot: Normalny")
par(mfrow = c(1, 1)) 

# --------------------------------------------------------------------------
# --- Zadanie 8: Napisy 
labels_a <- paste("label", 1:50)     # Ze spacją 
labels_b <- paste0("fn", 1:50)      # Bez spacji 

# --------------------------------------------------------------------------
# --- Zadanie 9: Operacje na napisach 
napis <- c("Katedra", "Informatyki", "Biznesowej", "i", 
           "Inżynierii", "Zarządzania", "WZ", "AGH", 2022)

len_napis <- length(napis)
type_napis <- class(napis)
chars_count <- nchar(napis)

# --------------------------------------------------------------------------
# --- Zadanie 10: Listy 
a <- c(2, 3, 5)
b <- c("aa", "bb", "cc", "dd", "ee")
c <- c(TRUE, FALSE, TRUE, FALSE, FALSE)

xlist <- list(a = a, b = b, c = c)

# (a-c)
elem_2_3 <- xlist[2:3]             
content_b <- xlist[[2]]          
minus_2 <- xlist[-2]              

# (d-g)
names(xlist) <- c("V1", "V2", "V3")
val_v1 <- xlist$V1
xlist$V4 <- 1:10

# --------------------------------------------------------------------------
# --- Zadanie 11: lapply i mapply 
l1 <- lapply(1:6, function(n) runif(n, 2, 8))
l2 <- lapply(1:6, function(n) runif(n, 2, 8))

l_sum <- mapply("+", l1, l2)