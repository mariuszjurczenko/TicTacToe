using TicTacToe.Gameplay;
using TicTacToe.Interfaces;
using TicTacToe.IoC;
using TicTacToe.Models;
using TicTacToe.Services;
using TicTacToe.UI;

namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        var container = new SimpleContainer();
        var gameUIWrapper = new GameUIWrapper();

        // Rejestracja typów
        container.For<IPlayerFactory>().Use<PlayerFactory>();
        container.For<IBoard>().Use<Board>();
        container.For<IGameEngine>().Use<GameEngine>();
        container.ForSingleton<IGameUI>(gameUIWrapper);

        // Rozwiązanie zależności
        var gameEngine = container.Resolve<IGameEngine>();
        var gameUI = container.Resolve<IGameUI>();

        var game = new Game(gameEngine, gameUI);
        game.PlayGame();
    }
}