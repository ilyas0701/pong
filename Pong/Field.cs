using System.Text;

namespace Pong;

public class Field
{
    private int FieldWidth { get; set; }
    private int FieldHeight { get; set; }
    private Player _player1 { get; set; }
    private Player _player2 { get; set; }
    private Ball _ball { get; set; }
    private char[,] Field1 { get; }

    public Field(int x, int y, Player player1, Player player2, Ball ball)
    {
        FieldWidth = x;
        FieldHeight = y;
        _player1 = player1;
        _player2 = player2;
        _ball = ball;
        Field1 = new char[y, x];

        Task.Run(MoveBall);
    }

    public void DrawField()
    {
        MakeField();

        var res = new StringBuilder(FieldWidth * FieldHeight + FieldHeight * 2);
        for (int i = 0; i < FieldHeight; i++)
        {
            for (int j = 0; j < FieldWidth; j++)
            {
                res.Append(Field1[i, j]);
            }
            res.Append(Environment.NewLine);
        }
        
        Console.Clear();
        Console.Write(res);

        Console.WriteLine("Player 1: " + _player1.Score + " Player 2: " + _player2.Score);
    }

    private void MoveBall()
    {
        while (true)
        {
            _ball.Move(FieldWidth, FieldHeight);

            if (_ball.X == 1 && !_player1.IsColliding(_ball))
            {
                _player2.Score++;
                Thread.Sleep(1000);
                _ball = new Ball(FieldWidth / 2, FieldHeight / 2);
            } else if (_ball.X == FieldWidth - 2 && !_player2.IsColliding(_ball))
            {
                _player1.Score++;
                Thread.Sleep(1000);
                _ball = new Ball(FieldWidth / 2, FieldHeight / 2);
            }
            
            Thread.Sleep(120);
        }
    }

    private void HadleInput(Player player1, Player player2)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            
            switch (key)
            {
                case ConsoleKey.W:
                    player1.MoveUp();
                    break;
                case ConsoleKey.S:
                    player1.MoveDown(FieldHeight);
                    break;
                case ConsoleKey.UpArrow:
                    player2.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    player2.MoveDown(FieldHeight);
                    break;
            }
        }
    }
    
    private void MakeField()
    {
        HadleInput(_player1, _player2);
        
        for (int i = 0; i < FieldHeight; i++)
        {
            for (int j = 0; j < FieldWidth; j++)
            {
                if (i == 0 || i == FieldHeight - 1)
                {
                    Field1[i, j] = '=';
                }
                else
                {
                    Field1[i, j] = ' '; 
                }
            }
        }
        
        for (int i = 0; i < _player1.Platform.GetLength(0); i++)
        {
            Field1[_player1.Y + i, _player1.X] = _player1.Platform[i, 0];
        }

        for (int i = 0; i < _player2.Platform.GetLength(0); i++)
        {
            Field1[_player2.Y + i, _player2.X] = _player2.Platform[i, 0];
        }
        
        Field1[_ball.Y, _ball.X] = _ball.Symbol;
    }
}