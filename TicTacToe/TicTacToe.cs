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
}
