namespace TicTacToe;

public static class GameTexts
{
    public const char SymbolX = 'X';
    public const char SymbolO = 'O';
    public const string ConfirmYes = "tak";
    public const string PlayerRepresentation = "Gracz {0}";
    public const string PromptPlayerMove = "Ruch gracza {0}: ";
    public const string PromptRow = "Wybierz wiersz (1-3): ";
    public const string PromptColumn = "Wybierz kolumnę (1-3): ";
    public const string GameTie = "I oto mamy remis! Cóż, czasami życie toczy się jak gra w kółko i krzyżyk, nieważne jak bardzo się starasz, i tak wychodzi na remis.";
    public const string GameWin = "Gratulacje, gracz {0}, wygrywa! Oto Twój cyfrowy laur zwycięstwa!";
    public const string PromptPlayAgain = "Czy chcesz spróbować swoich sił jeszcze raz? (tak/nie) - jak w dobrym serialu, decyzja należy do Ciebie!";
    public const string ErrorInvalidInputOrOccupied = "O nie! To pole jest już zajęte lub coś poszło nie tak. Spróbujmy jeszcze raz.";
    public const string ErrorInputRange = "Hej, superbohaterze, liczba musi być od {0} do {1}. Spróbuj jeszcze raz.";
}
