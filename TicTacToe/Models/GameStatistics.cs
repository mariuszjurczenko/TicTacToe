using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Models;

public class GameStatistics : IGameStatistics
{
    public int WinsX { get; private set; }
    public int WinsO { get; private set; }
    public int Ties { get; private set; }

    public void IncrementWinsX() => WinsX++;

    public void IncrementWinsO() => WinsO++;

    public void IncrementTies() => Ties++;

    public override string ToString()
    {
        return string.Format(GameTexts.Statistics, WinsX, WinsO, Ties);
    }

    public void SaveStats(string filePath)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(WinsX);
                sw.WriteLine(WinsO);
                sw.WriteLine(Ties);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Nie można zapisać statystyk: " + e.Message);
        }
    }

    public void LoadStats(string filePath)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                WinsX = int.Parse(sr.ReadLine());
                WinsO = int.Parse(sr.ReadLine());
                Ties = int.Parse(sr.ReadLine());
            }
        }
        catch (FileNotFoundException)
        {
            // Plik nie istnieje, zaczynamy bez wczytywania
            WinsX = 0;
            WinsO = 0;
            Ties = 0;
        }
        catch (Exception e)
        {
            Console.WriteLine("Nie można wczytać statystyk: " + e.Message);
        }
    }
}
