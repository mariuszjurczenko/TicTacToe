using TicTacToe.Interfaces;

namespace TicTacToe.Utils;

public static class GameRules
{
    // Sprawdzenie zaklęć zwycięstwa
    public static bool CheckForWinner(IBoard board, char symbol)
    {
        char[,] myBoard = board.GetBoard();

        // Tajemnice wierszy i kolumn
        for (int i = 0; i < 3; i++)
        {
            if (AreSymbolsAligned(myBoard[i, 0], myBoard[i, 1], myBoard[i, 2], symbol) ||
                AreSymbolsAligned(myBoard[0, i], myBoard[1, i], myBoard[2, i], symbol))
                return true;
        }

        // Magia przekątnych
        if (AreSymbolsAligned(myBoard[0, 0], myBoard[1, 1], myBoard[2, 2], symbol) ||
            AreSymbolsAligned(myBoard[0, 2], myBoard[1, 1], myBoard[2, 0], symbol))
        {
            return true;
        }

        return false;
    }

    // Sprawdzenie zaklęć remisu
    public static bool CheckForTie(IBoard board)
    {
        char[,] myBoard = board.GetBoard();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (IsFieldEmpty(myBoard[i, j])) // Gdy na polu leży kropka, oznacza to, że walka trwa
                    return false;
            }
        }
        // Gdy wszystkie pola są zajęte, a magia zwycięstwa nie została rzucona, oznacza to remis
        return true;
    }

    private static bool AreSymbolsAligned(char a, char b, char c, char symbol) =>
        a == symbol && b == symbol && c == symbol;

    private static bool IsFieldEmpty(char field) => field == '.';
}
