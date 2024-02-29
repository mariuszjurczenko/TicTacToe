using FluentAssertions;
using Moq;
using TicTacToe.Interfaces;
using TicTacToe.Services;

namespace TicTacToe.Tests;

public class GameEngineTests
{
    private readonly GameEngine _gameEngine;
    private readonly Mock<IBoard> _mockBoard;
    private readonly Mock<IPlayerFactory> _mockPlayerFactory;
    private readonly Mock<IPlayer> _mockPlayerX;
    private readonly Mock<IPlayer> _mockPlayerO;

    public GameEngineTests()
    {
        // Przygotowanie aren
        _mockBoard = new Mock<IBoard>();
        _mockPlayerFactory = new Mock<IPlayerFactory>();
        _mockPlayerX = new Mock<IPlayer>();
        _mockPlayerO = new Mock<IPlayer>();

        _mockPlayerX.Setup(p => p.Symbol).Returns('X');
        _mockPlayerO.Setup(p => p.Symbol).Returns('O');

        _mockPlayerFactory.Setup(f => f.CreatePlayer('X')).Returns(_mockPlayerX.Object);
        _mockPlayerFactory.Setup(f => f.CreatePlayer('O')).Returns(_mockPlayerO.Object);

        // Czar przywołania Mistrza Strategii
        _gameEngine = new GameEngine(_mockBoard.Object, _mockPlayerFactory.Object);
    }

    // Inicjacja Mistrza - "Ceremonia Przywołania"
    [Fact]
    public void Constructor_ShouldInitializeCurrentPlayerToPlayerX()
    {
        // Sprawdzenie, czy Mistrz rozpoczyna jako PlayerX
        _gameEngine.CurrentPlayer.Should().Be(_mockPlayerX.Object);
    }

    // Zmiana Gracza - "Rytuał Przemiany"
    [Fact]
    public void SwitchPlayer_ShouldSwitchFromPlayerXToPlayerO()
    {
        // Rytuał przemiany
        _gameEngine.SwitchPlayer();

        // Sprawdzenie, czy Mistrz Strategii przyjął nową postać - PlayerO
        _gameEngine.CurrentPlayer.Should().Be(_mockPlayerO.Object);
    }

    // Sprawdzanie Warunków Zwycięstwa - "Próba Mocy"
    [Fact]
    public void CheckForWinner_NoMovesMade_ShouldReturnFalse()
    {
        // Przywołanie czystej, nieskazitelnej planszy
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
        { '.', '.', '.' },
        { '.', '.', '.' },
        { '.', '.', '.' }
        });

        // Czy na tak niewzruszonej planszy pojawi się cień zwycięstwa?
        bool result = _gameEngine.CheckForWinner();

        // Mistrz wie, że jeszcze nie czas na zwycięstwo
        result.Should().BeFalse();
    }

    // Sprawdzanie Warunków Zwycięstwa - "Próba Mocy"
    [Fact]
    public void CheckForWinner_BoardHasWinningCondition_ShouldReturnTrue()
    {
        // Zaklęcie przywołania mistycznej planszy
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { 'X', 'X', 'X' },
            { '.', '.', '.' },
            { '.', '.', '.' }
        });

        // Oczekiwanie, czy światło prawdy ukazuje zwycięstwo
        bool result = _gameEngine.CheckForWinner();

        // Sprawdzamy, czy Mistrz został godnie uwieczniony w annałach zwycięzców
        result.Should().BeTrue();
    }

    // Sprawdzanie Warunków Zwycięstwa - "Próba Mocy"
    [Fact]
    public void CheckForWinner_FullColumnWithSameSymbol_ShouldReturnTrue()
    {
        // Przywołując planszę, na której mroczne siły ustawiły symbole 'X' w pionowej linii dominacji
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
        { 'X', '.', '.' },
        { 'X', '.', '.' },
        { 'X', '.', '.' }
        });

        // Wzywamy Mistrza Strategii, by rozstrzygnął, czy taka konfiguracja oznacza zwycięstwo
        bool result = _gameEngine.CheckForWinner();

        // Oczekujemy, że Mistrz, z całą swoją mądrością, potwierdzi, iż jest to niezaprzeczalny triumf
        result.Should().BeTrue();
    }

    // Sprawdzanie Warunków Zwycięstwa - "Próba Mocy"
    [Fact]
    public void CheckForWinner_MainDiagonalWithSameSymbol_ShouldReturnTrue()
    {
        // Przywołujemy planszę, na której starożytne znaki 'X' tworzą ścieżkę mocy wzdłuż głównej przekątnej
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { 'X', '.', '.' },
            { '.', 'X', '.' },
            { '.', '.', 'X' }
        });

        // Wezwijmy Czarodzieja Planszy, aby orzekł, czy takie ułożenie przynosi zwycięstwo
        bool result = _gameEngine.CheckForWinner();

        // Oczekujemy, że w swojej nieskończonej mądrości, potwierdzi on, iż jest to ścieżka do tryumfu
        result.Should().BeTrue();
    }

    // Sprawdzanie Warunków Zwycięstwa - "Próba Mocy"
    [Fact]
    public void CheckForWinner_SecondaryDiagonalWithSameSymbol_ShouldReturnTrue()
    {
        // Przygotowujemy planszę, na której znaki 'X' rysują linię mocy od jednego rogu do drugiego, lecz tym razem wzdłuż drugorzędnej przekątnej
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { '.', '.', 'X' },
            { '.', 'X', '.' },
            { 'X', '.', '.' }
        });

        // Wzywamy naszego GameEngine, Czarodzieja Wszechczasów, aby orzekł o tym niezwykłym zdarzeniu
        bool result = _gameEngine.CheckForWinner();

        // Oczekujemy, że z jego niewypowiedzianą mądrością, uzna on tę drogę za pewnik zwycięstwa
        result.Should().BeTrue();
    }

    // Sprawdzanie Warunków Remisu - "Test Równowagi"
    [Fact]
    public void CheckForTie_BoardIsFullAndNoWinner_ShouldReturnTrue()
    {
        // Ustawiamy scenariusz, w którym plansza jest zapełniona do ostatniego pola, ale żaden z graczy nie zaznaczył ścieżki zwycięstwa
        _mockBoard.Setup(b => b.IsFieldEmpty(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { 'X', 'O', 'X' },
            { 'X', 'X', 'O' },
            { 'O', 'X', 'O' }
        });

        // Wzywamy naszego strażnika zasad, by wydał werdykt
        bool result = _gameEngine.CheckForTie();

        // Oczekujemy, że w tak zrównoważonej rozgrywce, werdykt będzie jednoznaczny - remis
        result.Should().BeTrue();
    }

    // Sprawdzanie Warunków Remisu - "Test Równowagi"
    [Fact]
    public void CheckForTie_StartOfGame_ShouldReturnFalse()
    {
        // Na początku każdej rozgrywki, gdy nadzieje na zwycięstwo są jeszcze świeże, a plansza pusta...
        _mockBoard.Setup(b => b.IsFieldEmpty(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

        // Zapytujemy naszego sędziego, czy już można mówić o remisie
        bool result = _gameEngine.CheckForTie();

        // Oczekujemy, że przy tak wielu możliwościach przed nami, werdykt będzie jasny - jeszcze za wcześnie, by orzec o remisie
        result.Should().BeFalse();
    }

    // Ruchy na Planszy - "Taniec Mistrzów"
    // Ruch Zgodny z Regułami - "Krok do Przodu"
    [Fact]
    public void MakeMove_ValidMove_ShouldSetMoveOnBoard()
    {
        // Wybieramy salę (pole) do naszego pierwszego kroku
        int row = 0;
        int column = 1;

        // Nasz czarodziej-kontroler planszy potwierdza, że sala jest wolna
        _mockBoard.Setup(b => b.IsFieldEmpty(row, column)).Returns(true);

        // Dokonujemy ruchu, a orkiestra (GameEngine) zapisuje nasz wybór
        _gameEngine.MakeMove(row, column);

        // Upewniamy się, że nasz ruch został właściwie zarejestrowany
        _mockBoard.Verify(b => b.SetMove(row, column, _mockPlayerX.Object.Symbol), Times.Once);
    }

    // Ruchy na Planszy - "Taniec Mistrzów"
    // Nieproszony Gość - "Próba Wtargnięcia"
    [Fact]
    public void MakeMove_AttemptToMoveOnOccupiedField_ShouldNotChangeTheBoard()
    {
        // Wybieramy salę, która już jest zajęta
        int row = 0, column = 1;
        _mockBoard.Setup(b => b.IsFieldEmpty(row, column)).Returns(false);

        // Próba wykonania ruchu kończy się niepowodzeniem
        _gameEngine.MakeMove(row, column);

        // Orkiestra (GameEngine) ignoruje próbę wtargnięcia na zajęte pole
        _mockBoard.Verify(b => b.SetMove(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()), Times.Never);
    }

    // Ruchy na Planszy - "Taniec Mistrzów"
    // Próba Ucieczki z Sali - "Poza Granicami"
    [Theory]
    [InlineData(-1, -1)]
    [InlineData(3, 3)]
    public void MakeMove_MoveOutsideBoardBounds_ShouldNotChangeTheBoard(int row, int column)
    {
        // Próba wykonania kroku poza granice sali (planszy)
        _gameEngine.MakeMove(row, column);

        // Orkiestra (GameEngine) nie pozwala na kroki w nieistniejących miejscach
        _mockBoard.Verify(b => b.SetMove(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()), Times.Never);
    }

    // Rytuał Inicjalizacji - "Oczyszczenie Planszy"
    [Fact]
    public void InitializeBoard_ShouldResetAllFieldsToInitialValue()
    {
        // Wezwijmy magię inicjalizacji, aby przywrócić planszę do stanu dziewiczego
        _gameEngine.InitializeBoard();

        // Sprawdzenie, czy plansza została oczyszczona
        // Oczekujemy, że nasz wierny strażnik planszy, _mockBoard, potwierdzi wykonanie rytuału dokładnie jeden raz
        _mockBoard.Verify(b => b.InitializeBoard(), Times.Once);
    }

    // Zmiana Fazy Gry - "Włącznik Przeznaczenia"
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetGameRunning_ShouldUpdateGameStateAccordingly(bool isRunning)
    {
        // Wywołanie zaklęcia, które uruchamia lub zatrzymuje bieg losów w krainie TicTacToe
        _gameEngine.SetGameRunning(isRunning);

        // Sprawdzamy, czy zaklęcie zadziałało zgodnie z wolą maga
        _gameEngine.IsGameRunning.Should().Be(isRunning);
    }

    // Odrodzenie Gry - "Zaklęcie Nowego Początku"
    [Fact]
    public void AfterReset_CurrentPlayerShouldBePlayerXAndGameRunning()
    {
        // Symulacja zakończenia epickiej bitwy
        _gameEngine.SetGameRunning(false);

        // Oczarowanie planszy zaklęciem nowego początku
        _gameEngine.InitializeBoard();
        _gameEngine.SetGameRunning(true);

        // Sprawdzamy, czy pierwszy rycerz gotowy do walki to zawsze odważny PlayerX
        _gameEngine.CurrentPlayer.Should().Be(_mockPlayerX.Object);
        // Oraz czy świat gry ponownie pulsuje życiem
        _gameEngine.IsGameRunning.Should().BeTrue();
    }
}