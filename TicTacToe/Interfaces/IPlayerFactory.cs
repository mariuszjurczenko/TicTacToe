namespace TicTacToe.Interfaces;

public interface IPlayerFactory
{
    IPlayer CreatePlayer(char symbol, bool isAI = false);
}
