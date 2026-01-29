import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
import matplotlib.tri as tri
import tkinter as tk

points = np.asarray([[7.9934807395603, 0.8005766594516], [8.5095340827032, 7.6544113150683],
    [11.4, 0], [10.5861515998512, 5.0861837090313], [7.4289860385877, 1.949031395913],
    [10.8417520593961, 8.2665289074118],[5, 2],[11.1728346713043, 3.3265487231394],
    [3.5, 3],[10.8992939019232, 3.7927708113953],[3, 6],[10.0672238734015, 0.5413327373361],
    [2.7, 8.9],[10.1795346199575, 2.572262019378],[7.1, 10.8],[6, 4],[4.7, 10],[8.4217180989188, 3.661980833347],
    [8, 10],[8.0719690178815, 6.3417161206034],[10.7, 10.1],[9.2044903621258, 5.2349338978193], [12.8, 9.6],
    [12.8, 6.7],[12.2900722819763, 6.0392801617633],[6.1832116497398, 1.6530405553357], [13, 5.2],
    [7, 4],[13.4, 2.8],[6.2291641459993, 6.9823757810285],[11.9, 1.6],[8.2304820474874, 8.6800134859102],
    [5.789633048474, 8.7575970129635],[3.0048726881885, 7.5376067598861],[4.4876399338092, 7.8910478250317],
    [4.7413009386092, 5.1094956462337],[3.217044906115, 4.5937172361557],[12, 10], [8.9862127998914,4.2848715378685],
    [8.304926091821,2.6497834384997]])

wojewodztwa = {
    "zachodniopomorskie": [[12,16,34],[12,34,33],[34,16,32]],
    "pomorskie": [[32,16,14],[14,32,18],[18,32,31]],
    "warmińsko-mazurskie": [[31,18,20],[20,31,1],[1,20,5],[5,20,37]],
    "podlaskie": [[37, 22, 5], [22, 5, 23],  [5, 23, 24]],
    "lubelskie": [[7, 28, 26],  [26, 9, 7], [26, 9, 24],  [3, 24, 9]],
    "kujawsko-pomorskie": [[1,32,29], [1,19,29], [1,31,32]],
    "podkarpackie": [[28,30,7], [7, 30, 13], [13, 30, 2], [13, 2, 11]],
    "małopolskie": [[39, 13, 11], [39, 11, 4], [4, 11, 0]],
    "świętokrzyskie": [[38, 9, 13],[9, 7, 13],[38, 13, 17],[17, 13, 39]],
    "wielkopolskie": [[15, 29, 19],[29, 15, 35],[29, 35, 34], [34, 32, 29]],
    "opolskie": [[25, 6, 27],[6, 15, 27]],
    "lubuskie": [[10, 35, 36],[10, 35, 34],[33, 10, 34]],
    "mazowieckie": [[5, 24, 3],[1, 5, 3],[1, 3, 19], [19, 3, 21] ,[21, 3, 38] , [3, 9, 38]],
    "dolnośląskie": [[36, 35, 15],[36, 8, 15],[8, 15, 6]],
    "śląskie": [[27, 17, 39],[27, 39, 4],[27, 4, 25],[4, 0, 25]],
    "łódzkie": [[15, 27, 19],  [27, 19, 17],   [17, 19, 21],   [17, 38, 21]]

}

triangles = np.asarray([
    # zachodniopomorskie
    [12, 16, 34], [12, 34, 33], [34, 16, 32],
    # pomorskie
    [32, 16, 14], [14, 32, 18], [18, 32, 31],
    # warminsko - mazurskie
    [31, 18, 20], [20, 31, 1], [1, 20, 5], [5, 20, 37],
    # podlaskie
    [37, 22, 5], [22, 5, 23], [5, 23, 24],
    # lubelskie
    [7, 28, 26], [26, 9, 7], [26, 9, 24], [3, 24, 9],
    # kujawsko - pomorskie
    [1, 32, 29], [1, 19, 29], [1, 31, 32],
    # podkarpacki
    [28, 30, 7], [7, 30, 13], [13, 30, 2], [13, 2, 11],
    # małopolskie
    [39, 13, 11], [39, 11, 4], [4, 11, 0],
    # swietokrzyskie
    [38, 9, 13], [9, 7, 13], [38, 13, 17], [17, 13, 39],
    # wielkopolskie
    [15, 29, 19], [29, 15, 35], [29, 35, 34], [34, 32, 29],
    # opolskie
    [25, 6, 27], [6, 15, 27],
    # lubuskie
    [10, 35, 36], [10, 35, 34], [33, 10, 34],
    # mazowiecki
    [5, 24, 3], [1, 5, 3], [1, 3, 19], [19, 3, 21], [21, 3, 38], [3, 9, 38],
    # dolnoslaskie
    [36, 35, 15], [36, 8, 15], [8, 15, 6],
    # slaskie
    [27, 17, 39], [27, 39, 4], [27, 4, 25], [4, 0, 25],
    # lodzkie
    [15, 27, 19], [27, 19, 17], [17, 19, 21], [17, 38, 21]
])


def wczytaj_dane():
    df = pd.read_csv("dane.csv", sep=';', names=['wojewodztwo', 'zalesienie_2023','zalesienie_2013', 'powietrze_2023', 'powietrze_2013', 'ludnosc_2023', 'ludnosc_2013', 'inflacja_2023', 'inflacja_2013'], encoding='cp1250')

    df['zalesienie_2023'] = df['zalesienie_2023'].str.replace(',', '.', regex=False)
    df['zalesienie_2023'] = df['zalesienie_2023'].str.replace(' ', '', regex=False)
    df['zalesienie_2023'] = df['zalesienie_2023'].astype(float)

    df['zalesienie_2013'] = df['zalesienie_2013'].str.replace(',', '.', regex=False)
    df['zalesienie_2013'] = df['zalesienie_2013'].str.replace(' ', '', regex=False)
    df['zalesienie_2013'] = df['zalesienie_2013'].astype(float)

    df['powietrze_2023'] = df['powietrze_2023'].astype(str).str.replace(',', '.', regex=False)
    df['powietrze_2023'] = df['powietrze_2023'].astype(str).str.replace(' ', '', regex=False)
    df['powietrze_2023'] = df['powietrze_2023'].astype(float)

    df['powietrze_2013'] = df['powietrze_2013'].astype(str).str.replace(',', '.', regex=False)
    df['powietrze_2013'] = df['powietrze_2013'].astype(str).str.replace(' ', '', regex=False)
    df['powietrze_2013'] = df['powietrze_2013'].astype(float)

    df['ludnosc_2023'] = df['ludnosc_2023'].astype(str).str.replace(',', '.', regex=False)
    df['ludnosc_2023'] = df['ludnosc_2023'].astype(str).str.replace(' ', '', regex=False)
    df['ludnosc_2023'] = df['ludnosc_2023'].astype(float)

    df['ludnosc_2013'] = df['ludnosc_2013'].astype(str).str.replace(',', '.', regex=False)
    df['ludnosc_2013'] = df['ludnosc_2013'].astype(str).str.replace(' ', '', regex=False)
    df['ludnosc_2013'] = df['ludnosc_2013'].astype(float)

    df['inflacja_2023'] = df['inflacja_2023'].astype(str).str.replace(',', '.', regex=False)
    df['inflacja_2023'] = df['inflacja_2023'].astype(str).str.replace(' ', '', regex=False)
    df['inflacja_2023'] = df['inflacja_2023'].astype(float)

    df['inflacja_2013'] = df['inflacja_2013'].astype(str).str.replace(',', '.', regex=False)
    df['inflacja_2013'] = df['inflacja_2013'].astype(str).str.replace(' ', '', regex=False)
    df['inflacja_2013'] = df['inflacja_2013'].astype(float)

    mapachyba = pd.DataFrame({
        "wojewodztwo": list(wojewodztwa.keys()),
        "triangles": list(wojewodztwa.values())
    })
    mapaxdd = pd.merge(mapachyba, df, on="wojewodztwo")
    return mapaxdd

def generuj_mape(mapa, kolumna, tytul, legenda, cmap):
    all_triangles = []
    face_colors = []
    region_labels = []
    region_positions = []

    for i, row in mapa.iterrows():
        tris = row['triangles']
        all_triangles += tris
        face_colors += [row[kolumna]] * len(tris)

        tris_points = points[np.array(tris).flatten()].reshape(-1, 3, 2)
        centroid = np.mean(tris_points, axis=(0, 1))
        region_labels.append(row['wojewodztwo'])
        region_positions.append(centroid)

    triangulation = tri.Triangulation(points[:, 0], points[:, 1], np.array(all_triangles))
    fig, ax = plt.subplots(figsize=(10, 10))
    tpc = ax.tripcolor(triangulation, facecolors=face_colors, cmap=cmap, edgecolors='black', alpha=0.7)

    ax.scatter(points[:, 0], points[:, 1], color=None, zorder=3)
    for name, pos in zip(region_labels, region_positions):
        ax.text(pos[0], pos[1], name, fontsize=8, ha='center', va='center',
                bbox=dict(facecolor='white', edgecolor='none', alpha=0.7))

    ax.set_aspect('equal')
    ax.set_title(tytul)
    plt.colorbar(tpc, ax=ax, label=legenda)
    plt.show()


def inflacja_2023():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'inflacja_2023', 'Inflacja wg województw w 2023', 'Inflacja (%)', 'spring')


def inflacja_2013():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'inflacja_2013', 'Inflacja wg województw w 2013', 'Inflacja (%)', 'spring')

def ludnosc_2023():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'ludnosc_2023', 'Zaludnienie wg województw w 2023', 'Zaludnienie województwa (%)', 'winter')

def ludnosc_2013():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'ludnosc_2013', 'Zaludnienie wg województw w 2023', 'Zaludnienie województwa (%)', 'winter')

def zalesienie_2023():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'zalesienie_2023', 'Zalesienie wg województw w 2023 roku', 'Zalesienie (%)', 'summer')

def zalesienie_2013():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'zalesienie_2013', 'Zalesienie wg województw w 2023 roku', 'Zalesienie (%)', 'summer')

def powietrze_2023():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'powietrze_2023', 'Jakość Powietrza wg województw w 2023 roku', 'Jakość Powietrza (%)', 'Blues')

def powietrze_2013():
    mapa = wczytaj_dane()
    generuj_mape(mapa, 'powietrze_2013', 'Jakość Powietrza wg województw w 2023 roku', 'Jakość Powietrza (%)', 'Blues')

if __name__ == "__main__":
    root = tk.Tk()
    root.title("Dane Polska 2013/2023")
    root.geometry("400x200")
    root.eval('tk::PlaceWindow . center')
    root.configure(background='lavender')

    left_frame = tk.Frame(root, bg='lavender')
    left_frame.pack(side='left', padx=10, pady=20)

    right_frame = tk.Frame(root, bg='lavender')
    right_frame.pack(side='right', padx=30, pady=20)

    def clear_right():
        for widget in right_frame.winfo_children():
            widget.destroy()

    def inflacjaLata():
        clear_right()
        tk.Label(right_frame, text="Wybierz rok Inflacji:", bg="lavender").pack()
        tk.Button(right_frame, bg="hot pink", text="2023", command=inflacja_2023).pack()
        tk.Button(right_frame, bg="DeepPink", text="2013", command=inflacja_2013).pack()

    tk.Button(left_frame, bg="SlateBlue1", text="Inflacja", width=15, command=inflacjaLata).pack(pady=2)

    def zalesienieLata():
        clear_right()
        tk.Label(right_frame, text="Wybierz rok Zalesienia:", bg="lavender").pack()
        tk.Button(right_frame, bg="hot pink", text="2023", command=zalesienie_2023).pack()
        tk.Button(right_frame, bg="DeepPink", text="2013", command=zalesienie_2013).pack()

    tk.Button(left_frame, bg="purple1", text="Zalesienie", width=15, command=zalesienieLata).pack(pady=2)

    def powietrzeLata():
        clear_right()
        tk.Label(right_frame, text="Wybierz rok Stanu Powietzra:", bg="lavender").pack()
        tk.Button(right_frame, bg="hot pink", text="2023", command=powietrze_2023).pack()
        tk.Button(right_frame, bg="DeepPink", text="2013", command=powietrze_2013).pack()

    tk.Button(left_frame, bg="dark violet", text="Jakość powietrza", width=15, command=powietrzeLata).pack(pady=2)

    def zaludnienieLata():
        clear_right()
        tk.Label(right_frame, text="Wybierz rok Zaludnienia:", bg="lavender").pack()
        tk.Button(right_frame, bg="hot pink", text="2023", command=ludnosc_2023).pack()
        tk.Button(right_frame, bg="DeepPink", text="2013", command=ludnosc_2013).pack()

    tk.Button(left_frame, bg="DarkOrchid1", text="Zaludnienie", width=15, command=zaludnienieLata).pack(pady=2)

    root.mainloop()
    
    #zalesienie_2023()
    #zalesienie_2013()
    #powietrze_2023()
    #powietrze_2013()
    #ludnosc_2023()
    #ludnosc_2013()
    #inflacja_2023()
    #inflacja_2013()

