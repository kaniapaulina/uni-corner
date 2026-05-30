library(tidyverse)

set.seed(2026)

# 1. Generowanie danych

n <- 80
alpha <- 0.05
B <- 3000
k <- 8

dane <- tibble(
  id = 1:n,
  normalny = rnorm(n, 0, 1),
  t3_stand = rt(n, 3)/ sqrt(3 / (3-2))
) |> pivot_longer(
  cols = c(normalny, t3_stand),
  names_to = "proba",
  values_to = "x"
)

# 2. histogram + gestosc

ggplot(dane, aes(x=x)) +
  geom_histogram(aes(y = after_stat(density)), bins = 16) +
  geom_density() +
  facet_wrap(~proba, scales="free")


# 3. qq
# funkcja ktora z danej proby tworzy tabelke ktora zawiera wartosci uzywane do wykresow kwantylowych

make_qq_tbl<- function(x, proba) {
  m <- length(x)
  tibble(
    proba = proba,
    i = 1:n,
    p = (i-0.5)/n,
    q_teor = qnorm(p),
    q_emp = sort(x)
  )
}


qq_tbl <- bind_rows(
  make_qq_tbl(
    dane |> filter(proba == "normalny") |> pull(x),
    "normalny"
  ),
  make_qq_tbl(
    dane |> filter(proba == "t3_stand") |> pull(x),
    "t3_stand"
  )
)

ggplot(qq_tbl, aes(x = q_teor, y = q_emp))+
  geom_point() +
  geom_abline(intercept = 0, slope = 1, linetype = 2) +
  facet_wrap(~proba, scales = "free")














n <- 100
dane <- rnorm(n, 0, 1)

ecdf_func <- function(data) {
  n <- length(data)
  sorted <- sort(data)
  for(i in 1:n) {
    ecdf[i] <- sum(sorted <= data[i]) / n
  }
  return(ecdf)
}

ecdf <- ecdf_func(dane)
print(head(ecdf))
print(ecdf(dane))

identical(ecdf, ecdf(dane))