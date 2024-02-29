using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Services;

public class PlayerFactory : IPlayerFactory
{
    public IPlayer CreatePlayer(char symbol)
    {
        return new Player(symbol);
    }
}
