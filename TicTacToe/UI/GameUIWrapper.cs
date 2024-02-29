using TicTacToe.Interfaces;

namespace TicTacToe.UI;

public class GameUIWrapper : IGameUI
{
    public int GetInput(string prompt, int min, int max) => GameUI.GetInput(prompt, min, max);
    public void PrintMessage(string message) => GameUI.PrintMessage(message);
    public bool AskToPlayAgain() => GameUI.AskToPlayAgain();
}
