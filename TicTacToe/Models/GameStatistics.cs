using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Models;

public class GameStatistics : IGameStatistics
{
    public int WinsX { get; private set; }
    public int WinsO { get; private set; }
    public int Ties { get; private set; }

    public void IncrementWinsX() => WinsX++;

    public void IncrementWinsO() => WinsO++;

    public void IncrementTies() => Ties++;

    public override string ToString()
    {
        return string.Format(GameTexts.Statistics, WinsX, WinsO, Ties);
    }
}
