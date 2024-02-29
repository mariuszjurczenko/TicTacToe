using FluentAssertions;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class PlayerTests
{
    [Fact]
    public void Player_Constructor_ShouldInitializeSymbol()
    {
        // Arrange
        char expectedSymbol = 'X';

        // Act
        Player player = new Player(expectedSymbol);

        // Assert
        player.Symbol.Should().Be(expectedSymbol);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        char symbol = 'O';
        Player player = new Player(symbol);
        string expectedString = $"Gracz {symbol}"; // Zakładając, że GameTexts.PlayerRepresentation jest w formacie "Gracz {0}"

        // Act
        string result = player.ToString();

        // Assert
        result.Should().Be(expectedString, because: "każdy rycerz powinien być dumnie ogłoszony");
    }
}
