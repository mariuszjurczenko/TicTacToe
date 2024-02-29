using TicTacToe.Interfaces;

namespace TicTacToe.Models;

public class Board : IBoard
{
    private char[,] board;
    private const int Size = 3; // Rozmiar planszy, standardowo 3x3, jak stół do ping-ponga dla skrzatów.

    public Board()
    {
        board = new char[Size, Size]; // Tworzymy planszę, każde pole to jak czysta kartka w notatniku.
        InitializeBoard(); // Rozstawiamy "meble" - w naszym przypadku, wypełniamy planszę kropkami.
    }

    public void InitializeBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                board[i, j] = '.'; // Kropka to nasz uniwersalny symbol pustego miejsca, jak wolne miejsce parkingowe w środku nocy.
            }
        }
    }

    public void PrintBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(board[i, j]); // Wyświetlamy każde pole, jakby to była wystawa sztuki.
            }
            Console.WriteLine(); // Po każdym wierszu robimy odstęp, dla lepszego efektu wizualnego.
        }
    }

    public char[,] GetBoard()
    {
        return board; // Udostępniamy naszą planszę, jak książkę z biblioteki.
    }

    // Nasza plansza, niczym starożytny pergamin pełen tajemnic
    // Oto jak nasze oko czarodzieja odkrywa sekrety pergaminu
    public char GetSymbol(int x, int y)
    {
        return board[x, y];  // Odczytujemy zaklęcie zapisane na pergaminie
    }

    public void SetMove(int row, int col, char player)
    {
        if (row >= 0 && row < Size && col >= 0 && col < Size) // Sprawdzamy, czy ruch mieści się w granicach naszego "domu".
        {
            board[row, col] = player; // Zaznaczamy ruch gracza, jakby to był autograf na ścianie.
        }
    }

    public bool IsFieldEmpty(int row, int col)
    {
        return board[row, col] == '.'; // Sprawdzamy, czy pole jest wolne, jak miejsce w teatrze na premierze.
    }
}
