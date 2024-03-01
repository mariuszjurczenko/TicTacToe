using TicTacToe.Utils;

namespace TicTacToe.UI;

public static class GameUI
{
    public static int GetInput(string prompt, int min, int max)
    {
        int input = -1;
        bool isValidInput = false;

        while (!isValidInput)
        {
            Console.Write(prompt);
            isValidInput = int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max;

            if (!isValidInput)
            {
                Console.WriteLine(string.Format(GameTexts.ErrorInputRange, min, max));
            }
        }

        return input;
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static bool AskToPlayAgain()
    {
        Console.WriteLine(GameTexts.PromptPlayAgain);
        string answer = Console.ReadLine().ToLower();
        return answer == GameTexts.ConfirmYes;
    }

    public static GameMode AskForGameMode()
    {
        // Ah, wielki wybór przed Tobą, o wędrowcze cyfrowych krain! Czy zechcesz zmierzyć się z bezduszną maszyną
        // czy raczej wybierzesz ciepło ludzkiego towarzystwa? Wybierz mądrze, gdyż od tego zależy Twoja dalsza ścieżka.
        Console.WriteLine(GameTexts.ChooseGameMode);
        GameMode choice = 0;
        bool isValidChoice = false;

        while (!isValidChoice)
        {
            if (Enum.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(GameMode), choice))
            {
                isValidChoice = true;
            }
            else
            {
                Console.WriteLine(GameTexts.IncorrectSelectionGameMode);
                Console.WriteLine(GameTexts.ChooseGameMode);
            }
        }

        return choice;
    }

    public static char AskForPlayerSymbol()
    {
        Console.WriteLine(GameTexts.SelectSymbol);
        string input = Console.ReadLine().ToUpper();
        while (input != "X" && input != "O")
        {
            Console.WriteLine(GameTexts.IncorrectSelection);
            input = Console.ReadLine().ToUpper();
        }
        return input[0];
    }

    public static bool AskIfPlayerStartsFirst()
    {
        Console.WriteLine(GameTexts.AskIfPlayerStartsFirst);
        string input = Console.ReadLine().ToUpper();

        // Tutaj zaczyna się magia decyzji. To trochę jak wybór, czy chcesz być Gandalfem i prowadzić drużynę, czy Frodem, mającym zawsze wsparcie z tyłu.
        while (input != "T" && input != "N")
        {
            Console.WriteLine(GameTexts.IncorrectSelectionWhoStarts);
            input = Console.ReadLine().ToUpper();
        }
        return input == "T";
    }
}