# kudlacik_wpf_project

##Tento kód vytváří hru piškorky pro tři hráče, kteří střídavě klikají na tlačítka v mřížce a snaží se vytvořit řadu svých symbolů. Hra kontroluje vítězné podmínky a umožňuje restartování hry po jejím ukončení.

###Konstruktor MainWindow
Konstruktor volá metodu InitializeComponent, která inicializuje komponenty okna, a InitBoard, která inicializuje herní desku.

###Proměnné třídy
Proměnné třídy slouží k uložení aktuálního hráče, stavu herní desky a nastavení hry, jako je velikost desky, počet tahů a počet symbolů potřebných k vítězství.

###Metoda Button_Click
Tato metoda se spouští při kliknutí na tlačítko (pole na desce). Zajišťuje:
  1.Zjištění, který hráč je na tahu.
  1.Aktualizaci obsahu tlačítka (X, O, Y).
  1.Kontrolu, zda hráč vyhrál nebo zda hra skončila remízou.
  1.Přepnutí na dalšího hráče.

###Metoda CheckForWinner
Metoda kontroluje, zda některý z hráčů dosáhl vítězství. Prochází herní desku a hledá souvislé řady symbolů horizontálně, vertikálně a diagonálně.

###Metoda ResetGame
1.Vymaže herní desku.
1.Nastaví aktuálního hráče na prvního hráče.
1.Vymaže a znovu inicializuje herní pole.

###Metoda InitBoard
1.Přidá řádky a sloupce do mřížky (Grid).
1.Vytvoří tlačítka pro každé pole na desce a přiřadí jim událost Click.


