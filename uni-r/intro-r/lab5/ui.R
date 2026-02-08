library(shiny)
library(shinyWidgets) 

nzwSpolek <- data.frame(nazwy = c("Elzab","Larq","NTT System","Comarch","Quantum","Sygnity"),
                        skroty = c("elz","lrq","ntt","cmr","qnt","sgn"))

tabpanel1 <- tabPanel('Notowania', uiOutput('page1'),
                sidebarLayout( 
                  sidebarPanel(
                    sliderInput("bins", 
                                "Number of bins:", 
                                min = 1, 
                                max = 50, 
                                value = 30),
                    selectizeInput(
                      'spolka', label = 'Spółka',
                      choices = nzwSpolek$nazwy,
                      multiple = FALSE, selected='Elzab',
                      options = list(create = TRUE)
                    )
                  ), 
                  mainPanel( 
                    h3(verbatimTextOutput("name1")), 
                    verbatimTextOutput('print1'),      
                    plotOutput("distPlot")             
                  ) 
          ) 
)

tabpanel2 <- tabPanel('Wyrównanie', uiOutput('page2'),
                  sidebarLayout(
                    sidebarPanel(
                      selectizeInput(
                        'spolka2', label = 'Spółka',
                        choices = nzwSpolek$nazwy,
                        multiple=FALSE, selected='Elzab',
                        options = list(create = TRUE)),
                      checkboxInput("plot", "Pokaż wykres oryginalny", value = TRUE),
                      checkboxInput("smooth", "Pokaż wykres wyrównany", value = FALSE)
                    ), # sidebarPanel
                    #Pokaż wykres szeregu czasowego
                    mainPanel(
                      h3(verbatimTextOutput("name2")),
                      plotOutput("zPlot")
                    ) # mainPanel ) # sidebarLayout
              ) #sidebarLayout
) # tapPanel

tabpanelA1 <- tabPanel("Analiza 1", uiOutput('page3'),
                 sidebarLayout(
                   sidebarPanel(
                     selectizeInput( # wybór nazwy spółki po raz trzeci
                       'spolka3', label = 'Spółka',
                       choices = nzwSpolek$nazwy,
                       multiple=FALSE, selected='Elzab',
                       options = list(create = TRUE)),
                     # tworzenie przycisków jednokrotnego wyboru
                     radioButtons("radio", label = h3("Wybór okresu wyrównania"),
                                  choices = list("miesięczny" = 23,
                                                 "kwartalny" = 69,
                                                 "półroczny" = 139),
                                  selected = 23)
                   ), # sidebarPanel
                   
                   mainPanel(
                     h3(verbatimTextOutput('name4')), # wypisanie nazwy
                     # podział na kolumny
                     column(3,img(src='rshiny.PNG', height = 50, width = 50)), # wstawienie rysunku
                     column(5,h2(verbatimTextOutput('analiza1'))), # wypisanie tekstu cat
                     column(4,h2(verbatimTextOutput('value'))), # liczba dni
                     plotOutput("z2Plot") # rysowanie wykresu
                   ) # mainPanel
                 ) # sidebarLayout
) # end tab panel analiza 1

tabpanelA2 <- tabPanel("Analiza 2",
                 sidebarLayout(
                   sidebarPanel(id = 'sidebar', # poniżej wybór zakresu dat
                        dateRangeInput('datapk', label = 'Wybierz datę początkową',
                                       start = as.Date("2017-01-01"), end=as.Date("2018-12-19"),
                                       min = NULL, max = NULL,
                                       format = "yyyy-mm-dd", startview = "year",
                                       weekstart = 0, # zaczynanie od niedzieli
                                       language = "en", width = NULL) # język angielski
                   ), # sidebarPanel
                   mainPanel(
                     h3(verbatimTextOutput('name5')), # wypisanie nazwy spółki
                     h4(textOutput('datap')), # wypisanie zakresu wybranych dat
                     code('summary(d3()$Zamkniecie)'), # wypisanie komendy R
                     # podział na kolumny
                     column(3,verbatimTextOutput('analiza2')),
                     column(9,plotOutput("z3Plot"))
                   ) #mainPanel
                 ) # sidebarLayout
) # end tab panel analiza 2

ui <- fluidPage( 
    includeCSS("www/app_ad.css"), 
    titlePanel("Dane giełdowe"), 
    setBackgroundColor(color = c("#ebf0fa", 'white', "#c1d0f0"), 
           gradient = "linear", 
           direction = "left"), 
    navbarPage("", collapsible = TRUE, id = "navbar", 
           tabpanel1,
           tabpanel2, 
           navbarMenu("Inne analizy", 
               tabpanelA1, 
               tabpanelA2) 
    ) #navbarPage
) #fluidPage
