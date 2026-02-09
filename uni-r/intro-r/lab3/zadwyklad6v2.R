# --------------------------------------------------------------------------
# Temat: Web scraping (tym razem działające)
# --------------------------------------------------------------------------

library(rvest)
library(dplyr)
library(ggplot2)
library(stringr)
library(tidyr)

# Pobieranie danych z pełnej tabeli gier na Nintendo Switch
url <- "https://en.wikipedia.org/wiki/List_of_best-selling_Nintendo_Switch_video_games"
page <- read_html(url)

tables <- page %>% html_table(fill = TRUE)
full_sales_table <- tables[[2]]
full_sales_table
 
colnames(full_sales_table) <- make.names(colnames(full_sales_table), unique = TRUE)

sales_data <- full_sales_table %>%
  select(Title, Copies.sold = Copies.sold) %>%
  mutate(Rank = row_number()) %>% 
  mutate(
    Copies_Millions = as.numeric(str_replace_all(Copies.sold, "[^0-9.]", "")),
  ) %>%
  filter(Rank <= 100) %>%
  arrange(Rank)

average_sales_by_group <- sales_data %>%
  mutate(
    Group_Label = cut(
      Rank,
      breaks = c(0, 10, 20, 30, 100),
      labels = c("1-10", "11-20", "21-30", "31-100"),
      right = TRUE,
      include.lowest = TRUE
    )
  ) %>%
  group_by(Group_Label) %>%
  summarise(
    Mean_Copies_Millions = mean(Copies_Millions, na.rm = TRUE),
    .groups = 'drop'
  )

average_sales_by_group

plot <- ggplot(average_sales_by_group, aes(x = Group_Label, y = Mean_Copies_Millions)) +
  geom_bar(stat = "identity", fill = "#e60012", alpha = 0.9, color = "black") +
  geom_text(
    aes(label = sprintf("%.2fM", Mean_Copies_Millions)),
    vjust = -0.5,
    size = 4,
    fontface = "bold"
  ) +
  labs(
    title = "Średnia sprzedaż gier Nintendo Switch",
    subtitle = "Gry pogrupowane według pozycji (1-10, 11-20, 21-30)",
    x = "Pozycje w rankingu sprzedaży",
    y = "Średnia sprzedaż (miliony sztuk)"
  ) +
  theme_minimal() +
  theme(
    plot.title = element_text(face = "bold", size = 16, hjust = 0.5),
    plot.subtitle = element_text(size = 10, hjust = 0.5),
    axis.text.x = element_text(angle = 0, size = 10, face = "bold"),
    axis.title = element_text(size = 12),
    panel.grid.major.x = element_blank()
  )

print(plot)