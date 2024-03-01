namespace TicTacToe.Interfaces;

public interface IGameStatistics
{
    int WinsX { get; }
    int WinsO { get; }
    int Ties { get; }

    void IncrementWinsX();
    void IncrementWinsO();
    void IncrementTies();
}
