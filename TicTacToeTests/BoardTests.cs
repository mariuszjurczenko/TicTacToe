using FluentAssertions;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class BoardTests
{
    [Fact]
    public void Board_ShouldBeInitializedWithEmptyFields()
    {
        // Arrange
        var board = new Board();
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
        var board = new Board();

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
        var board = new Board();
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
        var board = new Board();

        // Act Próba - czy pole jest wolne?
        var result = board.IsFieldEmpty(row, col);

        // Assert Weryfikacja - pole gotowe na rycerski cios
        result.Should().BeTrue();
    }

    [Fact]
    public void PrintBoard_ShouldPrintCorrectlyFormattedBoard()
    {
        // Arrange Przygotowanie - saga bitwy na planszy
        var board = new Board();
        board.SetMove(0, 0, 'X');
        board.SetMove(1, 1, 'O');
        board.SetMove(2, 2, 'X');
        var expectedOutput = "X..\r\n.O.\r\n..X\r\n";

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act - wydruk sagi bitwy
            board.PrintBoard();

            // Assert Weryfikacja - czy saga została wiernie odzwierciedlona?
            var result = sw.ToString();
            result.Should().Be(expectedOutput, because: "saga bitewna musi być precyzyjnie przedstawiona na papierze");
        }
    }
}
