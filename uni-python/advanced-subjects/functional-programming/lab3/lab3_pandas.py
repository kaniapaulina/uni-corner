
import pandas as pd
#import numpy as np

# ZADANIE 1
def zad1():
    market_df = pd.read_csv("market.csv")

    print(market_df.info())
    print(market_df.head())

    print(f"a) Ilość transakcji: {len(market_df)}")
    print(f"b) Suma Wartości wszystkich transakcji: {market_df['cena'].sum()}")

    #print(market_df.groupby('nazwa').count())
    #print(market_df['nazwa'][market_df.head().sort(market_df['nazwa'].count())])
    print(f"Trzy najczęściej handlowane spółki: \n {market_df['nazwa'].value_counts().head(3)}")
    print(f"Trzy spółki na których obrót transakcji był najwyższy: \n {market_df.groupby('nazwa').sum().sort_values(by=['cena'], ascending=False).head(3)}")

# ZADANIE 2
def zad2():
    google_df = pd.read_csv("ex2/googl_us_m.csv")
    amazon_df = pd.read_csv("ex2/amzn_us_m.csv")
    microsoft_df = pd.read_csv("ex2/msft_us_m.csv")

    #merged_data_2 = pd.merge(google_df, amazon_df, on='Data', how='inner')
    #merged_data_3 = pd.merge(merged_data_2, microsoft_df, on='Data', how='inner')

    #with pd.option_context('display.max_columns', None):
    #    print(merged_data_3.head())
    pd.set_option('display.max_columns', None)

    print(google_df.head())
    print(google_df.shape)

    # ZMIANA CENY ZAMKNIECIA
    for i in range(1, len(google_df)):
        google_df.at[i, 'Zmiana'] = "%0.2f" % (round(google_df.at[i, 'Zamkniecie']/google_df.at[i-1, 'Zamkniecie'], 2))

    # SREDNIA RUCHOMA - SMA
    sum = 0
    for i in range(0, len(google_df)):
        sum += google_df.at[i, 'Zamkniecie']
        google_df.at[i, 'SMA'] = sum / (i+1)

    print(google_df.head())

    # i am out: 0.05 sec

def zad3():
    pd.set_option('display.max_columns', None)
    wholesale_df = pd.read_csv("https://archive.ics.uci.edu/ml/machine-learning-databases/00292/Wholesale%20customers%20data.csv")

    # Usuwanie brakujących danych
    wholesale_df.dropna()

    # Statystyki Opisowe
    """
    statistics = []
    for row in round(wholesale_df.mean(), 2):  
        statistics.append(row)
    print(statistics)
    """
    statistics = round(wholesale_df.agg(['mean', 'median', 'min', 'max', 'std']), 2)
    print(statistics)





def play():
    match int(input("Podaj numer zadania: ")):
        case 1:
            zad1()
        case 2:
            zad2()
        case 3:
            zad3()
        case _:
            print("Podałes zły numer")

play()