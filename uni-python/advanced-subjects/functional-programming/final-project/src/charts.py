import plotly.express as px
import seaborn as sns
import matplotlib.pyplot as plt
import altair as alt

# === Pogoda
def plot_yearly_temp(df):
    """Plotly: Wykres liniowy temperatury"""
    fig = px.line(df, x='date', y='temp',
                  title="Rozkład temperatur w Krakowie (Skala roczna)",
                  color_discrete_sequence=['orange'])
    return fig

def plot_correlation_heatmap(df):
    """Seaborn: Macierz korelacji zanieczyszczeń i pogody"""
    cols = ['pm10', 'pm2_5', 'no2', 'temp', 'wind', 'humidity']
    corr = df[cols].corr()

    fig, ax = plt.subplots(figsize=(10, 8))
    sns.heatmap(corr, annot=True, cmap='coolwarm', fmt=".2f", ax=ax)
    plt.title("Korelacja: Jak czynniki pogody z sobą interagują")
    return fig

def plot_yearly_temp_pm10(df):
    """Plotly: Wykres liniowy temperatury"""
    fig = px.line(df, x='date', y=['temp', 'pm10'],
                  title="Rozkład temperatur a zanieczyszczenia",
                  color_discrete_sequence=['orange', 'blue'])
    return fig


# === Zanieczyszczenie
def plot_pm_timeline(df):
     """Plotly: wykres liniowy pyłów"""
     fig = px.line(df, x='date', y=['pm10', 'pm2_5'],
                   title="Poziom pyłów PM10 i PM2.5 w czasie",
                   labels={'value': 'Stężenie [µg/m³]', 'date': 'Data'},
                   )
     return fig

def plot_winter_smog(df):
    """Seaborn: Regresja"""
    winter_df = df[df['date'].dt.month.isin([12, 1, 2])]

    fig, ax = plt.subplots(figsize=(10, 6))
    sns.regplot(data=winter_df, x='temp', y='pm10',
                scatter_kws={'alpha': 0.3, 'color': 'lightblue'},
                line_kws={'color': 'darkred'}, ax=ax)
    ax.set_title("Zależność PM10 od temperatury (Zima)")
    ax.set_xlabel("Temperatura [°C]")
    ax.set_ylabel("Stężenie PM10 [µg/m³]")
    return fig

def plot_pm10_vs_wind(df):
    """Bardzo biedny matplotlib"""
    summer_df = df[df['date'].dt.month.isin([4, 5, 6, 7, 8])]

    fig, ax = plt.subplots(figsize=(10, 6))
    ax.scatter(summer_df['wind'], summer_df['pm10'], c='lightblue', alpha=.5)
    ax.set_title("Zależność PM10 od wiatru (Lato)")
    ax.set_xlabel("Prędkość wiatru [km/h]")
    ax.set_ylabel("Stężenie PM10 [µg/m³]")
    return fig




# === NO2
def plot_no2_timeline(df):
    """Plotly: wykres liniowy smogu"""
    fig = px.line(df, x='date', y='no2',
                  title="Poziom NO2 w czasie",
                  labels={'value': 'Stężenie [µg/m³]', 'date': 'Data'})
    return fig

def plot_traffic_peak(hourly_df):
    """Altair: Wykres liniowy NO2 wzgledem godziny"""
    chart = alt.Chart(hourly_df).mark_line(point=True).encode(
        x=alt.X('hour', title='Godzina dnia'),
        y=alt.Y('no2', title='Średnie stężenie NO2'),
        tooltip=['hour', 'no2']
    ).properties(title="Szczyt komunikacyjny: Średnie stężenie NO2 w ciągu doby")
    return chart

def plot_no2_vs_wind(df):
    """Altair: Wykres punktowy NO2 względem wiatru"""
    chart = alt.Chart(df).mark_circle(size=60).encode(
        x=alt.X('wind', title='Prędkość wiatru [km/h]'),
        y=alt.Y('no2', title='Stężenie NO2 [µg/m³]'),
        color='aqi_index',
        tooltip=['date', 'no2', 'wind']
    ).properties(title="Korelacja wiatru a stężenia NO2")
    return chart


