using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Services;

public class GameEngine : IGameEngine
{
    private IPlayer playerX;
    private IPlayer playerO;
    private IGameAI _gameAI; // Sztuczna inteligencja
    private IGameUI _gameUI;
    private IPlayerFactory _playerFactory;

    public IPlayer CurrentPlayer { get; private set; }
    public IBoard Board { get; private set; }
    public bool IsGameRunning { get; private set; }

    public GameEngine(IBoard board, IPlayerFactory playerFactory, IGameAI gameAI, IGameUI gameUI)
    {
        IsGameRunning = true;   // Jak w dobrym serialu, gra trwa, dopóki widzowie (gracze) nie zdecydują inaczej  
        Board = board;
        _gameAI = gameAI;
        _gameUI = gameUI;
        _playerFactory = playerFactory;

        // W krainie kółka i krzyżyka, wybór bohatera jest kluczowy. Czy zechcesz walczyć ramię w ramię
        // z odważnym rycerzem, czy też przywołać do życia mistycznego golema, by walczył u twojego boku?
        InitializePlayers();
        WhoPlayerStartsFirst();
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

    public bool IsCurrentPlayerAI()
    {
        return CurrentPlayer.IsAI;
    }


    public void MakeAIMove()
    {
        if (IsCurrentPlayerAI())
        {
            var (row, column) = _gameAI.DecideMove(Board, CurrentPlayer.Symbol, CurrentPlayer == playerX ? playerO.Symbol : playerX.Symbol);
            MakeMove(row, column);
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

    public void InitializePlayers()
    {
        char playerSymbol = _gameUI.AskForPlayerSymbol();
        char opponentSymbol = playerSymbol == 'X' ? 'O' : 'X';

        playerX = _playerFactory.CreatePlayer(playerSymbol);
        CurrentPlayer = playerX;

        if (_gameAI == null)
        {
            playerO = _playerFactory.CreatePlayer(opponentSymbol); // Human player
        }
        else
        {
            playerO = _playerFactory.CreatePlayer(opponentSymbol, true); // AI player
        }
    }

    public void WhoPlayerStartsFirst()
    {
        bool playerStartsFirst = _gameUI.AskIfPlayerStartsFirst();
        if (playerStartsFirst)
        {
            CurrentPlayer = playerX;
        }
        else
        {
            CurrentPlayer = playerO;
        }

        IsGameRunning = true;
    }
}
