using TicTacToe.Interfaces;

namespace TicTacToe.Services;

public class GameEngine : IGameEngine
{
    private IPlayer playerX;
    private IPlayer playerO;

    public IPlayer CurrentPlayer { get; private set; }
    public IBoard Board { get; private set; }
    public bool IsGameRunning { get; private set; }

    public GameEngine(IBoard board, IPlayerFactory playerFactory)
    {
        Board = board;
        playerX = playerFactory.CreatePlayer(GameTexts.SymbolX);
        playerO = playerFactory.CreatePlayer(GameTexts.SymbolO);
        CurrentPlayer = playerX;    // X zawsze zaczyna, bo tradycja tak nakazuje
        IsGameRunning = true;   // Jak w dobrym serialu, gra trwa, dopóki widzowie (gracze) nie zdecydują inaczej
    }

    public void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == playerX ? playerO : playerX; // Zmiana graczy jest jak zmiana kierunków wiatru
    }

    public bool CheckForWinner()
    {
        char[,] myBoard = Board.GetBoard();
        char player = CurrentPlayer.Symbol;

        // Tu sprawdzamy wiersze, kolumny i przekątne jak detektyw szukający wskazówek
        for (int i = 0; i < 3; i++)
        {
            // Sprawdzanie wierszy i kolumn
            if (myBoard[i, 0] == player && myBoard[i, 1] == player && myBoard[i, 2] == player ||
                myBoard[0, i] == player && myBoard[1, i] == player && myBoard[2, i] == player)
                return true;    // Mamy zwycięzcę!
        }

        // Sprawdzanie przekątnych
        if (myBoard[0, 0] == player && myBoard[1, 1] == player && myBoard[2, 2] == player ||
            myBoard[0, 2] == player && myBoard[1, 1] == player && myBoard[2, 0] == player)
        {
            return true;    // Zwycięstwo na przekątnej, jak złoto olimpijskie w skokach narciarskich!
        }

        return false;   // Gra toczy się dalej
    }

    public bool CheckForTie()
    {
        // Sprawdzamy, czy na planszy są jeszcze wolne miejsca
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Board.IsFieldEmpty(i, j))
                    return false;   // Jeszcze jest miejsce, gra trwa.
            }
        }

        // Jeśli nie ma wolnych miejsc i nikt nie wygrał, to mamy remis.
        return !CheckForWinner();
    }

    public void InitializeBoard()
    {
        Board.InitializeBoard();    // Reset planszy jak po naciśnięciu magicznego przycisku.
    }

    public void MakeMove(int row, int column)
    {
        if (Board.IsFieldEmpty(row, column))
        {
            Board.SetMove(row, column, CurrentPlayer.Symbol);   // Ruch gracza to jak zaznaczenie terytorium.
        }
    }

    public void SetGameRunning(bool isRunning)
    {
        IsGameRunning = isRunning;  // Kontrolujemy, czy gra ma się toczyć dalej.
    }

    public void PrintBoard()
    {
        Board.PrintBoard(); // Wyświetlamy planszę jak najnowsze dzieło w galerii sztuki.
    }

    public bool IsFieldEmpty(int row, int column)
    {
        return Board.IsFieldEmpty(row, column); // Sprawdzamy, czy pole jest wolne, jak parking w niedzielę rano.
    }
}
