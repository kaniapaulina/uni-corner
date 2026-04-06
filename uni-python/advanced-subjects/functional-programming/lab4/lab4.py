import pandas as pd
import requests
import matplotlib.pyplot as plt
import altair as alt
import webbrowser

pd.set_option('display.max_columns', None)

def get_data():
    url = "https://wolnelektury.pl/api/books/"
    raw_data = requests.get(url).json()
    data = pd.DataFrame(raw_data)
    return data

def is_digit_in_title(title):
    return any(char.isdigit() for char in title)

def filter_by_title(df):
    return df[df['title'].apply(is_digit_in_title)]
    #return df[book for book in df if is_digit_in_title(book) is True]

def sort_by_epoch(df):
    return df.sort_values(by='epoch')

def group_by_epoch(df):
    return df.groupby('epoch')

def epoch_number_group(df):
    df = filter_by_title(df)
    df = group_by_epoch(df)
    return df.count().reset_index(names='type')

def connect_def():
    data = get_data()
    data = sort_by_epoch(data)
    data = epoch_number_group(data)
    data = data.loc[:, 'type':'kind']
    data.rename(columns={'kind': 'count'}, inplace=True)
    return data

def draw_plot():
    data = connect_def()
    plt.figure(figsize = (10,7))
    plt.bar(data['type'], data['count'], color='violet')
    plt.xticks(rotation=45, ha='right')
    plt.xlabel('Type')
    plt.ylabel('Count')
    plt.title('Epoch Number')
    plt.show()

def draw_plot_two():
    data = connect_def()
    chart = alt.Chart(data).mark_bar().encode(
        x=alt.X('type', title='Type'),
        y=alt.Y('count', title='Count'),
        tooltip=['type', 'count']
    ).properties(
        title='Titles with numbers in them sorted by Epochs',
    ).configure_mark(
        color='lightblue'
    )
    chart = chart.encode(
        x=alt.X('type', title='Type', axis=alt.Axis(labelAngle=45))
    )

    #return chart
    #chart.save('wykres.html')
    #webbrowser.open('wykres.html')

draw_plot_two()

