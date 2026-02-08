nzwSpolek<-data.frame(nazwy=c("Elzab","Larq","NTT System","Comarch","Quantum","Sygnity"),
                      skroty=c("elz","lrq","ntt","cmr","qnt","sgn"))

getName <- function(nazwa) {
  return(nzwSpolek$skroty[nzwSpolek$nazwy==nazwa])
}

zakres <- "0101201719122018"
p<-getwd() 
getData<-function(name) {
  return(read.csv(paste0(p,"/", name ,"_d", zakres,".csv"),sep=",",dec="."))
}
spolki_names <- nzwSpolek$nazwy

shinyServer(function(input, output) {
  splk <- reactive({getName(input$spolka)}) # wczytanie nazw
  output$name1 = renderText({ input$spolka }) # wypisanie nazwy / ścieżki dostępu
  d <- reactive({ getData( splk() ) }) # wczytanie spółek - lokalnie z dysku
  # wyniki
  output$print1 <- renderPrint({
    summary(d()$Zamkniecie) #obliczenie podstawowych statystyk kursu zamknięcia
  })
  output$distPlot <- renderPlot({
    
    # generowanie liczby słupków histogramu według input$bins z ui.R
    x<-d()$Zamkniecie
    bins <- seq(min(x), max(x), length.out = input$bins + 1)
    
    # rysowanie histogramu
    hist(x, breaks = bins, col = 'darkgray', border = 'white')
  })
  
  splk2 <- reactive({getName(input$spolka2)}) # wczytanie nazw
  output$name2 = renderText({ input$spolka2 }) # wypisanie nazwy / ścieżki dostępu
  d2 <- reactive({ getData( splk2() ) }) # wczytanie spółek - lokalnie z dysku
  
  output$zPlot <- renderPlot({
    # generowanie wykresu szeregu
    x<-d2()$Zamkniecie
    data = as.Date(d2()$Data, "%Y-%m-%d")
    x.m <- stats::filter(x, sides=2, rep(1,69)/69) # wyrównanie szeregu
    # wykres na podstawie wyboru checbox
    if(input$plot == T)
    { plot(data,x,type="l", main=c('Wykres szeregu'),
           ylab="Prices", xlab="Time")
      if(input$smooth == T)
      { lines(data,x.m, col="red",lty="dashed")} } # wykres wyrównany
    if(input$plot == F) # jeśli nie rysujemy szeregu
    { if (input$smooth == T)
    { plot(data,x.m, type="l",main='Wykres wyrównany', col='red',
           ylab="Prices", xlab="Time")}
      else
        plot.new()} # jeśli nic nie rysujemy
  }) # renderPlot
  
  splk3 <- reactive({getName(input$spolka3)}) # wczytanie nazw
  d3 <- reactive({ getData( splk3() ) }) # wczytanie spółek - lokalnie z dysku
  
  output$name4 = renderText({ input$spolka3 }) # nazwy spółek
  output$value <- renderPrint({ input$radio }) # wybrana liczba dni do wyrównania
  output$analiza1 <- renderPrint({
    cat('Wyrównano liczbą dni ') # zwykłe wypisanie tekstu
  })
  output$z2Plot <- renderPlot({ # wykres
    x<-d3()$Zamkniecie
    data = as.Date(d3()$Data, "%Y-%m-%d")
    # wyrównanie średnią ruchomą
    dl<-as.numeric(input$radio)
    x.m <- filter(x, sides=2, rep(1,dl)/dl)
    # rysowanie wykresu
    plot(data,x,type="l",col="darkblue", main=c('Wykres szeregu'),
         ylab="Zamknięcie", xlab="Dni",lwd =2)
    lines(data,x.m, col="red",lty="dashed",lwd =3)
  })
  
  output$name5 = renderText({ paste('Analiza',input$spolka3 )}) # opis spółki
  
  output$datap <- renderPrint({ # wypisanie zakresu dat
    paste("Wartości w okresie od", input$datapk[1], "do", input$datapk[2])
  })
  output$analiza2 <- renderPrint({ # podstawowe statystyki w kolumnie
    data = as.Date(d3()$Data, "%Y-%m-%d")
    as.matrix(summary(d3()$Zamkniecie[data >= input$datapk[1] & data <= input$datapk[2]]),ncol=1)
  })
  output$z3Plot <- renderPlot({ # wykres
    data1 = as.Date(d3()$Data, "%Y-%m-%d")
    x<-d3()$Zamkniecie[data1 >= input$datapk[1] & data1 <= input$datapk[2]]
    data2<-data1[data1 >= input$datapk[1] & data1 <= input$datapk[2]] # wybór zakresu dat do wykresu
    x.m <- stats::filter(x, sides=2, rep(1,23)/23)
    # rysowanie wykresu
    plot(data2,x,type="l",col="darkblue", main=c('Wykres szeregu'),
         ylab="Zamknięcie", xlab="Dni",lwd =2)
    lines(data2,x.m, col="red",lty="dashed",lwd =3)
  })  
  
})# end shinyServer

