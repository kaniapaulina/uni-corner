# -*- coding: utf-8 -*-


#from scipy import *
import numpy as np
from numpy import r_ , pi
from scipy.special import jn, jn_zeros
import argparse
import matplotlib.pyplot as plt

# solution:
# https://en.wikipedia.org/wiki/Bessel_function
# https://docs.scipy.org/doc/scipy/reference/generated/scipy.special.jn_zeros.html

# CLI parametrization for: n, distance, angle, t


def drumhead_height(n, k, r, theta, t):
    nth_zero = jn_zeros(n, k)  # Zera funkcji Bessela
    return np.cos(t) * np.cos(n * theta) * jn(n, r * nth_zero)

def wykres(n, distance, angle, t):

    theta = np.linspace(0, 2 * pi, 50)  # Kąty od 0 do 2π (50 punktów)
    r = np.linspace(0, 4, 50)  # Promienie od 0 do 4 (50 punktów)

    R, Theta = np.meshgrid(r, theta)  # Siatka współrzędnych
    X = R * np.cos(Theta)  # Współrzędna X
    Y = R * np.sin(Theta)  # Współrzędna Y

    #Z = np.array([[drumhead_height(n, 1, ri, ti, t) for ri, ti in zip(r_row, theta_row)]
                  #for r_row, theta_row in zip(R, Theta)])
    Z = drumhead_height(n, 1, R, Theta, t)  # Apply function to 2D arrays directly

    from matplotlib import pyplot
    from mpl_toolkits.mplot3d import Axes3D
    from matplotlib import cm

    fig = pyplot.figure()
    ax = Axes3D(fig, auto_add_to_figure=False)
    ax.set_zlim(zmin=-1.3, zmax=1.3)
    fig.add_axes(ax)

    ax.set_zlim(-1.3, 1.3)  # Ustawienie zakresu osi Z
    ax.plot_surface(X, Y, Z, rstride=1, cstride=1, cmap=cm.jet)

    ax.set_xlabel('X')
    ax.set_ylabel('Y')
    ax.set_zlabel('Z')

    plt.show()

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("n", type=int)
    parser.add_argument("distance", type=float)
    parser.add_argument("angle", type=float)
    parser.add_argument("t", type=float)
    args = parser.parse_args()
    print(args)

    wykres(args.n, args.distance, args.angle, args.t)

    #cmd: python 02-drumhead.py 4 3.5 2.094 2.0
