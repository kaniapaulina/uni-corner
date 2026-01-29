import itertools

#Zadanie 51. Dane są dwie liczby naturalne z których budujemy trzecią liczbę. W budowanej liczbie muszą wystąpić wszystkie cyfry występujące w liczbach wejściowych. Wzajemna kolejność cyfr każdej z liczb wejściowych musi być zachowana. Na przykład mając liczby 123 i 75 możemy zbudować liczby 12375,17523,75123,17253, itd. Proszę napisać funkcję która wyznaczy ile liczb pierwszych można zbudować z dwóch zadanych liczb.
def czy_pierwsza(x):
    dzielnik = 2
    while dzielnik ** 2 < x:
        if x % dzielnik == 0:
            return False
        dzielnik += 1
    return True

def zad51(x,y):
    a = list(str(x))
    b = list(str(y))
    n = len(a) + len(b)

    unique = set()

    for pos in itertools.combinations(range(n), len(a)): #pozycja
        temp = [None]*n
        for i, idx in enumerate(pos): #enumerate nadanie numerkow - index
            temp[idx] = a[i]

        bb = iter(b)
        for z in range(n):
            if temp[z] is None:
                temp[z] = next(bb)

        num_str = ''.join(temp)
        if len(num_str) > 1 and num_str[0] == '0':
            continue
        num = int(num_str)
        if czy_pierwsza(num):
            unique.add(num)
            print(num)
    return len(unique)


 #Zadanie 52. Liczba Smitha to taka, której suma cyfr jest równa sumie cyfr wszystkich liczb występujących w jej rozkładzie na czynniki pierwsze. Na przykład: 85 = 5 ∗ 17, 8 + 5 = 5+1+7. Proszę napisać program wypisujący liczby Smitha mniejsze od 106.

 #Zadanie 53. Liczba dwu-trzy-piątkowa w rozkładzie na czynniki pierwsze nie posiada innych czynników niż 2,3,5. Jedynka też jest taką liczbą. Proszę napisać program, który wylicza, ile takich liczb znajduje się w przedziale od 1 do N włącznie.

 #Zadanie 54. Proszę napisać program wczytujący dwie liczby naturalne a,b i wypisujący rozwinięcie dziesiętne ułamka a/b uwzględniając ułamki okresowe. Na przykład 2/3 = 0.(6),1/5 = 0.2,1/6 = 0.1(6),1/7 = 0.(142857)
def zad54(a, b):
    integer = a // b
    remains = a % b

    if remains == 0:
        return str(integer)

    decimal = []
    seen = {}
    while remains != 0:
        if remains in seen:
            idx = seen[remains]
            nie = decimal[:idx]
            tak = decimal[idx:]
            return f"{integer}.{''.join(str(d) for d in nie)}({''.join(str(d) for d in tak)})"

        seen[remains] = len(decimal) #ustawia index rowny pozycji w przyecinku
        remains = remains * 10
        digit = remains //b
        decimal.append(digit)
        remains %= b

    return f"{integer}.{''.join(decimal)}"


 #Zadanie 55. Dwie liczby naturalne są różno-cyfrowe, jeżeli nie posiadają żadnej wspólnej cyfry. Proszę napisać program, który wczytuje dwie liczby naturalne i poszukuje najmniejszej podstawy systemu (w zakresie 42 −16) w którym liczby są różno-cyfrowe. Program powinien wypisać znalezioną podstawę, jeżeli podstawa taka nie istnieje, należy wypisać komunikat o jej braku. Na przykład: dla liczb 123 i 522 odpowiedzią jest podstawa 11 bo 123(10) = 102(11) i 522(10) = 435(11).

 #Zadanie 56. „Obcięcie” liczby naturalnej polega na usunięciu z niej M początkowych i N końcowych cyfr, gdzie M,N >= 0. Proszę napisać funkcję, która dla danej liczby naturalnej K zwraca największą liczbę pierwszą o różnych cyfrach jaką można uzyskać z obcięcia liczby K albo 0 gdy taka liczba nie istnieje. Na przykład dla liczby 1202742516 spośród obciętych liczb pierwszych: 2,5,7,251,2027 liczbą spełniającą warunek jest liczba 251.

 #Zadanie 57. Liczbę nazywamy iloczynowo-pierwszą, jeżeli iloczyn jej cyfr w systemie o podstawie b jest liczbą pierwszą. Na przykład: 13 jest liczbą iloczynowo-pierwszą w systemie dziesiętnym, bo 1∗3 = 3 16 jest liczbą iloczynowo-pierwszą w systemie trójkowym, bo 16 = 121(3),1∗2∗1 = 2 W liczbie naturalnej możemy dokonywać rotacji jej cyfr, np. 1428, 4281, 2814, 8142 albo 209, 092, 920. Proszę napisać funkcję, która dla danej liczby naturalnej N, zwróci najmniejszą podstawę systemu (z zakresu 2-16) w którym przynajmniej jedna z rotowanych liczb jest iloczynowo-pierwsza albo wartość None gdy taka podstawa nie istnieje.

 #Zadanie 58. Proszę napisać program znajdujący jak najwięcej liczb N-cyfrowych dla których suma N tych potęg cyfr liczby jest równa tej liczbie, np. 153 = 13 + 53 + 33.

 #Zadanie 59. Tylko 7 liczb pierwszych spełnia warunek z poprzedniego zadania. Proszę napisać program znajdujący wszystkie te liczby


if __name__ == "__main__":
    print("Zabijam sie pt2 jezu to koniec\n")
    print(zad54(1, 6))
