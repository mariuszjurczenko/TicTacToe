namespace TicTacToe;

public class TicTacToe
{
    char[,] board = new char[3, 3];

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
}
