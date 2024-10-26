namespace Pong;

public class Player
{
    public int Score { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    
    public readonly char[,] Platform = new char[,] {
        { '|' },
        { '|' },
        { '|' }
    };
    public Player(int x, int y)
    {
        Score = 0;
        X = x;
        Y = y;
    }

    public void MoveUp()
    {
        if(Y <= 1) return;

        Y--;
    }

    public void MoveDown(int maxHeight)
    {
        if(Y + 4 == maxHeight) return;

        Y++;
    }

    public bool IsColliding(Ball ball)
    {
        if((ball.X == X + 1 || ball.X == X - 1) && (ball.Y >= Y && ball.Y <= Y + 2)) return true;
        
        return false;
    }
}