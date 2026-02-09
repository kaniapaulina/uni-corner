#obróbka danych z tabelki xoxo

library(XML)
library(httr)

theurl <- "https://www.vgchartz.com/charts/platform_totals/Hardware.php"
doc <- htmlParse(GET(theurl, user_agent("Mozilla")))
results <- xpathSApply(doc, "//*/table[@id='myTable']")
tab <- readHTMLTable(results[[1]])

colnames(tab)
tab$V3 <- replace(tab$V3, tab$V3 == "N/A", "0")
tab$V4 <- replace(tab$V4, tab$V4 == "N/A", "0")
tab$V5 <- replace(tab$V5, tab$V5 == "N/A", "0")
tab$V6 <- replace(tab$V6, tab$V6 == "N/A", "0")

tab$V3 <- as.numeric(tab$V3)
tab$V4 <- as.numeric(tab$V4)
tab$V5 <- as.numeric(tab$V5)
tab$V6 <- as.numeric(tab$V6)
tab$V7 <- as.numeric(tab$V7)

typeof(tab$V6)

inne <- data.frame(
    V1 = 31,
    V2 = "Inne",
    V3 = sum(tab$V3[31:82]),
    V4 = sum(tab$V4[31:82]),
    V5 = sum(tab$V5[31:82]),
    V6 = sum(tab$V6[31:82]),
    V7 = sum(tab$V7[31:82])
)

tab<-tab[-(31:82),]

tab <- rbind(tab, inne)
tab

#Które konsole miały najbardziej zrównoważoną sprzedaż międzynarodową?
#Czy istnieje korelacja między sukcesem w Japonii a sukcesem globalnym?
#Który producent ma najbardziej stabilną sprzedaż między generacjami?
#Jak zmieniała się geografia sprzedaży konsol na przestrzeni lat?
#Które konsole były "hitami" w konkretnych regionach?

write.csv(tab,file='konsole.csv', row.names=FALSE)
