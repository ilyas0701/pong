namespace Pong;

class Program
{
    private const int FieldX = 71;
    private const int FieldY = 13;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Player player1 = new Player(0, FieldY/2 - 1);
        Player player2 = new Player(FieldX - 1, FieldY/2 - 1);
        
        Ball ball = new Ball(FieldX/2, FieldY/2);
        
        Field field = new Field(FieldX, FieldY, player1, player2, ball);

        while (true)
        {
            field.DrawField();
            Thread.Sleep(50);
        }
        
        Console.ReadLine();
    }
}