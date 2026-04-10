using System;

public class Robot : IRobot
{
    // Robot coordinates
    public int _X { get; set; }
    public int _Y { get; set; }
    public Direction _direction {  get; set; }
    bool isPlaced = false;

    public void Place(int x, int y, Direction direction)
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        throw new NotImplementedException();
    }

    public void Left()
    {
        throw new NotImplementedException();
    }

    public void Right()
    {
        throw new NotImplementedException();
    }

    public void Report()
    {
        if(isPlaced)
        {
            Console.WriteLine($"({_X}),({_Y}),{_direction}");
        }
    }
}