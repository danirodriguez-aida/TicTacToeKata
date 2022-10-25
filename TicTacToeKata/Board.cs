namespace TicTacToeKataTests;

public class Board
{
    private string[,] board = new string[3, 3];

    public void SetCoordinate(string symbol, Square square)
    {
        if (board[square.X, square.Y] != null) throw new UsedCoordinateException();
        board[square.X, square.Y] = symbol;
    }

    public string GetCoordinate(int x, int y)
    {
        return board[x, y];
    }
}