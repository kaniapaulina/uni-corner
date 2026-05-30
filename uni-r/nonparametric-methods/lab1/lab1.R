proba = rnorm(20, 0, 5)
t.test(proba)$p.value < 0.05

# tysiac razy wykonany test
sapply(1:1000, function(i) t.test(rnorm(20, 1, 5))$p.value < 0.05) |> mean()

# 0.139 - bardzo mala szansa wystapienia, slaby wynik to sie nie wydarzy
# w tylu procentach odrzucamy hip zerowa na rzecz hipotezyalternatywnej

moc_fun <- function(mu) {
  sapply(
    1:1000, 
    function(i) t.test(rnorm(20, mu, 5))$p.value < 0.05
    ) |> mean()
}

mu_seq = seq(-5, 5, by=0.5) #ciag liczb od -5 do 5 co pol wartosci

library(ggplot2)

# analiza mocy testu w zaleznosci od wielkosci efektu
data.frame(mu = mu_seq,
           moc = sapply(mu_seq, moc_fun)
) |> ggplot(aes(x=mu, y=moc)) + 
  geom_line() +
  geom_hline(yintercept = c(0, 0.05, 1), lty=2)
  


# =============================================
# Zadanie
# =============================================

library(tidyverse)
set.seed(123)



# 1. Analiza Mocy Testu

m_fun <- function(mu) {
  sapply(
    1:1000, 
    function(i) t.test(rnorm(20, mu, 5), mu=0)$p.value < 0.05
  ) |> mean()
}

mu_seq = seq(-5, 5, by=0.5) 

df_mu <- data.frame(mu = mu_seq,
                    moc = sapply(mu_seq, m_fun)
) 

df_mu |> ggplot(aes(x=mu, y=moc)) + 
  geom_line(size=1) +
  geom_hline(yintercept = c(0, 0.05, 1), lty=2, color = "red") + 
  
  theme_minimal() +
  labs(title = "Wpływ ddchylenie standardowego populacji na moc testu t-Studenta", 
       x = "Wielkość efektu (Średnia populacji przy hipotezie alternatywnej, H0: mu = 0)",
       y = "Moc testu (Prawdopodobieństwo odrzucenia H0)") +
  theme(
    legend.position = "bottom",
    plot.title = element_text(face = "bold", size = 14)
  )




# 2. Wpływ poziomu istotności (α)

a_fun <- function(a, mu) {
  sapply(
    1:1000, 
    function(i) t.test(rnorm(20, mu, 5), mu=0)$p.value < a
  ) |> mean()
}

a_seq <- c(0.01, 0.05, 0.1)
mu_seq = seq(-5, 5, by=0.5) 

df_a <- expand.grid(mu=mu_seq, a=a_seq)
df_a$a_test <- mapply(a_fun, df_a$a, df_a$mu)

ggplot(df_a, aes(x=mu, y=a_test, color=as.factor(a))) +
  geom_line() +
  geom_hline(yintercept = a_seq, lty=2) +
  labs(title = "Wpływ poziomu istotności (alpha) na moc", 
       x = "Odchylenie", 
       y = "Moc", 
       color = "Alpha")





# 3. Wpływ liczebności próby (n)

n_fun <- function(n, mu) {
  sapply(
    1:1000, 
    function(i) t.test(rnorm(n, mu, 5), mu=0)$p.value < 0.05
  ) |> mean()
}

n_seq = seq(10, 100, by=10)
mu_seq = seq(-5, 5, by=0.5) 

df_n <- expand.grid(mu=mu_seq, n=n_seq)
df_n$n_test <- mapply(n_fun, df_n$n, df_n$mu)

ggplot(df_n, aes(x=mu, y=n_test, color=as.factor(n))) +
  geom_line() +
  labs(title = "Wpływ poziomu istotności (liczebność) na moc", 
       x = "Odchylenie", 
       y = "Moc", 
       color = "Liczebność próby")





# 4. Niespełnienie założeń testu

r_fun <- function(mu, rozklad) {
  sapply(1:1000, function(i) {
    dane <- switch(as.character(rozklad),
                   "normalny"  = rnorm(20, mean = mu, sd = 1),
                   "chi-sq" = rchisq(20, df = 3) - 3 + mu,
                   "bimodalny" = c(rnorm(20/2, -1, 0.5), rnorm(20/2, 1, 0.5)) + mu
    )
    t.test(dane, mu = 0)$p.value < 0.05
  }) |> mean()
}

mu_seq <- seq(0, 2, by = 0.2)
df_r <- expand.grid(mu = mu_seq, type = c("normalny", "chi-sq", "bimodalny"))
df_r$r_test <- mapply(r_fun, df_r$mu, df_r$type)

ggplot(df_r, aes(x=mu, y=r_test, color=type)) + 
  geom_line(linewidth=1) +
  theme_minimal() +
  labs(
    title = "Moc testu a postać rozkładu populacji",
    x = "Średnia",
    y = "Moc testu",
    color = "Rodzaj rozkładu"
  )



# WIZUALIZACJA 

moc_fun <- function(n, mu, alpha) {
  sapply(
    1:1000,
    function(i) t.test(rnorm(n, mu, 5), mu=0)$p.value < alpha
  ) |> mean()
}

# Wielkość efektu
mu_seq <- seq(-5, 5, by=0.5)

# Liczebność próby
n_seq     <- c(10, 20, 40, 60, 80, 100)

# Poziom Istotności
alpha_seq <- c(0.01, 0.05, 0.10)

df_symulacja <- expand.grid(mu = mu_seq, n = n_seq, alpha = alpha_seq)
df_symulacja$moc <- mapply(moc_fun, df_symulacja$n, df_symulacja$mu, df_symulacja$alpha)

df_symulacja$a <- as.factor(df_symulacja$alpha)
df_symulacja$n <- factor(df_symulacja$n, levels = n_seq, labels = paste("n =", n_seq))

head(df_symulacja)

ggplot(df_symulacja, aes(x = mu, y = moc, color = a, group = a)) +
  geom_line(linewidth = 1) +
  geom_point(size = 1.2) +
  
  facet_wrap(~ n) + 
  geom_hline(yintercept = c(0.01, 0.05, 0.10), lty = 2, alpha = 0.5) +
  geom_hline(yintercept = 0.90, lty = 2, color = "red", alpha = 0.7) +
  
  theme_minimal() +
  labs(
    title = "Kompleksowa analiza mocy testu t-Studenta",
    subtitle = "Wpływ wielkości efektu (mu), liczebności próby (n) oraz poziomu istotności (alpha)",
    x = "Wielkość efektu (Średnia populacji przy hipotezie alternatywnej, H0: mu = 0)",
    y = "Moc testu (Prawdopodobieństwo odrzucenia H0)",
    color = "Poziom istotności (Alpha)"
  ) +
  theme(
    legend.position = "bottom",
    strip.text = element_text(face = "bold", size = 11),
    plot.title = element_text(face = "bold", size = 14)
  )
