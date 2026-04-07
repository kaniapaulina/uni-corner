def get_statistics(df, stat):
    """
    Function to calculate pollution statistics
    """
    stats = {
        "max": df[stat].max(),
        "avg": df[stat].mean(),
        "highest": df.loc[df[stat].idxmax(), 'date']
    }
    return stats

def identify_smog_episodes(df, threshold=50):
    """
    Function to identify the worst possible days
    """
    stats = {
        "worst_pollution": df.loc[df['pm10'] > df['pm10'].mean()].head(5),
        "air_quality": df['pm10'].apply(
            lambda x: "Good" if x < threshold/2 else ("Medium" if x < threshold else "Bad")
        )
    }
    return stats

def pearson_corr(data, a, b):
    return data[a].corr(data[b], method="pearson")

def get_hourly_profile(df, *args):
    """
    Function to calculate hourly profile statistics, by multiple possible inputs
    """
    df['hour'] = df['date'].dt.hour
    return df.groupby('hour')[list(args)].mean().reset_index()

def get_daily_averages(df, *args):
    """
    Function to calculate daily averages - resample('D')
    """
    temp_df = df.set_index('date')
    return temp_df[list(args)].resample('D').mean().reset_index()