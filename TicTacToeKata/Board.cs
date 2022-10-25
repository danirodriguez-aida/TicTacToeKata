namespace TicTacToeKataTests;

public class Board
{
    private string[,] board = new string[3, 3];

    public void SetSymbol(string symbol, Square square)
    {
        if (board[square.X, square.Y] != null) throw new UsedCoordinateException();
        board[square.X, square.Y] = symbol;
    }

    public string GetSymbol(Square square)
    {
        return board[square.X, square.Y];
    }
}