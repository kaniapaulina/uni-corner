# --------------------------------------------------------------------------
# Temat: Ćwiczenia 6 - Pisanie własnych funkcji w języku R
# --------------------------------------------------------------------------

# --- Zadanie 1: Funkcja minmaxK(x, K)
minmaxK <- function(x, K = 5) {
  stopifnot(is.numeric(x))
  if (length(x) < K) return("Błąd: wektor jest krótszy niż K")
  
  # Zwraca K najmniejszych i K największych elementów
  return(list(
    Min = sort(x)[1:K],
    Max = sort(x, decreasing = TRUE)[1:K]
  ))
}

set.seed(123)
wektor_testowy <- sample(1:4000, 100, replace = TRUE)
print(minmaxK(wektor_testowy, 5))

# --------------------------------------------------------------------------
# --- Zadanie 2: Funkcja lDsknl(x) - Liczby doskonałe
lDsknl <- function(x) {
  dzielniki <- which(x %% seq_len(x/2) == 0)
  return(sum(dzielniki) == x)
}

system.time({
  doskonale <- which(sapply(1:10000, lDsknl))
})
print(doskonale)

# --------------------------------------------------------------------------
# --- Zadanie 3: Funkcja myNorm(x) - Unitaryzacja (normalizacja [0,1])
myNorm <- function(x, na.rm = FALSE) {
  if (length(na.omit(x)) == 0) return(x)
  min_x <- min(x, na.rm = na.rm)
  max_x <- max(x, na.rm = na.rm)
  
  if (max_x == min_x) return(rep(0, length(x)))
  return((x - min_x) / (max_x - min_x))
}

# --------------------------------------------------------------------------
# --- Zadanie 4: Funkcja myCorr(x, y) - Korelacje
myCorr <- function(x, y) {
  if (length(x) != length(y)) stop("Błąd: Wektory muszą mieć tę samą długość")
  
  return(c(
    Pearson  = cor(x, y, method = "pearson"),
    Kendall  = cor(x, y, method = "kendall"),
    Spearman = cor(x, y, method = "spearman")
  ))
}

# --------------------------------------------------------------------------
# --- Zadanie 5: Funkcja myStats(x, p) - Statystyki opisowe
myStats <- function(x, p = 0) {
  stopifnot(is.numeric(x), p %in% c(0, 1))
  
  if (p == 0) {
    return(c(Mean = mean(x), SD = sd(x)))
  } else {
    return(c(Median = median(x), MAD = mad(x)))
  }
}

# --------------------------------------------------------------------------
# --- Zadanie 6: Funkcja myFun(x) i miejsca zerowe
myFun <- function(x) 10*sin(1.5*x)*cos(0.5*x^3) + (0.5)*sqrt(abs(x))

# (a) Miejsca zerowe w zadanych przedziałach
print(uniroot(myFun, c(6, 7))$root)
print(uniroot(myFun, c(1, 2))$root)

# (b-c) Wizualizacja i wszystkie miejsca zerowe
library(rootSolve)
curve(myFun, -3, 3, main = "Wykres myFun i miejsca zerowe", cex.main = 0.8)
abline(h = 0, lty = 2)
miejsca <- uniroot.all(myFun, c(-3, 3))
points(miejsca, rep(0, length(miejsca)), col = "red", pch = 19)

# --------------------------------------------------------------------------
# --- Zadanie 7: myLin(x) - Układ równań liniowych
library(rootSolve)
myLin <- function(x) {
  f1 <- 2*x[1] + x[2] - 2*x[3] + 2
  f2 <- x[1] + 2*x[2] - 2*x[3] - 1
  f3 <- 2*x[1] + x[2] - x[3] + 3
  return(c(f1, f2, f3))
}
print(multiroot(f = myLin, start = c(1, 1, 1))$root)

# --------------------------------------------------------------------------
# --- Zadanie 8: myNonLin(x) - Układ równań nieliniowych
myNonLin <- function(x) {
  f1 <- 2*x[1] + x[2]^2 - 2*x[3] - 2
  f2 <- x[1]^2 + 2*x[2] - 2*x[3] - 3
  f3 <- 2*x[1] + x[2] - x[3] - 3
  return(c(f1, f2, f3))
}
print(multiroot(f = myNonLin, start = c(1, 1, 1))$root)

# --------------------------------------------------------------------------
# --- Zadanie 9: myDane(url) - Pobieranie i obróbka danych z Wikipedia
library(rvest)
url <- "https://pl.wikipedia.org/wiki/Lista_najwi%C4%99kszych_przedsi%C4%99biorstw"

myDane <- function(target_url) {
  html_table(read_html(target_url))[[1]]
}

df_wiki <- myDane(url)

# Czyszczenie i konwersja kolumny Przychód (k4)
czyste_k4 <- as.numeric(gsub("[^0-9.]", "", df_wiki[[4]]))

k4_norm <- myNorm(na.omit(czyste_k4))
print(head(k4_norm))