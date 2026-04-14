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
from itertools import combinations
import seaborn as sns
from matplotlib import pyplot as plt
from statsmodels import stats
from statsmodels.stats.diagnostic import het_breuschpagan, linear_reset
from statsmodels.stats.stattools import durbin_watson
import statsmodels.formula.api as smf
from scipy import stats

def compose(*funcs):
    return lambda initial: reduce(lambda acc, f: f(acc),reversed(funcs),initial)

"""
MODEL:
Zmienna objaśniana:
- PLN=X - zmiana dollara wyrażona w złotówkach

Zmienne objaśniane: 
- CL=F,EURUSD=X,GC=F,^GSPC,^VIX,une_rt_m,T10Y2Y,TRESEGUSM052N,TRESEGPL M052N
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

    column = ['PLN=X'] + [c for c in df.columns if c != 'PLN=X']
    df = df.reindex(columns=column)

    rows, columns = df.shape
    print(f"Zestaw danych zawiera {rows} obserwacji x {columns} zmiennych i daty jako index\n")
    print(f"Lista dostępnych zmiennych: {df.columns.values.tolist()}\n")

    stats = df.agg(['mean', 'median', 'std', 'min', 'max', 'kurtosis', 'skew'])
    print(f"Statystyki: \n {stats}\n")

    print(f"Korelacja: {df.corr().round(3)}\n")

    fig, ax = plt.subplots()
    sns.heatmap(data=df.corr(), annot=True, fmt=".2f", ax=ax)
    ax.set_title("Macierz Korelacji")
    plt.show()

def log_return(df):
    """
    Modele liniowe z wykorzystaniem logarytmicznych stóp zwrotu (log returns) są fundamentem ekonometrii finansowej. Pozwalają one przekształcić nieliniowe zależności (np. wykładniczy wzrost cen) w liniowe, co umożliwia zastosowanie klasycznej metody najmniejszych kwadratów (MNK).
    """
    log = lambda x: np.log(x.astype(float)/x.astype(float).shift(1))
    return df.apply(log, axis=0)

def hellwigs_method(df):
    numeric_data = df.select_dtypes(include=[np.number])
    feature_cols = [c for c in numeric_data.columns if c != "PLN=X"]

    corr_matrix = numeric_data.corr()
    print(corr_matrix)

    R0 = corr_matrix.iloc[1:len(feature_cols)+1, 0]
    R = corr_matrix.iloc[1:len(feature_cols)+1, 1:len(feature_cols)+1]

    n_vars = len(feature_cols)

    best_H = -np.inf
    best_combo = []

    for r in range(1, n_vars+1):
        for combo in combinations(range(n_vars), r):
            k = list(combo)
            H=0
            for i in k:
                mianownik = sum(abs(R.iloc[i, j]) for j in k)
                if mianownik > 0:
                    H += R0.iloc[i]**2/mianownik
            if H > best_H:
                best_H = H
                best_combo = [feature_cols[i] for i in k]

    print(f"From Hellwigs Method the best combo of data is: {best_combo}")

def test_summary(model):
    r = model.resid

    # Normalność Reszt
    stat, p = stats.shapiro(r)
    print(f'\nShapiro-Wilk (normalność reszt):')
    print(f'  W={stat:.4f}, p={p:.4f}  {"normlanosc" if p > 0.05 else "brak normalności"}')

    x, bp_p, y, z = het_breuschpagan(r, model.model.exog)
    print(f'\nBreusch-Pagan (heteroskedastyczność):')
    print(f'  p={bp_p:.4f}  {"homoskedastyczność" if bp_p > 0.05 else "heteroskedastyczność!"}')

    # Postać liniowa (RESET)
    reset_res = linear_reset(model, power=2, use_f=True)
    print(f'\nRESET (postać liniowa):')
    print(f'  p={reset_res.pvalue:.4f}  {"postac liniowa" if reset_res.pvalue > 0.05 else "zła postać modelu!"}')


    # Autokorelacja (test serii)
    dw = durbin_watson(r)
    print(f'\nDurbin-Watson: {dw:.4f}  (idealnie ~2.0)')
    print('=' * 55)

def using_test_summary(df):
    model = smf.ols('Q("PLN=X") ~ Q("CL=F") + Q("EURUSD=X") + Q("GC=F") + Q("^GSPC") + Q("^VIX") + Q("une_rt_m") + Q("T10Y2Y") + Q("TRESEGUSM052N") + Q("TRESEGPLM052N")', data=df).fit()
    print(model.summary())
    test_summary(model)

    model = smf.ols(
        'Q("PLN=X") ~ Q("GC=F") + Q("TRESEGUSM052N")',
        data=df).fit()
    print(model.summary())
    test_summary(model)

def predict(df):
    idx = np.random.permutation(len(df))
    data_r = df.iloc[idx].reset_index(drop=True)

    train = data_r.iloc[:1500].copy()
    test = data_r.iloc[1500:].copy()

    model = smf.ols(
        'Q("PLN=X") ~ Q("CL=F") + Q("EURUSD=X") + Q("GC=F") + Q("^GSPC") + Q("^VIX") + Q("une_rt_m") + Q("T10Y2Y") + Q("TRESEGUSM052N") + Q("TRESEGPLM052N")',
        data=df).fit()

    p_fit = model.predict(test)
    e = test['PLN=X'] - p_fit

    MAE = np.mean(np.abs(e))
    RMSE = np.sqrt(np.mean(e ** 2))
    MAPE = np.mean(np.abs(e / test['PLN=X'])) * 100

    print(f'MAE:  {MAE:.2f}')
    print(f'RMSE: {RMSE:.2f}')
    print(f'MAPE: {MAPE:.2f}%')

from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_absolute_error, mean_squared_error, r2_score

def predict_ml(df):
    X = df.iloc[:, :-1]
    y = df.iloc[:, 0]

    scaler = StandardScaler()
    X_scaled = scaler.fit_transform(X)

    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

    model = LinearRegression()
    model.fit(X, y)

    print("Coefficient (Slope):", model.coef_[0])
    print("Intercept:", model.intercept_)

    y_pred = model.predict(X_test)
    predictions = pd.DataFrame({'Actual': y_test, 'Predicted': y_pred})
    print(predictions.head())

    mae = mean_absolute_error(y_test, y_pred)
    mse = mean_squared_error(y_test, y_pred)
    r2 = r2_score(y_test, y_pred)

    print("Mean Absolute Error (MAE):", mae)
    print("Mean Squared Error (MSE):", mse)
    print("R-squared Score:", r2)



# === FINAL FUNCTION ===
def econometrics_project():
    pd.set_option('display.max_columns', None)

    df = data_reader()
    print(f"\n{df.head()}\n")

    #analize_data(df)
    #hellwigs_method(df)
    #using_test_summary(df)
    #predict(df)
    #predict_ml(df)

    model = smf.ols(
        'Q("PLN=X") ~ Q("CL=F") + Q("EURUSD=X") + Q("GC=F") + Q("^GSPC") + Q("^VIX") + Q("une_rt_m") + Q("T10Y2Y") + Q("TRESEGUSM052N") + Q("TRESEGPLM052N")',
        data=df).fit()
    print(model.summary())
    print("===\n")
    print(model.rsquared)
    print("===\n")
    print(model.params)
    print("===\n")
    print(model.bse)
    print("===\n")
    print(model.predict())
    print("===\n")
    test_summary(model)




# =========== ŚCIANA PŁACZU
if __name__ == "__main__":
    econometrics_project()