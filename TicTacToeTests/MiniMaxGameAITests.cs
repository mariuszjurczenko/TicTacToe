using FluentAssertions;
using Moq;
using TicTacToe.AI;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class MiniMaxGameAITests
{
    private readonly Mock<IBoardRenderer> _mockBoardRenderer;

    public MiniMaxGameAITests()
    {
        _mockBoardRenderer = new Mock<IBoardRenderer>();
    }

    [Fact]
    public void DecideMove_Should_SelectWinningMove_When_Possible()
    {
        // Arrange
        var board = new Board(_mockBoardRenderer.Object);        // Ustawiamy planszę w stanie, gdzie AI ma natychmiastową możliwość wygranej
        board.SetMove(0, 0, 'X');
        board.SetMove(0, 1, 'X');
        board.SetMove(1, 1, 'O');
        board.SetMove(2, 0, 'O');
        var ai = new MiniMaxGameAI();

        // Act
        var move = ai.DecideMove(board, 'X', 'O');

        // Assert
        move.Should().Be((0, 2), "AI powinno wybrać ruch wygrywający (0,2)");
    }

    [Fact]
    public void DecideMove_Should_BlockOpponentWinningMove_When_Possible()
    {
        // Arrange
        var board = new Board(_mockBoardRenderer.Object);        // Ustawienie tak aby gracz 'O', był o jeden ruch od wygranej
        board.SetMove(0, 0, 'O');
        board.SetMove(0, 2, 'O');
        board.SetMove(1, 0, 'X');
        board.SetMove(2, 0, 'X');
        var ai = new MiniMaxGameAI();

        // Act
        var move = ai.DecideMove(board, 'X', 'O');

        // Assert
        move.Should().Be((0, 1), "AI powinno wybrać ruch blokujący wygraną przeciwnika (0,1)");
    }
}