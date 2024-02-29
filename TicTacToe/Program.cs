using TicTacToe.AI;
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

        // Tutaj zaczyna się nasza przygoda. Jak w starożytnym rytuale, pytamy wielkiego Orakulum (czyli naszego użytkownika),
        // czy woli stanąć oko w oko z innym śmiertelnikiem, czy też zmierzyć się z bezdusznym Golemem AI.
        // Pytanie użytkownika o tryb gry
        bool playWithAI = gameUIWrapper.AskForGameMode();

        // W zależności od wyboru ścieżki przez naszego bohatera, przyzywamy z głębin naszego kodu
        // albo żywego przeciwnika, albo budzimy do życia Golema AI, by stanął na polu bitwy.
        // To trochę jak wybór pomiędzy smokiem a hydrą – każdy przeciwnik wymaga innego rodzaju odwagi i sprytu.

        // Rejestracja typów
        if (playWithAI)
        {
            container.For<IGameAI>().Use<SimpleGameAI>();
        }

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