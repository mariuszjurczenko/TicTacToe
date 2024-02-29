namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        game.PlayGame();
        Console.ReadLine(); // Tutaj czekamy, aż gracz przeczyta wynik gry, zanim zamknie konsolę.
    }
}