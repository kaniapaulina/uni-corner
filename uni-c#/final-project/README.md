# Dnd-BBB
Nasza aplikacja WPF została stworzona do zarządzania postaciami i drużynami w DnD - popularnym na całym świecie systemie RPG. Interfejs użytkownika znajduje się w projekcie `DndGUI`, logika domenowa i dostęp do danych w projekcie `Dnd_BBB`.

## Funkcjonalności
- Zarządzanie postaciami (`Character`): tworzenie, edycja, przechowywanie informacji.
- Zarządzanie drużynami (`Party`): tworzenie i edycja drużyn oraz przechowywanie informacji o nich.
- Informacje ogólne (`Info`): podstawowe informacje dotyczące tworzenia postaci.

## Technologie
- .NET SDK 8 (target: `net8.0-windows`)
- Język: C# (projekt ustawiony dla C# 12)
- WPF (Windows Presentation Foundation) — interfejs użytkownika
- Entity Framework 6 (pakiet `EntityFramework` wersja 6.5.1) — dostęp do bazy w trybie Code First z migracjami
- HandyControl (pakiet `HandyControl` wersja 3.5.1) — dodatkowe kontrolki UI
- `System.Text.Json` — serializacja/deserializacja JSON (eksport/import drużyn)
- Zasoby graficzne w katalogu `DndGUI/Images`

## Wymagania
- Zainstalowany .NET SDK 8.
- Zalecane: Visual Studio 2022 z obsługą .NET desktop development.
- SQL Server / LocalDB / SQL Express.

## Setup
1. Sklonuj repozytorium i otwórz rozwiązanie w Visual Studio 2022.
2. W Visual Studio 2022 przy otwartym rozwiązaniu uruchom Build Solution (lub menu kontekstowe projektu Restore NuGet Packages).
3. Domyślne zachowanie Entity Framework: jeśli nie podano connection stringa, EF może utworzyć bazę danych lokalnie (np. LocalDB) bazując na konwencjach. Aby mieć kontrolę nad DB, dodaj connection string do pliku `App.config` w projekcie `Dnd_BBB`.
5. W Visual Studio 2022 Ustaw projekt `DndGUI` jako projekt startowy, naciśnij Start Debugging (F5).
6. W oknie edycji drużyny dostępna jest opcja eksportu (zapis do folderu `Documents\DnD_Exports`).

## Dodatkowe informacje
- W razie pojawienia się komunikatu o błędzie bazy danych podczas uruchamiania, należy sprawdzić connection string oraz czy silnik SQL jest dostępny.
- HandyControl wymaga zasobów tematów — jeśli GUI wygląda nieprawidłowo, należy upewnić się, że odpowiadające style/zasoby są załadowane (sprawdź `App.xaml` i referencje do HandyControl).

## Autorki
- Paulina Kania
- Natalia Kruk
- Wiktoria Kowalska

