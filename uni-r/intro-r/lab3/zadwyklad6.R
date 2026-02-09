# --------------------------------------------------------------------------
# Temat: Web scraping 
# --------------------------------------------------------------------------

library(rvest)
library(dplyr)
library(ggplot2)
library(stringr)

# --- Pobieranie i czyszczenie danych
url <- "https://en.wikipedia.org/wiki/Aespa_discography"
page <- read_html(url)
korean_singles <- html_table(page, fill = TRUE)[[5]]

# Uproszczenie nazw kolumn
colnames(korean_singles) <- c("Title", "Year", "KOR", "KOR_Billb", "JPN", "JPN_Hot", 
                              "NZ", "SGP", "US_World", "WW", "Sales", "Certifications", "Album")

# Oczyszczanie wartości KOR z przypisów i konwersja na numeric
korean_singles_clean <- korean_singles %>%
  filter(!Title %in% c("Title", "")) %>%
  mutate(KOR = as.numeric(str_replace_all(KOR, "\\[.*\\d+\\]|[^0-9]", ""))) %>%
  filter(!is.na(KOR))

# --- Wizualizacja
plot_aespa <- ggplot(korean_singles_clean, aes(x = reorder(Title, KOR), y = KOR)) +
  geom_bar(stat = "identity", fill = "steelblue", alpha = 0.8) +
  geom_text(aes(label = KOR), vjust = -0.5, size = 4, fontface = "bold") +
  # Odwrócenie osi Y (miejsce 1 na samej górze)
  scale_y_reverse(breaks = seq(1, max(korean_singles_clean$KOR), by = 10)) +
  labs(
    title = "Najwyższe pozycje singli aespa w Circle Chart (KOR)",
    x = "Tytuł piosenki",
    y = "Pozycja w rankingu"
  ) +
  theme_minimal() +
  theme(
    plot.title = element_text(face = "bold", size = 16, hjust = 0.5),
    axis.text.x = element_text(angle = 45, hjust = 1, size = 10),
    panel.grid.minor = element_blank()
  )

print(plot_aespa)
