public interface IRobot
{
    public void Place(int x, int y, Direction direction);
    public void Move();
    public void Left();
    public void Right();
    public void Report();
}