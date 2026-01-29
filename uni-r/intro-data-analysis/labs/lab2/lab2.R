"
ZADANIE 1
Ciekawym narzędziem w R są funkcje z rodziny apply. W szczególności mowa o czterech funkcjach: apply(), lapply(), sapply() oraz tapply().

Funkcja lapply() ma składnię lapply(X, FUN, ...) i jej wywołanie powoduje, że dla każdego elementu wektora lub listy X, wykonuje ona funkcję FUN. W sytuacji, gdy funkcja FUN wymaga dodatkowych argumentów (poza danymi), podaje się je jako kolejne argumenty.

Spróbuj zastosować tę funkcję dla poniższej listy licząc podstawowe statystyki opisowe, tj. mean(), sd() oraz quantile()

lista2 <- list(dane1 = c(NA, 1:10),
               dane2 = c(-5:5, NA))
Uwaga: Zauważmy, że w ramach zestawu danych mam wartości brakujące NA. Odszukaj, jakie argumenty używanych funkcji “załatwiają” ten problem.

ZADANIE 2
Funkcja sapply() ma zastosowanie w sytuacji, gdy wynik dla każdego obiektu jest jednoelementowym wektorem. Użyj jej dla zestawu danych poniżej (wybierz funkcje max() oraz min()).

lista4 <- list(dane1 = 20:1,
               dane2 = 1:10,
               dane3 = 1:5)
Uwaga: Co jest wynikiem działania funkcji sapply()? Jaka to różnica w porównaniu do funkcji lapply().

Uwaga2 Zbuduj funkcję mierzącą współczynnik zmienności (iloraz odchylenia st. i średniej). Czy możesz dla niej zastosować funkcję sapply()?
  
  ZADANIE 3
Wyjaśnij na kilku przykładach, w jaki sposób działa funkcja apply(). Czym się ona różni od wcześniejszych funkcji?
  
  ZADANIE 4
W pewnych sytuacjach praktycznych zależy nam na tym, by wyznaczyć statystyki w grupach. Do tego działania przydaje się znajomość funkcji tapply():
  
  Dwa pierwsze argumenty tej funkcji tapply(X, INDEX, FUN, ..., ) pozwalają na podział wektora X na podzbiory wg zmiennej kategorycznej index.

Domyślnym wynikiem działania funkcji tapply() jest lista z wynikami działania funkcji FUN na wszystkich poziomach kategorii index.

Obejrzeć zestaw mtcars (on również jest jednym ze zbiorów w pakiecie datasets).
Z wykorzystaniem odpowiedniej funkcji z rozdziny apply(), uzyskać informację o przeciętnym spalaniu w zależności od liczby cylindów.
Rozszerzyć analizę w/w problemu i wyświetlić podstawowe statystyki opisowe (funkcja summary).
ZADANIE 5
Obejrzyj dane przedstawione w ramce anscombe z pakietu datasets oraz dane fgl z pakietu MASS. Wybierz ciekawsze dane, napisz o nich kilak słów, a następnie rozwiąż poniższe zadania.

Użyć funkcji z rodziny apply() do wyznaczenia średnich we wszystkich kolumnach wybranej ramki danych.
Użyj funkcji str() do sprawdzenia, które kolumny są numeryczne, i powtórzyć zad. 1 tylko do tych kolumn.
Użyć funkcji z rodziny apply() do wyznaczenia mediany we wszystkich kolumnach iloścowych. Dla której zmiennej widzimy największą różnicę między średnią a medianą?
  Użyć funkcji z rodziny apply() do obliczenia odchylenia standardowego oraz współczynnika zmienności dla wszystkich kolumn ilościowych.
ZADANIE 6
Z wykorzystaniem funkcji install.packages() proszę zainstalować, a następnie z wykorzystaniem funkcji library() wczytać pakiety: tidyr, dplyr oraz gapminder.

Na początek zajmiemy się zestawem danych gapminder.

Proszę zmienić nazwy zmiennych, tj. zmienną year nazwać rok, a zmienną gdpperCap nazwać PKB.
Proszę zmienić wartości zmiennej pop tak, aby ludność była przedstawiona w milionach osób.
Wyświetlić wszystkie kraje afrykańskie, które w roku 1957 miały PKB większe niż 12000$ A czy jesteś w stanie narysować wykres, który pokazuje ile tych krajów było w każdym roku badania?
  Które kraje spoza Afryki w roku 1962 miały PKB mniejsze od 750$?
  Na przykładzie lat 1952, 1977 i 2002 sprawdzić, ile wynosiła przeciętna długość życia w Polsce. W których krajach obu Ameryk była ona większa? Czy na podstawie tych informacji, możesz spróbować wyciągnąć jakieś wnioski?
  Wyznaczyć podstawowe statystyki opisowe dot. wielkości populacji na różnych kontynentach w roku 2007. Pamiętaj o wykorzystaniu funkcji group_by() i summarize().
Wśród krajów o PKB niższym od 5000$ (rozważyć dane za rok 1977), wyznaczyć po trzy kraje z Afryki, Europy i Azji, w których spodziewana długość życia jest największa.
Wyfiltrować dane z roku 1987 dla krajów europejskich. Dodać zmienną system, która będzie przyjmowała trzy wartości: RWPG dla krajów RWPG, UE dla krajów Unii Europejskiej oraz inne dla pozostałych krajów. Następnie wyznaczyć podstawowe statystyki opisowe (średnia, mediana, odchylenie standardowe, Q1 i Q3 ). Czy można wyciągnąć z w/w statystyk jakieś ciekawe wnioski?
  
  Uwaga: Kraje RWPG (z reguły socjalistyczne) i UE postaraj się wyszukać np. w Wikipedii.

ZADANIE 7
Na jednym wykresie liniowym narysować, jak w rozważanych latach zmieniała się oczekiwana długość życia w trzech wybranych przez Ciebie krajach. Sugestia: Być może warto przypomnieć sobie, jak przekształca się dane do postaci szerokiej (funkcja spread()).

ZADANIE 8
Zapoznać się z funkcją set.seed(). Do czego ona służy? Kiedy należy jej używać? Z wykorzystaniem funkcji sample() zasymuluj rzut kostką sześcienną. Rzuć ową kostką 2, 10, 50, 100 i 1000 razy. Wykorzystać funkcję table() do tego, by sprawdzić, jakie liczby uzyskałeś. Wykorzystaj funkcję mean(), by wyznaczyć średnią liczbę oczek w doświadczeniu.

Uwaga! To, co masz zrobić w poniższym podpunkcie, to symulacja Monte Carlo. Poczytaj o niej w Wikipedii i w kilku słowach wyjaśnij, co ona tak naprawdę robi.

Dwa zespoły NBA, Chicago Bulls i NY Knicks, rozgrywają serię play-off składającą się z siedmiu meczów. Knicks są lepsi i mają 65% szans na wygranie każdego meczu. Rywalizacja toczy się do czterech zwycięstw. Przeprowadzić 10000 symulacji i sprawdzić jak często NY wygra rywalizację.

ZADANIE 9
Rozważmy ramkę danych mammals z pakietu MASS, która zawiera informacje o masie ciała i masie mózgu dla 62 wybranych zwierząt. Weźmy też pod uwagę dane, które znajdują się w ramce danych Animals2 zamieszczone w pakiecie robustbase. W obu przypadkach nazwy wierszy identyfikują zwierzęta, a celem ćwiczenia jest zbadanie różnic między zwierzętami scharakteryzowanymi w obu zestawach danych.

Funkcja rownames() zwraca wektor nazw wierszy dla ramki danych, a funkcja intersect() wyznacza część wspólną dwóch zestawów, zwracając wektor ich wspólnych elementów. Korzystając z tych funkcji, skonstruować i wyświetlić wektor zwierzaki nazw zwierząt wspólnych dla obu ramek danych. Ile zwierząt zawiera ten zestaw?
  
  Funkcja setdiff() zwraca wektor elementów zawartych w jednym zbiorze, ale nie w drugim. Prosżę użyć tej funkcji, aby wyświetlić zwierzęta obecne w zestawie mammals, których nie ma w zestawie Animals2.

Użyć funkcji setdiff(), aby wyświetlić zwierzęta obecne w Animals2, które nie występują w zestawie mammals.

ZADANIE 10
Jedną z zalet teorii prawdopodobieństwa jest to, że pozwala nam ona przybliżyć zakres danych przy założeniu, że próba pochodzi z danego rozkładu.

Użyć funkcji qnorm() by wyznaczyć 5% i 95% kwantyl dla rozkładu N(0,1).
Użyć funkcji qt(), by wyznaczyć 5% i 95% kwantyl dla rozkładu t-Studenta.
Założyć, że liczba stopni swobody (parametr tego rozkładu) wynosi odpowiednio 1, 5, 10, 30, 50 i 1000. Jak uważasz, co ciekawego pokazują te przedziały?
  "
# Cwiczenia 3 - 12.01.2026

# ======= Zadanie 1 =======
lista2 <- list(dane1 = c(NA, 1:10),
               dane2 = c(-5:5, NA))
lapply(lista2, mean, na.rm=TRUE)
lapply(lista2, sd, na.rm=TRUE)
lapply(lista2, quantile, na.rm=TRUE)

# ======= Zadanie 2 =======
lista4 <- list(dane1 = 20:1,
               dane2 = 1:10,
               dane3 = 1:5)
sapply(lista4, max)
sapply(lista4, min)

zmiennosc <- function(x) {
  return(sd(x)/mean(x))
}
sapply(lista4, zmiennosc)

# ======= Zadanie 3 =======
macierz1 <- matrix(round(rnorm(20), 1),5)
macierz2 <- matrix(sample(1:5,16,replace = T),4)
macierz3 <- matrix(1:9,3)
macierz1
macierz2
macierz3

apply(macierz1, 1, median) #wiersze
apply(macierz2, 2, max) #kolumny
apply(macierz3, 1, summary)

# ======= Zadanie 4 =======
#a
mtcars
#b
tapply(mtcars$mpg, mtcars$cyl, mean)
tapply(mtcars[,1], mtcars[,2], mean)
#c
summary(mtcars)

# ======= Zadanie 5 =======
library(datasets)
head(anscombe)
library(MASS)
head(fgl)

#a
sapply(anscombe, mean)
sapply(fgl, mean, na.rm=T)

#b
str(fgl)
sapply(fgl[,1:9], mean)

#c
sapply(anscombe, median)
sapply(fgl[,1:9], median)

roznica <- function(x) {
  return(mean(x) - median(x))
}
sapply(anscombe, roznica)
sapply(fgl[,1:9], roznica)

#d
sapply(anscombe, sd)
sapply(fgl[,1:9], sd)

sapply(anscombe, zmiennosc)
sapply(fgl[,1:9], zmiennosc)

# lub zamiast pisac 1:9
numeryczne <- sapply(fgl, is.numeric)

# ======= Zadanie 6 =======
library(tidyr)
library(dplyr)
library(ggplot2)
library(gapminder)

# part a
gapminder <- gapminder %>% rename(rok = "year", PKB = gdpPercap)

names(gapminder)
summary(gapminder)

# part b
gapminder <- gapminder %>% mutate(pop=pop/1000000)

# part c
gapminder %>% filter(continent=="Africa" & rok==1957 & PKB>1200)

#gapminder |> filter(continent=="Africa" & PKB>12000) |> group_by(rok) |> reframe(country=n()) |> plot()
gapminder %>% filter(continent=="Africa" & PKB>12000) %>% 
  count(rok) %>% plot()

countafrica <- gapminder |> filter(continent=="Africa" & PKB > 12000) |> group_by(rok) |> summarise(count_country = n())

ggplot(countafrica, aes(x=rok, y=count_country)) + geom_col()

# part d 
gapminder |> filter(continent != "Africa" & rok==1962 & PKB<750)

# part e
zad6pol <- pull(gapminder |> filter(rok %in% c(1952, 1977, 2002) & country=="Poland") |> select(lifeExp))
typeof(zad6pol)

zad6usa <- gapminder %>% filter(rok %in% c(1952, 1977, 2002) & continent=="Americas" & lifeExp>zad6pol) %>% arrange(desc(lifeExp))
print(zad6usa, n=25) 
unique(zad6usa$rok)

# part f
gapminder %>% filter(rok==2007) %>% group_by(continent) %>%
  summarize(
    mean=mean(pop), 
    median=median(pop),
    sd=sd(pop)
  )

# part g
gapminder %>% filter(rok==1977 & PKB<5000 & continent %in% c("Africa", "Europe", "Asia")) %>% group_by(continent) %>% top_n(-3, PKB)

# part +
gapminder %>% filter(continent=="Europe" & rok==1987)%>% 
  mutate(
    system = ifelse(country %in% c("Poland", "Czech Republic", "Hungary", "Romania", "Bulgaria"), "RWPG", ifelse(country %in% c("Germany", "Belgium", "France", "Netherlands", "Italy", "Denmark", "Ireland", "United Kingdom"), "UE", "others")))%>% 
  group_by(system) %>% summarise(
    mean=mean(lifeExp),
    median=median(lifeExp),
    sd=sd(lifeExp),
    q1 = quantile(lifeExp, 0.25),
    q3 = quantile(lifeExp, 0.75)
  )

gapminder %>% filter(continent=="Europe" & rok==1977) %>%
  mutate(
    system = case_when(
      country %in% c("Poland", "Czech Republic", "Hungary", "Romania", "Bulgaria") ~ "RWPG",
      country %in%c("Germany", "Belgium", "France", "Netherlands", "Italy", "Denmark", "Ireland", "United Kingdom") ~ "UE",
      TRUE ~ "others"
    )
  ) %>%
  group_by(system) %>% summarise(
    mean=mean(lifeExp),
    median=median(lifeExp),
    sd=sd(lifeExp),
    q1 = quantile(lifeExp, 0.25),
    q3 = quantile(lifeExp, 0.75)
  )
     

# ======= Zadanie 7 =======
# wybrane przeze mnie kraje: Germany, China, Angola
#gapminder %>% sort_by(gapminder$lifeExp)

#ger <- gapminder[gapminder$country=="Germany",]
wideger <- gapminder %>% 
  filter(country =="Germany") %>% 
  select(country, lifeExp, rok) %>% 
  spread(rok, lifeExp) 

yearsger <- as.numeric(colnames(wideger)[-1])

plot(yearsger, wideger[1,-1], type="l")

ggplot(data=(gapminder %>% filter(country %in% c("Germany", "China", "Angola"))), aes(x=rok, y=lifeExp, color=country)) + geom_line()


# ======= Zadanie 8 =======
set.seed(8)
for (i in c(2,10,50,100,1000)) {
  cat("\n dla ", i, " rzutów")
  a <- sample(1:6, i, replace = T)
  print(table(a))
  cat("Srednia: ", mean(a), "\n")
}

# Metoda Monte Carlo z mojego rozumowania - to metoda stosowana do trudnych i zlozonych procesow obliczeniowych i statystycznych by przewidziec wyniki osiagniete. Dokladność wyniku zależy od ilości powtórzeń i zgodności rozkładu

los <- function () {
  nba <- c("Chicaco Bulls", "NY Knicks")
  sample(nba, 1, prob = c(0.35, 0.65))
}
score <- 0
for (i in 1:10000) {
  winK <- 0
  winC <- 0
  while( winK + winC < 7) {
    if (los() == "NY Knicks") {
      winK <- winK + 1
    }
    else {
      winC <- winC + 1
    }
  }
  if (winK >= 4) {
    score <- score + 1
  }
}
print(score)


score <- 0
for (i in 1:10000) {
  match <- sample(0:1, 7, prob = c(0.35, 0.65), replace=T)
  if (sum(match) >= 4) {
    score <- score + 1
  }
}
print(score)
print(score/100)


# ======= Zadanie 9 =======
library(MASS)
mammals

library(robustbase)
Animals2

# part a
animals <- intersect(rownames(mammals), rownames(Animals2))
print(animals)
length(animals)*2

# part b
setdiff(rownames(mammals), rownames(Animals2))

# part c
setdiff(rownames(Animals2), rownames(mammals))

# ======= Zadanie 10 =======
qnorm(0.05, 0, 1)
qnorm(0.95, 0, 1)

stSwobody <- c( 1, 5, 10, 30, 50, 1000)

for(df in stSwobody) {
  tstudent <- qt(c(0.05, 0.95), df = df)
  cat("dla", df, "stopien swobody: ", tstudent, "\n")
}










                                                                           