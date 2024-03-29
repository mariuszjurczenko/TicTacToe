﻿using FluentAssertions;
using Moq;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class BoardTests
{
    private readonly Mock<IBoardRenderer> _mockBoardRenderer;
    private readonly IBoard board;

    public BoardTests()
    {
        _mockBoardRenderer = new Mock<IBoardRenderer>();
        board = new Board(_mockBoardRenderer.Object);
    }

    [Fact]
    public void Board_ShouldBeInitializedWithEmptyFields()
    {
        // Arrange
        var expectedValue = '.';

        // Act & Assert
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board.GetBoard()[i, j].Should().Be(expectedValue, because: "na początku turnieju każde pole powinno być niezajęte");
            }
        }
    }

    [Theory]
    [InlineData(0, 0, 'X')]
    [InlineData(1, 1, 'O')]
    [InlineData(2, 2, 'X')]
    public void SetMove_ShouldPlacePlayerSymbolOnBoard(int row, int col, char symbol)
    {
        // Arrange Przygotowanie do pojedynku

        // Act Rycerski cios - ustawienie symbolu na planszy
        board.SetMove(row, col, symbol);

        // Assert Weryfikacja, czy symbol został prawidłowo umieszczony
        board.GetBoard()[row, col].Should().Be(symbol);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void IsFieldEmpty_ShouldReturnFalseAfterMoveIsSet(int row, int col)
    {
        // Arrange Przygotowanie - rycerz zajmuje pole
        board.SetMove(row, col, 'X');

        // Act Próba - czy pole jest zajęte?
        var result = board.IsFieldEmpty(row, col);

        // Assert Weryfikacja - pole nie jest już puste
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void IsFieldEmpty_ShouldReturnTrueForEmptyFields(int row, int col)
    {
        // Arrange Przygotowanie - plansza przed bitwą

        // Act Próba - czy pole jest wolne?
        var result = board.IsFieldEmpty(row, col);

        // Assert Weryfikacja - pole gotowe na rycerski cios
        result.Should().BeTrue();
    }

    [Fact]
    public void PrintBoard_ShouldInvokeRenderBoardCorrectly()
    {
        // Arrange
        board.SetMove(0, 0, 'X');
        board.SetMove(1, 1, 'O');
        board.SetMove(2, 2, 'X');

        // Act
        board.PrintBoard();

        // Assert
        _mockBoardRenderer.Verify(m => m.RenderBoard(It.IsAny<Board>()), Times.Once());
    }
}