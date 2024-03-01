using FluentAssertions;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class GameStatisticsTests
{
    [Fact]
    public void IncrementWinsX_ShouldIncrementWinsXCount_BecauseXAlwaysMarksTheSpot()
    {
        // Arrange
        var stats = new GameStatistics();

        // Act
        stats.IncrementWinsX();

        // Assert
        stats.WinsX.Should().Be(1, because: "X nie tylko wyznacza miejsce, ale także oznacza nasze pierwsze zwycięstwo!");
    }

    [Fact]
    public void IncrementWinsO_ShouldIncrementWinsOCount_BecauseOIsNotJustAZero()
    {
        // Arrange
        var stats = new GameStatistics();

        // Act
        stats.IncrementWinsO();

        // Assert
        stats.WinsO.Should().Be(1, because: "O to nie tylko zera; w naszej książce są to całkowite zwycięstwa!");
    }

    [Fact]
    public void IncrementTies_ShouldIncrementTiesCount_BecauseEvenStalematesNeedLove()
    {
        // Arrange
        var stats = new GameStatistics();

        // Act
        stats.IncrementTies();

        // Assert
        stats.Ties.Should().Be(1, because: "Każdy remis przypomina, że nawet remis wymaga przytulenia.");
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat_BecauseStatisticsTellTheTaleOfGlory()
    {
        // Arrange
        var magicNumber = 1; // The number of times we all tried to be heroes.
        var stats = new GameStatistics();
        stats.IncrementWinsX();
        stats.IncrementWinsO();
        stats.IncrementTies();
        var expectedString = $"Wygrane X: {magicNumber}, Wygrane O: {magicNumber}, Remisy: {magicNumber}";

        // Act
        var result = stats.ToString();

        // Assert
        result.Should().Be(expectedString, because: "Każda liczba w naszych statystykach opowiada historię chwały, rozpaczy i czasami remisu.");
    }
}
