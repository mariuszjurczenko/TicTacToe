using FluentAssertions;
using Moq;
using TicTacToe.AI;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class HeuristicGameAITests
{
    private readonly HeuristicGameAI _ai;
    private readonly Mock<IBoard> _mockBoard;

    public HeuristicGameAITests()
    {
        _ai = new HeuristicGameAI();
        _mockBoard = new Mock<IBoard>();
    }

    [Fact]
    public void DecideMove_ShouldWin_WhenHasWinningMove()
    {
        // Arrange
        var board = new Board();
        // Przygotuj planszę tak, aby AI miało możliwość wygranej
        board.SetMove(0, 0, 'X');
        board.SetMove(0, 1, 'X');
        board.SetMove(1, 1, 'O');

        // Act
        var move = _ai.DecideMove(board, 'X', 'O');

        // Assert
        move.Should().Be((0, 2), "because AI should complete the winning line");
    }

    [Fact]
    public void DecideMove_ShouldBlockOpponent_WhenOpponentHasWinningMove()
    {
        // Arrange
        var board = new Board();
        // Przygotuj planszę tak, aby przeciwnik miał możliwość wygranej
        board.SetMove(0, 0, 'O');
        board.SetMove(0, 1, 'O');
        board.SetMove(1, 1, 'X');

        // Act
        var move = _ai.DecideMove(board, 'X', 'O');

        // Assert
        move.Should().Be((0, 2), "because AI should block the opponent's winning line");
    }

    [Fact]
    public void DecideMove_ShouldChooseCenter_WhenAvailable()
    {
        // Arrange
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { '.', '.', '.' },
            { '.', '.', '.' },
            { '.', '.', '.' }
        });
        _mockBoard.Setup(b => b.IsFieldEmpty(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

        // Act
        var move = _ai.DecideMove(_mockBoard.Object, 'X', 'O');

        // Assert
        move.Should().Be((1, 1), "because the center is the most strategic position when available.");
    }

    [Fact]
    public void DecideMove_ShouldChooseACorner_WhenCenterIsNotAvailable()
    {
        // Arrange
        _mockBoard.Setup(b => b.GetBoard()).Returns(new char[,]
        {
            { '.', '.', '.' },
            { '.', 'X', '.' },
            { '.', '.', '.' }
        });
        _mockBoard.Setup(b => b.IsFieldEmpty(It.IsAny<int>(), It.IsAny<int>())).Returns((int row, int col) => row != 1 || col != 1);

        // Act
        var move = _ai.DecideMove(_mockBoard.Object, 'X', 'O');

        // Assert
        move.Should().Match<(int, int)>(m => (m.Item1 == 0 || m.Item1 == 2) && (m.Item2 == 0 || m.Item2 == 2), "because corners are the next strategic positions after the center.");
    }
}
