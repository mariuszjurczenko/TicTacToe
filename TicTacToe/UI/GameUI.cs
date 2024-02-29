﻿using TicTacToe.Utils;

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

    public static bool AskForGameMode()
    {
        // Ah, wielki wybór przed Tobą, o wędrowcze cyfrowych krain! Czy zechcesz zmierzyć się z bezduszną maszyną
        // czy raczej wybierzesz ciepło ludzkiego towarzystwa? Wybierz mądrze, gdyż od tego zależy Twoja dalsza ścieżka.
        Console.WriteLine(GameTexts.ChooseGameMode);
        var choice = Console.ReadLine();
        // 1 dla AI, cokolwiek innego i masz szansę na ludzki kontakt. Chyba że to też bot. W takim razie, powodzenia!
        return choice == "1";
    }
}