using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Services;

public class GameEngine : IGameEngine
{
    private IPlayer playerX;
    private IPlayer playerO;
    private IGameAI _gameAI; // Sztuczna inteligencja
    private IPlayerFactory _playerFactory;

    public IPlayer CurrentPlayer { get; private set; }
    public IBoard Board { get; private set; }
    public bool IsGameRunning { get; private set; }

    public GameEngine(IBoard board, IPlayerFactory playerFactory, IGameAI gameAI)
    {
        IsGameRunning = true;   // Jak w dobrym serialu, gra trwa, dopóki widzowie (gracze) nie zdecydują inaczej  
        Board = board;
        _gameAI = gameAI;
        _playerFactory = playerFactory;

        // W krainie kółka i krzyżyka, wybór bohatera jest kluczowy. Czy zechcesz walczyć ramię w ramię
        // z odważnym rycerzem, czy też przywołać do życia mistycznego golema, by walczył u twojego boku?
        InitializePlayers(_gameAI);
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

    private void InitializePlayers(IGameAI gameAI)
    {
        // Każda epopeja zaczyna się od pierwszego bohatera. Tutaj mamy naszego nieustraszonego X,
        // gotowego stanąć na polu bitwy.
        playerX = _playerFactory.CreatePlayer('X');
        CurrentPlayer = playerX;

        // A teraz decyzja, czy nasz drugi bohater będzie równie krwisty jak pierwszy, czy może
        // postanowimy wezwać z głębin cyfrowego świata naszego golema AI.
        if (gameAI == null)
        {
            // Ah, wybór pada na kolejnego śmiertelnika. Niech walka będzie sprawiedliwa!
            playerO = _playerFactory.CreatePlayer('O'); // Gracz ludzki, jak dobrze mieć kogoś z krwi i kości po drugiej stronie.
        }
        else
        {
            // Golem AI zostaje przywołany! Niech jego cyfrowy umysł przyniesie nam zwycięstwo!
            playerO = _playerFactory.CreatePlayer('O', true); // AI, niech stanie przed nami w całej swej algorytmicznej chwale.
        }
    }
}
