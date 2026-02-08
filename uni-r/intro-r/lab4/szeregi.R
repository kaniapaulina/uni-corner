
getData <- function(name) {
  data <- read.csv(paste0("https://stooq.pl/q/d/l/?s=",
                          name,"&d1=20200101&d2=20201206&i=d"))
}

f1 <- function(name) {
  
  d <- getData(name)
  
  newdata = as.Date(d[,1],"%Y-%m-%d")

  plot(newdata,d[,5],type = "l",ylab = "Kurs zamknięcia [zł]",xlab="Data", main = name, col="red")
  return (data.frame(data=newdata,zamkniecie=d[,5]))
  }
