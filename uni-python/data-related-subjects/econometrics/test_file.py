"""
Zebranie danych - proszę nie korzystać z "gotowych" zbiorów danych (np. Kaggle) tylko samodzielnie dobrać zmienne. Przykładowe źródła: GUS, Eurostat, stooq, Our World in Data, World Bank database
1. Analiza rozkładów zmiennych i ich zależności (czyszczenie danych, jeśli konieczne)
2. Podział na zbiór treningowy i testowy
3. Dobór zmiennych i estymacja modelu
4. Diagnostyka
5. Poprawa modelu
6. Predykcja na zbiór testowy i analiza błędów ex post
7. Podsumowanie (w tym interpretacja parametrów).
"""


# usdpln_d - kurs dolara w złotówkach
# plopln3m_d - referencyjna stopa procentowa określająca koszt pożyczek na polskim rynku międzybankowym
# etfbw20tr_d - beta etf
# ^spx_d - index spx, S&P 500 czyli top 500 firm w ameryce

"""
import yfinance as yf

# Pobierasz wszystko jednym poleceniem
tickers = ["PLN=X", "CL=F", "^GSPC", "^VIX", "^TNX", "EURUSD=X"]
data_fakowe = yf.download(tickers, start="2021-01-01", end="2024-01-01")['Close']

# Usuwasz braki danych (NaN), które wynikają z różnych świąt na giełdach
data_fakowe = data_fakowe.dropna()"""

"""
import pandas_datareader.data_fakowe as web
import datetime

start = datetime.datetime(2021, 1, 1)
end = datetime.datetime(2024, 1, 1)

# Pobieranie danych z FRED
fred_data = web.DataReader(['T10Y2Y', 'VIXCLS', 'T10YIE', 'DCOILWTICO'], 'fred', start, end)



import yfinance as yf
import pandas_datareader.data as web
import pandas as pd

# 1. Pobieranie z Yahoo Finance
yf_data = yf.download(["PLN=X", "CL=F", "GC=F", "^GSPC", "^WIG20", "EURUSD=X", "^VIX"], 
                       start="2020-01-01")['Close']

# 2. Pobieranie z FRED
fred_ids = ["T10Y2Y", "POLCPIALLMINMEI", "CPIAUCSLD", "WALCL"]
fred_data = web.DataReader(fred_ids, "fred", start="2020-01-01")

# 3. Łączenie i wyrównanie (resampling do danych miesięcznych dla stabilności Hellwiga)
df = pd.merge(yf_data, fred_data, left_index=True, right_index=True, how='outer')
df_monthly = df.resample('ME').last() # bierzemy wartości z końca miesiąca
df_monthly = df_monthly.dropna() # usuwamy ewentualne braki
"""

"""
$Y$ (Objaśniana): PLN=X (Kurs USD/PLN) lub ^WIG20 (jeśli wolisz rynek akcji).

$X$ (Kandydaci na zmienne objaśniające):

Rynek Surowców: CL=F (Ropa Crude) lub GC=F (Złoto – bezpieczna przystań).

Globalny Sentyment (Risk-on/Risk-off): ^GSPC (S&P 500) lub ^VIX (Indeks strachu – genialny do metody Hellwiga).

Rynek Długu (Interest Rate Differential): ^TNX (Rentowność 10-letnich obligacji USA) – to ona napędza dolara.

VIXCLS (CBOE Volatility Index): Indeks strachu. Jeśli chcesz sprawdzić, jak panika na rynkach wpływa na złotego (zazwyczaj go osłabia), to jest zmienna nr 1.

DCOILWTICO (Crude Oil Prices: WTI): Dzienne ceny ropy WTI. Jeśli Yahoo Finance sprawiało problemy, FRED ma dane bardzo czyste.

T10Y2Y (Yield Curve Spread): Różnica między rentownością obligacji 10-letnich a 2-letnich USA. To najsłynniejszy wskaźnik nadchodzącej recesji. W Quant Finance używa się go do oceny cyklu koniunkturalnego.

Kryptowaluty (jako proxy płynności): BTC-USD.

Konkurencyjne waluty: EURUSD=X.




from pandas_datareader import wb # Bank Światowy
import eurostat # pip install eurostat

def get_external_data():
    start_year = 2019
    end_year = 2025
    
    # --- World Bank (Roczne) ---
    print("Pobieranie z World Bank...")
    indicators = {
        'BX.KLT.DINV.CD.WD': 'FDI_PL',
        'FI.RES.XGLD.CD': 'Reserves_PL'
    }
    for code, name in indicators.items():
        df = wb.download(indicator=code, country=['PL'], start=start_year, end=end_year)
        df.to_csv(f"data/worldbank/{name}.csv")

    # --- Eurostat (Miesięczne) ---
    print("Pobieranie z Eurostat...")
    # une_rt_m to stopa bezrobocia
    df_ue = eurostat.get_data_df('une_rt_m')
    # Filtrowanie dla Polski, ogółem (Total), jednostka procentowa (PC_ACT)
    df_pl = df_ue[(df_ue['geo'] == 'PL') & (df_ue['age'] == 'TOTAL') & (df_ue['unit'] == 'PC_ACT')]
    df_pl.to_csv("data/eurostat/unemployment_pl.csv")
    
    
    
    import pandas as pd
import glob

def merge_everything():
    # 1. Wczytaj główne dane (USDPLN) i sprowadź do interwału miesięcznego (średnia)
    usd_pln = pd.read_csv("data/yahoo/PLN=X.csv", index_col=0, parse_dates=True)
    df_main = usd_pln.resample('ME').mean() # 'ME' = Month End

    # 2. Dołączaj kolejne pliki z folderów
    # Przykład dla FRED:
    for file in glob.glob("data/fred/*.csv"):
        temp_df = pd.read_csv(file, index_col=0, parse_dates=True)
        temp_df = temp_df.resample('ME').mean()
        df_main = df_main.join(temp_df, how='left')

    # 3. Interpolacja dla danych rocznych (World Bank)
    # Dane roczne będą miały dużo NaN w ujęciu miesięcznym - wypełniamy je:
    df_main = df_main.interpolate(method='linear').fillna(method='ffill')
    
    df_main.to_csv("final_model_data.csv")
    return df_main
    
"""