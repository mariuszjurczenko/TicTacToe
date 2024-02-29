using TicTacToe.Interfaces;

namespace TicTacToe.AI;

public class SimpleGameAI : IGameAI
{
    // Tutaj Golem rozpoczyna swój taniec strategii
    public (int row, int column) DecideMove(IBoard board, char playerSymbol, char opponentSymbol)
    {
        var currentBoard = board.GetBoard();
        int size = currentBoard.GetLength(0);

        // 1. Golem szuka zwycięskiego ruchu dla siebie
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (board.IsFieldEmpty(i, j))
                {
                    board.SetMove(i, j, playerSymbol); // Golem wykonuje prubny ruch

                    if (CheckWin(board, playerSymbol))
                    {
                        board.SetMove(i, j, '.'); // Cofnij ruch
                        return (i, j); // Golem triumfuje
                    }
                    board.SetMove(i, j, '.'); // Golem cofa prubny ruch
                }
            }
        }

        // 2. Golem próbuje zablokować gracza
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (board.IsFieldEmpty(i, j))
                {
                    board.SetMove(i, j, opponentSymbol); // Golem wykonuje prubny ruch przeciwnika

                    if (CheckWin(board, opponentSymbol))
                    {
                        board.SetMove(i, j, '.'); // Cofnij ruch
                        return (i, j); // Golem blokuje zwycięstwo przeciwnika
                    }
                    board.SetMove(i, j, '.'); // Golem cofa prubny ruch
                }
            }
        }

        //  3. Gdy wszystko inne zawiedzie, Golem dokonuje ruchu losowego
        Random random = new Random();
        while (true)
        {
            // Golem rzuca kośćmi losu
            int row = random.Next(size);
            int column = random.Next(size);
            if (board.IsFieldEmpty(row, column))
            {
                return (row, column);
            }
        }
    }

    // Sekretna wiedza Golema o zwycięstwie
    private bool CheckWin(IBoard board, char symbol)
    {
        return Utils.GameRules.CheckForWinner(board, symbol);
    }
}
