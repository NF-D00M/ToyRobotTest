public interface IRobot
{
    public void Place(int x, int y, string direction);
    public void HandlePlacePosition(string placePosition);
    public void Move();
    public void Left();
    public void Right();
    public string Report();
}