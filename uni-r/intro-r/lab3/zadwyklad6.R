library(rvest)
library(dplyr)
library(ggplot2)
library(stringr)

url <- "https://en.wikipedia.org/wiki/Aespa_discography"
page <- read_html(url)

tables <- page %>% html_table(fill = TRUE)
korean_singles <- tables[[5]]

colnames(korean_singles) <- make.names(colnames(korean_singles), unique = TRUE)

print("Surowe dane:")
print(korean_singles)
print("\nNazwy kolumn:")
print(colnames(korean_singles))

title_col <- "Title"
kor_col <- "Peak.chart.positions"  

plot <- ggplot(singles_data%>%tail(10), aes(x = reorder(Title, KOR_Position), y = -KOR_Position)) +
  geom_bar(stat = "identity", fill = "steelblue", alpha = 0.8) +
  geom_text(aes(label = KOR_Position), vjust = -0.5, size = 4, fontface = "bold") +
  labs(
    title = "Pozycje singli aespa w KOR Chart",
    x = "Tytuł piosenki",
    y = "Pozycja w rankingu"
  ) +
  theme_minimal() +
  theme(
    plot.title = element_text(face = "bold", size = 16, hjust = 0.5),
    axis.text.x = element_text(angle = 45, hjust = 1, size = 10),
    axis.title = element_text(size = 12),
    panel.grid.major.x = element_blank()
  )

print(plot)
