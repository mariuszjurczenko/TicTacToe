using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Models;

public class Player : IPlayer
{
    public char Symbol { get; private set; }
    public bool IsAI { get; private set; } // Implementacja właściwości IsAI. Oto jak uczymy kowala magii

    public Player(char symbol, bool isAI = false)
    {
        Symbol = symbol;    // Przydzielamy każdemu graczowi jego unikatowy symbol, jak wybierając superbohaterowi jego kostium.
        IsAI = isAI;
    }

    public override string ToString()
    {
        // Tutaj gracze mówią światu, kim są - za pomocą swojego symbolu.
        return string.Format(GameTexts.PlayerRepresentation, Symbol);   // Każdy gracz jest gotów wskoczyć na planszę i stawić czoła wyzwaniu.
    }
}
