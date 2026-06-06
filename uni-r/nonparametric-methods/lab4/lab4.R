library(tidyverse)

dane <- read.csv("prognozy_popytu.csv")
glimpse(dane)

count(dane, kategoria)
count(dane, typ_sklepu)

# Błędy prognozy

dane <- dane |>
  mutate(
    ae_bazowy = abs(prognoza_bazowa - sprzedaz_rzeczywista),
    ae_alt = abs(prognoza_alternatywna - sprzedaz_rzeczywista),
    diff = ae_bazowy - ae_alt
  )

dane |> 
  summarize(
    n = n(),
    mean_baz = mean(ae_bazowy),
    mean_alt = mean(ae_alt),
    mean_diff = mean(diff),
    median_baz = median(ae_bazowy),
    median_alt = median(ae_alt),
    median_diff = median(diff)
  )

ggplot(dane, aes(x=diff)) +
  geom_histogram(bins=40) +
  theme_minimal()

ggplot(dane, aes(x=ae_bazowy, y=ae_alt)) + 
  geom_point()
       
ggplot(dane, aes(x = kategoria, y = diff)) +
  geom_boxplot()

t.test(dane$diff, mu=0)
