namespace TicTacToe.Interfaces;

public interface IGameEngine
{
    IPlayer CurrentPlayer { get; }
    IBoard Board { get; }
    bool IsGameRunning { get; }

    void SwitchPlayer();
    bool CheckForWinner();
    bool CheckForTie();
    void InitializeBoard();
    void MakeMove(int row, int column);
    void SetGameRunning(bool isRunning);
    void PrintBoard();
    bool IsFieldEmpty(int row, int column);
}
