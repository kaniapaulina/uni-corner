#>> 2024-03-12
## https://pandas.pydata.org/docs/user_guide/visualization.html#visualization

# CLI parametrization for:
# np.random.randn(_N_), periods,
# plus: verbosity/quiet level

import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import argparse

def data(one, two):
    plt.figure()

    ts = pd.Series(np.random.randn(1000), index=pd.date_range("1/1/2020", periods=1000))
    ts = ts.cumsum()

    ts.plot()
    plt.show()
    plt.close("Figure 1")

    df = pd.DataFrame(np.random.randn(1000, 4), index=ts.index, columns=list("ABCD"))
    df = df.cumsum()
    #plt.figure()
    df.plot()
    plt.show()

    df3 = pd.DataFrame(np.random.randn(1000, 2), columns=["B", "C"]).cumsum()
    df3["A"] = pd.Series(list(range(len(df))))
    df3.plot(x="A", y="B");
    plt.show()

    df.iloc[10].plot(kind = "bar");
    plt.show()

    df = pd.DataFrame(np.random.rand(1000, 4), index=ts.index, columns=list("ABCD"))
    df = df.cumsum()
    df.iloc[10].plot(kind = "pie")
    plt.show()


if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument("one", type=int)
    parser.add_argument("two", type=int)
    parser.add_argument('-v', action='count', dest='verbosity', default=0, help="verbose output (repeat for increased verbosity)")
    parser.add_argument('-q', action='store_const',const=-1, default=0, dest='verbosity', help="quiet output (show errors only)")
    args = parser.parse_args()

    data(args.one, args.two)

    #cmd: python Pandasy02.py 10 20