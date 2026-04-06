import streamlit as st

from src.data_loader import get_data

import datetime

st.set_page_config(page_title=":P", layout="wide")

st.title("Your trusted Air Fairy")

lat = 50.0614       #latitude
lon = 19.9366       #longitude
start = "2026-03-01"
end = "2026-04-01"

data = get_data(lat, lon, start, end, use_api=False)

st.dataframe(data.head())

# run the app: streamlit run final-project\degrees-of-weather.py