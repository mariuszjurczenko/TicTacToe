using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Renderers;

public class ConsoleBoardRenderer : IBoardRenderer
{
    public void RenderBoard(Board board)
    {
        for (int i = 0; i < board.GetSize(); i++)
        {
            for (int j = 0; j < board.GetSize(); j++)
            {
                Console.Write(board.GetSymbol(i, j));
            }
            Console.WriteLine();
        }
    }
}
