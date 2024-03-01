namespace TicTacToe.Interfaces;

public interface IBoard
{
    void InitializeBoard();
    void PrintBoard();
    char[,] GetBoard();
    int GetSize();
    // Tutaj dodajemy nową umiejętność do naszego magicznego zwierciadła
    char GetSymbol(int x, int y);   // Oko czarodzieja
    void SetMove(int row, int col, char player);
    bool IsFieldEmpty(int row, int col);
}
