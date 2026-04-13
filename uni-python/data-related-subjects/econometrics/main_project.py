"""
Projekt - Ekonometria
1. Zebranie danych - data_loader.py, data_processor.py
2. Analiza rozkładów zmiennych i ich zależności
3. Dobór zmiennych i estymacja modelu
4. Podział na zbiór treningowy i testowy
5. Diagnostyka
6. Poprawa modelu
7. Predykcja na zbiór testowy i analiza błędów ex post
8. Podsumowanie (w tym interpretacja parametrów).
"""

"""
PLAN DZIAŁAŃ:
1. rozklady - log-returns bo inaczej regresja bedzie pozorna
2. korelacje sprawedzamy
3. train 80% danych, test reszta
4. estymacja modelu i diagnostyka - czyli hellwg potem testy
5. Normalność reszt: Test Jarque-Bera. 
6. Autokorelacja: Test Durbina-Watsona
7. Homoskedastyczność: Test White'a lub Breuscha-Pagana 
8. predykacja: OLS biblioteka statsmodel
9. ex post  MSE, RMSE, MAE
10. test chow
"""

import pandas as pd
import numpy as np
from functools import reduce

def compose(*funcs):
    return lambda initial: reduce(lambda acc, f: f(acc),reversed(funcs),initial)

"""
MODEL:
Zmienna objaśniana:
- PLN=X - zmiana dollara wyrażona w złotówkach

Zmienne objaśniane: 
- CL=F,EURUSD=X,GC=F,^GSPC,^VIX,une_rt_m,T10Y2Y,TRESEGUSM052N,TRESEGPLM052N
"""

def data_reader():
    """
    Zebranie danych - data_loader.py, data_processor.py
    """
    df = pd.read_csv("data/merged_data.csv")
    df['Date'] = pd.to_datetime(df['Date'])
    df = df.set_index('Date')
    df = df.dropna()
    return df

def analize_data(df):
    """
    Analiza rozkładów zmiennych i ich zależności
    """
    print("=== Projekt: Zmienność kursu dollara w złotówkach ===\n")

    rows, columns = df.shape
    print(f"Zestaw danych zawiera {rows} obserwacji x {columns} zmiennych i daty jako index\n")
    print(f"Lista dostępnych zmiennych: {df.columns.values.tolist()}\n")

    stats = df.agg(['mean', 'median', 'std', 'min', 'max', 'kurtosis', 'skew'])
    print(f"Statystyki: \n {stats}\n")

    return df

def log_return(df):
    """
    Modele liniowe z wykorzystaniem logarytmicznych stóp zwrotu (log returns) są fundamentem ekonometrii finansowej. Pozwalają one przekształcić nieliniowe zależności (np. wykładniczy wzrost cen) w liniowe, co umożliwia zastosowanie klasycznej metody najmniejszych kwadratów (MNK).
    """
    log = lambda x: np.log(x.astype(float)/x.astype(float).shift(1))
    return df.apply(log, axis=0)


# === FINAL FUNCTION ===
def econometrics_project():
    pd.set_option('display.max_columns', None)

    df = data_reader()
    print(f"\n{df.head()}\n")

    # Potok wszystkich funkcji od prawej do lewej
    pipeline = compose(
        analize_data
    )

    wynik = pipeline(df)

    print(f"\n{wynik.head()}\n")





# =========== ŚCIANA PŁACZU
if __name__ == "__main__":
    econometrics_project()