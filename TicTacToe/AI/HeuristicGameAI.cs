using TicTacToe.Interfaces;

namespace TicTacToe.AI;

public class HeuristicGameAI : IGameAI
{
    public (int row, int column) DecideMove(IBoard board, char playerSymbol, char opponentSymbol)
    {
        var boardState = board.GetBoard();
        int size = boardState.GetLength(0);

        // Sprawdź, czy można wygrać lub zablokować przeciwnika
        var winOrBlockMove = FindWinOrBlockMove(board, playerSymbol, opponentSymbol);
        if (winOrBlockMove.HasValue) return winOrBlockMove.Value;

        // Zajmij środkowe pole, jeśli jest wolne
        if (board.IsFieldEmpty(size / 2, size / 2))
        {
            return (size / 2, size / 2);
        }

        // Zajmij wolny róg
        var cornerMove = FindCornerMove(board);
        if (cornerMove.HasValue) return cornerMove.Value;

        // Zajmij wolne boczne pole
        return FindSideMove(board);
    }

    private (int, int)? FindWinOrBlockMove(IBoard board, char playerSymbol, char opponentSymbol)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board.IsFieldEmpty(i, j))
                {
                    // Spróbuj wygrać
                    board.SetMove(i, j, playerSymbol);
                    if (Utils.GameRules.CheckForWinner(board, playerSymbol))
                    {
                        board.SetMove(i, j, '.'); // Cofnij ruch
                        return (i, j);
                    }
                    board.SetMove(i, j, '.'); // Cofnij ruch

                    // Spróbuj zablokować
                    board.SetMove(i, j, opponentSymbol);
                    if (Utils.GameRules.CheckForWinner(board, opponentSymbol))
                    {
                        board.SetMove(i, j, '.'); // Cofnij ruch
                        return (i, j);
                    }
                    board.SetMove(i, j, '.'); // Cofnij ruch
                }
            }
        }

        return null;
    }

    private (int, int)? FindCornerMove(IBoard board)
    {
        var corners = new List<(int, int)> { (0, 0), (0, 2), (2, 0), (2, 2) };
        foreach (var corner in corners)
        {
            if (board.IsFieldEmpty(corner.Item1, corner.Item2))
            {
                return corner;
            }
        }
        return null;
    }

    private (int, int) FindSideMove(IBoard board)
    {
        var sides = new List<(int, int)> { (0, 1), (1, 0), (1, 2), (2, 1) };
        foreach (var side in sides)
        {
            if (board.IsFieldEmpty(side.Item1, side.Item2))
            {
                return side;
            }
        }
        // Jako ostateczność, zwróć pierwszy wolny ruch
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board.IsFieldEmpty(i, j))
                {
                    return (i, j);
                }
            }
        }
        return (0, 0); // Teoretycznie nigdy nie powinno się zdarzyć
    }
}
