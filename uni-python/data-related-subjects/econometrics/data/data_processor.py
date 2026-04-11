import pandas as pd

import glob
import os

def merge_data():
        all_daily_files = glob.glob(os.path.join("yahoo/", '*.csv'))
        main_df = pd.DataFrame()

        for file in all_daily_files:
            if not os.path.exists(file):
                print(f"File missing: {file}")
                continue

            element_name = os.path.basename(file).replace(".csv", "")
            df = pd.read_csv(file, skiprows=2)

            df['Date'] = pd.to_datetime(df['Date'])
            df.set_index('Date', inplace=True)

            temp = df.iloc[:, 1]
            temp.name = element_name

            if main_df.empty:
                main_df = temp.to_frame()
            else:
                main_df = main_df.join(temp, how='outer')

            main_df = main_df.ffill().bfill()
            main_df.sort_index(inplace=True)

        all_montly_files = ["eurostat/une_rt_m.csv", "fred/T10Y2Y.csv", "fred/TRESEGUSM052N.csv", "fred/TRESEGPLM052N.csv"]

        for file in all_montly_files:
            if not os.path.exists(file):
                print(f"File missing: {file}")
                continue

            element_name = os.path.basename(file).replace(".csv", "")
            df = pd.read_csv(file)

            df['Date'] = pd.to_datetime(df.iloc[:, 0])
            df.set_index('Date', inplace=True)

            temp = df.iloc[:, 1]
            temp.name = element_name

            main_df = main_df.join(temp, how='outer')

            main_df.ffill(inplace=True)
            main_df.dropna(inplace=True)
            main_df.to_csv("merged_data.csv")

merge_data()