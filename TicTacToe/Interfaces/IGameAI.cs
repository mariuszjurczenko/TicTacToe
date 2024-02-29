namespace TicTacToe.Interfaces;

public interface IGameAI
{
    (int row, int column) DecideMove(IBoard board, char playerSymbol, char opponentSymbol);
}

