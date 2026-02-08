"
Wstęp do analizy danych - zestaw nr 1


Zadania do samodzielnego rozwiązania:
  
  Zdefiniować zmienne o nazwach pierwsza i druga. Obie zmienne powinny się składać z ośmiu dowolnych obiektów, a każdy obiekt ma być cyfrą. Warto zapamiętać, że do stworzenia obiektów w ramach wektora, używamy funkcji c().
Wyznaczyć zmienną suma, która jest wynikiem działania: pierwsza + druga, zmienna różnica, która jest wynikiem działania: pierwsza - druga oraz zmienną wiecej, która jest wynikiem działania: pierwsza + 1
Uwaga Zastanowić się (i skomentować w raporcie), jak działa program wykonując działanie pierwsza + 1.

1a. Zdefiniować zmienne trzecia i czwarta. Niech zmienna trzecia ma długość 6, a zmienna czwarta długość 4. Teraz wykonać działanie trzecia - czwarta.

Uwaga Zastanowić się (i skomentować w raporcie), skąd taki a nie inny wynik. Warto pamiętać o tej własności działań arytmetycznych w pakiecie R.

Wykorzystując funkcje mean() oraz sd() wyznaczyć dwie podstawowe statystyki opisowe, tj. średnią arytmetyczną i odchylenie standardowe.
Uwaga: Jeśli masz kłopoty z prawidłowym zastosowaniem tych zmiennych, to proszę użyć pomocy (tj. funkcji help()).

Stworzyć ramkę danych o nazwie osoby, która składa się z dziesięciu obserwacji i dwóch zmiennych: wzrost i waga. Uzupełnić ją danymi wg własnego uznania (ale racjonalnie!). Następnie, z wykorzystaniem funkcji:
  str(), która pozwala na poznanie struktury obiektu,
head(), która pozwala na poznanie kilku pierwszych obiektów w zbiorze,
tail(), która pozwala na poznanie kilku ostatnich obiektów w zbiorze,
dim(), która pozwala na poznanie wymiaru rozważanego obiektu,
summary(), która pozwala na wyznaczenie statystyk opisowych w obiekcie,
przeprowadzić podstawową inspekcją danych.

Dla danych z zad. 2 wykonać następujące działania:
  wykorzystać funkcję rownames() do nadania imion obiektom w ramce osoby.
stworzyć obiekt BMI, który bedzie przechowywał informacje o wartościach BMI (ang. body mass index)
wyświetl tylko te osoby, których BMI przyjmuje wartość wiekszą niż 30.
ile jest osób o BMI≤25
?
  Uwaga: Wzór, w jaki wyznacza się BMI, można znaleźć w sieci. Proszę pomyśleć o tym, jak do rozwiązania zadania można wykorzystać funkcję sum() oraz instrukcje warunkowe.

W pakiecie datasets znajduje sie wiele ciekawych zbiorów danych, a w szczegolności ramki danych mtcars i Orange.
Wykorzystać komendy str() oraz help(), by dowiedzieć się więcej o tych zbiorach danych. Proszę napisać w kilku słowach, co opisują w/w pliki z danymi.
Wykorzystujac instrukcje warunkowe, wyświetlić wyłącznie auta posiadające 6 cylindrów.
Jaką przeciętną liczbę koni mechanicznych (zmienna hp) posiadają auta o spalaniu (zmienna mpg) mniejszym niż 20.
Narysować histogram (formuła hist()), dla wybranej zmiennej w zestawie danych Orange.
Narysować wykres pudełkowy z wąsem (boxplot()) dla zmiennych mpg, hp i qsec ze zbioru mtcars.
Uwaga: Funkcje, których jeszcze nie znamy, można wyszukać w helpie, ew. w sieci. Praca z R to ciagłe szukanie i poznawanie funkcji, których dotąd nie używaliśmy. Przestrzegam jednak przed zbyt wczesnym i pasywnym korzystaniu z narzędzi AI. One są pomocne, ale rozsądnie najpierw zrozumieć ideę danego języka i zdobyć w nim pewne doświadczenia i umiejętności, a dopiero później (bardziej świadomie) szukać łatwiejszej pomocy.

Świetnym narzędziem statystycznym dla psychologów jest pakiet psych, który mieści wiele potrzebnych i ważnych dla nich funkcji.
Zainstalować ten pakiet, a nastepnie wczytać go do pamieci (funkcja library()).
W pakiecie psych istnieje funkcja describe(). Postarać się, za jej pomocą, wyswietlić statytyski opisowe dla danych mtcars. Czym się ona różni od funkcji summary()?
  Zapoznać się z działaniem i zaproponować sensowne wykorzystanie funkcji describeBy()
Na zajęciach używaliśmy funkcji sample(). Służy ona do losowania danych z pewnej próby. Argumenty tej funkcji to: x - możliwe wyniki losowania, size - liczba wylosowanych liczb, replace - informacja, czy losujemy ze zwracaniem.
Wygenerować 20 wyników rzutu kostką do gry. Nazwijmy tę zmienną proba. Ile wynosi średnia i odchylenie standardowe?
  Wygeneruj 100 wyników rzutu monetą. Nazwijmy tę zmienną rzut (uwaga: jako 1 możesz oznaczyć orła, jako 0 reszkę). Ile wypadło orłów?
  Wylosować (bez zwracania) 10 liczb ze zbioru liczb naturalnych od 0 do 100.
Zapoznać się z funkcjami rnorm(), rt() oraz rpois(). Na wymyślonym przez siebie przykładzie, zastosować jedną z w/w funkcji.
Stworzyć zestaw danych lista wg instrukcji poniżej:"
#  lista <- list(palenie = c(F,T,T,F,F,T,F),
#                cyfry = 0:9,
#                macierz = matrix(sample(1:5,16,replace = T),4,4),
#                tekst = c("Litwo", "ojczyzno", "moja", "ty",
#                          "jestes", "jak", "zdrowie"))
"
Odwołać się do obiektu tekst.
Odwołać się do trzeciego elementu wektora cyfry.
Odwołać się do trzeciej kolumny obiektu macierz.
Proszę każdą z tych rzeczy zrobić na więcej niż jeden sposób.

Zdefiniować zmienną wiek <- c(50, 17, 39, 27, 90) i waga <- c(80, 75, 92, 105, 60). Są to zmienne opisujące osoby o danej wadze i danym wieku. Zbudować z nich ramkę danych pacjenci, a następnie wykluczyć z zestawu osoby o wadze >90 kg lub osoby w wieku <18 lat.

Zainstalować i załadować pakiet nycflights13. Korzystając z danych dostarczonych przez ten pakiet, na podstawie kodu poniżej, zbudować model regresji:
  
  library(nycflights13)

flight_lm <- lm(arr_delay ~ dep_delay + month + carrier, 
                data = flights)
Obiekt flight_lm jest listą, która zbiera różne wyniki uzyskane w ramach zbudowanego modelu regresji liniowej. Proszę spróbować znaleźć odpowiedzi na poniższe pytania:
  
  ile różnych pozycji znajduje się na tej liście,
jak nazywają się te elementy listy,
wyświetl współczynniki tego modelu.
Uwaga: W wykonaniu zadania może pomóc funkcja str().

Wyświetlić macierz VADeaths. Jakie dane ona przedstawia, jakie są nazwy wierszy i kolumn (jeśli trzeba zmień owe nazwy na polskie).
Podzielić tę macierz na dwie podmacierze - tylko dla mężczyzn i tylko dla kobiet.Sprawdzić, czy i w jaki sposób możesz obliczyć średnie dla każdej kolumny i wiersza. Spróbować dodać te średnie do tabeli jako ostatni wiersz i ostatnią kolumnę.

Użyć instrukcji if-else oraz funkcji ifelse() do sprawdzenia, czy dowolna liczba jest podzielna przez 4.

Stworzyć zmienną książki mówiącą o tym, ile dana osoba przeczytała książek w ostatnim kwartale. Zrobić to wg instrukcji poniżej:
  
  ksiazki <- sample(0:4, size = 25, replace = TRUE)
Ile wynosi średnia liczby przeczytanych książek?
  Ile osób przeczytało przynajmniej trzy książki?
  Ile osób nie przeczytało żadnej książki?
  Stworzyć zmienną ksiazki2, która będzie mówiła o tym, czy ktoś czyta książki (przeczytał min. jedna). Uzyj do tego petli for.
Stworzyć instrukcję warunkową, która mając datę (miesiąc i rok), odpowie na pytanie o liczbę dni w tym miesiącu.
Uwaga: Rozsądnie jest przyswoić sobie relacje %in%, później pójdzie z górki…

Stworzyć funkcję, która zamienia temperaturę w Celsjuszach na temperaturę w Kelwinach i Fahrenheita.

Stworzyć funkcję, która na podstawie długości boków trójkąta, wyznacza jego pole. Zadbaj o to, by funkcja wyświetliła komunikat, jeśli podane długości boków nie tworzą trójkąta.

Stworzyć funkcję, która na podstawie długości boków trójkąta odpowiada na pytanie o to, czy trójkąt jest ostrokątny, prostokątny lub rozwartokątny.

Za pomocą funkcji sample() i rnorm() stworzyć ramkę danych (patrz kod poniżej):
  
  wzrost <- round(rnorm(100, 175, 10),0)
waga   <- round(wzrost - 105 + rnorm(1,0,5))
wiek   <- sample(20:60, 100, replace = TRUE)
dzieci <- rpois(100, lambda = 1)
osoby  <- data.frame(wzrost = wzrost, waga = waga,
                     wiek = wiek, dzieci = dzieci)
Dołączyć do zestawu danych zmienną BMI oraz zmienną plec (pierwsza połowa danych to kobiety, a druga to mężczyzni - można w tym celu użyć np. funkcji rep())

Z wykorzystaniem funkcji: str(), head(), tail(), dim() oraz summary() przyjrzeć się uzyskanemu zestawowi danych.

Ile osób w zbiorze danych posiada min. dwójkę dzieci? Spróbować w tym celu wykorzystać operacje logiczne oraz funkcję sum().

Użyć instrukcji logicznych, by wydobyć z danych osoby, które posiadają min. 185 cm wzrostu.

Ile wynosi średnia wzrostu w badanej grupie? (użyć np. funkcji mean())? Czy możemy odpowiedzieć na pytanie kto jest przeciętnie wyższy: kobiety, czy mężczyźni (proszę użyć funkcji describe.by() z pakietu psych lub podzielić zestaw danych na kobiety i mężczyzn i wyznaczyć odpowiednie statystyki opisowe)

Z wykorzystaniem instrukcji logicznych pokazać te osoby, które mają BMI > 30. Ile wśród nich to mężczyźni, a ile to kobiety?
  
  Dołączyć do zestawu danych zmienną wzrost2, która będzie przyjmowała trzy wartości: niski o ile wzrost < 165, sredni, o ile wzrost jest między 165 i 185 oraz wysoki, gdy wzrost >=185.

Skorzystać z funkcji summary() dla zmiennej wzrost2. Czy na jej podstawie możesz ocenić, ile osób jest wysokich? Zmień typ tej zmiennej na factor - czy to pomogło?
  
  Stworzyć funkcję, która mając datą (miesiąc i rok) odpowie na pytanie o liczbę dni w tym miesiącu.

Stworzyć ciekawą i niebanalną funkcję, która będzie wyznaczała jakąś wielkość na podstawie matematycznego (lub innego) wzoru.
"


# Ćwiczenia 1 - 27.11.2025

# ===== Zadanie 1
pierwsza <- c(1:8)
druga <- c(1:8)

suma <- pierwsza + druga
różnica <- pierwsza - druga
wiecej <- pierwsza + 1
# Działąnie pierwsza + 1 dodaje do każdego elementu wektora pierwsza cyfre 1

trzecia <- c(1:6)
czwarta <- c(1:4)
wynik <- trzecia - czwarta
# dzialanie odejmujace od wektora "trzecia" wektor "czwarty", gdy kończy sie wektor "czwarty" w działaniach "loopuje" sie od początku wiec dla trzecia[5] - czwarta[1]

mean(pierwsza)
sd(pierwsza)

# ===== Zadanie 2
osoby <- data.frame(
  wzrost = c(1.72, 1.88, 1.56, 1.55, 1.78, 1.70, 1.90, 2.01, 1.49, 1.66),
  waga = c(56, 77, 68, 92, 81, 70, 59, 64, 94, 100)
)
str(osoby)
head(osoby, 3)
tail(osoby, 3)
dim(osoby)
summary(osoby)

# ===== Zadanie 3
rownames(osoby) = c("Emilia", "Weronika", "Wiktoria", "Gabriel", "Michał", "Adrian", "Jacek", "Paulina", "Iza", "Daria")

osoby$BMI = osoby$waga/(osoby$wzrost^2)
#osoby <- cbind(osoby, BMI)
osoby[osoby$BMI>30,]
sum(osoby$BMI<=25)

# ===== Zadanie 4
str(mtcars)
help(mtcars)
# dane z gazetki (1974 Motor Trend US), opisuje aspekty konstrukcji i wydajności 32 samochodów
str(Orange)
help(Orange)
# 35 wiersze i 3 kolumny, o danych dotyczących cyklu wzrostu drzewa pomarańczowego

mtcars[mtcars$cyl == 6,]

mtcars_spal20 <- mtcars[mtcars$mpg<20,]
mean(mtcars_spal20$hp)

hist(Orange$age)
boxplot(mtcars$mpg, horizontal=T)
boxplot(mtcars$hp, horizontal=T)
boxplot(mtcars$qsec, horizontal = T)
        
# ====== Zadanie 5
library(psych)
describe(mtcars)

# ====== Zadanie 6
proba <- sample(1:6, 20, replace=T)
mean(proba)
sd(proba)

rzut <- sample(c(0,1), 100, replace=T)
sum(rzut==1)

bez <- sample(0:100, 10, replace=F)
bez 

a <- rnorm(10, 50, 25)
a
sum(a>50)

b <- rt(10, 20, 5)
b
c <- rpois(10, 10)
c

# ======= Zadanie 7
lista <- list(palenie = c(F,T,T,F,F,T,F),
              cyfry = 0:9,
              macierz = matrix(sample(1:5,16,replace = T),4,4),
              tekst = c("Litwo", "ojczyzno", "moja", "ty",
                        "jestes", "jak", "zdrowie"))
lista[["tekst"]]
lista[["cyfry"]][3]
lista[["macierz"]][,3]

# =======  Zadanie 8
wiek <- c(50, 17, 39, 27, 90)
waga <- c(80, 75, 92, 105, 60)
pacjenci <- data.frame(
  "wiek"=wiek,
  "waga"=waga
)
pacjenci[pacjenci$waga<90 & pacjenci$wiek>18,]

# ======= Zadanie 9
library(nycflights13)

flight_lm <- lm(arr_delay ~ dep_delay + month + carrier, 
                data = flights)

str(flight_lm)
summary(flight_lm)

length(flight_lm)
names(flight_lm)
coef(flight_lm)

# ======== Zadanie 10
VADeaths
VAMale <- VADeaths[,c("Rural Male", "Urban Male")]
VAFemale <- VADeaths[,c("Rural Female", "Urban Female")]

VAMale <- cbind(VAMale, Mean=rowMeans(VAMale))
VAMale <- rbind(VAMale, Mean=colMeans(VAMale))
VAMale
VAFemale <- cbind(VAFemale, Mean=rowMeans(VAFemale))
VAFemale <- rbind(VAFemale, Mean=colMeans(VAFemale))
VAFemale

# ======= Zadanie 11
cztery <- function(x) {
  if(x %% 4 == 0) {
    print("TAK!")
  }
  else {
    print("Nie..")
  }
}

czteryifelse <- function(x) {
  ifelse(x%%4==0, "TAK!", "Nie..")
}

cztery(8)
cztery(9)
czteryifelse(c(8, 9))

# ========= Zadanie 12
ksiazki <- sample(0:4, size = 25, replace = TRUE)
ksiazki

mean(ksiazki)
sum(ksiazki>3)
sum(ksiazki<0)

ksiazki2<-0
for(x in ksiazki) {
  if(x>0) {
    ksiazki2<- ksiazki2+1
  }
}
ksiazki2

days_in_month <- function(x, y) {
  dni <- c(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31)
  if(y%%4==0) {
    if(x==2){
      cat("29 days w ", month.name[x], "-", y)
    }
  }
  else {
    cat(dni[x], "days in ",  month.name[x], "-", y)
  }
  
}
days_in_month(2,2001)
days_in_month(2,1996)

# ========= 13
temp <- function(x) {
  far <- ((x*9/5)+32)
  kel <- x + 273.15
  cat("Celsius: ", x, ", Fahrenheit: ", far, ", Kelvin: ", kel)
}
temp(0)
temp(23)


# ========= Zadanie 14
pole <- function(a,b,c) {
  if (!((a + b > c) & (a + c > b) & (b + c > a))) {
    return("BŁĄD!!!")
  }
  s <- (a + b + c) / 2
  pole <- sqrt(s * (s - a) * (s - b) * (s - c))
  return(pole)
}

print(pole(3,4,5))
print(pole(1,2,10))


# =========== Zadanie 15
typ <- function(a, b, c) {
  if (!((a + b > c) & (a + c > b) & (b + c > a))) {
    return("BŁĄD!!! Boki nie tworzą trójkąta")
  }

  boki <- sort(c(a, b, c))
  a_kw <- boki[1]^2
  b_kw <- boki[2]^2
  c_kw <- boki[3]^2
  
  if (a_kw + b_kw == c_kw) {
    return("Trójkąt jest prostokatny")
  } else if (a_kw + b_kw > c_kw) {
    return("Trójkąt jest ostrokatny")
  } else {
    return("Trójkąt jest rozwartokatny")
  }
}

print(typ(3, 4, 5))   
print(typ(2, 2, 2))   
print(typ(2, 3, 4)) 


# ============ Zadanie 16
wzrost <- round(rnorm(100, 175, 10),0)
waga   <- round(wzrost - 105 + rnorm(1,0,5))
wiek   <- sample(20:60, 100, replace = TRUE)
dzieci <- rpois(100, lambda = 1)
osoby  <- data.frame(wzrost = wzrost, 
                     waga = waga,
                     wiek = wiek, 
                     dzieci = dzieci)
osoby$BMI <- osoby$waga / (osoby$wzrost / 100)^2
osoby$plec <- factor(rep(c("Kobieta", "Mezczyzna"), each = 50))

# a
str(osoby)
head(osoby)
tail(osoby)
dim(osoby)
summary(osoby)

# b
sum(osoby$dzieci >= 2)

# c
osoby[osoby$wzrost >= 185, ]

# d 
mean(osoby$wzrost)

library(psych)
describeBy(osoby$wzrost, osoby$plec)

# e
nadwaga <- osoby[osoby$BMI > 30, ]
table(nadwaga$plec)

# f
osoby$wzrost2 <- ifelse(osoby$wzrost < 165, "niski",
                        ifelse(osoby$wzrost <= 185, "sredni",
                               "wysoki"))

print(head(osoby[, c("wzrost", "wzrost2")]))

# g
summary(osoby$wzrost2)


# ============ Zadanie 17
sila_grawitacji <- function(m1, m2, r) {
  G <- 6.674e-11
  Newton <- G * (m1 * m2) / (r^2)
  return(Newton)
}

print(sila_grawitacji(m1 = 5.972e24, m2 = 100, r=6.371e6))



days_in_month <- function(x, y) {
  if(x %in% c(1,3,5,7,8,10,12)) {
    return(31)
  } 
  else if(x %in% c(4, 6, 9, 11)) {
    return(30)
  }
  else if(x==2) {
    if((y%%4==0) | (y%%400==0) & (y%%100 != 0)) {
      return(29)
    }
    else {
      return(28)
    }
  }
  
}
days_in_month(2,2023)
days_in_month(2,2024)