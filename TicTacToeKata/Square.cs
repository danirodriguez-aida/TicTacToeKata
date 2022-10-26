namespace TicTacToeKataTests;

public class Square
{
    private Symbol? _mark;
    public Symbol? GetMark() => _mark;

    public void SetMark(Symbol value) => _mark = value;

    public Square(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

}