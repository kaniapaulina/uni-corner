# --------------------------------------------------------------------------
# Temat: Zadanie 1 - wektory i operacje na danych
# --------------------------------------------------------------------------

# --- Zadanie 1: Utwórz wektory
# (a)
print(c(1:20, 19:1))

# (b)
print(rep(c(4, 6, 3), length.out = 50))

# (c)
print(rep(c(4, 6, 3), times = c(10, 20, 30)))

# (d)
print(seq(100, 4, by = -8))

# (e) 
print(0.1^(seq(3, 36, by = 3)) * 0.2^(seq(1, 34, by = 3)))

# --------------------------------------------------------------------------
# --- Zadanie 2: Utwórz wektor napisów
# Napisy typu "A_1.B", "X_2.D", "A_3.F" itd. do 30 
print(paste0(rep(c("A", "X"), 15), "_", 1:30, ".", rep(c("B", "D", "F"), 10)))

# --------------------------------------------------------------------------
# --- Zadanie 3: Losowanie z ziarnem 50
set.seed(50)

# (a) 100 liczb z zakresu 5-15 ze zwracaniem 
print(sample(5:15, 100, replace = TRUE))

# (b) 100 małych i dużych liter alfabetu
print(sample(c(letters, LETTERS), 100, replace = TRUE))

# --------------------------------------------------------------------------
# --- Zadanie 4: Operacje na wektorach x, y (ziarno 30)
set.seed(30) 
x <- sample(0:999, 250)
y <- sample(0:999, 250)

# (a) 
print(x[1:248] + 2 * x[2:249] - y[3:250])

# (b)
print(sum(exp(-x[2:250]) / (x[1:249] + 10)))

# (c)
i_v <- rep(1:20, each = 5)
j_v <- rep(1:5, times = 20)
print(sum(i_v^4 / (3 + j_v)))

# --------------------------------------------------------------------------
# --- Zadanie 5: Statystyki wektora x (ziarno 50)
set.seed(50)
x_500 <- sample(0:999, 500)

# (a)
print(sum(x_500 %% 2 == 0))

# (b)
print(sum(x_500 %% 6 == 0))

# (c)
print(sum(x_500 < 30 | x_500 > 70))

# --------------------------------------------------------------------------
# --- Zadanie 6: Operacje na tekście
napis <- c("Katedra", "Informatyki", "Biznesowej", "i", "Inżynierii", 
           "Zarządzania", "WZ", "AGH", 2022) 
znaki <- unlist(strsplit(as.character(napis), split = ""))

# (a)
print(length(unique(znaki)))

# (b) 
print(names(which.max(table(znaki))))