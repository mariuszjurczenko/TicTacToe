using TicTacToe.Services;

namespace TicTacToe;

public class Game
{
    private GameEngine gameEngine;

    public Game()
    {
        gameEngine = new GameEngine();  // Tutaj Gandalf przywołuje swojego wiernego rumaka Shadowfaxa, czyli nasz GameEngine.
    }

    void TakeTurn()
    {
        bool moveMade = false;

        while (!moveMade)
        {
            GameUI.PrintMessage(string.Format(GameTexts.PromptPlayerMove, gameEngine.CurrentPlayer));

            int row = GameUI.GetInput(GameTexts.PromptRow, 1, 3) - 1;
            int column = GameUI.GetInput(GameTexts.PromptColumn, 1, 3) - 1;

            if (!gameEngine.IsFieldEmpty(row, column))
            {
                GameUI.PrintMessage(GameTexts.ErrorInvalidInputOrOccupied);
            }
            else
            {
                gameEngine.MakeMove(row, column);
                moveMade = true;
            }
        }
    }

    public void PlayGame()
    {
        while (gameEngine.IsGameRunning)
        {
            bool isWinner;
            bool isTie;

            do
            {
                Console.Clear();
                gameEngine.PrintBoard();
                TakeTurn();
                isWinner = gameEngine.CheckForWinner();

                if (isWinner)
                {
                    Console.Clear();
                    gameEngine.PrintBoard();
                    GameUI.PrintMessage(string.Format(GameTexts.GameWin, gameEngine.CurrentPlayer));
                    break;
                }

                isTie = gameEngine.CheckForTie();
                if (isTie)
                {
                    Console.Clear();
                    gameEngine.PrintBoard();
                    GameUI.PrintMessage(GameTexts.GameTie);
                    break;
                }

                gameEngine.SwitchPlayer();

            } while (!isWinner && !isTie);

            // Pytanie o kolejną grę
            gameEngine.SetGameRunning(GameUI.AskToPlayAgain());

            if (gameEngine.IsGameRunning)
                gameEngine.InitializeBoard();   // Reset planszy to jak Gandalf, który mówi "A teraz zaczynamy od nowa".
        }
    }
}