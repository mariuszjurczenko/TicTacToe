using System.Text;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Renderers;

public class ConsoleBoardRenderer : IBoardRenderer
{
    private int boardRows;
    private int boardCols;
    private int cellWidth;
    private int cellHeight;
    private int boardHeight;
    private int leftPadding;
    private int topPadding;

    public void RenderBoard(Board board)
    {
        CalculateBoardDimensions(board);

        for (int row = 0; row <= boardRows; ++row)
        {
            DrawHorizontalLines(row);

            if (row < boardRows)
            {
                for (int line = 1; line <= cellHeight; ++line)
                {
                    DrawVerticalLinesAndSymbols(row, line, board);
                }
            }
        }

        Console.SetCursorPosition(0, topPadding + boardHeight);
    }

    private void DrawHorizontalLines(int row)
    {
        StringBuilder horizontalLineBuilder = new StringBuilder();
        horizontalLineBuilder.Append("+");

        for (int col = 0; col < boardCols; ++col)
        {
            horizontalLineBuilder.Append(new string('-', cellWidth - 1)).Append("+");
        }

        Console.SetCursorPosition(leftPadding, topPadding + (row * cellHeight));
        Console.Write(horizontalLineBuilder.ToString());
    }

    private void DrawVerticalLinesAndSymbols(int row, int line, Board board)
    {
        Console.SetCursorPosition(leftPadding, topPadding + (row * cellHeight) + line);
        for (int col = 0; col <= boardCols; ++col)
        {
            Console.Write("|");
            if (col < boardCols)
            {
                RenderCellSymbol(row, col, board);
            }
        }
    }

    private void RenderCellSymbol(int row, int col, Board board)
    {
        char symbol = board.GetSymbol(row, col);
        Console.ForegroundColor = symbol == 'X' ? ConsoleColor.Green : symbol == 'O' ? ConsoleColor.Red : ConsoleColor.White;
        Console.Write(" " + (symbol != '\0' ? symbol.ToString() : " ") + " ");
        Console.ResetColor();
    }

    private void CalculateBoardDimensions(Board board)
    {
        boardRows = board.GetBoard().GetLength(0);
        boardCols = board.GetBoard().GetLength(1);

        // Szerokość i wysokość komórki wizualnej, łącznie z obramowaniem
        cellWidth = 4;
        cellHeight = 2;

        // Całkowita szerokość i wysokość planszy wizualnej
        int boardWidth = (boardCols * cellWidth) + 1;   // +1 dla linii po prawej stronie
        boardHeight = (boardRows * cellHeight) + 1;

        // Obliczanie marginesów, aby wyśrodkować planszę
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        leftPadding = (consoleWidth - boardWidth) / 2;
        topPadding = (consoleHeight - boardHeight) / 2;

        // Czyszczenie konsoli i ustawienie kursora
        Console.Clear();
    }
}
