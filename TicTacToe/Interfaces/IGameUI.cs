namespace TicTacToe.Interfaces;

public interface IGameUI
{
    int GetInput(string prompt, int min, int max);
    void PrintMessage(string message);
    bool AskToPlayAgain();
}
