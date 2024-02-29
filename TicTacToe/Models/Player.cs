using TicTacToe.Interfaces;

namespace TicTacToe.Models;

public class Player : IPlayer
{
    public char Symbol { get; private set; }    // To ich znak rozpoznawczy, jak logo Batmana na niebie nad Gotham.

    public Player(char symbol)
    {
        Symbol = symbol;    // Przydzielamy każdemu graczowi jego unikatowy symbol, jak wybierając superbohaterowi jego kostium.
    }

    public override string ToString()
    {
        // Tutaj gracze mówią światu, kim są - za pomocą swojego symbolu.
        return string.Format(GameTexts.PlayerRepresentation, Symbol);   // Każdy gracz jest gotów wskoczyć na planszę i stawić czoła wyzwaniu.
    }
}
