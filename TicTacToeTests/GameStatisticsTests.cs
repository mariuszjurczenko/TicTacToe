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

    [Fact]
    public void SaveStats_Should_CorrectlyWriteStatsToFile()
    {
        // Arrange
        var gameStatistics = new GameStatistics();
        gameStatistics.IncrementWinsX();
        gameStatistics.IncrementWinsO();
        gameStatistics.IncrementTies();
        string filePath = "TestStatsSave.txt";

        // Act
        gameStatistics.SaveStats(filePath);

        // Assert
        File.Exists(filePath).Should().BeTrue("plik statystyk powinien istnieć");

        var lines = File.ReadAllLines(filePath);
        lines.Length.Should().BeGreaterOrEqualTo(3, "plik powinien zawierać przynajmniej 3 linie");
        lines[0].Should().Be("1", "pierwsza linia powinna reprezentować wygrane X");
        lines[1].Should().Be("1", "druga linia powinna reprezentować wygrane O");
        lines[2].Should().Be("1", "czwarta linia powinna reprezentować liczby remisów");

        // Cleanup
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void LoadStats_Should_CorrectlyReadStatsFromFile()
    {
        // Arrange
        string filePath = "TestStatsLoad.txt";
        File.WriteAllLines(filePath, new string[] { "3", "1", "7" }); // Format zgodny z wymaganiami

        var gameStatistics = new GameStatistics();

        // Act
        gameStatistics.LoadStats(filePath);

        // Assert
        gameStatistics.WinsX.Should().Be(3, "powinna istnieć jedna wygrana dla X");
        gameStatistics.WinsO.Should().Be(1, "powinna istnieć jedna wygrana dla O");
        gameStatistics.Ties.Should().Be(7, "powinien istnieć jeden remis");

        // Cleanup
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
