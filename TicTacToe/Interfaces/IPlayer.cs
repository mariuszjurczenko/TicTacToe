namespace TicTacToe.Interfaces;

public interface IPlayer
{
    char Symbol { get; }
    // Zaklęcie wskazujące, czy gracz jest dziełem magów
    // Dodajemy właściwość wskazującą, czy gracz jest AI
    bool IsAI { get; }
    string ToString();
}
