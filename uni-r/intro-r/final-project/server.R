library(shiny)
library(ggplot2)
library(dplyr)
library(tidyr)
library(DT)
library(corrplot)

console_data <- read.csv("konsole.csv")

colnames(console_data) <- c("Pozycja", "Konsola", "Ameryka_Polnocna", "Europa", 
                            "Japonia", "Reszta_Swiata", "Sprzedaz_Globalna")

console_data$Producent <- case_when(
  grepl("PlayStation|PS[0-9]|PSP|PSV", console_data$Konsola) ~ "Sony",
  grepl("Nintendo|GameBoy|NES|SNES|N64|Wii|Switch", console_data$Konsola) ~ "Nintendo", 
  grepl("Xbox|X360|XOne", console_data$Konsola) ~ "Microsoft",
  grepl("Sega|Genesis|Master System|Saturn|Dreamcast", console_data$Konsola) ~ "Sega",
  TRUE ~ "Inni"
)

# wskaźnik zrównoważenia sprzedaży HELP HELP
console_data$Zrównowazenie <- apply(console_data[, 3:6], 1, function(x) {
  if(mean(x) == 0) return(0)
  sd(x)/mean(x)
})

server <- function(input, output, session) {
  
  #pspsp data pspps
  data_reactive <- reactive({
    console_data
  })
  
  #jebitny wykres
  output$plot <- renderPlot({
    data <- data_reactive()
    req(data)
    
    analysis_type <- input$analysis_type
    
    if(analysis_type == "global_ranking") {
      top_data <- head(data[order(-data$Sprzedaz_Globalna), ], input$top_n)
      
      p <- ggplot(top_data, aes(x = reorder(Konsola, Sprzedaz_Globalna), 
                                y = Sprzedaz_Globalna, 
                                fill = Producent)) +
        geom_col() +
        coord_flip() +
        labs(title = paste("Top", input$top_n, "najlepiej sprzedających się konsol"),
             x = "Konsola", y = "Sprzedaż globalna (mln)") +
        scale_fill_brewer(palette = "RdPu") +
        theme_minimal() +
        theme(legend.position = "bottom")
      
    } else if(analysis_type == "geographic") {
      region_data <- data[order(-data[[input$region]]), ]
      top_region <- head(region_data, 15)
      
      p <- ggplot(top_region, aes(x = reorder(Konsola, .data[[input$region]]), 
                                  y = .data[[input$region]], 
                                  fill = Producent)) +
        geom_col() +
        coord_flip() +
        labs(title = paste("Top konsole w regionie:", input$region),
             x = "Konsola", y = paste("Sprzedaż (mln)")) +
        scale_fill_brewer(palette = "YlGn") +
        theme_minimal() +
        theme(legend.position = "bottom")
      
    } else if(analysis_type == "producers") {
      producer_summary <- data %>%
        group_by(Producent) %>%
        summarise(
          Sprzedaz_Total = sum(Sprzedaz_Globalna),
          Liczba_Konsol = n(),
          Srednia_Sprzedaz = mean(Sprzedaz_Globalna)
        )
      
      p <- ggplot(producer_summary, aes(x = reorder(Producent, -Sprzedaz_Total), 
                                        y = Sprzedaz_Total, 
                                        fill = Producent)) +
        geom_col() +
        labs(title = "Sprzedaż całkowita według producentów",
             x = "Producent", y = "Sprzedaż globalna (mln)") +
        scale_fill_brewer(palette = "BuPu") +
        theme_minimal() +
        theme(legend.position = "none")
      
    } else if(analysis_type == "regional_success") {
      top_region_data <- data.frame(
        Region = c("Ameryka_Polnocna", "Europa", "Japonia", "Reszta_Swiata"),
        Konsola = c(data$Konsola[which.max(data$Ameryka_Polnocna)],
                    data$Konsola[which.max(data$Europa)],
                    data$Konsola[which.max(data$Japonia)],
                    data$Konsola[which.max(data$Reszta_Swiata)]),
        Sprzedaz = c(max(data$Ameryka_Polnocna), max(data$Europa), 
                     max(data$Japonia), max(data$Reszta_Swiata))
      )
      
      p <- ggplot(top_region_data, aes(x = Region, y = Sprzedaz, fill = Region)) +
        geom_col() +
        geom_text(aes(label = Konsola), vjust = -0.5, size = 3) +
        labs(title = "Rekordy sprzedaży w poszczególnych regionach",
             x = "Region", y = "Sprzedaż (mln)") +
        scale_fill_brewer(palette = "PiYG") +
        theme_minimal() +
        theme(legend.position = "none")
      
    } else if(analysis_type == "balance") {
      balanced_data <- head(data[order(data$Zrównowazenie), ], input$balance_top)
      
      p <- ggplot(balanced_data, aes(x = reorder(Konsola, -Zrównowazenie), 
                                     y = Zrównowazenie, 
                                     fill = Producent)) +
        geom_col() +
        coord_flip() +
        labs(title = "Konsole o najbardziej zrównoważonej sprzedaży międzynarodowej",
             subtitle = "Mniejsza wartość = bardziej zrównoważona sprzedaż między regionami",
             x = "Konsola", y = "Wskaźnik zrównoważenia (sd/mean)") +
        scale_fill_brewer(palette = "PRGn") +
        theme_minimal() +
        theme(legend.position = "bottom")
      
    } else if(analysis_type == "top_by_region") {
      top_consoles <- head(data[order(-data$Sprzedaz_Globalna), ], input$top_regions)
      region_data <- top_consoles %>%
        select(Konsola, Ameryka_Polnocna, Europa, Japonia, Reszta_Swiata) %>%
        pivot_longer(cols = -Konsola, names_to = "Region", values_to = "Sprzedaz")
      
      p <- ggplot(region_data, aes(x = Konsola, y = Sprzedaz, fill = Region)) +
        geom_col(position = "dodge") +
        labs(title = paste("Porównanie sprzedaży top", input$top_regions, "konsol według regionów"),
             x = "Konsola", y = "Sprzedaż (mln)") +
        scale_fill_brewer(palette = "YlOrRd") +
        theme_minimal() +
        theme(axis.text.x = element_text(angle = 45, hjust = 1),
              legend.position = "bottom")
    } else if(analysis_type == "correlation") {
      required_cols <- c("Ameryka_Polnocna", "Europa", "Japonia", "Reszta_Swiata")
      if (all(required_cols %in% colnames(data))) {
        correlation_matrix <- cor(data[, required_cols])
        
        p <- ggplot(data = as.data.frame(as.table(correlation_matrix)), 
                    aes(x = Var1, y = Var2, fill = Freq)) +
          geom_tile() +
          geom_text(aes(label = round(Freq, 2)), color = "white", size = 5) +
          scale_fill_gradient2(low = "pink", high = "darkgreen", mid = "white", 
                               midpoint = 0, limit = c(-1,1), space = "Lab", 
                               name = "Korelacja") +
          labs(title = "Macierz korelacji między regionami sprzedaży",
               x = "", y = "") +
          theme_minimal() +
          theme(axis.text.x = element_text(angle = 45, hjust = 1))
      } else {
        p <- ggplot() + 
          annotate("text", x = 1, y = 1, label = "Brak wymaganych kolumn do analizy korelacji") +
          theme_void()
      }
    } else {
      #to sie pierwsze ma niby wyswieltac a czy tak jest to inna sprawa
      top_data <- head(data[order(-data$Sprzedaz_Globalna), ], 10)
      p <- ggplot(top_data, aes(x = reorder(Konsola, Sprzedaz_Globalna), 
                                y = Sprzedaz_Globalna, 
                                fill = Producent)) +
        geom_col() +
        coord_flip() +
        labs(title = "Top 10 najlepiej sprzedających się konsol",
             x = "Konsola", y = "Sprzedaż globalna (mln)") +
        theme_minimal() +
        theme(legend.position = "bottom")
    }
    
    p
  })
  
    #Tabele (do we even need them)
  output$table <- renderDT({
    data <- data_reactive()
    req(data)
    
    analysis_type <- input$analysis_type
    
    if(analysis_type == "global_ranking") {
      display_data <- head(data[order(-data$Sprzedaz_Globalna), ], input$top_n)
    } else if(analysis_type == "geographic") {
      display_data <- head(data[order(-data[[input$region]]), ], 15)
    } else if(analysis_type == "producers") {
      display_data <- data %>%
        group_by(Producent) %>%
        summarise(
          Sprzedaz_Total = round(sum(Sprzedaz_Globalna), 2),
          Liczba_Konsol = n(),
          Srednia_Sprzedaz = round(mean(Sprzedaz_Globalna), 2)
        )
    } else if(analysis_type == "regional_success") {
      display_data <- data.frame(
        Region = c("Ameryka Północna", "Europa", "Japonia", "Reszta Świata"),
        Konsola = c(data$Konsola[which.max(data$Ameryka_Polnocna)],
                    data$Konsola[which.max(data$Europa)],
                    data$Konsola[which.max(data$Japonia)],
                    data$Konsola[which.max(data$Reszta_Swiata)]),
        Sprzedaz = c(
          round(max(data$Ameryka_Polnocna), 2),
          round(max(data$Europa), 2),
          round(max(data$Japonia), 2),
          round(max(data$Reszta_Swiata), 2)
        )
      )
    } else if(analysis_type == "balance") {
      display_data <- head(data[order(data$Zrównowazenie), 
                                c("Konsola", "Zrównowazenie", "Producent", "Sprzedaz_Globalna")], 
                           input$balance_top)
      display_data$Zrównowazenie <- round(display_data$Zrównowazenie, 4)
      display_data$Sprzedaz_Globalna <- round(display_data$Sprzedaz_Globalna, 2)
    } else if(analysis_type == "top_by_region") {
      display_data <- head(data[order(-data$Sprzedaz_Globalna), ], input$top_regions)
    } else if(analysis_type == "correlation") {
      required_cols <- c("Ameryka_Polnocna", "Europa", "Japonia", "Reszta_Swiata")
      if (all(required_cols %in% colnames(data))) {
        correlation_matrix <- cor(data[, required_cols])
        display_data <- as.data.frame(round(correlation_matrix, 3))
        display_data$Region <- rownames(display_data)
        display_data <- display_data[, c(5, 1:4)]
      } else {
        display_data <- data.frame(Info = "Brak wymaganych kolumn do analizy korelacji")
      }
    } else {
      display_data <- data
    }
    
    datatable(display_data, 
              options = list(
                pageLength = 10,
                scrollX = TRUE,
                dom = 'Bfrtip'
              ),
              rownames = FALSE)
  })
  
  #Statystyki globalne (whatever the hell sure)
  output$global_stats <- renderTable({
    data <- data_reactive()
    req(data)
    
    global_stats <- data.frame(
      Metryka = c("Łączna sprzedaż", "Średnia sprzedaż", "Mediana sprzedaży", "Maksymalna sprzedaż"),
      Wartość = c(
        round(sum(data$Sprzedaz_Globalna), 2),
        round(mean(data$Sprzedaz_Globalna), 2),
        round(median(data$Sprzedaz_Globalna), 2),
        round(max(data$Sprzedaz_Globalna), 2)
      ),
      Jednostka = rep("mln", 4)
    )
    
    global_stats
  }, bordered = TRUE, striped = TRUE)
  
  # Statystyki producentów also whatever the hell
  output$producer_stats <- renderTable({
    data <- data_reactive()
    req(data)
    
    producer_stats <- data %>%
      group_by(Producent) %>%
      summarise(
        Sprzedaz = round(sum(Sprzedaz_Globalna), 1),
        Udział = round(sum(Sprzedaz_Globalna) / sum(data$Sprzedaz_Globalna) * 100, 1)
      ) %>%
      arrange(desc(Sprzedaz))
    
    producer_stats
  }, bordered = TRUE, striped = TRUE)
}

