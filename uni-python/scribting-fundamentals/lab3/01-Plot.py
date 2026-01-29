
from numpy import linspace, polyval, polyfit, sqrt, random
from scipy import stats
from pylab import plot, title, show, legend
import argparse

# CLI parametrization for:
# xmin, xmax, npoints, a, b, c;
# plus: verbosity/quiet level(so do not compute stats.linregress(t,xn))

def wykres(xmin, xmax, n, a, b, c):

    t=linspace(xmin,xmax,n)

    #Sample data creation
    #number of points
    #n=100
    #t=linspace(-5,5,n)  # xmin, xmax, npoints, a, b, c
    #parameters
    #a=0.8; b=-4; c=3
    x=polyval([a,b,c],t)
    print(type(x))

    #add some noise
    xn=x+random.randn(n)

    #Linear regression -polyfit - polyfit can be used other orders polys
    (ar,br,cr)=polyfit(t,xn,2)
    xr=polyval([ar,br,cr],t)
    #compute the mean square error
    err=sqrt(sum((xr-xn)**2)/n)

    print('Linear regression using polyfit')
    print('parameters: a=%.2f b=%.2f \nregression: a=%.2f b=%.2f, ms error= %.3f' % (a,b,ar,br,err))

    #matplotlib ploting
    title('Linear Regression Example')
    plot(t,x,'bx--')
    plot(t,xn,'ko')
    plot(t,xr,'r+')
    legend(['original','plus noise 2', 'regression2'])

    show()

    if args.verbose:
        (a_s, b_s, r, tt, stderr) = stats.linregress(t, xn)
        print('Linear regression using stats.linregress')
        print('parameters: a=%.2f b=%.2f \nregression: a=%.2f b=%.2f, std error= %.3f' % (a, b, a_s, b_s, stderr))

#Linear regression using stats.linregress
#https://docs.scipy.org/doc/scipy/reference/generated/scipy.stats.linregress.html


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("-xmin", type=int, required=True)
    parser.add_argument("-xmax", type=int, required=True)
    parser.add_argument("-npoints", type=int, required=True)
    parser.add_argument("-a", type=float, required=True)
    parser.add_argument("-b", type=float, required=True)
    parser.add_argument("-c", type=float, required=True)
    parser.add_argument("-v", "--verbose", help="verbosity level", action="store_true", required=False)

    args = parser.parse_args()

    wykres(args.xmin, args.xmax, args.npoints, args.a, args.b, args.c)

    #cmd: python 01-Plot.py -xmin -5 -xmax 5 -npoints 100 -a 0.8 -b -4 -c 3