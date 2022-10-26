namespace TicTacToeKataTests;

public class Board
{
    private string[,] board = new string[3, 3];

    public void SetSymbol(Symbol symbol, Square square)
    {
        if (board[square.X, square.Y] != null) throw new UsedCoordinateException();
        board[square.X, square.Y] = symbol.ToString();
    }

    public string GetSymbol(Square square)
    {
        return board[square.X, square.Y];
    }

    public bool IsSameSymbolForRow(int row, string symbol) {
        return Board.GetSquaresForRow(row).All(s => this.GetSymbol(s) == symbol);
    }

    public bool IsSameSymbolForColumn(int column, string symbol) {
        return Board.GetSquaresForColumn(column).All(s => this.GetSymbol(s) == symbol);
    }

    public bool IsSameSymbolForDiagonal(bool isLeftUpToRightDown, string symbol) {
        return Board.GetSquaresForDiagonal(isLeftUpToRightDown).All(s => this.GetSymbol(s) == symbol);
    }

    private static IEnumerable<Square> GetSquaresForRow(int row) {
        return new List<Square>()
        {
            new(row, 0), new (row, 1), new (row, 2)
        };
    }

    private static IEnumerable<Square> GetSquaresForColumn(int column) {
        return new List<Square>()
        {
            new(0,column), new (1,column), new (2,column)
        };
    }

    private static IEnumerable<Square> GetSquaresForDiagonal(bool isLeftUpToRightDown) {
        if (isLeftUpToRightDown) {
            return new List<Square>()
            {
                new(0,0), new (1,1), new (2,2)
            };
        }
        return new List<Square>()
        {
            new(0,2), new (1,1), new (2,0)
        };
    }
}