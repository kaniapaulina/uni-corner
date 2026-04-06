# Return on Investment — Education
### Czy ścieżka STEM to jedyna droga do sukcesu w Stanach Zjednoczonych?

Projekt EDA badający zależności między kierunkiem studiów, typem uczelni i regionem a przyszłymi zarobkami absolwentów w USA.

---

## 📁 Struktura repozytorium

```
├── eda-project.ipynb               # Główny notebook z analizą
├── degrees-that-pay-back.csv       # Zarobki wg kierunku studiów (50 kierunków)
├── salaries-by-college-type.csv    # Zarobki wg typu uczelni (269 szkół)
├── salaries-by-region.csv          # Zarobki wg regionu USA (320 szkół)
└── README.md
```

---

## Dane

Źródło: [Kaggle — College Salaries (WSJ)](https://www.kaggle.com/datasets/wsj/college-salaries)

**Uwaga:** Dane pochodzą sprzed ok. 9 lat — trendy pozostają aktualne, ale konkretne kwoty mogą odbiegać od dzisiejszego rynku, szczególnie w sektorze technologicznym (AI, post-pandemia).

---

##  Pytania badawcze i wizualizacje

| # | Pytanie | Typ wykresu |
|---|---------|-------------|
| 1 | Dominacja STEM — statystyki opisowe | tabela, histogram |
| 2 | Prędkość wzrostu wynagrodzeń | dumbbell chart, bar chart |
| 3 | Które subkategorie STEM zarabiają najwięcej? | grouped bar chart |
| 4 | Kierunki „bezpieczne" vs. high risk/reward | boxplot |
| 5 | Rozpiętość płac (P25 vs P75) | dumbbell chart |
| 6 | Korelacje między zmiennymi | heatmapa korelacji |
| 7 | Typ uczelni a zarobki (Ivy League vs Engineering vs State) | boxplot, statystyki |
| 8 | Rozkład zarobków wg typu uczelni | KDE density plot |
| 9 | Porównanie regionów USA | tabela statystyk |
| 10 | Podsumowanie — pełny krajobraz opłacalności studiów | grouped bar chart |

---

##  Technologie:

`pandas`, `numpy`, `matplotlib`, `seaborn`

**Python 3.10+**

---

## Uruchomienie

```bash
git clone https://github.com/kaniapaulina/roe-of-education.git
cd roe-of-education
pip install pandas numpy matplotlib seaborn
jupyter notebook eda-project.ipynb
```
