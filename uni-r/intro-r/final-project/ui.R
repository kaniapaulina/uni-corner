library(shiny)
library(ggplot2)
library(dplyr)
library(tidyr)
library(DT)

ui <- fluidPage(
  titlePanel("Analiza Sprzedaży Konsol do Gier"),
  sidebarLayout(
    sidebarPanel(
      selectInput("analysis_type", "Typ analizy:",
                  choices = c(
                    "Ranking globalny" = "global_ranking",
                    "Analiza geograficzna" = "geographic", 
                    "Analiza producentów" = "producers",
                    "Rekordy regionalne" = "regional_success",
                    "Zrównoważenie sprzedaży" = "balance",
                    "Top konsole według regionów" = "top_by_region",
                    "Korelacje" = "correlation"
                  ),
                  selected = "global_ranking"),
      
      conditionalPanel(
        condition = "input.analysis_type == 'global_ranking'",
        sliderInput("top_n", "Liczba konsol do wyświetlenia:",
                    min = 5, max = 17, value = 10)
      ),
      
      conditionalPanel(
        condition = "input.analysis_type == 'geographic'",
        selectInput("region", "Region:",
                    choices = c("Ameryka_Polnocna", "Europa", "Japonia", "Reszta_Swiata"),
                    selected = "Europa")
      ),
      
      conditionalPanel(
        condition = "input.analysis_type == 'balance'",
        sliderInput("balance_top", "Liczba konsol do wyświetlenia:",
                    min = 5, max = 10, value = 10)
      ),
      
      conditionalPanel(
        condition = "input.analysis_type == 'top_by_region'",
        sliderInput("top_regions", "Liczba konsol do wyświetlenia:",
                    min = 3, max = 10, value = 5)
      ),
      
      br(),
      h4("Informacje o danych:"),
      p("> dane przedstawiają sprzedaż konsol do gier w milionach jednostek w różnych regionach świata do października 2025 roku."),
      tags$a(href="https://www.vgchartz.com/charts/platform_totals/Hardware.php
", "> źródło danych")
    ),
    
    mainPanel(
      tabsetPanel(
        tabPanel("Wykres", plotOutput("plot", height = "600px")),
        tabPanel("Tabela", DTOutput("table")),
        tabPanel("Statystyki", 
                 h4("Statystyki globalne"),
                 tableOutput("global_stats"),
                 h4("Statystyki producentów"),
                 tableOutput("producer_stats"))
      )
    )
  )
)

