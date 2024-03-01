using FluentAssertions;
using Moq;
using TicTacToe.AI;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class SimpleGameAITests
{
    private readonly Board board;
    private readonly SimpleGameAI ai;
    private readonly char playerSymbol;
    private readonly char opponentSymbol;
    private readonly Mock<IBoardRenderer> mockBoardRenderer;

    public SimpleGameAITests()
    {
        mockBoardRenderer = new Mock<IBoardRenderer>();
        board = new Board(mockBoardRenderer.Object);
        ai = new SimpleGameAI();
        playerSymbol = 'X';
        opponentSymbol = 'O';
    }

    [Fact]
    public void DecideMove_ShouldChooseFirstEmptyField_OnEmptyBoard()
    {
        // Arrange
        // Na pustej planszy AI powinno wybrać pierwsze lepsze wolne pole.
        // Ale jak to mówią, w prostocie siła!

        // Act
        var (row, column) = ai.DecideMove(board, playerSymbol, opponentSymbol);

        // Assert
        row.Should().BeInRange(0, 2);
        column.Should().BeInRange(0, 2);
    }

    [Fact]
    public void DecideMove_ShouldBlockOpponentWinningMove()
    {
        // Arrange
        // Przeciwnik jest o krok od zwycięstwa, ale nasze AI stoi na straży!
        // Blokuje ruch przeciwnika z taką gracją, jakby to była szachowa partia.
        // Symulacja sytuacji, gdzie przeciwnik ma już dwa 'O' w pierwszym wierszu i tylko jedno pole jest puste
        board.SetMove(0, 0, opponentSymbol);
        board.SetMove(0, 1, opponentSymbol);

        // Act
        var (row, column) = ai.DecideMove(board, playerSymbol, opponentSymbol);

        // Assert
        // AI powinno zablokować przeciwnika, wykonując ruch na ostatnim wolnym polu w pierwszym wierszu
        row.Should().Be(0);
        column.Should().Be(2);
    }

    [Fact]
    public void DecideMove_ShouldChooseWinningMove_WhenPossible()
    {
        // Arrange
        // AI dostrzega szansę na zwycięstwo i chwyta ją obiema rękoma!
        // To ruch godny mistrza szachowego, kończący grę z triumfem.
        // Symulacja sytuacji, gdzie AI ma już dwa 'X' w pierwszej kolumnie i tylko jedno pole jest puste
        board.SetMove(0, 0, playerSymbol);
        board.SetMove(1, 0, playerSymbol);

        // Act
        var (row, column) = ai.DecideMove(board, playerSymbol, opponentSymbol);

        // Assert
        // AI powinno wybrać ruch prowadzący do wygranej, uzupełniając trzeci 'X' w pierwszej kolumnie
        row.Should().Be(2);
        column.Should().Be(0);
    }
}