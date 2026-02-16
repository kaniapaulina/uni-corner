# Intro-Python

![](https://media2.giphy.com/media/v1.Y2lkPTc5NDFmZGM2NWdhMWd0OTU5cTA5c2ViMzE5cWh4M2k1ejllM2Yzbzd6MjJxa3h1OSZlcD12MV9naWZzX3NlYXJjaCZjdD1n/w9Bww684FwYco/giphy.gif)

## **1. Basics: Variables, Types, and Operations**

### **Variables & Data Types (Typy Danych)**

A variable is a name that refers to a value stored in the computer's memory. Python is **dynamically typed**, meaning you don't have to declare a variable's type.

- **`type(object)`**: A built-in function that returns the data type of an object.
  ```python
  x = 5
  print(type(x)) # Output: <class 'int'>

  ```
- **Basic Data Types:**
  - **`int`**: **integer** (bezprzecinkowe / liczba całkowita) - whole numbers like `5`, `3`, `0` .
  - **`float`**: **float** (przecink / liczba zmiennoprzecinkowa) - numbers with decimal point like `3.14`, `0.5`, `2.0`
  - **`str`**: String (sequence of characters or napis, łańcuch znaków), e.g., `"hello"`, `'Python'`, `"123"`.
  - **`bool`**: Boolean (logical value or wartość logiczna), e.g., `True` or `False`.
  Boolean operations: **not, or, and**
  ```python
  equal = 2 == 3
  if (equal is False):
      print("Klamco…")
  ```
- **Type Conversion:**
  ```python
  int("5")   # Converts string "5" to integer 5
  float(3)   # Converts integer 3 to float 3.0
  str(42)    # Converts integer 42 to string "42"
  bool(1)    # Converts integer 1 to boolean True (0 is False)

  ```

### **Operators**

- **Arithmetic:**
  - `+` (Addition), (Subtraction), (Multiplication)
  - `/` (Division): Always returns a `float`. `10 / 2` is `5.0`.
  - `//` (Floor Division): Returns an `int` (rounded down). `10 // 3` is `3`.
  - `%` (Modulo): Returns the remainder. `10 % 3` is `1`.
  - `*` (Exponentiation): `2 ** 3` is `8`.
- **Comparison (return `True` or `False`):**
  - `==` (equal to), `!=` (not equal to)
  - `<` (less than), `>` (greater than)
  - `<=` (less than or equal to), `>=` (greater than or equal to)

**Built-in Math Functions:**

- `abs(n)` - wartość bezwzględna
- `min(a,b,…)` - najmniejsza z liczb
- `max(a,b,…)` - największa z liczb
- `round(x)` - zaokrąglenie wartości
- `divmod(liczba, dzielnik)` = iloraz, reszta

---

## **2. Strings**

Strings are immutable sequences of characters.

**Creation:** Enclosed in single (`'`) or double (`"`) quotes. Use triple quotes (`'''` or `"""`) for multi-line strings.

```python
phrase = """It is a really long string
triple-quoted strings are used
to define multi-line strings"""
```

**Indexing & Slicing:**

**Indexing:** Access a single character. `my_string[0]` gets the first character.

**Negative Indexing:** `my_string[-1]` gets the last character.

**Slicing:** Extract a substring. `my_string[start:end]` gets characters from `start` to `end-1`.

```python
# String Indexing
str[index]
+---+---+---+---+---+---+
| P | y | t | h | o | n |
+---+---+---+---+---+---+
 0   1   2   3   4   5   6
-6  -5  -4  -3  -2  -1

# String Slicing
str[start:end]  # items start through end-1
str[start:]     # items start through the rest of the array
str[:end]       # items from the beginning through end-1
str[:]          # a copy of the whole array

# Examples
s = "Python"
print(s[0:2])  # "Py" (index 0 to 1)
print(s[2:])   # "thon" (index 2 to end)
print(s[:4])   # "Pyth" (start to index 3)
print(s[:])    # "Python" (a copy of the whole string)
print(s[::-1]  # "mohtyP" (reverse)
```

### **String Operations**

**Concatenation:** **`+`** -> **`"Hello" + "World" = "HelloWorld"`**

**Repetition:**  -> **`"Hi" * 3 = "HiHiHi"`**

**Checking substring:** `"" in _`

**Length:** `len()` - used to count how many characters a string contains

Escape Characters
Backslash is used to escape special symbols, such as single or double quotation marks, for example, `"It\'s me"` or `"She said \"Hello\""`. If you need to actually type the \ character as part of your string, you will need to escape it too.

**Special symbols:**

- `'\n'` - line break
- `'\t'` - tabulation

### String Methods

- **Useful Methods:**
  - Case Conversion:  **`lower()`**, **`upper()`**, **`capitalize()`**, **`title()`**
  - Searching & Counting:  **`count()`**, **`find()`**, **`rfind()`**, **`startswith()`**, **`endswith()`**, **`in`** keyword
  - Transformation:  **`replace()`**, **`strip()`**, **`ljust()`**, **`center()`**, **`rjust()`**
  - Splitting & Joining:  **`split()`**, **`join()`**
  - sort: **`sorted()`, `reverse()`**
- **Methods by category:**
  **Case conversion:**
  - `lower()` - returns a lowercase version
  - `upper()` - returns an uppercase version
  - `capitalize()` - converts the first character to uppercase and the rest to lowercase
  - `title()` - converts the first character of each word to uppercase and the rest to lowercase
  **Searching & Counting:**
  - `string.count(sub)` - counts how many times the substring `sub` appears. `"apple".count('p')` returns `2`
  - `string.find(sub)` - returns the lowest index where the substring `sub` is found. Returns `-1` if not found. `"hello".find('l')` returns `2`
  - `string.rfind(sub)` - returns the highest index where the substring `sub` is found
  - `string.startswith(prefix)` - returns `True` if the string starts with the specified `prefix`
  - `string.endswith(suffix)` - returns `True` if the string ends with the specified `suffix`
  - `"sub" in string` - checks if a substring exists (`True`/`False`)
  **Transformation:**
  - `string.replace(old, new)` - replaces all occurrences of substring `old` with substring `new`. `"hello".replace('l', 'p')` returns `'heppo'`
  - `string.strip()` or `rstrip()` or `lstrip()` - removes whitespace (spaces, tabs, newlines) from the beginning and end
  - `string.center(width)` - returns a centered string of a specified `width`, padded with spaces. `"Hi".center(10)` returns `'   Hi    '`
  - `string.ljust(width)` - returns a left-aligned string. `"Hi".ljust(10)` returns `'Hi        '`
  - `string.rjust(width)` - returns a right-aligned string
  **Splitting & Joining:**
  - `string.split(sep)` - splits a string into a list of substrings using the separator `sep`. If no separator is specified, it splits on any whitespace.
    - `"A B C".split()` returns `['A', 'B', 'C']`
    - `"A,B,C".split(',')` returns `['A', 'B', 'C']`
  - `string.join(iterable)` - the opposite of split. Joins elements of an `iterable` (like a list) into a single string.
    - `" and ".join(['cat', 'dog'])` returns `'cat and dog'`
    - `"".join(['1', '2', '3'])` returns `'123'`
  **Sorting:**
  - `sorted()` - returns a new sorted list
  - `reverse()` - reverses the string
  Explore more options: `str.` + Ctrl+Space

### String Formatting

1. **f-strings (Recommended!):** Most modern and readable.

   ```python
   name = "Alice"
   age = 30
   print(f"My name is {name} and I am {age} years old.")
   ```

2. **`str.format()`:**

   ```python
   print("My name is {} and I am {} years old.".format(name, age))
   ```

3. **% - formatting (Older method):**

   ```python
   print("My name is %s and I am %d years old." % (name, age)) # %s string, %d digit
   ```

---

## **3. Data Structures (Struktury Danych)**

### Lists (Lista) or Array (Tablica)

Lists are **mutable**, ordered sequences of items (items can be of different types).

**Properties:**

- **Ordered:** Elements have a defined order that won't change.
- **Mutable:** Elements can be added, removed, or changed after creation.
- **Elements can be of any type:** Can mix numbers, strings, other lists, etc.

**Creation:** `my_list = [1, 2, 3]` or `my_list = []` for an empty list.

**Basic Operations:**

```python
lista1 = []                 # Empty list
lista2 = [2, 3, 5, 7]       # List of integers
lista3 = [23, "ala", [1, 2, 3]] # Mixed list

# Operations similar to strings
combined = lista2 + [11, 13] # Concatenation: [2, 3, 5, 7, 11, 13]
repeated = lista2 * 2        # Repetition: [2, 3, 5, 7, 2, 3, 5, 7]
element = lista2[0]          # Indexing: 2
sublist = lista2[1:3]        # Slicing: [3, 5]
length = len(lista2)         # Length: 4
```

**Modifying Lists:**

- `list.append(item)`: Adds an item to the end.
- `list[index] = new_value`: Replaces the value at `index`.
- `list.pop()`: Removes and returns the last item.
- `del list[index]`: Deletes the item at `index`.
- Slicing can also be used for assignment: `my_list[1:3] = ['a', 'b']`

```python
my_list = []
my_list.append(10)       # Adds to the end: [10]
my_list.extend([20, 30]) # Adds multiple elements: [10, 20, 30]
last = my_list.pop()     # Removes & returns last element (30). List: [10, 20]
my_list.sort()           # Sorts the list itself
my_list.reverse()        # Reverses the list itself
del my_list[index]       # Deletes the item at index

# sorted() returns a new sorted list, leaving original unchanged.
new_sorted_list = sorted(my_list)
```

**Example:**

```python
cubes = [1, 8, 27, 65, 125]  # something's wrong here
4 ** 3  # the cube of 4 is 64, not 65!
cubes[3] = 64  # replace the wrong value
cubes
```

**Adding items:**

```python
squares = [1, 4, 9, 16, 25]
squares.append(6**2)

# or
squares += [36]
```

**Modifying with slices:**

Assignment is possible to slices of lists, just like to individual list elements. This way you can even change the size of a list or clear it entirely:

```python
animals[:] = []
```

```python
animals = ["elephant", "lion", "tiger", "giraffe", "monkey", "dog"]
print(animals)

animals[1:3] = ["cat"]    # Replace 2 items
print(animals)

animals[1:3] = []     # Remove 2 items
print(animals)

animals[1:3] = ["elephant", "elephant"]
print(animals)
```

### Nested Lists

A list can contain any kind of objects, even other lists (sublists). This data structure is known as a nested list. You can use nested lists to arrange data into hierarchical structures.

```python
nested_list = [[1, 2, 3], [4, 5], 6]

print(nested_list[1])  # Output: [4, 5]
print(nested_list[2])  # Output: 6
print(nested_list[0][0])  # Output: 1
```

**Example:**

```python
matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
print(matrix[1][2]) # Output: 6 (2nd list, 3rd element)
```

### Tuples (Krotka)

Tuples are **immutable**, ordered sequences. Used for data that shouldn't change.

**Properties:**

- **Immutable:** Cannot be changed after creation (no adding, removing, changing elements).
- **Ordered:** Elements have a defined order.
- **Use Case:** Perfect for representing fixed collections of items, like a point `(x, y)` or a date `(year, month, day)`. Also used for returning multiple values from a function.

**Creation:** `my_tuple = (1, 2, 3)` or `my_tuple = 1, 2, 3` (parentheses are optional but recommended).

```python
k1 = ()                    # Empty tuple
k2 = ('ala', 'ola', 'ula') # Tuple of strings
k3 = (1,)                  # Single-element tuple (comma is mandatory!)
point = (10, 20)
x, y = point               # Tuple unpacking: x=10, y=20

# Conversion
my_list = list(k2)         # Convert tuple to list: ['ala', 'ola', 'ula']
my_tuple = tuple(my_list)  # Convert list to tuple
```

**Special cases:**

Empty tuples are constructed by an empty pair of parentheses; a tuple with one item is constructed by following a value with a comma:

```python
empty = ()
singleton = 'hello',    # <-- note the trailing comma (bez niego robi sie string)
len(empty)  # Output: 0
```

**Tuple packing:**

The statement `t = 12345, 54321, 'hello!'` is an example of tuple packing: the values 12345, 54321, and hello! are packed together in a tuple.

**Example: Day of the Week Calculation (Zeller's Congruence-like)**

```python
# Lookup table for month codes
rm = (-1, 0, 3, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5)
days = ('niedziela', 'poniedziałek', 'wtorek', 'środa', 'czwartek', 'piątek', 'sobota')

d = int(input("Dzień 1-31: "))
m = int(input("Miesiąc 1-12: "))
r = int(input("Rok 1900-2099: "))

dt = d + rm[m] + (r-1900) + (r-1900)//4
if r % 4 == 0 and m < 3:
    dt = dt - 1
dt = dt % 7

print(days[dt]) # Prints the day of the week
```

### Dictionaries (Słownik)

Dictionaries are **mutable** collections of **key-value pairs (klucz-wartość)**. Keys must be immutable (e.g., strings, numbers, tuples). Also called maps, associative arrays, or hash tables.

**Properties:**

- **Unordered:** (Before Python 3.7). While they now remember insertion order, the primary purpose is lookup by key, not position.
- **Keys must be unique and immutable:** (e.g., strings, numbers, tuples).
- **Values can be any type:** and can be mutable.

**Creation:**

```python
phone_book = {"John": 123, "Jane": 234} # Curly braces {}
empty_dict = {}
# Using dict()
another_dict = dict(John=123, Jane=234)

t1 = {}                    # Empty dictionary
t2 = {'ala': 6, 'ola': 12, 'jan': 23} # Dictionary with key-value pairs
```

**Accessing/Modifying:**

- `phone_book["John"]`: Gets the value for key `"John"`.
- `phone_book["Jill"] = 456`: Adds a new key-value pair.
- `del phone_book["John"]`: Removes the key `"John"` and its value.
- `dict.clear()`: Deletes the dictionary.

```python
# Accessing values
grade = t2['ala']          # Get value for key 'ala' -> 6
t2['jan'] = 100            # Set value for key 'jan' to 100
del t2['ola']              # Remove the key 'ola' and its value

# Safe access with .get()
grade = t2.get('piotr', 0) # Returns 0 if key 'piotr' is not found
```

```python
phone_book = {"John": 123, "Jane": 234, "Gerard": 345}
print(phone_book)

# Add a new item
phone_book["Jill"] = 345
print(phone_book)

# Remove a key-value pair
del phone_book["John"]

# Add Jared's number
phone_book["Jared"] = 570

# Remove Gerard's number
del phone_book["Gerard"]

# Clear dictionary
phone_book.clear()
```

**Building dictionaries from lists:**

```python
list_of_keys = ["key1", "key2", "key3"]
list_of_values = [100, 200, 300]

my_dict = {}
for x in range(len(list_of_keys)):
    my_dict[list_of_keys[x]] = list_of_values[x]

print(my_dict.items())
```

**Dictionary methods:**

```python
h = {'a': 1, 'b': 2, 'c': 3}
h.keys()    # Returns a view of all keys: dict_keys(['a', 'b', 'c'])
h.values()  # Returns a view of all values: dict_values([1, 2, 3])
h.items()   # Returns a view of all (key, value) pairs: dict_items([('a', 1), ('b', 2), ('c', 3)])

# Iterating is most commonly done over .items()
for key, value in h.items():
    print(f"Klucz: {key}, Wartość: {value}")
```

- `dict.keys()` - returns a view of all keys
- `dict.values()` - returns a new view of the dictionary's values
- `dict.items()` - returns a new view of the dictionary's items as tuples in a list ((key, value) pairs)
- `"key" in dict` - checks if a key exists

The objects returned by dict.keys(), dict.values(), and dict.items() provide a dynamic view on the dictionary's entries, which means that when the dictionary changes, the view reflects these changes.

**Important notes:**

- Dictionary keys can only be of immutable types
- Keys need to be unique

**The `in` keyword:**

The `in` keyword is used to check if a list or dictionary contains a specific item.

```python
grocery_list = ["fish", "tomato", "apples"]
print("tomato" in grocery_list)

grocery_dict = {"fish": 1, "tomato": 6, "apples": 3}
print(6 in grocery_dict.values())
print("basil" in grocery_dict.keys())
```

### Sets (Zbiór)

Sets are **unordered** collections of _unique_ elements. Perfect for membership tests and set operations (union, intersection).

**Properties:**

- **Unordered:** Elements have no defined order.
- **Unique:** No duplicate elements allowed. Adding a duplicate does nothing.
- **Elements must be immutable:** You can have a set of numbers, strings, or tuples, but **not** lists or other sets

**Creation:** `unique_numbers = {1, 2, 2, 3}` becomes `{1, 2, 3}`

```python
s = set()               # Empty set. NOTE: s = {} creates an empty *dictionary*!
s2 = {1, 2, 3}          # Set with elements
s3 = set([2, 3, 5])     # Create a set from a list (duplicates are removed)

new = set(arr) # turns an array into a set with no duplicates
```

**Basic Operations & Methods:**

```python
s.add(4)           # Adds element 4: {1, 2, 3, 4}
s.remove(3)        # Removes element 3. CRASHES if element is not found!
s.discard(10)      # Removes element 10 if present. Safe, does nothing if not found.
s.clear()          # Removes all elements: set()
len(s)             # Returns the number of elements (cardinality)

# Membership testing (Very Fast!)
if 2 in s:         # Check if 2 is in the set
if 5 not in s:     # Check if 5 is NOT in the set
```

**Example:** `if user_id in banned_users_set: ...` # Very fast!

**Set Operations (Return new sets):**

```python
a = {1, 2, 3}; b = {3, 4, 5}
a.union(b)           # {1, 2, 3, 4, 5}          (All elements in a OR b)
a.intersection(b)    # {3}                       (Elements in a AND b)
a.difference(b)      # {1, 2}                    (Elements in a but NOT in b)
a.symmetric_difference(b) # {1, 2, 4, 5}        (Elements in a OR b but NOT both)
```

### Multi-dimensional Arrays (Tablice wielowymiarowe)

**Using Nested Lists (For simplicity):**

```python
# 2D Array (8x8) - e.g., a chessboard
tablica = []
for i in range(8):
    inner_list = []           # Create a new inner list for each row
    for j in range(8):
        inner_list.append(0)  # Fill it with zeros
    tablica.append(inner_list) # Add the row to the main list

tablica[6][5] = 23 # Access element at row 6, column 5
```

**Using numpy (For performance & scientific computing):**

```python
import numpy as np
# Creates a 8x8 array filled with zeros, of type float
tablica = np.zeros((8, 8), dtype=float)
tablica[6, 5] = 23.0 # More intuitive indexing
tablica[6, 6] = 0.1428
```

**1D "Arrays":**

```python
# As a list (most common)
t_list = [0] * 100 # Creates a list of 100 zeros
t_list[6] = 23

# As a numpy array
import numpy as np
t_np = np.zeros(100, dtype=float)
t_np[6] = 0.1428
```

### Other Useful Elements

**`map(function, iterable)`**

- **Purpose:** Applies a given **function** to every item in an **iterable** (like a list, string, tuple) and returns a special `map` object (which is an iterator).
- **How it works:** It "maps" the function across the iterable.

```python
numbers = [1, 2, 3, 4]
# Map the function `str` to each element in the list
map_object = map(str, numbers)
result_list = list(map_object) # Convert the map object to a list
print(result_list)  # Output: ['1', '2', '3', '4']
```

**`list([iterable])`**

- **Purpose:** Creates a new **list** from an optional **iterable** (like a `map` object, tuple, string, etc.).
- **How it works:** It takes the elements from the iterable and places them into a new list.

```python
my_string = "hello"
my_list = list(my_string) # Creates a list from the string's characters
print(my_list)  # Output: ['h', 'e', 'l', 'l', 'o']

my_tuple = (1, 2, 3)
my_list2 = list(my_tuple) # Creates a list from the tuple
print(my_list2) # Output: [1, 2, 3]
```

**`enumerate(iterable)`**

Funkcja, która zwraca **pary (index, element)** dla każdego elementu w iterable (np. liście).

```python
a = ['a', 'b', 'c']
for i, letter in enumerate(a):
    print(i, letter)
```

**Wynik:**

```
0 a
1 b
2 c
```

---

## **4. Control Flow: Conditionals and Loops**

### **`if`, `elif`, `else`**

Controls which code blocks execute based on conditions.

```python
# === Example 1
age = 20
if age >= 18:
    print("You are an adult.")
elif age >= 13:
    print("You are a teenager.")
else:
    print("You are a child.")


# === Example 2
name = "John"
age = 17

if name == "John" or age == 17:
    print("name is John")
    print("John is 17 years old")

tasks = ["task1", "task2"]

if len(tasks) != 0:
    print("Not an empty list!")

tasks.clear()

if len(tasks) == 0:
    print("Empty list!")


# === Example 3
from random import random

my_random_number = random() * 100

if my_random_number > 50:
    print(my_random_number)
else:
    print("Too small!")

# Ternary operator:
print(my_random_number) if my_random_number > 50 else print("Too small!")

# === Example 4
import datetime

if datetime.date.today().day < 15:
    print("It's the beginning of the month still!")
else:
    print("It's not the beginning of the month anymore :(")

```

### **`for` Loops**

Iterate over items in any sequence (list, tuple, string, dictionary, etc.).

```python
# === Example 1
fruits = ["apple", "banana", "cherry"]
for fruit in fruits: # Iterate directly over items
    print(fruit)

for i in range(5): # Iterate using an index. range(5) = [0, 1, 2, 3, 4]
    print(i)

for _ in range(5): #_ to taki placeholder z ktorym nic nie robisz w pętli
		print(lalala)

# === Example 2
for i in range(5):    # For each number i in range 0-4
    print(i)          # This line is executed 5 times

primes = [2, 3, 5, 7]

for i in range(0, len(primes)):
    print(primes[i])


# === Example 3 - Iterating over strings
hello_world = "Hello, World!"

for character in hello_world:
    print(character)

length = 0

for character in hello_world:
    length += 1

print(len(hello_world) == length)
```

- **`range()` function:** `range(start, stop, step)`. `range(5)` generates numbers from 0 to 4.

### Nested Loops

A nested loop is a loop inside another loop. The inner loop is executed once for each iteration of the outer loop.

```python
# === Example 1
coordinates = [1, 2, 3]
for coordinate1 in coordinates:
    for coordinate2 in coordinates:
        print(f'{coordinate1} x {coordinate2}')


# === Example 2
adjectives = ["black", "stylish", "expensive"]
clothes = ["jacket", "shirt", "boots"]

for x in adjectives:
    for y in clothes:
        print(x, y)
```

### **`while` Loops**

Execute a block of code as long as a condition is `True`.

```python
# === Example 1
count = 0
while count < 5:
    print(count)
    count += 1 # This is CRUCIAL to avoid an infinite loop!

# === Example 2
count = 0
while True:
    print(count)
    count += 1
    if count >= 5:
        break  # Exit loop if count >= 5

# Output:
1
2
3
4


# === Example 3
zoo = ["lion", "tiger", "elephant", "giraffe", "python"]
while True:
    animal = zoo.pop()
    print(animal)
    if animal == "elephant":
        break

print(zoo)

# Output:
python
giraffe
elephant
['lion', 'tiger']
```

### **Loop Control Statements**

- `break`: Exits the loop immediately.
- `continue`: Skips the rest of the current iteration and moves to the next one.
  ```python
  for i in range(5):
      if i == 3:
          continue   # Skip the rest of the code inside loop for current i value
      print(i)

  for x in range(10):
      if x % 2 == 0:
          continue
      print(x)
  ```

### Else Clause in Loops

Python allows loop statements to have an `else` clause. It is executed when the loop terminates through exhaustion of the iterable (with for) or when the condition becomes False (with while), but not when the loop is terminated by a break statement.

**Prime number search example:**

```python
for n in range(2, 10):
    for x in range(2, n):
        if n % x == 0:
            print(n, 'equals', x, '*', n//x)
            break
    else:
        # loop fell through without finding a factor
        print(n, 'is a prime number')
```

Output:

```
2 is a prime number
3 is a prime number
4 equals 2 * 2
5 is a prime number
6 equals 2 * 3
7 is a prime number
8 equals 2 * 4
9 equals 3 * 3
```

```python
i = 0
while i < 5:
    print('it\'s less than 5')
    i += 1
else:
    print('and now it\'s 5')

for i in range(1, 5):
    if i >= 3:
        break
    print(i)
else:
    print("for loop is done")

print("Outside the for loop")
```

```python
def contains_even_number(lst):
    for i in lst:
        if i % 2 == 0:
            print(f"List {lst} contains an even number.")
            break
    else:
        print(f"List {lst} does not contain an even number.")

contains_even_number([1, 9, 8])
contains_even_number([1, 3, 5])
```

### **List Comprehensions**

A concise way to create lists. Syntax: `[expression for item in iterable if condition]`.

```python
# Example 1
# Instead of this:
my_list = []
for i in range(5):
    my_list.append(i)

print(my_list)  # Output: [0, 1, 2, 3, 4]

# Use this:
my_list = [i for i in range(5)]
print(my_list)  # Output: [0, 1, 2, 3, 4]

# === Example 2
# Instead of this:
squares = []
for x in range(5):
    squares.append(x**2)

# Do this:
squares = [x**2 for x in range(5)] # Output: [0, 1, 4, 9, 16]

# With a condition:
even_squares = [x**2 for x in range(10) if x % 2 == 0] # Squares of even numbers

```

**Example:**

```python
starting_numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
my_inefficient_list = []

for i in starting_numbers:
    my_inefficient_list.append(i + 10)

print(my_inefficient_list)

my_efficient_list = [i+10 for i in my_inefficient_list]
print(my_efficient_list)
```

**Nested list comprehension:**

```python
matrix = []
for i in range(3):
    matrix.append([])
    for j in range(0, 10, 2):
        matrix[i].append(j)

print(matrix)  # Output: [[0, 2, 4, 6, 8], [0, 2, 4, 6, 8], [0, 2, 4, 6, 8]]

# Or with comprehension:
matrix = [[j for j in range(0, 10, 2)] for i in range(3)]
print(matrix)

# range(0,10,2) - od zera zamkniete do 10 otwarte co druga liczba
```

```python
string = '0123456789'
matrix = [[j for j in string] for i in string]

for row in matrix:
    print(row)
```

### **Exception Handling**

Prevent your program from crashing on errors by catching and handling exceptions.

```python
try:
    number = int(input("Enter a number: "))
    result = 10 / number
    print(f"Result is {result}")
except ValueError:
    print("That was not a valid number!")
except ZeroDivisionError:
    print("You can't divide by zero!")
except Exception as e: # Catch any other error
    print(f"An unexpected error occurred: {e}")
```

---

## **5. Functions**

Functions are reusable blocks of code defined with the `def` keyword.

### Basic Function Definition

Functions are a convenient way to divide your code into useful blocks, make it more readable, and reuse it. The keyword `def` introduces a function definition. It must be followed by the function name and the parenthesized list of **formal parameters** (which can be empty). The statements that form the body of the function start at the next line and must be indented.

**Definition and Call:**

```python
def greet(name): # `name` is a parameter
    print(f"Hello, {name}!")

greet("Alice") # "Alice" is an argument. Output: Hello, Alice!
```

**`return` statement:** Sends a result back to the caller. Without it, a function returns `None`.

```python
def fib(n):
    """This is documentation string for function. It'll be available by fib.__doc__()
    Return a list containing the Fibonacci series up to n."""
    result = []
    a = 1
    b = 1
    while a < n:
        result.append(a)
        tmp_var = b
        b += a
        a = tmp_var
    return result

if __name__ == '__main__':
    print(fib(10))
```

**Docstring example:**

```python
def increment_list(mylist):
    """This function adds 1 to each element of the list."""
    for i in range(len(mylist)):
        mylist[i] += 1
    return mylist

print(increment_list.__doc__)
print(increment_list([1, 2, 3]))
```

### Parameter Passing

- **Immutable objects (ints, strings, tuples):** Passed by _value_. Changes inside a function don't affect the original.
- **Mutable objects (lists, dicts, sets):** Passed by _reference_. Changes inside a function _do_ affect the original.

### Default Parameters

Parameters can have default values.

```python
def multiply_by(a, b=2, c=1):
    return a * b + c

print(multiply_by(3, 47, 0))  # Custom values for all parameters
print(multiply_by(3, 47))     # Default value for c
print(multiply_by(3, c=47))   # Default value for b
print(multiply_by(3))         # Default values for b and c
print(multiply_by(a=7))       # Default values for b and c
```

```python
def power(base, exponent=2): # exponent defaults to 2
    return base ** exponent
print(power(3))    # 9 (3^2)
print(power(3, 3)) # 27 (3^3)
```

```python
def hello(subject, name=""):
    print(f"Hello {subject}! My name is {name}")

hello("PyCharm", "Jane")  # With both parameters
hello("PyCharm")          # With default name
```

```python
def print_table(height, length=3, symbol='++++'):
    for y in range(height):
        for x in range(length):
            print(f'|{symbol}', end='')
        print('|\n')

print_table(height=5, length=5, symbol='____')
```

### Keyword Arguments

Call a function by explicitly naming the arguments. Order doesn't matter.

```python
def describe_pet(animal, name):
    print(f"I have a {animal} named {name}.")
describe_pet(name="Whiskers", animal="cat")
```

### _args and_ \*kwargs

- **`*args` (Arbitrary Arguments):** Collects extra positional arguments into a **tuple**.
- **`**kwargs` (Keyword Arguments): **Collects extra keyword arguments into a** dictionary.

```python
def my_function(*args, **kwargs):
    print(f"Positional arguments (tuple): {args}")
    print(f"Keyword arguments (dict): {kwargs}")

my_function(1, 2, 3, name="Alice", age=30)
# Output:
# Positional arguments (tuple): (1, 2, 3)
# Keyword arguments (dict): {'name': 'Alice', 'age': 30}
```

```python
def random_dialogue(place, *args, **kwargs):
    print("-- Do you know how to get to the", place, "?")
    print("-- I'm sorry, I am not from here, no idea about the", place)
    for arg in args:
        print(arg)
    print("-" * 40)
    for kw in kwargs:
        print(kw, ":", kwargs[kw])
    print('\n')

random_dialogue("Library", "Do you at least have a cigar, sir?",
                "Sure, help yourself.",
                lost_person="old banker",
                other_guy="street clown",
                scene="in a park")

dic = {"lost_person": "old banker", "other_guy": "street_clown", "scene": "in a park"}
lst = ["Do you at least have a cigar, sir?", "Sure, help yourself."]
random_dialogue("Library", *lst, **dic)  # Same output
```

**Another example:**

```python
def cat(food, *args, state='still hungry', action='meow', breed='Siamese'):
    print(f"-- This cat would {action}", end=' ')
    print(f"if you gave it {food}")
    print(f"-- Lovely fur, the {breed}")
    print(f"-- It's {state}!")
    for arg in args:
        print(arg.upper())

phrases = ['IT IS TOO FAT.', 'YOU ARE FEEDING YOUR CAT TOO MUCH']
keywords = {'state':'fat', 'action':'eat', 'breed':'Maine Coon'}

cat('anything', *phrases, **keywords)
```

### Lambda Functions

Small, anonymous functions defined with the **`lambda`** keyword.

```python
# A lambda that adds 10 to its argument
f = lambda x: x + 10
print(f(5)) # 15

# Often used with `filter`, `map`, `sorted`
numbers = [1, 4, 2, 5]
squared = map(lambda x: x**2, numbers) # Returns [1, 16, 4, 25]
```

### Generators

Functions that **`yield`** values one at a time, pausing their state. They are memory efficient for large data streams or infinite sequences.

```python
def countdown(n):
    print("Starting countdown!")
    while n > 0:
        yield n  # Yield a value and pause
        n -= 1
    print("Blastoff!")

for num in countdown(5): # The loop resumes the function each time
    print(num)
# Output: Starting countdown! 5 4 3 2 1 Blastoff!
```

### Built-in Functions

- `abs(n)` - wartość bezwzględna
- `chr(n)` - znak o kodzie n
- `ord(zn)` - kod znaku
- `min(a,b,…)` - najmniejsza z liczb
- `max(a,b,…)` - największa z liczb
- `round(x)` - zaokrąglenie wartości
- `len(s)` - długość napisu, listy, krotki
- `divmod(liczba, dzielnik)` = iloraz, reszta

---

## 6. Recursion

Recursion is when a function calls itself.

```python
def factorial(n):
    if n <= 1:
        return 1
    else:
        return n * factorial(n-1)

print(factorial(12))
```

```python
def countdown(n):
    print(n, end=' ')
    if n == 0:
        return             # Terminates recursion
    else:
        countdown(n - 1)   # Recursive call
```

---

## **7. Classes and Objects (OOP) (Programowanie Obiektowe)**

A **class** is a blueprint for creating objects. An **object** is an instance of a class.

### Basic Class Definition

```python
class MyClass:
    variable = 13

    def foo(self):  # self parameter explained later
        print("Hello from function foo")

my_object = MyClass()
my_object.foo()
print(my_object.variable)
```

```python
class Car:
    color = ""

    def description(self):
        description_string = f"This is a {self.color} car."
        return description_string

car1 = Car()
car2 = Car()

car1.color = "blue"
car2.color = "red"

print(car1.description())
print(car2.description())
```

```python
class Dog:
    # Class Attribute (shared by all instances)
    species = "Canis familiaris"

    # Initializer / Instance Attributes (unique to each instance)
    def __init__(self, name, age):
        self.name = name # 'self' refers to the current instance
        self.age = age

    # Instance Method
    def bark(self):
        return f"{self.name} says woof!"

# Create Objects (Instances)
my_dog = Dog("Rex", 5)
your_dog = Dog("Fido", 3)

print(my_dog.name)    # Rex
print(your_dog.age)   # 3
print(my_dog.species) # Canis familiaris
print(my_dog.bark())  # Rex says woof!
```

**`self`**: The first parameter of every method. It's a reference to the current instance of the class. You don't pass it when calling the method; Python does it automatically.

### Methods Calling Other Methods

```python
class Bag:
    def __init__(self):
        self.data = []

    def add(self, x):
        self.data.append(x)

    def addtwice(self, x):
        self.add(x)  # Calling the method `add` from another method
        self.add(x)
```

**Examples:**

```python
class Complex:
    def create(self, real_part, imag_part):
        self.r = real_part
        self.i = imag_part

    def build(self):
        self.num = complex(self.r, self.i)

complex_number = Complex()
complex_number.create(12, 5)
complex_number.build()
print(complex_number.num)
```

```python
class Calculator:
    current = 0

    def add(self, amount):
        self.current += amount

    def get_current(self):
        return self.current

my_value = Calculator()
my_value.add(100500)
print(my_value.get_current())

new_value = my_value
new_value.add(100000)
print(new_value.get_current())
```

```python
class Calculator:
    current = 0

    def add(self, number):
        self.current += number

    def multiply(self, number):
        self.current *= number

    def exponentiate(self, power):
        base = self.current

        for i in range(power - 1):
            self.current = base ** power
        # OR:
        # for i in range(power - 1):
        #     self.multiply(base)

    def get_current(self):
        return self.current

calc = Calculator()
print(calc.get_current())  # 0

calc.add(2)
print(calc.get_current())  # 2

calc.multiply(3)
print(calc.get_current())  # 6

calc.exponentiate(3)
print(calc.get_current())  # 216
```

### The **init** Method

The instantiation operation ("calling" a class object) creates an empty object, but it is useful to create objects with instances customized to a specific initial state. Therefore, a class may define a special method named `__init__()`.

```python
class MyClass:
    def __init__(self):
        self.data = []
```

`__init__` is one of the reserved methods in Python. If defined, the `__init__()` method is invoked automatically when an instance of the class is created, and it initializes the object and its attributes. It always takes at least one argument, `self`.

The `__init__()` method may receive arguments for greater flexibility:

```python
class Complex:
    def __init__(self, real_part, imag_part):
        self.r = real_part
        self.i = imag_part
        self.num = complex(self.r, self.i)
```

**Examples:**

```python
class Square:
    def __init__(self):
        self.sides = 4

square = Square()
print(square.sides)
```

```python
class Car:
    def __init__(self, color, brand):
        self.color = color
        self.brand = brand

car = Car("blue", "BMW")
print(car.color, car.brand)
```

### Special Methods: **str** and **repr**

Both `str()` and `repr()` methods in Python are used for string representation of an object, but there are differences:

```python
s = 'Hello World'
print(str(s))   # Hello World
print(repr(s))  # 'Hello World'
```

`str()` is used for creating output for the user, while `repr()` is normally used for debugging and development. `repr()` needs to be unambiguous, and `str()` — to be readable.

- **`__init__(self)`**: Called automatically when a new object is created (the constructor).
- **`__str__(self)`**: Called by `print()` and `str()` to get a user-friendly string representation of the object.
- **`__repr__(self)`**: Called by `repr()` to get an unambiguous string representation, often used for debugging.

The `print()` statement and the `str()` built-in function use the `__str__` method defined in the object's class. The `repr()` built-in function uses the `__repr__` method.

```python
class Dog:
    def __init__(self, name):
        self.name = name
    def __str__(self):
        return f"My dog's name is {self.name}."
    def __repr__(self):
        return f"Dog('{self.name}')"

my_dog = Dog("Rex")
print(my_dog)       # Uses __str__: "My dog's name is Rex."
print(repr(my_dog)) # Uses __repr__: "Dog('Rex')"
```

```python
class Complex:
    def __init__(self, real_part, imag_part):
        self.real = real_part
        self.img = imag_part

    def __repr__(self):
        return f'Complex({self.real}, {self.img})'

    def __str__(self):
        return f'{self.real} + i{self.img}'

x = Complex(2, 5)
print(str(x))   # 2 + i5
print(repr(x))  # Complex(2, 5)
```

**Another example:**

```python
class Cat:
    # Class Attribute (shared by all cats)
    species = "Felis catus"

    # Initializer / Instance Attributes
    def __init__(self, breed, name):
        self.breed = breed # Instance attributes (unique to each cat)
        self.name = name

    # Instance Method
    def speak(self):
        return f"{self.name} says meow!"

    # Special Methods
    def __str__(self):
        return f"My {self.breed} cat's name is {self.name}."

    def __repr__(self):
        return f"Cat('{self.breed}', '{self.name}')"

# Create Objects
cat1 = Cat("Siamese", "Lucy")
print(cat1)         # Uses __str__: "My Siamese cat's name is Lucy."
print(repr(cat1))   # Uses __repr__: "Cat('Siamese', 'Lucy')"
print(cat1.speak()) # "Lucy says meow!"
```

### Class Variables vs Instance Variables

In general, instance variables are for data unique to each instance, and class variables are for attributes and methods shared by all instances of the class:

```python
class Cat:
    species = "Felis catus"  # Class variable

    def __init__(self, breed, name):
        self.breed = breed  # Instance variable
        self.name = name    # Instance variable

cleo = Cat('mix', 'Cleo')
furry = Cat('bengal', 'Furry')

print(cleo.name)      # Cleo
print(cleo.species)   # Felis catus
print(furry.name)     # Furry
print(furry.species)  # Felis catus
```

**Important:** Mutable class variables can cause unexpected behavior!

**Bad example:**

```python
class Cat:
    favorite_food = []  # Mutable class variable - shared by all instances!

    def __init__(self, name):
        self.name = name

    def add_food(self, food):
        self.favorite_food.append(food)

kitty = Cat('Kitty')
barsik = Cat('Barsik')
kitty.add_food('salmon')  # Affects both instances!
print(barsik.favorite_food)  # ['salmon'] - unexpected!
```

**Good example:**

```python
class Cats:
    def __init__(self, name):
        self.name = name
        self.favorite_food = []  # Instance variable - unique to each instance

    def add_food(self, food):
        self.favorite_food.append(food)

kitty = Cats('Kitty')
barsik = Cats('Barsik')
kitty.add_food('salmon')
print(barsik.favorite_food)  # [] - empty as expected!
```

**More examples:**

```python
class Animals:
    kind = 'pets'  # Class variable

    def __init__(self, name, species):
        self.name = name        # Instance variable
        self.species = species  # Instance variable

    def __str__(self):
        return f'\nThis is {self.name} the {self.species}, one of my {self.kind}.'

george = Animals('George', 'rabbit')
sally = Animals('Sally', 'horse')
print(george, sally)
print(type(george.kind))
```

```python
class City:
    all_cities = []  # Mutable class variable

    def __init__(self, name, population, country):
        self.name = name
        self.population = population
        self.country = country
        self.add_city()

    def add_city(self):
        self.all_cities.append(self.name)

if __name__ == '__main__':
    malaga = City('Malaga', 569005, 'Spain')
    boston = City('Boston', 689326, 'USA')
    beijing = City('Beijing', 21540000, 'China')

    print(malaga.all_cities)  # ['Malaga', 'Boston', 'Beijing']
```

### Importing Classes from Modules

```python
from calculator import Calculator

calc = Calculator()
for i in range(100):
    calc.add(i)

print(calc.get_current())

# calculator.py file:
class Calculator:
    def __init__(self):
        self.current = 0

    def add(self, amount):
        self.current += amount

    def get_current(self):
        return self.current
```

---

## **8. Working with Files,  I/O (Input/Output)**

Python provides built-in functions to read from and write to files on your computer. The key to working with files is the **`open()`** function.

### The open() Function and File Modes

**`f = open(filename, mode, buffering)`**

- **`filename`**: String containing the file path.
- **`mode`**: String specifying the mode in which the file is opened.
- **`buffering`**: Controls buffering policy (0=off, 1=line buffering, >1=buffer size). Usually left default.

### Essential File Modes

| **Mode**  | **Description**                                                                   | **File Pointer** |
| --------- | --------------------------------------------------------------------------------- | ---------------- |
| **`'r'`** | **Read** (default). Opens for reading.                                            | Start of file    |
| **`'w'`** | **Write**. Opens for writing. **Overwrites** existing file or creates new.        | Start of file    |
| **`'a'`** | **Append**. Opens for writing. Data is **added to the end** of existing file.     | End of file      |
| **`'x'`** | **Exclusive creation**. Fails if file already exists.                             | Start of file    |
| **`'b'`** | **Binary** mode (e.g., **`'rb'`**, **`'wb'`**). Use for images, executables, etc. | -                |
| **`'t'`** | **Text** mode (default).                                                          | -                |
| **`'+'`** | **Updating** (reading & writing), e.g., **`'r+'`**, **`'w+'`**                    | -                |

### The with Statement (Best Practice)

**Always** use the **`with`** statement when working with files. It automatically handles closing the file, even if an error occurs. This prevents resource leaks.

```python
# DON'T DO THIS (unless you have a very good reason)
f = open('file.txt', 'r')
data = f.read()
f.close() # You might forget this!

# DO THIS INSTEAD (The proper way)
with open('file.txt', 'r') as f:
    data = f.read()
# File is automatically closed here, even if an error happened above.
```

It is good practice to use the `with` keyword when dealing with file objects. The file is properly closed after the code suite finishes.

```python
with open('somefile.txt') as f:
    read_data = f.read()

f.closed  # True - file is automatically closed
```

**Important:** If you're not using the `with` keyword, you should call `f.close()` to close the file and free up system resources.

### Reading Files

[\*\*f.read](http://f.read)(size)\*\* - reads some quantity of data and returns it as a string. When size is omitted or negative, the entire contents of the file will be read.

```python
with open('somefile.txt') as f:
    print(f.read())
# Output: Here's everything that's in the file.\n
```

**Note:** There will be a problem if the file is twice as large as your machine's memory.

**f.readline()** - reads a single line from the file. A newline character (n) is left at the end of the string and is only omitted on the last line if the file doesn't end in a newline. If `f.readline()` returns an empty string, the end of the file has been reached.

```python
f.readline()  # 'This is the first line of the file.\n'
f.readline()  # 'Second line of the file\n'
f.readline()  # ''
```

**Reading from a File:**

```python
with open('input.txt', 'r') as f:
    content = f.read()       # Reads the entire file into a single string.
    content = f.read(100)    # Reads the next 100 bytes/characters.

    line = f.readline()      # Reads a single line (includes the '\n' at the end).
    all_lines = f.readlines() # Reads all lines into a list of strings.

    # Most memory-efficient for large files:
    for line in f:           # Loop over the file object to read line by line.
        print(line.strip())  # .strip() removes the trailing newline character.
```

**Looping over lines (recommended):**

For reading lines from a file, you can loop over the file object. This is memory efficient, fast, and simple:

```python
for line in f:
    print(line)
```

**f.readlines()** - read all lines into a list:

```python
list(f)  # or f.readlines()
```

**Examples:**

```python
with open("input.txt", "r") as f:
    for line in f:
        print(line)

with open("input1.txt", "r") as f1:
    print(f1.readline())  # Print only first line
```

```python
with open("input.txt", "r") as infile:
    lines_list = []
    for line in infile:
        lines_list += [line]

# OR:

with open("input.txt", "r") as infile:
    lines_list = infile.readlines()

if __name__ == "__main__":
    print(lines_list)
```

### Writing to Files

If you use `'w'` as the second argument in `open()`, the file opens for writing only. A new empty file will be created. If another file with the same name already exists, it will be erased. If you want to add content to an existing file, use `'a'` (append).

**f.write(string)** - writes the contents of a string to the file, returning the number of characters written.

```python
f.write('This is a test\n')  # Returns: 15
```

Other types of objects need to be converted to a string first:

```python
value = ('the answer', 42)
s = str(value)  # Convert the tuple into string
f.write(s)  # Returns: 18
```

**Writing to a File:**

```python
with open('output.txt', 'w') as f:
    f.write("Hello, World!\n")  # Writes a string to the file.
    lines = ["Line 1\n", "Line 2\n", "Line 3\n"]
    f.writelines(lines)         # Writes a list of strings to the file.
```

**File modes:**

- `'a'` - text will be inserted at the end of the file
- `'w'` - file will be emptied before text is inserted at the beginning

To include line breaks:

```python
f.write('\n' + 'string,' + ' ' + 'another string')
```

**Examples:**

```python
with open('input.txt', 'r') as my_file:
    print(my_file.read(), '\n')

with open('input1.txt', 'r') as file:
    outfile_name = file.readline()

outfile = open('outfile.txt', 'w')
outfile.write('Hello World')
outfile.close()
```

```python
zoo = ["lion", "elephant", "monkey"]
number = 15

with open("output.txt", 'a') as f:
    zoo = " and ".join(zoo)
    f.write('\n' + zoo)
    number = str(number)
    f.write('\n' + number)
```

### File Position & Navigation

```python
with open('file.txt', 'rb+') as f: # Often need 'b' for seek on Windows
    position = f.tell()    # Returns the current file pointer's position (in bytes).
    f.seek(0)              # Move the file pointer to the beginning of the file.
    f.seek(10)             # Move to the 10th byte in the file.
    f.seek(-5, 2)          # Move to the 5th byte from the end of the file (mode 2).
    # seek(offset, whence)
    # whence: 0=start, 1=current, 2=end of file.
```

### Other File Methods

```python
f.flush()    # Force Python to write data from its internal buffer to the disk file.
f.close()    # Manually close the file. (The `with` statement does this for you!).
```

### Practical Examples

**Example 1: Read a file and process each line**

```python
word_count = 0
with open('story.txt', 'r') as file:
    for line in file:
        words_in_line = line.split() # Split the line into a list of words.
        word_count += len(words_in_line)
print(f"The file contains {word_count} words.")
```

**Example 2: Read a config file into a dictionary**

```python
config = {}
with open('config.cfg', 'r') as file:
    for line in file:
        if '=' in line:
            key, value = line.strip().split('=', 1)
            config[key] = value
print(config.get('username'))
```

**Example 3: Write data to a CSV-like file**

```python
data = [['Name', 'Age'], ['Alice', 30], ['Bob', 25]]
with open('output.csv', 'w') as file:
    for row in data:
        line = ','.join(str(item) for item in row)
        file.write(line + '\n')
```

### Bonus: ASCII Heart Pattern

```python
def print_heart(n):
    for i in range(n // 2, n, 2):
        for j in range(1, n - i, 2):
            print(end="  ")
        for j in range(1, i + 1):
            print("*", end=" ") if (j == 1 or j == i) else print(end="  ")
        for j in range(1, n - i + 1):
            print(end="  ")
        for j in range(1, i + 1):
            print("*", end=" ") if (j == 1 or j == i) else print(end="  ")
        print()

    for i in range(n, 0, -1):
        for j in range(i, n):
            print(end="  ")
        for j in range(1, i * 2):
            print("*", end=" ") if (j == 1 or j == i * 2 - 1 or (i == n and j == i)) else print(end="  ")
        print()

if __name__ == '__main__':
    print_heart(5)
```

---

## **9. Modules**

A module is just a Python file (`.py`) containing functions, classes, and variables. You can import them to use in another file.

### Standard Modules

Python comes with a library of standard modules. Some modules are built into the interpreter; these provide access to operations that are not part of the core of the language but are nevertheless built in.

**sys module example:**

```python
import sys
import datetime

print(sys.path)
print(datetime.datetime.today())
```

One particular module deserves attention: `sys`, which is built into every Python interpreter. The variables [`sys.ps](http://sys.ps)1` and [`sys.ps](http://sys.ps)2` define the strings used as primary and secondary prompts in interactive mode.

The variable `sys.path` is a list of strings that determines the interpreter's search path for modules.

You can use Ctrl+Space after a dot (.) to explore available methods of a module.

### Import Variations

**Importing:**

```python
import math                         # Import the whole module
print(math.sqrt(16))                # Use its contents with dot notation

from math import sqrt, pi           # Import specific things
print(sqrt(16))                     # Use directly without 'math.'
print(pi)

from math import *                  # Import everything (generally discouraged)
import math as m                    # Import with an alias
print(m.sqrt(16))

from math import sqrt as square_root # Import specific thing with an alias
print(square_root(16))
```

**Direct name import:**

```python
from calculator import Add

calc = Add()  # Name `Add` used directly without prefix
```

**Import all names:**

```python
from calculator import *
calc = Multiply()
```

Note: This imports all names except those beginning with underscore `_`. In most cases, Python programmers do not use this, since it introduces an unknown set of names into the interpreter.

**Import with alias:**

```python
import my_module as mm
mm.hello_world()

from calculator import Subtract as Minus
```

**Examples:**

```python
from calculator import Calculator
from my_module import hello as hey

print(hey("User"))

calc = Calculator()
calc.add(2)
calc.multiply(100)
calc.divide(3)

print(calc.get_current())
```

```python
import functions.goodbye as bye
import functions.greeting.hello
from classes import calculator
import functions.greeting.official

print(functions.greeting.hello.hello('Susan'))
print(bye.good_bye('Alex'))

c = calculator.Calculator()
c.add(2)
c.multiply(10)
print(c.get_current())

print(functions.greeting.official.hello('Sam'))
```

### The **name** and **main** Pattern

A Python module is a file containing executable statements as well as function or class definitions. These statements are executed the first time the module name is encountered in an import statement. The file name is the module name with the suffix .py appended. Within a module, the module's name (as a string) is available as the value of the global variable `__name__`.

When you run a module **directly** (not by importing it), the code in the module will be executed with `__name__` set to `"__main__"`.

**`if __name__ == "__main__":`**

- Code inside this block only runs if the script is executed **directly** (e.g., `python my_[script.py](http://script.py)`).
- It does **not** run if the script is **imported** as a module into another script.
- This is essential for writing code that can be both a reusable module and a runnable program.

You can use this pattern:

```python
if __name__ == "__main__":
    # Do something here
```

The statements inside this block will be executed only if the module is run directly and not through import.

**Example with two files:**

```python
# In my_module.py
def my_function():
    print("Function from module")

if __name__ == "__main__":
    # This will only run if you execute: python my_module.py
    print("This script was run directly!")
    my_function()
```

main_program:

```python
import some_module

print(f"main_program __name__ is: {__name__}")

if __name__ == "__main__":
    print("main_program executed directly")
else:
    print("main_program executed when imported")
```

some_module:

```python
print(f"some_module __name__ is: {__name__}")

if __name__ == "__main__":
    print("some_module executed directly")
else:
    print("some_module executed when imported")
```

Output after running main_program:

```
some_module __name__ is: some_module
some_module executed when imported
main_program __name__ is: __main__
main_program executed directly
```

Output after running some_module:

```
some_module __name__ is: __main__
some_module executed directly
```
