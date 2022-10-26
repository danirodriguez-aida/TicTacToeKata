namespace TicTacToeKataTests;

public class Board
{
    private List<Square> squares = new()
    {
        new(0, 0), new (0, 1), new (0, 2),
        new(1, 0), new (1, 1), new (1, 2),
        new(2, 0), new (2, 1), new (2, 2)
    };

    public void SetSymbol(Symbol symbol, Square square)
    {
        var squareBoard = GetSquareBy(square);
        if (squareBoard.GetMark().HasValue) throw new UsedCoordinateException();
        squareBoard.SetMark(symbol);
    }

    public Symbol? GetSymbol(Square square)
    {
        var squareBoard = GetSquareBy(square);
        return squareBoard.GetMark();
    }

    public bool IsSameSymbolForRow(int row, Symbol symbol) {
        return GetSquaresForRow(row).All(s => GetSymbol(s) == symbol);
    }

    public bool IsSameSymbolForColumn(int column, Symbol symbol) {
        return GetSquaresForColumn(column).All(s => GetSymbol(s) == symbol);
    }

    public bool IsSameSymbolForDiagonal(bool isLeftUpToRightDown, Symbol symbol) {
        return GetSquaresForDiagonal(isLeftUpToRightDown).All(s => GetSymbol(s) == symbol);
    }

    private Square GetSquareBy(Square square)
    {
        return squares.Single(s => s.X == square.X && s.Y == square.Y);
    }

    private IEnumerable<Square> GetSquaresForRow(int row)
    {
        return squares.Where(s => s.X == row).ToArray();
    }

    private IEnumerable<Square> GetSquaresForColumn(int column) {
        return squares.Where(s => s.Y == column).ToArray();
    }

    private IEnumerable<Square> GetSquaresForDiagonal(bool isLeftUpToRightDown)
    {
        yield return squares.Single(s => s.X ==1 && s.Y == 1);
        if (isLeftUpToRightDown) {
            yield return squares.Single(s => s.X ==0 && s.Y == 0);
            yield return squares.Single(s => s.X ==2 && s.Y == 2);
        }
        else
        {
            yield return squares.Single(s => s.X ==0 && s.Y == 2);
            yield return squares.Single(s => s.X ==2 && s.Y == 0);
        }
    }
}