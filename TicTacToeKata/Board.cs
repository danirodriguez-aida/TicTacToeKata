namespace TicTacToeKataTests;

public class Board
{
    private string[,] board = new string[3, 3];

    public void SetCoordinate(string symbol, int x, int y)
    {
        if (board[x, y] != null) throw new UsedCoordinateException();
        board[x, y] = symbol;
    }

    public string GetCoordinate(int x, int y)
    {
        return board[x, y];
    }
}