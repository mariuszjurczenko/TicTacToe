using FluentAssertions;
using TicTacToe.Services;

namespace TicTacToe.Tests;

public class PlayerFactoryTests
{
    [Theory]
    [InlineData('X')]
    [InlineData('O')]
    public void CreatePlayer_ShouldCreatePlayerWithGivenSymbol(char symbol)
    {
        // Aranżacja - przygotowanie kuźni do rytuału tworzenia
        var playerFactory = new PlayerFactory();

        // Akt - wezwanie bohatera z głębin magii
        var player = playerFactory.CreatePlayer(symbol);

        // Aserty - potwierdzenie, że kuźnia wykuła prawdziwego bohatera
        player.Should().NotBeNull();
        player.Symbol.Should().Be(symbol, because: "każdy bohater nosi znak swojego przeznaczenia");
    }

    [Fact]
    public void CreatePlayer_WithDifferentSymbols_ShouldCreateDifferentPlayers()
    {
        // Aranżacja - rozbudzenie kuźni przed dwoma różnymi zaklęciami
        var playerFactory = new PlayerFactory();
        char symbolX = 'X';
        char symbolO = 'O';

        // Akt - przywołanie dwóch bohaterów, każdy z innym znakiem przeznaczenia
        var playerX = playerFactory.CreatePlayer(symbolX);
        var playerO = playerFactory.CreatePlayer(symbolO);

        // Aserty - ostateczne potwierdzenie, że kuźnia nie myli bohaterów
        playerX.Should().NotBeSameAs(playerO, because: "każdy bohater jest unikatową istotą");
        playerX.Symbol.Should().Be(symbolX, because: "znak X to przeznaczenie pierwszego bohatera");
        playerO.Symbol.Should().Be(symbolO, because: "znak O to los drugiego wojownika");
    }
}