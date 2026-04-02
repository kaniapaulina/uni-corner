import streamlit as st
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import plotly.express as px
import altair as alt

import lab4

st.title('Lektury z liczbą')
col1, col2 = st.columns([0.3 , 0.7])

with col1:
    st.subheader( "Zebrane dane", divider = "gray")
    st.table(lab4.connect_def())

with col2:
    st.subheader( "Wykres", divider = "gray")
    option = st.selectbox( "Wybierz biblioteke", options = ("matplotlib","seaborn","plotly","altair"))
    if option:
        try:
            if option == "matplotlib":
                data = lab4.connect_def()
                fig = plt.figure()
                plt.bar(data['type'], data['count'], color='violet')
                plt.xticks(rotation=45, ha='right')
                plt.xlabel('Type')
                plt.ylabel('Count')
                plt.title('Titles with numbers in them sorted by Epochs')
                st.pyplot(fig)

                """
                fig, ax = plt.subplots()
                ax.bar(data['type'], data['count'], color='violet')
                ax.set_xlabel('Type')
                st.pyplot(fig)
                """

            if option == "seaborn":
                data = lab4.connect_def()
                fig, ax = plt.subplots()
                sns.barplot(data=data, x='type', y='count', ax=ax, color='violet')
                plt.xticks(rotation=45, ha='right')
                ax.set_xlabel('Type')
                ax.set_ylabel('Count')
                st.pyplot(fig)

            if option == "plotly":
                data = lab4.connect_def()
                fig = px.bar(
                    data,
                    x='type',
                    y='count',
                    title='Titles with numbers in them sorted by Epochs',
                    color_discrete_sequence=['violet'])
                fig.update_layout(xaxis_tickangle=-45)
                st.plotly_chart(fig, use_container_width=True)

            if option == "altair":
                st.subheader( "Wykres", divider = "gray")
                data = lab4.connect_def()
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

                st.altair_chart(chart.interactive(), use_container_width=True)

        except:
            st.error("something went wrong")