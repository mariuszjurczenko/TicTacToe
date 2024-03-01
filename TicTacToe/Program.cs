using TicTacToe.AI;
using TicTacToe.Gameplay;
using TicTacToe.Interfaces;
using TicTacToe.IoC;
using TicTacToe.Models;
using TicTacToe.Renderers;
using TicTacToe.Services;
using TicTacToe.UI;
using TicTacToe.Utils;

namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        var container = new SimpleContainer();
        var gameUIWrapper = new GameUIWrapper();

        // Tutaj zaczyna się nasza przygoda. Jak w starożytnym rytuale, pytamy wielkiego Orakulum (czyli naszego użytkownika),
        // czy woli stanąć oko w oko z innym śmiertelnikiem, czy też zmierzyć się z bezdusznym Golemem AI.
        // Pytanie użytkownika o tryb gry
        GameMode gameMode = gameUIWrapper.AskForGameMode();

        // Rejestracja typów
        switch (gameMode)
        {
            case GameMode.EasyAI:
                container.For<IGameAI>().Use<SimpleGameAI>(); // Dla przeciwnika AI łatwego
                break;
            case GameMode.MediumAI:
                container.For<IGameAI>().Use<HeuristicGameAI>(); // Dla przeciwnika AI średniego
                break;
            case GameMode.HardAI:
                container.For<IGameAI>().Use<MiniMaxGameAI>(); // Dla przeciwnika AI trudnego
                break;
            case GameMode.HumanOpponent:
                // Nie rejestruj żadnego AI, gra z ludzkim przeciwnikiem
                break;
            default:
                break;
        }

        container.For<IPlayerFactory>().Use<PlayerFactory>();
        container.For<IBoardRenderer>().Use<ConsoleBoardRenderer>();
        container.For<IBoard>().Use<Board>();
        container.For<IGameEngine>().Use<GameEngine>();
        container.For<IGameStatistics>().Use<GameStatistics>();
        container.ForSingleton<IGameUI>(gameUIWrapper);

        // Rozwiązanie zależności
        var gameEngine = container.Resolve<IGameEngine>();
        var gameUI = container.Resolve<IGameUI>();

        var game = new Game(gameEngine, gameUI);
        game.PlayGame();
    }
}