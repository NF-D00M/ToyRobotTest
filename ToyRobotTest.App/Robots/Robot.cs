public class Robot : IRobot
{
    private bool isPlaced = false;
    private int _x { get; set; }
    private int _y { get; set; }
    private string _direction = string.Empty;

    private static readonly Dictionary<string, int> _map = new Dictionary<string, int>
    {
        { "NORTH", 0 },
        { "EAST",  1 },
        { "SOUTH", 2 },
        { "WEST",  3 }
    };

    public void Place(int x, int y, string direction)
    {
        // Place co-ordinates
        _x = x;
        _y = y;
        _direction = direction;
        isPlaced = true;
    }

    public void HandlePlacePosition(string placePosition)
    {
        string[] positions = placePosition.Split(',');
        int x = int.Parse(positions[0]);
        int y = int.Parse(positions[1]);
        string direction = positions[2];

        // Validation rules
        if (IsWithinBounds(x, y) && IsValidDirection(direction))
        {
            Place(x, y, direction);
        }
    }

    public void Move()
    {
        // Set new index 
        int newX = _x;
        int newY = _y;

        // Get current direction index
        int directionIndex = _map[_direction];

        // Predict next index
        switch (directionIndex)
        {
            case 0:
                newY++;
                break;
            case 1:
                newX++;
                break;
            case 2:
                newY--;
                break;
            case 3:
                newX--;
                break;
        }

        // Set _x if in boundary
        if (IsWithinBounds(newX, newY))
        {
            _x = newX;
            _y = newY;
        }
    }

    public void Left()
    {
        if (isPlaced)
        {
            // Get direction index
            string key = _direction;
            int directionIndex = _map[_direction];

            // Set new direction index
            int newDirectionIndex = (directionIndex + 3) % 4;
            _direction = _map.FirstOrDefault(x => x.Value == newDirectionIndex).Key;
        }
    }

    public void Right()
    {
        if (isPlaced)
        {
            // Get direction index
            string key = _direction;
            int directionIndex = _map[_direction];

            // Set new direction index
            int newDirectionIndex = (directionIndex + 1) % 4;
            _direction = _map.FirstOrDefault(x => x.Value == newDirectionIndex).Key;
        }
    }

    public String Report()
    {
        if(isPlaced)
        {
            string report = $"{_x},{_y},{_direction}";

            return report;
        }

        return string.Empty;
    }

    public bool IsWithinBounds(int x, int y)
    {
        if (x is >= 0 and < 5 && y is >= 0 and < 5)
        {
            return true;
        }

        return false;
    }

    public bool IsValidDirection(string direction)
    {
        if (!string.IsNullOrWhiteSpace(direction) && _map.ContainsKey(direction.ToUpper()))
        {
            return true;
        }

        return false;
    }
}