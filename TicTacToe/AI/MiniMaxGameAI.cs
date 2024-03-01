using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.AI;

public class MiniMaxGameAI : IGameAI
{
    public (int row, int column) DecideMove(IBoard board, char playerSymbol, char opponentSymbol)
    {
        int bestScore = int.MinValue;
        int row = -1;
        int column = -1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board.IsFieldEmpty(i, j))
                {
                    board.SetMove(i, j, playerSymbol);
                    int score = MiniMax(board, false, playerSymbol, opponentSymbol);
                    board.SetMove(i, j, '.'); // Strategia "cofnij i zobacz", przypominająca grę w szachy z samym sobą.

                    if (score > bestScore)
                    {
                        bestScore = score;
                        row = i;
                        column = j;
                    }
                }
            }
        }

        return (row, column); // Zwraca ruch godny Kasparowa, przemyślany i strategiczny.

    }

    private int MiniMax(IBoard board, bool isMaximizing, char playerSymbol, char opponentSymbol)
    {
        if (GameRules.CheckForWinner(board, playerSymbol))
            return 1; // "Zwycięstwo jest słodkie, ale zwycięstwo przewidziane jest jeszcze słodsze."
        if (GameRules.CheckForWinner(board, opponentSymbol))
            return -1; // "Przegrana to tylko kolejna lekcja, nie porażka."
        if (GameRules.CheckForTie(board))
            return 0; // "Remis, czyli pokój na naszych warunkach."

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.IsFieldEmpty(i, j))
                    {
                        board.SetMove(i, j, playerSymbol);
                        int score = MiniMax(board, false, playerSymbol, opponentSymbol);
                        board.SetMove(i, j, '.'); // Taktyka "zrób krok do przodu, ale miej plan na krok wstecz."
                        bestScore = Math.Max(score, bestScore);
                    }
                }
            }
            return bestScore;   // "Maksymalizowanie: zawsze dążyć do najlepszego."
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.IsFieldEmpty(i, j))
                    {
                        board.SetMove(i, j, opponentSymbol);
                        int score = MiniMax(board, true, playerSymbol, opponentSymbol);
                        board.SetMove(i, j, '.'); // "Minimalizowanie: ogranicz ryzyko, zwiększaj szanse."
                        bestScore = Math.Min(score, bestScore);
                    }
                }
            }
            return bestScore; // "Zawsze miej plan awaryjny, nawet gdy jesteś o krok od przegranej."
        }
    }
}
