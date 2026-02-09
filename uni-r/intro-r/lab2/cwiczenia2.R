# --------------------------------------------------------------------------
# Temat: Ćwiczenia 2 - Generowanie danych, macierze i ramki danych
# --------------------------------------------------------------------------

# --- Zadanie 1: Generowanie wektorów 101-elementowych
set.seed(111)

# (a-b)
cs <- seq(0.5, 60, length.out = 101)
cp <- seq(356, 480, length.out = 101)

# (c)
odp <- sample(c("tak", "nie", "nie_wiem"), 101, replace = TRUE)

# (d-f)
wn  <- rnorm(101, mean = 65, sd = 15)
pun <- runif(101, 0, 200)
gr  <- sample(1:4, 101, replace = TRUE)

# --------------------------------------------------------------------------
# --- Zadanie 2: Operacje na macierzy A (20x10)
A <- matrix(sample(-20:20, 200, replace = TRUE), nrow = 20, ncol = 10)

# (a-b)
print(colSums(A))
print(rowMeans(A))

# (c) Sumy w wierszach parzystych
print(rowSums(A[seq(2, 20, by = 2), ]))

# (d-g)
print(apply(A, 2, max))                             
print(apply(A, 1, sd)) 
print(apply(A[seq(2, 20, by = 2), ], 1, var))
print(apply(A, 1, prod))     

# --------------------------------------------------------------------------
# --- Zadanie 3: Lista macierzy o zmiennych parametrach
# Generowanie parametrów dla 10 macierzy
dims  <- sample(2:10, 10, replace = TRUE)
means <- runif(10, 8, 12)
sds   <- runif(10, 1, 4)

# Utworzenie listy macierzy
x_list <- lapply(1:10, function(i) {
  matrix(rnorm(dims[i]^2, mean = means[i], sd = sds[i]), nrow = dims[i])
})

# (a-c)
print(lapply(x_list, dim))
print(det(x_list[[1]]))
print(det(x_list[[3]]))
print(sapply(x_list, det))

# --------------------------------------------------------------------------
# --- Zadanie 4: Utworzenie ramki danych
dane <- data.frame(cs = cs, cp = cp, odp = odp, wn = wn, pun = pun, gr = gr)
print(head(dane, 10))

# --------------------------------------------------------------------------
# --- Zadanie 5: Dodanie kolumny z datami
# Generowanie 101 dni od podanej daty
dane$daty <- seq(as.Date("2025-07-06"), by = "day", length.out = 101)
print(head(dane, 10))

# --------------------------------------------------------------------------
# --- Zadanie 6: Dodanie nowego wiersza (rbind)
nowy_wiersz <- data.frame(cs = 0.52, cp = 358.5, odp = "nie", wn = 75, 
                          pun = 199.2, gr = 4, daty = as.Date("2025-10-16"))
dane <- rbind(dane, nowy_wiersz)
print(tail(dane, 5))

# --------------------------------------------------------------------------
# --- Zadanie 7: Filtrowanie danych (warunki logiczne)
# Wybór wierszy: nie_wiem oraz wynik > 60
print(dane[which(dane$odp == "nie_wiem" & dane$wn > 60), ])

# --------------------------------------------------------------------------
# --- Zadanie 8: Agregacja - średni czas spóźnienia na grupę
print(aggregate(cs ~ gr, data = dane, mean))

# --------------------------------------------------------------------------
# --- Zadanie 9: Agregacja - średni wynik dla każdej odpowiedzi
print(aggregate(wn ~ odp, data = dane, meaan))

# --------------------------------------------------------------------------
# --- Zadanie 10: Tabela przestawna (reshape2)
library(reshape2)
# Średnie punkty dla grup w podziale na odpowiedzi
print(dcast(dane, gr ~ odp, value.var = "pun", fun.aggregate = mean))