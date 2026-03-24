#>> 2024-03-12
# https://pandas.pydata.org/docs/getting_started/index.html
# https://pandas.pydata.org/docs/getting_started/intro_tutorials/02_read_write.html#min-tut-02-read-write

#import numpy as np
import pandas as pd
import argparse

# CLI parametrization for:
# input file name (str, opcja -i, --input), output file name (str, opcja -o, --output), file type (str, -f, --format),
# parmetr pozycyjny dla przedziału wieku (line 40.).
# plus: verbosity/quiet level

def tytan(input, output, format, position, verbose):
    #1: ------------
    titanic = pd.read_csv("titanic.csv")

    if args.verbose:
        print(titanic)

        # 2: ------------
        print(titanic.head(8))
        print(titanic.tail(8))
        print(titanic.dtypes)

    #2A: ------------
    ## titanic.to_excel("titanic.xlsx", sheet_name="passengers", index=True)
    ## titanic = pd.read_excel("titanic.xlsx", sheet_name="passengers")

    match args.format:
        case "csv":
            titanic.to_csv(args.output, index=True)
        case "xlsx":
            titanic.to_excel(args.output, sheet_name="passengers", index=True)
        case "html":
            titanic.to_html(args.output, index=True)
    if args.verbose:
        #3: ------------
        print( titanic.info() )

        #4: ------------
        ages = titanic[ "Age" ]
        print( ages.head(10) )
        print( type(ages) )
        print( ages.shape )

        #5: ------------
        agnam = titanic[ ["Age", "Name"] ]
        print( agnam.head(10) )
        print( agnam.shape )

        #6: ------------
        above_position_parameter = titanic[titanic["Age"] > position]
        print("Passengers above 40:\n", above_position_parameter.head())
        #print("Above 40\n",above_40[["Age", "Name"]].head())

        #7: ------------
        class_13 = titanic[titanic["Pclass"].isin([ 3, 1 ])]
        print( f"shape is {class_13.shape}\n")
        print( class_13.head() )

        #8: ------------
        class_23 = titanic[(titanic["Pclass"] == 2) | (titanic["Pclass"] == 3)]
        print( f"shape is {class_23.shape}\n")
        print( class_23.head() )

        #9: loc[] ------------
        adult_names = titanic.loc[titanic["Age"] > 35, "Name"]
        print( "Adults > 35:\n",adult_names.head() )

        #10: iloc[] ------------
        zakres = titanic.iloc[9:25, 2:5]
        print("\nZakres: wiersz 10-25, kolumna 3-6:\n", zakres )
        ##=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("-i", "--input", help="input file name", type=str, required=True)
    parser.add_argument("-o", "--output", help="output file name", type=str, required=True)
    parser.add_argument("-f", "--format", help="file type", type=str, required=True)
    parser.add_argument("-p", "--position", help="parmetr pozycyjny dla przedziaÅ‚u wieku", type=int, required=False,
                        default=40)
    parser.add_argument("-v", "--verbose", help="verbosity level", action="store_true", required=False)

    args = parser.parse_args()

    tytan(args.input, args.output, args.format, args.position, args.verbose)

    #cmd: python Pandasy01.py -i titanic.csv -o titanic.csv -f csv -p 50 -v