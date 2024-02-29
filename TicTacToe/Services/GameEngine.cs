using TicTacToe.Interfaces;
using TicTacToe.Utils;

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
        return GameRules.CheckForWinner(this.Board, this.CurrentPlayer.Symbol);
    }

    public bool CheckForTie()
    {
        // Użyj GameRules do sprawdzenia remisu, ale tylko jeśli nie ma zwycięzcy
        return !CheckForWinner() && GameRules.CheckForTie(this.Board);
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
