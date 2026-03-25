
import pandas as pd
import numpy as np

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
    google_df = pd.read_csv("ex2/googl_us_d.csv")
    amazon_df = pd.read_csv("ex2/amzn_us_d.csv")
    microsoft_df = pd.read_csv("ex2/msft_us_d.csv")

    #merged_data_2 = pd.merge(google_df, amazon_df, on='Data', how='inner')
    #merged_data_3 = pd.merge(merged_data_2, microsoft_df, on='Data', how='inner')

    #with pd.option_context('display.max_columns', None):
    #    print(merged_data_3.head())
    pd.set_option('display.max_columns', None)

    print(google_df.head())
    print(google_df.shape)
    print(google_df.dtypes)
    print(google_df.info())
    print(google_df.describe())

    google_df['Data'] = pd.to_datetime(google_df['Data'])
    #google_df.fillna(method="ffil")
    google_df = google_df.ffill()

    # ZMIANA CENY ZAMKNIECIA
    for i in range(1, len(google_df)):
        google_df.at[i, 'Zmiana'] = "%0.2f" % (round(google_df.at[i, 'Zamkniecie']/google_df.at[i-1,'Zamkniecie'], 2))

    google_df['Zmiana - Stopa zwrotu'] = google_df['Zamkniecie'].pct_change()

    # SREDNIA RUCHOMA - SMA
    sum = 0
    for i in range(0, len(google_df)):
        sum += google_df.at[i, 'Zamkniecie']
        google_df.at[i, 'SMA'] = sum / (i+1)

    google_df['Srednia Ruchoma'] = google_df['Zamkniecie'].rolling(window=5).mean()

    # WARUNKI, kiedy zmiana była wieksza niż 2%
    print("\n")
    print(google_df[google_df['Zmiana - Stopa zwrotu'] > 0.02])

    # NAJWIEKSZA STOPA ZWROTU
    print("\n")
    print(google_df['Zmiana - Stopa zwrotu'].idxmax())

    print("\n")
    print(google_df.head())
    print(google_df.info())

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

    statistics_region = wholesale_df.groupby('Region').mean()
    print(statistics_region)

    statistics_alt = wholesale_df.describe()
    print(statistics_alt)

    korelacja = wholesale_df.corr()
    print(korelacja)

    klienci_premium = wholesale_df[wholesale_df['Fresh'] > wholesale_df['Fresh'].quantile(0.95)]
    print(klienci_premium)


def zad5():
    dane = pd.read_excel("Miasta.xlsx", sheet_name=None)
    print(dane.keys())

    poland_df = dane['Poland']
    print(poland_df.info())
    print(poland_df.head())

    statystyki = poland_df.describe()
    print(statystyki)

    srednie_wojewodztwa = poland_df.groupby('admin_name')['population'].mean()
    print(srednie_wojewodztwa.sort_values(ascending=False))

    progi = [0, 20000, 100000, np.inf]
    etykiety = ['small', 'medium', 'big']
    poland_df['City Size'] = pd.cut(poland_df['population'], bins=progi, labels=etykiety)
    print(poland_df['City Size'].value_counts())

def play():
    match int(input("Podaj numer zadania: ")):
        case 1:
            zad1()
        case 2:
            zad2()
        case 3:
            zad3()
        case 5:
            zad5()
        case _:
            print("Podałes zły numer")

play()