namespace TicTacToe;

public class TicTacToe
{
    char[,] board = new char[3, 3];
    char currentPlayer = 'X';   // Zaczynamy od 'X', bo tradycja mówi, że krzyżyk zawsze zaczyna.

    public void PlayGame()
    {
        // Tutaj rozpocznie się magia gry
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '.';  // Początkowo wszystkie pola są jak niespisane kartki historii.
            }
        }
    }

    private void PrintBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]); // Dodajemy trochę przestrzeni, żeby było jak w prawdziwym kółko i krzyżyk.
            }
            Console.WriteLine();    // Po każdym wierszu przechodzimy do nowej linii, żeby nie było tłoku.
        }
    }

    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';   // Taki mały trik, żeby nie zgubić się, kto teraz tańczy.
    }

    private void TakeTurn()
    {
        int row = -1, column = -1;
        bool isValidInput = false;

        while (!isValidInput)
        {
            // Tutaj gracz decyduje, gdzie chce postawić swój znak. Musi być czujny, bo jak wiadomo, w kółko i krzyżyk nie ma miejsca na błąd.
            Console.WriteLine($"Ruch gracza {currentPlayer}: ");
            Console.Write("Wybierz wiersz (1-3): ");
            isValidInput = int.TryParse(Console.ReadLine(), out row) && row >= 1 && row <= 3;

            if (isValidInput)
            {
                Console.Write("Wybierz kolumnę (1-3): ");
                isValidInput = int.TryParse(Console.ReadLine(), out column) && column >= 1 && column <= 3;
            }

            if (!isValidInput || board[row - 1, column - 1] != '.')
            {
                Console.WriteLine("O nie! To pole jest już zajęte lub coś poszło nie tak. Spróbujmy jeszcze raz.");
                isValidInput = false; // Zapewnia, że pętla kontynuuje, jeśli dane są nieprawidłowe lub pole jest zajęte
            }
        }

        // Aktualizacja planszy, gdy dane wejściowe są prawidłowe i pole nie jest zajęte
        // Pamiętaj, że aktualizacja planszy to jak zapisanie swojego imienia w historii - tylko zamiast imienia, wstawiamy 'X' lub 'O'.
        board[row - 1, column - 1] = currentPlayer;
    }

    private bool CheckForWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            // Sprawdzanie wierszy i kolumn, bo kto nie lubi wygrywać w linii prostej?
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer ||
                board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;    // Bingo! Mamy zwycięzcę!
        }

        // Sprawdzanie przekątnych, bo każdy lubi być skośnym strategiem.
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
            board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;    // Ktoś właśnie zdobył skośnego jackpota!

        return false;   // Nie ma zwycięzcy, gra toczy się dalej.
    }

    private bool CheckForTie()
    {
        // Sprawdź, czy wszystkie pola są zajęte
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '.')
                    return false;   // Jeśli znajdziemy chociaż jedno puste miejsce, to jak na dyskotece, gdzie jest jeszcze miejsce na parkiecie.
            }
        }
        return true;    // Wszystkie miejsca zajęte, czas ogłosić remis.
    }
}
