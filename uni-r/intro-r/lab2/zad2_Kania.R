# --------------------------------------------------------------------------
# Temat: Zadania domowe 2 - Macierze, ramki danych i operacje na listach
# --------------------------------------------------------------------------

# --- Zadanie 1: Macierz nxn z liczbami 1:n na przekątnych
set.seed(11)
n <- sample(seq(5, 29, by = 2), 1)
B <- matrix(0, nrow = n, ncol = n)
diag(B) <- 1:n
B[cbind(1:n, n:1)] <- 1:n
print(B)

# --------------------------------------------------------------------------
# --- Zadanie 2: Mnożenie macierzy C i D (ziarno 41)
set.seed(41)
C <- matrix(runif(50, 2, 5), nrow = 5, ncol = 10)
D <- matrix(runif(50, 2, 5), nrow = 5, ncol = 10)

# (a) Iloczyn C^T * D
print(t(C) %*% D)

# (b) Iloczyn C * D^T przy użyciu crossprod
print(crossprod(t(C), t(D)))

# --------------------------------------------------------------------------
# --- Zadanie 3: Wektor z brakującymi danymi (NA)
x_vec <- as.vector(c(C, D))
set.seed(40)
x_vec[sample(length(x_vec), 20)] <- NA

# (a-b)
print(mean(x_vec, na.rm = TRUE))
print(sd(x_vec, na.rm = TRUE))

# --------------------------------------------------------------------------
# --- Zadanie 4: Specyficzne struktury macierzy (outer)
# (a)
m4a <- outer(0:9, 0:9, function(a, b) (a + b) %% 10)
print(m4a)

# (b)
m4b <- outer(0:8, 0:8, function(a, b) (10 - (a + b)) %% 11)
print(m4b)

# --------------------------------------------------------------------------
# --- Zadanie 5: Dwa największe elementy w wierszach
set.seed(31)
G <- matrix(sample(-20:20, 200, replace = TRUE), 20, 10)
print(G)

print(t(apply(G, 1, function(x) sort(x, decreasing = TRUE)[1:2])))

# --------------------------------------------------------------------------
# --- Zadanie 6: Pary kolumn o sumie > 75
set.seed(31)
E <- matrix(sample(1:10, 60, replace = TRUE), nrow = 6, ncol = 10)
s_cols <- colSums(E)
razem <- outer(s_cols, s_cols, "+")

# (a)
pary <- which(razem > 75, arr.ind = TRUE)
print(pary)

# (b)
print(pary[pary[, 1] < pary[, 2], ])

# --------------------------------------------------------------------------
# --- Zadanie 7: Tworzenie ramki danych dane.stud (ziarno 27)
set.seed(27)
x_wiek <- sample(20:27, 200, replace = TRUE)
y_wykszt <- character(200)


idx_mlodzi <- x_wiek <= 22
y_wykszt[idx_mlodzi] <- sample(c("lic", "inż."), sum(idx_mlodzi), replace = TRUE, prob = c(0.4, 0.6))
y_wykszt[!idx_mlodzi] <- sample(c("mgr", "mgr inż."), sum(!idx_mlodzi), replace = TRUE, prob = c(0.3, 0.7))

z_miasta <- sample(c("Kraków", "Warszawa", "Katowice", "Rzeszów", "Częstochowa"), 200, replace = TRUE)

dane.stud <- data.frame(wiek = x_wiek, wykształcenie = y_wykszt, adres = z_miasta)
print(dane.stud)

# --------------------------------------------------------------------------
# --- Zadanie 8: Analiza ramki danych
print(nrow(dane.stud[complete.cases(dane.stud), ])) 
print(sum(!duplicated(dane.stud)))
print(table(dane.stud$wiek))

# --------------------------------------------------------------------------
# --- Zadanie 9: Filtrowanie subset()
# (a)
print(subset(dane.stud, wiek > 20 & adres %in% c("Kraków", "Warszawa"), select = c("wiek", "adres")))

# (b)
print(subset(dane.stud, wiek > 20 & adres %in% c("Kraków", "Warszawa")))

# --------------------------------------------------------------------------
# --- Zadanie 11 & 12: Listy i sumowanie składowych
set.seed(23)
lista1 <- lapply(1:6, function(n) runif(n, 2, 8))
lista2 <- lapply(1:6, function(n) runif(n, 2, 8))
lista_suma <- mapply("+", lista1, lista2)

print(lista1)     
print(lista2)     
print(lista_suma) 