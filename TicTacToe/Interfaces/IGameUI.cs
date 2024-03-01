namespace TicTacToe.Interfaces;

public interface IGameUI
{
    int GetInput(string prompt, int min, int max);
    void PrintMessage(string message);
    bool AskToPlayAgain();
    // O, wielka poro, która stoi przed każdym graczem, nim jeszcze pierwszy ruch zostanie wykonany.
    // Czy zdecydujesz się na samotną podróż w starciu z niezgłębioną logiką AI,
    // czy też wybierzesz bardziej ludzką ścieżkę, stając oko w oko z innym śmiałkiem?
    bool AskForGameMode();
    char AskForPlayerSymbol();
    bool AskIfPlayerStartsFirst();
}
