# PROJECT

#data from kaggle: https://www.kaggle.com/datasets/wsj/college-salaries?resource=download

#install.packages("tidyverse")
library(mice)
library(naniar)
library(corrplot)
library(ggrepel)
library(tidyverse)
library(knitr)


# Pobieranie danych z pliku csv
degreesThatPayBack <- read.csv("degrees-that-pay-back.csv")
salariesByCollegeType <- read.csv("salaries-by-college-type.csv")
salariesByRegion <- read.csv("salaries-by-region.csv")

# zaczynam od czyszczenia danych z pliku 'degrees that pay back'
degree <- degreesThatPayBack

# funkcje opisujące dane: summary, str, dim, class, head, tail, names, colnames
summary(degree)
names(degree)

str(degree)
str(degreesThatPayBack)

# zmiana nazw kolumn - dla czytelności i łatwiejszej obsługi danych
# użyje do tego dplyr::rename()
degree <- rename(
  degree,
  major = Undergraduate.Major, 
  career_start = Starting.Median.Salary, 
  career_mid = Mid.Career.Median.Salary,
  p_change = Percent.change.from.Starting.to.Mid.Career.Salary,
  p10_salary = Mid.Career.10th.Percentile.Salary,                
  p25_salary = Mid.Career.25th.Percentile.Salary,               
  p75_salary = Mid.Career.75th.Percentile.Salary,            
  p90_salary = Mid.Career.90th.Percentile.Salary
  )

# zmiana na lepsze
colnames(degree)

# zmiana typu danych - na numeryczne by móc je używać do analizy
# użyje do tego stringr::str_replace_all()

degree <- degree %>%
  mutate(
    career_start = as.numeric(str_replace_all(career_start, "[\\$,]", "")),
    career_mid = as.numeric(str_replace_all(career_mid, "[\\$,]", "")),
    p10_salary = as.numeric(str_replace_all(p10_salary, "[\\$,]", "")),
    p25_salary = as.numeric(str_replace_all(p25_salary, "[\\$,]", "")),
    p75_salary = as.numeric(str_replace_all(p75_salary, "[\\$,]", "")),
    p90_salary = as.numeric(str_replace_all(p90_salary, "[\\$,]", ""))
    )

# kolumna p_change to: (degree$career_mid-degree$career_start)/degree$career_start*100, czyli wzrost procentowy na bazie roku startowego 

str(degree)

' ======================================
inne sposoby to:
cols_to_fix <- c("career_start", "career_mid", "p10_salary", "p25_salary", "p75_salary", "p90_salary")

a. 
degree <- degree %>%
  mutate(across(
    .cols = cols_to_fix,
    .fns = ~ as.numeric(str_replace_all(., "[\\$,]", ""))
  ))

b.
clean <- function(x) {
 x <- gsub("\\D", "", x)
 as.numeric(x)/100
}
degree[cols_to_fix] <- lapply(degree[cols_to_fix], clean)
'
kable(degree)
glimpse(degree)


college <- salariesByCollegeType
str(college)

college <- college %>%
  rename(
    university = School.Name,
    type = School.Type,
    career_start = Starting.Median.Salary, 
    career_mid = Mid.Career.Median.Salary,
    p10_salary = Mid.Career.10th.Percentile.Salary,                
    p25_salary = Mid.Career.25th.Percentile.Salary,               
    p75_salary = Mid.Career.75th.Percentile.Salary,            
    p90_salary = Mid.Career.90th.Percentile.Salary
  )

college <- college %>%
  mutate(
    university = School.Name,
    career_start = as.numeric(str_replace_all(career_start, "[\\$,]", "")),
    career_mid = as.numeric(str_replace_all(career_mid, "[\\$,]", "")),
    p10_salary = as.numeric(str_replace_all(p10_salary, "[\\$,]", "")),
    p25_salary = as.numeric(str_replace_all(p25_salary, "[\\$,]", "")),
    p75_salary = as.numeric(str_replace_all(p75_salary, "[\\$,]", "")),
    p90_salary = as.numeric(str_replace_all(p90_salary, "[\\$,]", ""))
  )
head(college)

vis_miss(college)


region <- salariesByRegion
str(region)

region <- region %>%
  rename(
    university = School.Name,
    career_start = Starting.Median.Salary, 
    career_mid = Mid.Career.Median.Salary,
    p10_salary = Mid.Career.10th.Percentile.Salary,                
    p25_salary = Mid.Career.25th.Percentile.Salary,               
    p75_salary = Mid.Career.75th.Percentile.Salary,            
    p90_salary = Mid.Career.90th.Percentile.Salary
  )

region <- region %>%
  mutate(
    career_start = as.numeric(str_replace_all(career_start, "[\\$,]", "")),
    career_mid = as.numeric(str_replace_all(career_mid, "[\\$,]", "")),
    p10_salary = as.numeric(str_replace_all(p10_salary, "[\\$,]", "")),
    p25_salary = as.numeric(str_replace_all(p25_salary, "[\\$,]", "")),
    p75_salary = as.numeric(str_replace_all(p75_salary, "[\\$,]", "")),
    p90_salary = as.numeric(str_replace_all(p90_salary, "[\\$,]", ""))
  )
head(region)

##################### ANALIZA

# ===================== Pytanie 1
# Dominacja STEM - mit czy nie - Statytsyka opisowa

list(degree$major)

engineering <- c("Aerospace Engineering", "Chemical Engineering", "Civil Engineering", 
  "Computer Engineering", "Electrical Engineering", "Industrial Engineering", 
  "Mechanical Engineering", "Architecture")

tech <- c("Computer Science", "Information Technology (IT)", 
  "Management Information Systems (MIS)")

math <- c("Math")

science <- c("Biology", "Chemistry", "Geology", "Physics", 
             "Nursing", "Nutrition", "Physician Assistant")

liberalart <- c("Anthropology", "Art History", "Communications", "Criminal Justice", 
  "Drama", "Education", "English", "Film", "Geography", "History", 
  "Journalism", "Music", "Philosophy", "Political Science", 
  "Psychology", "Religion", "Sociology", "Spanish", "International Relations")

business <- c("Accounting", "Business Management", "Economics", "Finance", 
  "Marketing", "Hospitality & Tourism", "Health Care Administration",
  "Construction", "Agriculture", "Forestry", "Graphic Design", "Interior Design")

degree <- degree %>% 
  mutate(
    type = case_when(
      major %in% engineering ~ "Engineering",
      major %in% tech ~ "Technology",
      major %in% math ~ "Mathematics",
      major %in% science ~ "Science",
      major %in% liberalart ~ "Liberal Arts",
      major %in% business ~ "Business"
    )
  )

table(degree$type)

degree <- degree %>% 
  mutate(
    category = case_when(
      type %in% c("Engineering", "Technology", "Mathematics", "Science") ~ "STEM",
      TRUE ~ "Others"
    )
  )

table(degree$category)

degreestart <- degree %>% group_by(category) %>%
  summarise(
    mean_start = mean(career_start),
    median_start = median(career_start),
    max_start = max(career_start),
    min_start = min(career_start),
    range_start = max(career_start)-min(career_start),
    sd_start = sd(career_start),
  )

glimpse(degree)

degree %>% 
  ggplot(aes(career_start)) + 
  geom_histogram(fill="lightblue1", colour="darkgray", binwidth=10000, alpha=0.6) +
  geom_histogram(aes(career_mid), fill="#FF6A6A", colour="darkgray", binwidth=10000, alpha=0.6) +
    labs(title = "Histogram zarobków na początku kariery i po 10 latach (skala w 10000$)",
      x="Zarobki w dollarach ($)",
      y="Ilość kierunków w danym przedziale",
      subtitle="niebieski - początek kariery a czerwony - po 10 latach"
    ) +
  theme_bw() +
  theme(legend.position = "right")


library(datawizard)
degreestart <- data_rotate(degreestart, colnames = TRUE)
(degreestart$STEM/degreestart$Others)[1]
degreestart$STEM[1]/degreestart$Others[1]
degreestart$STEM[1]-degreestart$Others[1]
degreestart
' ====================================
degreestart <- data.frame(t(as.matrix(degreestart)))
degreestart <- round(degreestart, 0)
'

degreemid <- degree %>% group_by(category) %>%
  summarise(
    mean_mid = mean(career_mid),
    median_mid = median(career_mid),
    max_mid = max(career_mid),
    min_mid = min(career_mid),
    range_mid = max(career_mid)-min(career_mid),
    sd_mid = sd(career_mid),
  )
degreemid <- data_rotate(degreemid, colnames = TRUE)
degreemid$STEM[1]/degreemid$Others[1]
degreemid

degree %>% 
  arrange(desc(career_start)) %>%
  ggplot(
    aes(y = reorder(major, career_start), x = career_start, fill=category)
  ) +
  geom_col(colour='darkgray', alpha = 0.5) +
  geom_col(
    aes(y = reorder(major, career_mid), x = career_mid), alpha=0.2
  ) +
  scale_fill_manual(values=c('pink1', 'skyblue1')) +
  labs(
    title = "Kierunki i ich zarobki na początku jak i po 10 latach",
    x = "Zarobki w dollarach ($)",
    y = NULL,
  ) + theme_bw()

'
ggplot(data=(degreesThatPay %>% arrange(desc(Starting.Median.Salary))), aes(x=Undergraduate.Major, y=Starting.Median.Salary)) + geom_col()
'

# ============== Pytanie 2 - Pytanie 2: Dynamika wzrostu wynagrodzeń  
#Cel: Identyfikacja kierunków o największym i najmniejszym przyroście płac w czasie. Sprawdzenie, czy absolwenci nauk humanistycznych z czasem niwelują dystans finansowy do grup technicznych.

glimpse(degree)

degree %>%
  arrange(desc(p_change)) %>%
  head(15) %>%
  ggplot(aes(x=reorder(major, p_change), y=p_change, fill=category)) + 
  geom_col(width=0.8) +
  scale_fill_manual(values=c('burlywood2', 'skyblue1')) +
  coord_flip() +
  labs(title = "Największe zmiany procentowe kariery: Start vs po 10 latach",
       x = "Kierunki Studiów",
       y = "Zmiana wyrażona w procentach (%)") + theme_bw()

degree %>%
  arrange(desc(p_change)) %>%
  tail(15) %>%
  ggplot(aes(x=reorder(major, p_change), y=p_change, fill=category)) + 
  geom_col(width=0.8) +
  scale_fill_manual(values=c('burlywood2', 'skyblue1')) +
  coord_flip() +
  labs(title = "Największe zmiany procentowe kariery: Start vs po 10 latach",
       x = "Kierunki Studiów",
       y = "Zmiana wyrażona w procentach (%)") + theme_bw()

degree %>% 
  group_by(type) %>% 
  top_n(5, career_mid) %>%
  ggplot(aes(y = reorder(major, career_mid), color=type)) +
  geom_segment(aes(x=career_start, xend=career_mid), size=1.2) +
  geom_text(aes(x=(career_start+career_mid)/2, label=paste0(p_change, "%")), nudge_y=0.3, color='black') +
  geom_point(aes(x=career_start, y=major), colour='palegreen4') +
  geom_point(aes(x=career_mid, y=major), colour='orchid4') +
  theme_bw() +
  scale_color_manual(values=c('Engineering'='deepskyblue2', 'Mathematics'='deepskyblue4', 'Science'='darkseagreen4', 'Technology'='seagreen3', 'Business'='plum3')) +
  labs(
    title = "Top3 Kierunki z każdego rodzaju nauki - i ich wzrost z początku do środka kariery",
    x = "Zarobki w ($)",
    y = NULL,
    subtitle = "Zmiana procentowa między początkiem a środkiem kariery - podana nad linią wykresu"
  ) + 
  scale_x_continuous(limits= c(min(degree$career_start),max(degree$career_mid))) 

cor_data <- degree %>%
  mutate(
    is_stem = ifelse(category == "STEM", 1, 0)
    ) %>%
  select(is_stem, career_start, career_mid, p_change)  

cor = cor(cor_data)
corrplot(cor, 
         method = "color",       
         type = "upper",         
         tl.col = "black",  
         tl.srt = 45,
         diag = FALSE)

### Pytanie 3: Wewnętrzna hierarchia "Imperium STEM".  
#Cel: Analiza porównawcza subdziedzin (Science, Technology, Engineering, Mathematics) w celu wskazania profilu o najwyższym potencjale dochodowym.
degree %>%
  filter(category=="STEM") %>%
  ggplot(
    aes(y = reorder(major, career_start), x = career_start, fill = type)) +
  geom_col(colour='darkgray', alpha = 0.5) +
  scale_fill_manual(values=c('deepskyblue2', 'deepskyblue4', 'darkseagreen4', 'seagreen3')) +
  geom_col(
    aes(y = reorder(major, career_mid), x = career_mid), alpha=0.3) +
  labs(
    title = "Subdziedziny STEM - kto króluje",
    x = "Zarobki w dollarach ($)",
    y = NULL,
    subtitle = "Porównanie początków kariery i środkowych zarobków"
  ) + theme_bw()



## Sekcja II: Analiza ryzyka i finansowa siatka bezpieczeństwa  
#Cel: Ocena stabilności dochodów i wytropienie nieoczywistych ścieżek sukcesu.

### Pytanie 4: Bezpieczny wybór vs. hazard zawodowy.  
#Cel: Analiza rozpiętości między 10- a 90- percentylem płac. Wskazanie kierunków "bezpiecznych" (z małą wariancja) oraz tych o wysokim risk/reward (duże dysproporcje).

degree %>% ggplot(aes(x = reorder(type, career_mid, FUN = median), y = career_mid, fill = type)) +
  geom_boxplot(alpha = 0.7) +
  coord_flip() +
  scale_y_continuous(limits= c(60000, 110000)) +
  theme_bw() +
  scale_fill_manual(values=c('Engineering'='deepskyblue2', 'Mathematics'='deepskyblue4', 'Science'='darkseagreen4', 'Technology'='seagreen3', 'Liberal Arts'='plum1', 'Business'='plum4')) +
  labs(title = "Stabilność vs. Ryzyko finansowe",
       subtitle = "Rozkład zarobków w środku kariery według typu edukacji",
       x = NULL, 
       y = "Wynagrodzenie ($)") +
  theme(legend.position = "none")

degreerisk <- degree %>% 
  filter(!is.na(p10_salary) & !is.na(p90_salary)) %>%
  mutate(
    risk25 = p75_salary - p25_salary,
    risk10 = p90_salary - p10_salary
  ) 

degreerisk %>%
  group_by(type) %>%
  top_n(5, career_mid) %>%
  ggplot(
    aes(y = reorder(major, p75_salary))
    ) +
  geom_segment(
    aes(x=p25_salary, xend=p75_salary, yend=major), size=1.2, colour='darkgray') +
  geom_point(
    aes(x=p25_salary, y=major), colour='palegreen4') +
  geom_point(
    aes(x=p75_salary, y=major), colour='orchid4') +
  geom_text(
    aes(x=(p25_salary+p75_salary)/2, label = risk25), nudge_y=0.3) +
  theme_bw() +
  labs(
    title = "Rozpiętość płac",
    x = "Wynagrodzenie w ($)",
    y = NULL,
    subtitle = "Różnica między najlepiej a najgorzej zarabiającymi absolwentami"
  ) + 
  scale_x_continuous(limits= c(min(degree$p25_salary),max(degree$p75_salary))) 



### Pytanie 5: Sufit zarobków: STEM vs. Biznes.  
#Cel: Sprawdzenie, która z grup szybciej osiąga maksimum potencjału zarobkowego (analiza 90- percentyla w połowie kariery). (z osobistej ciekawości studiując Informatyke na Wydziale Zarządzania)

outlierstable <- degreerisk %>%
  filter(type == "Business" | category=="STEM") %>%
  mutate(
    growth = p90_salary / career_start) %>%
  arrange(desc(growth)) %>%
  head(5) %>%
  select(major, type, career_start, p90_salary, growth)

kable(outlierstable)

degree %>% 
  filter(type == "Business" | category=="STEM") %>%
  ggplot(aes(x = career_start, y = p90_salary, color = type)) +
  geom_point(size = 3, alpha = 0.6) +
  geom_smooth(method = "lm", se=F) +
  theme_bw() +
  scale_color_manual(values=c('Engineering'='deepskyblue2', 'Mathematics'='deepskyblue4', 'Science'='darkseagreen4', 'Technology'='seagreen3', 'Business'='plum4')) +
  labs(
    title = "Relacja: Start kariery vs. Szczyt finansowy",
    x = "Płaca początkowa",
    y = "90. percentyl zarobków"
    )

### Pytanie 6: Anomalie humanistyczne (Outliers).  
#Cel: Identyfikacja konkretnych kierunków spoza grupy STEM, które statystycznie odstają od swojej grupy i dorównują zarobkami inżynierom.

glimpse(degree)

degree %>% 
  filter(category=="Others") %>%
  ggplot(aes(x = reorder(type, career_mid), y = career_mid, fill = type)) +
  geom_boxplot(alpha = 0.7) +
  coord_flip() +
  theme_bw() +
  scale_fill_manual(values=c('Liberal Arts'='plum1', 'Business'='plum4')) +
  labs(title = "Stabilność vs. Ryzyko finansowe",
       subtitle = "Rozkład zarobków w środku kariery według typu edukacji",
       x = NULL, 
       y = "Wynagrodzenie ($)") +
  theme(legend.position = "none")

outlierstable <- degree %>%
  mutate(
    growth = p90_salary / career_start) %>%
  arrange(desc(multiplier)) %>%
  head(10) %>%
  select(major, type, career_start, p90_salary, multiplier)

kable(outlierstable)

outliersname <- degree %>%
  filter(category == "Others") %>%
  arrange(desc(p90_salary)) %>%
  slice(1:5)

degree %>% 
  filter(category=="Others") %>%
  ggplot(aes(x = career_start, y = p90_salary, color = type)) +
  geom_point(size = 3, alpha = 0.6) +
  geom_text_repel(data = outliersname, 
                  aes(label = major), 
                  size = 3)+
  geom_smooth(method = "lm", se=F) +
  theme_bw() +
  scale_color_manual(values=c('Liberal Arts'='plum1', 'Business'='plum4')) +
  labs(
    title = "Anomalie dla kierunków nie-STEM",
    x = "Płaca początkowa",
    y = "90. percentyl zarobków"
  )

## Sekcja III: Wpływ instytucji i geografii
#Cel: Analiza czynników zewnętrznych: prestiżu uczelni oraz lokalizacji.

### =========== Pytanie 7: Prestiż Ivy League vs. praktyczność State Schools.
#Cel: Bezpośrednie porównanie: czy "historyk z Harvardu" zarabia więcej niż "informatyk z uczelni stanowej"? Czy marka uczelni niweluje różnice między kierunkami?
  
glimpse(college)
list(college$type)

head(college)
head(region)

table(college$type)
table(region$Region)

ggplot(college, aes(x = type, y = career_mid, fill = type)) +
  geom_boxplot() +
  coord_flip() +
  theme_bw() +
  scale_fill_manual(values=c('Engineering'='plum1', 'Ivy League'='plum3', 'Liberal Arts'='hotpink3', 'Party'='lightblue4', 'State'='skyblue2')) +
  labs(
    title = "Wykres pudełkowy według typu uczelni",
    x = "Wynagrodzenie po 10 latach w ($)",
    y = "Typ uczelnii"
  )

Q1 <- quantile(college$career_mid, 0.25, na.rm = TRUE)
Q3 <- quantile(college$career_mid, 0.75, na.rm = TRUE)
IQR_value <- Q3 - Q1

gorna_granica <- Q3 + 1.5 * IQR_value
dolna_granica <- Q1 - 1.5 * IQR_value

outliers_list <- college %>%
  filter(career_mid > gorna_granica | career_mid < dolna_granica)

kable(outliers_list %>% select(university, type, career_mid))

ivystate <- college %>%
  filter(type %in% c("Ivy League", "State", "Engineering")) %>%
  group_by(type) %>%
  summarise(
    school_count = n(),
    median_start = median(career_start, na.rm = TRUE),
    median_mid = median(career_mid, na.rm = TRUE),
    p10 = median(p10_salary, na.rm = TRUE),
    p90 = median(p90_salary, na.rm = TRUE),
    max_mid = max(career_mid, na.rm = TRUE)
  ) %>%
  arrange(desc(median_mid))

kable(ivystate)

college %>%
  filter(type %in% c("Ivy League", "State", "Engineering")) %>%
  arrange(desc(career_mid)) %>%
  head(20) %>%
  ggplot(
    aes(x = career_mid, y = reorder(university, career_mid), fill = type)) +
  geom_col() +
  scale_fill_manual(values=c('Engineering'='plum1', 'Ivy League'='plum3', 'State'='skyblue2')) +
  theme_bw() +
  labs(title = "Szczyt wynagrodzenia",
       subtitle = "Top 20 uczelni pod względem zarobków w środku kariery",
       x = "Mediana zarobków w ($)",
       y = NULL)

### Pytanie 8: Stabilność finansowa a profil uczelni.
#Cel: Porównanie rozkładów gęstości zarobków dla różnych typów szkół (Party, Engineering, Liberal Arts, Ivy League).

college %>%
  ggplot(aes(x = career_mid, fill = type)) +
  geom_density(alpha = 0.5) +
  theme_bw() +
  scale_fill_manual(values=c('Engineering'='plum1', 'Ivy League'='plum3', 'Liberal Arts'='hotpink3', 'Party'='lightblue4', 'State'='skyblue2')) +
  labs(title = "Rozkład prawdopodobieństwa zarobków wg typu uczelni",
       x = "Wynagrodzenie Mid-Career w ($)",
       y = "Gęstość występowania",
       fill = "Typ uczelni")
  

### Pytanie 9: Geografia sukcesu: Regiony USA.
#Cel: Weryfikacja różnic płacowych między regionami (np. Northeast vs. Midwest). Sprawdzenie, co ma silniejszy wpływ na płacę: lokalizacja czy typ uczelni.

region %>%
  group_by(Region) %>%
  top_n(3, career_mid) %>%
  ggplot(aes(x = Region, y = university, fill = career_mid)) +
  geom_tile() +
  scale_fill_gradient(low = "lightgray", high = "steelblue") +
  theme_minimal() +
  labs(title = "Ranking regionalny",
       x = "Region",
       y = NULL,
       fill = "Zarobki Mid-Career") +
  theme(axis.text.x = element_text(angle = 90, hjust=1)) +
  coord_flip()

region %>%
  group_by(Region) %>%
  summarise(
    median_start = median(career_start, na.rm = TRUE),
    median_mid = median(career_mid, na.rm = TRUE),
    p10 = median(p10_salary, na.rm = TRUE),
    p90 = median(p90_salary, na.rm = TRUE)
  ) %>%
  pivot_longer(cols = -Region, names_to = "Etap", values_to = "Zarobki") %>%
  ggplot(aes(x = Region, y = Etap, fill = Zarobki)) +
  geom_tile(color = "white") +
  scale_fill_gradient(low = "white", high = "steelblue")+
  theme_bw() +
  labs(title = "Finansowa mapa USA",
       subtitle = "Średnie zarobki w regionach na różnych etapach kariery",
       x = "Region",
       y = "Poziom wynagrodzenia",
       fill = "Kwota w ($)")


### Pytanie 10: "Złoty bilet" – Synteza wyników.
#Cel: Podsumowanie analizy i próba wskazania optymalnej kombinacji (kierunek + typ uczelni + region), która statystycznie daje największą pewność sukcesu finansowego.