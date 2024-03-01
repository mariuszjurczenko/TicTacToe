using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Renderers;

public class ConsoleBoardRenderer : IBoardRenderer
{
    public void RenderBoard(Board board)
    {
        int boardRows = board.GetBoard().GetLength(0);
        int boardCols = board.GetBoard().GetLength(1);

        // Szerokość i wysokość komórki wizualnej, łącznie z obramowaniem
        int cellWidth = 4;
        int cellHeight = 2;

        // Całkowita szerokość i wysokość planszy wizualnej
        int boardWidth = (boardCols * cellWidth) + 1;   // +1 dla linii po prawej stronie
        int boardHeight = (boardRows * cellHeight) + 1; // +1 dla linii na dole

        // Obliczanie marginesów, aby wyśrodkować planszę
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        int leftPadding = (consoleWidth - boardWidth) / 2;
        int topPadding = (consoleHeight - boardHeight) / 2;

        // Czyszczenie konsoli i ustawienie kursora
        Console.Clear();

        // Rysowanie szachownicy
        for (int row = 0; row <= boardRows; ++row)
        {
            // Rysowanie górnej linii każdego rzędu komórek
            Console.SetCursorPosition(leftPadding, topPadding + (row * cellHeight));
            Console.Write("+");
            for (int col = 0; col < boardCols; ++col)
            {
                Console.Write(new string('-', cellWidth - 1) + "+");
            }

            // Przejście do kolejnych linii komórek, jeśli nie jest to ostatni rząd
            if (row < boardRows)
            {
                for (int line = 1; line <= cellHeight; ++line)
                {
                    Console.SetCursorPosition(leftPadding, topPadding + (row * cellHeight) + line);
                    for (int col = 0; col <= boardCols; ++col)
                    {
                        // Rysowanie linii pionowych komórek i symbole wewnątrz
                        Console.Write("|");
                        if (col < boardCols)
                        {
                            Console.ForegroundColor = (board.GetSymbol(row, col) == 'X') ? ConsoleColor.Green : (board.GetSymbol(row, col) == 'O') ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write(" " + (board.GetSymbol(row, col) != '\0' ? board.GetSymbol(row, col).ToString() : " ") + " ");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }

        // Ustawienie kursora na koniec, aby nie nadpisywać planszy
        Console.SetCursorPosition(0, topPadding + boardHeight);
    }
}
