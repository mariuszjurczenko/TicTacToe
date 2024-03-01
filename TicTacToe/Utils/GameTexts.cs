namespace TicTacToe.Utils;

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
    public const string ChooseGameMode = "Wybierz tryb gry: 1 - dla przeciwnika AI łatwy, 2 - dla przeciwnika AI średni, 3 - dla ludzkiego przeciwnika";
    public const string SelectSymbol = "Wybierz symbol: X lub O";
    public const string IncorrectSelection = "Nieprawidłowy wybór. Proszę wybrać X lub O:";
    public const string AskIfPlayerStartsFirst = "Czy chcesz rozpocząć grę jako pierwszy? (T/N):";
    public const string IncorrectSelectionWhoStarts = "Nieprawidłowy wybór. Proszę wpisać T (tak) lub N (nie):";
    public const string IncorrectSelectionGameMode = "Nieprawidłowy wybór. Proszę wybrać 1, 2 lub 3.";
    public const string Statistics = "Wygrane X: {0}, Wygrane O: {1}, Remisy: {2}";
}
