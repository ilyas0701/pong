namespace Pong;

public class Ball
{
    private int _xVector = 1;
    private int _yVector = 1;
    public int X { get; set; }
    public int Y { get; set; }
    public readonly char Symbol = '@';

    public Ball(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(int maxWidth, int maxHeight)
    {
        if (Y + 2 == maxHeight || Y == 1)
        {
            _yVector *= -1;
        }

        if (X + 2 == maxWidth || X == 1)
        {
            _xVector *= -1;
        }
        
        X += _xVector;
        Y += _yVector;
    }
}