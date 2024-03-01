using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Gameplay;

public class Game
{
    private IGameEngine _gameEngine;
    private readonly IGameUI _gameUI;

    public Game(IGameEngine gameEngine, IGameUI gameUI)
    {
        _gameEngine = gameEngine;
        _gameUI = gameUI;
    }

    void TakeTurn()
    {
        bool moveMade = false;

        while (!moveMade)
        {
            if (_gameEngine.IsCurrentPlayerAI())
            {
                _gameEngine.MakeAIMove();
                moveMade = true;
            }
            else
            {
                _gameUI.PrintMessage(string.Format(GameTexts.PromptPlayerMove, _gameEngine.CurrentPlayer));

                int row = _gameUI.GetInput(GameTexts.PromptRow, 1, 3) - 1;
                int column = _gameUI.GetInput(GameTexts.PromptColumn, 1, 3) - 1;

                if (!_gameEngine.IsFieldEmpty(row, column))
                {
                    _gameUI.PrintMessage(GameTexts.ErrorInvalidInputOrOccupied);
                }
                else
                {
                    _gameEngine.MakeMove(row, column);
                    moveMade = true;
                }
            }          
        }
    }

    public void PlayGame()
    {
        while (_gameEngine.IsGameRunning)
        {
            bool isWinner;
            bool isTie;

            do
            {
                Console.Clear();
                _gameEngine.PrintBoard();
                TakeTurn();
                isWinner = _gameEngine.CheckForWinner();

                if (isWinner)
                {
                    Console.Clear();
                    _gameEngine.PrintBoard();
                    _gameUI.PrintMessage(string.Format(GameTexts.GameWin, _gameEngine.CurrentPlayer));
                    break;
                }

                isTie = _gameEngine.CheckForTie();
                if (isTie)
                {
                    Console.Clear();
                    _gameEngine.PrintBoard();
                    _gameUI.PrintMessage(GameTexts.GameTie);
                    break;
                }

                _gameEngine.SwitchPlayer();

            } while (!isWinner && !isTie);

            // Pytanie o kolejną grę
            _gameEngine.SetGameRunning(_gameUI.AskToPlayAgain());

            if (_gameEngine.IsGameRunning)
            {
                _gameEngine.InitializeBoard();  // Reset planszy to jak Gandalf, który mówi "A teraz zaczynamy od nowa".
                _gameEngine.InitializePlayers();
                _gameEngine.WhoPlayerStartsFirst();
            }
        }
    }
}