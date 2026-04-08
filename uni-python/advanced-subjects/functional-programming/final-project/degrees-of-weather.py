from src.data_loader import get_data
from src.data_loader import clean_data
from src.processing import *
from src.charts import *

import datetime

def load_all_data():
    lat = 50.0614  # latitude
    lon = 19.9366  # longitude
    start = "2025-01-01"
    end = "2026-01-01"

    raw_data = get_data(lat, lon, start, end, use_api=False)

    process = compose(
        clean_data,
        sort_by_date,
    )

    # Uruchamiamy potok
    return process(raw_data)



# === APP ===
import streamlit as st

st.set_page_config(page_title="🍃", layout="wide")
st.title("Powietrze w Krakowie na 2025")

data = load_all_data()

if "page" not in st.session_state:
    st.session_state.page = "Pogoda"


def set_page(name):
    st.session_state.page = name


with st.sidebar:
    # Each button updates the session state via a callback
    st.button("Pogoda", on_click=set_page, args=("Pogoda",), use_container_width=True)
    st.button("Zanieczyszczenie", on_click=set_page, args=("PM10",), use_container_width=True)
    st.button("Smog", on_click=set_page, args=("CO2",), use_container_width=True)

    st.divider()

    #limit = st.slider("Wybierz przedział czasowy", datetime.datetime(2025, 1, 1), datetime.datetime(2025, 12, 31))

    date_start = st.sidebar.date_input('start date', datetime.date(2025, 1, 1))
    date_end = st.sidebar.date_input('end date', datetime.date(2025, 12, 31))
    data['date_v'] = data['date'].dt.date
    limit_data = data[(((data['date_v'] >= date_start) & (data['date_v'] <= date_end)))].drop('date_v', axis=1)

if st.session_state.page == "Pogoda":
    stats_temp = get_statistics(data, 'temp')

    st.header("Sezonowość temperatury")
    st.warning(
        "Kraków charakteryzuje się umiarkowanym klimatem przejściowym, w którym historycznie (na przestrzeni ostatniego stulecia) obserwuje się wzrost średnich temperatur oraz wyraźne zróżnicowanie jakości powietrza.")

    daily_data_temp = get_daily_averages(limit_data, 'temp')
    st.plotly_chart(plot_yearly_temp(daily_data_temp), use_container_width=True)

    col1, col2, col3 = st.columns(3)
    col1.metric(f"Średnia wartość temperatury",
                f"{stats_temp['avg']:.1f} °C")
    col2.metric("Najwieksza wartość temperatury",
                f"{stats_temp['max']:.1f} °C")
    col3.metric("Najgorszy dzień w roku", f"{stats_temp['highest'].strftime('%Y-%m-%d')}")

    st.divider()

    st.warning(
        "Ze względu na położenie w kotlinie (otoczenie wzgórz) oraz specyfikę zabudowy, Kraków jest podatny na zjawiska inwersji temperatury (cieplejsze powietrze nad zimnym), szczególnie w chłodnych porach roku.")

    st.warning(
        "Powoduje to utrudnioną wymianę powietrza, co historycznie (wraz z rozwojem przemysłu i ogrzewaniem węglowym) prowadziło do powstawania smogu i wysokiego poziomu zanieczyszczeń pyłowych (PM10, PM2.5) w okresie jesienno-zimowym. W ostatnich dekadach obserwuje się stopniową poprawę jakości powietrza dzięki działaniom proekologicznym i wymianie źródeł ciepła.")

    col1, col2 = st.columns(2)
    with col1:
        st.pyplot(plot_correlation_heatmap(data))
    with col2:
        cor_pm10 = pearson_corr(data, 'temp', 'pm10')
        cor_hum = pearson_corr(data, 'pm10', 'humidity')
        cor_pm10_no2 = pearson_corr(data, 'no2', 'pm10')
        st.text(
            "Przy analizie korelacji pierwsze co wrzuca się w oko to silna zależność (lub bardziej antyzależność) między temperaturą a zanieczyszczeniem. Gdy jedno wzrasta drugie spada! Podobnie też jest z wiatrem a przeciwnie jest w wilgotnością powietrza. Ta osobiście zawsze kojarzyła mi się z cieżkimi wartościami i zauważalnie koreluje z zanieczyszczeniem")
        st.subheader("Korelacja")
        col1, col2, col3 = st.columns(3)
        with col1:
            st.metric("Temperatura x PM10", f"{cor_pm10:.2f}")
        with col2:
            st.metric("PM10 x Wilgotność", f"{cor_hum:.2f}")
        with col3:
            st.metric("PM10 x NO2", f"{cor_pm10_no2:.2f}")

        st.text(
            "i tak powstaje smog: Mgła (wysoka wilgotność) w połączeniu z zanieczyszczeniami tworzy aerozol, który znacznie trudniej się rozprasza niż suchy pył.")

    daily_data_temp_pm10 = get_daily_averages(data, 'temp', 'pm10')
    st.plotly_chart(plot_yearly_temp_pm10(daily_data_temp_pm10), use_container_width=True)

if st.session_state.page == "PM10":
    stats_pm10 = get_statistics(data, 'pm10')

    st.header("Zanieczyszczenie w powietrzu")
    st.info(
        "Kraków choć w ostatnich latach bardzo poprawił jakość swojego powietrza, wciąż jest znany jako jedno z najbardziej zabrudzonych miast na świecie .W ostatnich latach Kraków odnotował znaczny spadek stężenia pyłów (ponad 40% spadku w sezonach grzewczych 2014-2020). Dzięki zakazowi spalania węgla i drewna, drastycznie zmniejszyła się liczba dni z ekstremalnym smogiem.")
    daily_data_pm10 = get_daily_averages(limit_data, 'pm10', 'pm2_5')
    st.plotly_chart(plot_pm_timeline(daily_data_pm10))

    col1, col2, col3 = st.columns(3)
    col1.metric(f"Średnia wartość PM10",
                f"{stats_pm10['avg']:.1f} µg/m³")
    col2.metric("Największa wartość PM10",
                f"{stats_pm10['max']:.1f} µg/m³")
    col3.metric("Najgorszy dzień w roku", f"{stats_pm10['highest'].strftime('%Y-%m-%d')}")

    st.divider()

    st.subheader("Analiza wpływu Zimy a Lata na zanieczyszczenia")
    col1, col2 = st.columns(2)
    with col1:
        st.pyplot(plot_winter_smog(data))
    with col2:
        st.pyplot(plot_pm10_vs_wind(data))
    st.info(
        "W Krakowie obowiązuje całkowity zakaz spalania węgla i drewna, co znacznie zmniejszyło lokalną emisję smogu jednak linia czerwona na lewym wykresie pokazuje, że im zimniej, tym stężenie pyłów gwałtownie rośnie. To z powodu napływu zanieczyszczeń z sąsiednich gmin, ruchu samochodowego i warunków atmosferycznych. Natomiast na prawym bardzo dobrze widać ilość zanieczyszczenia przy braku wiatru. Ruch powietrza pozwala rozmyć szkodliwe pierwiastki nad miastem, które jest postawione w trudnej sytuacji przez swoją lokalizacje geograficzną. Gdy brakuje wiatru, a temperatura spada, występuje zjawisko inwersji temperatury. Zimne, zanieczyszczone powietrze zostaje „uwięzione” przy ziemi i nie ma możliwości wymieszania się z wyższymi, czystszymi warstwami atmosfery.")

    st.divider()

    col1, col2 = st.columns([0.35, 0.7])
    smog_ep = identify_smog_episodes(data)
    with col1:
        st.subheader("Ilość Kategorycznych Dni")
        viewdata = round(
            smog_ep["air_quality"].groupby(smog_ep["air_quality"]).count().sort_values(ascending=False) / 24, 2)
        st.dataframe(viewdata)
        # st.text(f"{viewdata['Good']} - {round(viewdata['Bad'] + viewdata['Medium'], 2)} = {viewdata['Good'] - (viewdata['Bad'] + viewdata['Medium'])}")
        st.text(f"Procent dobrych dni w roku {round((viewdata['Good']) / 365 * 100, 2)}%")
    with col2:
        st.subheader("Najgorsze dni w roku")
        st.dataframe(get_smog_report(data))

if st.session_state.page == "CO2":
    stats_no2 = get_statistics(data, 'no2')

    st.header("Smog w powietrzu")
    st.info(
        "Ponad 620 tysięcy mieszkańców Krakowa - czyli około 77 proc. populacji miasta - żyje na obszarach z przekroczeniami nowych norm dla dwutlenku azotu (NO₂). Wynika to z najnowszych analiz Głównego Inspektoratu Ochrony Środowiska. Głównym źródłem zanieczyszczenia jest ruch samochodowy. ")

    daily_data_no2 = get_daily_averages(limit_data, 'no2')
    st.plotly_chart(plot_no2_timeline(daily_data_no2))

    col1, col2, col3 = st.columns(3)
    col1.metric(f"Średnia wartość PM10",
                f"{stats_no2['avg']:.1f} µg/m³")
    col2.metric("Największa wartość PM10",
                f"{stats_no2['max']:.1f} µg/m³")
    col3.metric("Najgorszy dzień w roku", f"{stats_no2['highest'].strftime('%Y-%m-%d')}")

    st.divider()

    hourly_data = get_hourly_profile(data, 'no2', 'pm10')
    st.altair_chart(plot_traffic_peak(hourly_data), use_container_width=True)
    st.info(" w godzinach szczytu (7-9 oraz 15-17) prędkościomierze wskazują o 5 km/h mniej niż w pozostałych porach dniach. Efekt? Średnia prędkość krakowskiego kierowcy wynosi w szczycie zaledwie 32 km/h. Widać to dobrze na wykresie emisyjnym. To efekt rur wydechowych.")

    st.divider()

    st.altair_chart(plot_no2_vs_wind(data))

    st.info("wiatr w kontekście Krakowa ma także drugie, niezwykle ważne oblicze. Jest on kluczowym sojusznikiem w walce ze smogiem. Położenie miasta w dolinie Wisły sprzyja gromadzeniu się zanieczyszczeń, zwłaszcza w sezonie grzewczym ale i też godzinach szczytu ruchu drogowego. Tworzy się wówczas zjawisko inwersji temperatury, gdzie zimne, zanieczyszczone powietrze jest uwięzione przy ziemi przez cieplejszą warstwę powyżej. Silny wiatr jest w stanie przełamać tę inwersyjną “pokrywę” i dosłownie “przewietrzyć” miasto. Poprawa jakości powietrza, jaką przynosi taki wiatr, jest odczuwalna niemal natychmiast dla wszystkich mieszkańców miasta Kraków.")

# run the app: streamlit run final-project\degrees-of-weather.py
