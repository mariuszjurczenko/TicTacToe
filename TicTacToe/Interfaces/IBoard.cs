namespace TicTacToe.Interfaces;

public interface IBoard
{
    void InitializeBoard();
    void PrintBoard();
    char[,] GetBoard();
    void SetMove(int row, int col, char player);
    bool IsFieldEmpty(int row, int col);
}
