using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.UI;

public class GameUIWrapper : IGameUI
{
    public int GetInput(string prompt, int min, int max) => GameUI.GetInput(prompt, min, max);
    public void PrintMessage(string message) => GameUI.PrintMessage(message);
    public bool AskToPlayAgain() => GameUI.AskToPlayAgain();
    // Poprzez ten prosty, lecz potężny rytuał, nasz wojownik - opiekun granicy między światami,
    // przywołuje starożytne zaklęcie z krainy GameUI, pytając dusze wędrowców o wybór ścieżki, którą pragną podążyć.
    public GameMode AskForGameMode() => GameUI.AskForGameMode();
    public char AskForPlayerSymbol() => GameUI.AskForPlayerSymbol();
    public bool AskIfPlayerStartsFirst() => GameUI.AskIfPlayerStartsFirst();
}
