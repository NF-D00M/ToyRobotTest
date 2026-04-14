public class Robot : IRobot
{
    private bool _isPlaced = false;
    private int _tableDimensions = 0;
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

    public Robot(int tableDimensions)
    {
        _tableDimensions = tableDimensions;
    }

    public void Place(int x, int y, string direction)
    {
        // Place co-ordinates
        _x = x;
        _y = y;
        _direction = direction;
        _isPlaced = true;
    }

    public void HandlePlacePosition(string placePosition)
    {
        string[] positions = placePosition.Split(',');

        // Ignore malformed positions
        if (positions.Length != 3)
        {
            return;
        }

        // Parse positions, ignore if malformed
        if (int.TryParse(positions[0], out int x) is false ||
            int.TryParse(positions[1], out int y) is false)
        {
            return;
        }

        string direction = positions[2].Trim().ToUpper();

        // Validation rules
        if (IsWithinBounds(x, y) && IsValidDirection(direction))
        {
            Place(x, y, direction);
        }
    }

    public void Move()
    {
        if (!_isPlaced)
        {
            return;
        }

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
        if (_isPlaced)
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
        if (_isPlaced)
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
        if(_isPlaced)
        {
            string report = $"{_x},{_y},{_direction}";

            return report;
        }

        return string.Empty;
    }

    public bool IsWithinBounds(int x, int y)
    {
        if (x >= 0 && x < _tableDimensions && y >= 0 && y < _tableDimensions)
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