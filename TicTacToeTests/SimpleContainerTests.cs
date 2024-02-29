using FluentAssertions;
using TicTacToe.Interfaces;
using TicTacToe.IoC;
using TicTacToe.Models;

namespace TicTacToe.Tests;

public class SimpleContainerTests
{
    [Fact]
    public void ShouldResolveType_WhenTypeIsRegistered()
    {
        // Arrange - przygotowanie zaklęcia rejestracji
        var container = new SimpleContainer();
        container.For<IBoard>().Use<Board>();

        // Act - przywołanie ducha planszy
        var result = container.Resolve<IBoard>();

        // Assert - potwierdzenie, że duch został prawidłowo wywołany
        result.Should().NotBeNull();
        result.Should().BeOfType<Board>();
    }

    [Fact]
    public void ShouldResolveSameInstance_WhenRegisteredAsSingleton()
    {
        // Arrange - zaklęcie tworzenia wiecznego więzienia
        var container = new SimpleContainer();
        var singletonInstance = new Board();
        container.ForSingleton<IBoard>(singletonInstance);

        // Act - dwukrotne przywołanie ducha planszy
        var result1 = container.Resolve<IBoard>();
        var result2 = container.Resolve<IBoard>();

        // Assert - potwierdzenie, że oba wywołania przywołały tego samego ducha
        result1.Should().BeSameAs(singletonInstance);
        result2.Should().BeSameAs(singletonInstance);
    }

    [Fact]
    public void ShouldResolveTypeWithConstructorDependencies()
    {
        // Arrange - przygotowanie rytuału tworzenia związku między duchami
        var container = new SimpleContainer();
        container.For<IService>().Use<Service>();
        container.For<Consumer>().Use<Consumer>();

        // Act - przywołanie konsumenta duchów
        var result = container.Resolve<Consumer>();

        // Assert - potwierdzenie, że konsument posiada ducha usługi
        result.Should().NotBeNull();
        result.Service.Should().NotBeNull();
        result.Service.Should().BeOfType<Service>();
    }

    [Fact]
    public void Resolve_ShouldReturnNull_WhenTypeCannotBeResolved()
    {
        // Arrange
        var container = new SimpleContainer();

        // Act 
        var result = container.Resolve<IService>();

        // Assert
        result.Should().BeNull();
    }

    public interface IService { }
    public class Service : IService { }

    public class Consumer
    {
        public IService Service { get; }

        public Consumer(IService service)
        {
            Service = service;
        }
    }
}