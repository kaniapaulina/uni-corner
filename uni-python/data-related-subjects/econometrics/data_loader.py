""""""
import os
import datetime
import yfinance as yf
import pandas_datareader.data as dr
from pandas_datareader import wb
import eurostat

# === Dane ===
"""
Zmienna Objaśniana: 
PLN=X (Kurs USD/PLN)

Zmienne Objaśniające:
Dzienne (Yahoo Finance):
SD/PLN (Y) - PLN=X - Kurs bazowy dla Twojego projektu.
Cena Ropy - CL=F - Kontrakty terminowe na ropę Crude Oil WTI.
Cena Złota - GC=F - Kontrakty terminowe na złoto (bezpieczna przystań).
S&P 500 - ^GSPC - Główny indeks giełdy w USA.
WIG20 - ^WIG20 - Główny indeks GPW 
EUR/USD - EURUSD=X - Kluczowa para walutowa 
VIX - ^VIX - Indeks zmienności (strachu) z Yahoo.

Miesięczne (FRED):
Różnica stóp - T10Y2Y 
T10Y2Y (Yield Curve Spread) - Różnica między rentownością obligacji 10-letnich a 2-letnich USA. To najsłynniejszy wskaźnik nadchodzącej recesji. Używa się go do oceny cyklu koniunkturalnego.
Rezerwy Walutowe Polski- TRESEGPLM052N

Roczne (FRED):
Inflacja USA - FPCPITOTLZGUSA
Inflacja Polska - FPCPITOTLZGPOL
FDI Polski - BXKLTDIWDCDPL

Roczne (World Bank Database):
BX.KLT.DINV.CD.WD (FDI, net inflows w USD).
FI.RES.XGLD.CD (Total reserves w USD).

Miesieczne (Eurostat):
une_rt_m (Unemployment by sex and age).
"""

start_date = datetime.datetime(2019, 1, 1)
end_date = datetime.datetime(2025, 12, 31)

def make_folders():
    folders = ['yahoo', 'eurostat', 'world_bank', 'fred']
    for folder in folders:
        if not os.path.exists(folder):
            os.makedirs(folder)


def yahoo_data():
    tickers = ["PLN=X", "CL=F", "GC=F", "^GSPC", "EURUSD=X", "^VIX"]
    for ticker in tickers:
        try:
            url = f"data/yahoo/{ticker}.csv"
            df = yf.download(
                ticker,
                start_date,
                end_date,
                interval="1d",
                auto_adjust=True,
                progress=False
            )
            df.to_csv(url)
        except Exception as e:
            print(f"Błąd przy pobieraniu {ticker}: {e}")

def fred_data():
    ids = ["T10Y2Y", "TRESEGPLM052N", "TRESEGUSM052N", "FPCPITOTLZGUSA", "FPCPITOTLZGPOL"]
    for id in ids:
        try:
            url = f"data/fred/{id}.csv"
            df = dr.DataReader(
                id,
                'fred',
                start_date,
                end_date
            )
            df.to_csv(url)
        except Exception as e:
            print(f"Błąd przy pobieraniu {id}: {e}")

def wb_data():
    indicators = ['BX.KLT.DINV.CD.WD', 'FI.RES.XGLD.CD']
    countries = ['US', 'PL']
    for country in countries:
        for indicator in indicators:
            try:
                url = f"data/world_bank/{country}={indicator}.csv"
                df = wb.download(
                    indicator=indicator,
                    country=country,
                    start=start_date.year,
                    end=end_date.year
                ).reset_index()
                df.to_csv(url, index=False)
            except Exception as e:
                print(f"Błąd przy pobieraniu {indicator} {country}: {e}")

def eurostat_data():
    code = 'une_rt_m'
    url = f"data/eurostat/{code}.csv"
    df = eurostat.get_data_df(code)

    df = df[(df['geo\\TIME_PERIOD'] == 'PL') & (df['age'] == 'TOTAL') & (df['unit'] == 'PC_ACT') & (df['sex'] == 'T') & (df['s_adj'] == 'SA')]
    df = df.drop(df.columns[-2:], axis = 1)
    df = df.drop(df.columns[0:438], axis = 1)
    df = df.T
    df.to_csv(url)

def get_data():
    yahoo_data()
    fred_data()
    wb_data()
    eurostat_data()

get_data()
