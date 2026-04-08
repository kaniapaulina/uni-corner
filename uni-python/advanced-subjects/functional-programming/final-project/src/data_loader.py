import openmeteo_requests
import requests_cache
from retry_requests import retry

import pandas as pd

cache_session = requests_cache.CachedSession('.cache', expire_after = 3600)
retry_session = retry(cache_session, retries = 5, backoff_factor = 0.2)
openmeteo = openmeteo_requests.Client(session = retry_session)

lat = 50.0614       #latitude
lon = 19.9366       #longitude

start = "2026-03-01"
end = "2026-04-01"

def get_air_quality_data(lat, lon, start, end):
    """
    Function to retrieve air quality data from OpenMeteo
    """
    url = "https://air-quality-api.open-meteo.com/v1/air-quality"
    params = {
        "latitude": lat,
        "longitude": lon,
        "start_date": start,
        "end_date": end,
        "hourly": ["pm10", "pm2_5", "nitrogen_dioxide", "dust", "uv_index", "european_aqi"],
        "timezone": "Europe/Berlin"
    }

    responses = openmeteo.weather_api(url, params=params)

    response = responses[0]
    hourly = response.Hourly()

    data = {
        "date": pd.date_range(
            start=pd.to_datetime(hourly.Time(), unit="s", utc=True),
            end=pd.to_datetime(hourly.TimeEnd(), unit="s", utc=True),
            freq=pd.Timedelta(seconds=hourly.Interval()),
            inclusive="left"
        ),
        "pm10": hourly.Variables(0).ValuesAsNumpy(),
        "pm2_5": hourly.Variables(1).ValuesAsNumpy(),
        "no2": hourly.Variables(2).ValuesAsNumpy(),
        "dust": hourly.Variables(3).ValuesAsNumpy(),
        "uv_index": hourly.Variables(4).ValuesAsNumpy(),
        "aqi_index": hourly.Variables(5).ValuesAsNumpy()
    }

    return pd.DataFrame(data)

def get_weather_data(lat, lon, start, end):
    """
    Function to retrieve weather data from OpenMeteo
    """
    url = "https://archive-api.open-meteo.com/v1/archive"
    params = {
        "latitude": lat,
        "longitude": lon,
        "start_date": start,
        "end_date": end,
        "hourly": ["temperature_2m", "relative_humidity_2m", "rain", "wind_speed_10m"],
        "timezone": "Europe/Berlin"
    }

    responses = openmeteo.weather_api(url, params=params)

    response = responses[0]
    hourly = response.Hourly()

    data = {
        "date": pd.date_range(
            start=pd.to_datetime(hourly.Time(), unit="s", utc=True),
            end=pd.to_datetime(hourly.TimeEnd(), unit="s", utc=True),
            freq=pd.Timedelta(seconds=hourly.Interval()),
            inclusive="left"
        ),
        "temp": hourly.Variables(0).ValuesAsNumpy(),
        "humidity": hourly.Variables(1).ValuesAsNumpy(),
        "rain": hourly.Variables(2).ValuesAsNumpy(),
        "wind": hourly.Variables(3).ValuesAsNumpy(),
    }

    return pd.DataFrame(data)

def clean_data(df):
    """
    Function to fill missing values with the previous hour's value (interpolation) in a dataframe
    """
    return df.ffill().dropna()

def fetch_all_data(lat, long, start, end):
    """
    Function to combine two dataframes
    """
    df1 = get_air_quality_data(lat, long, start, end)
    df2 = get_weather_data(lat, long, start, end)
    df_final = pd.merge(df1, df2, on='date')
    df_final['date'] = pd.to_datetime(df_final['date'])

    return df_final


def get_data(lat, lon, start, end, use_api=True):
    """
    Returns the finished product of data_loader.py
    """
    file_path = "final-project/src/krakow_air_data_backup.csv"

    if not use_api:
        return pd.read_csv(file_path, parse_dates=['date'])

    if use_api:
        df = fetch_all_data(lat, lon, start, end)
        df.to_csv(file_path, index=False)
        return df