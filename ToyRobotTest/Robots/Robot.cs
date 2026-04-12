using System;

public class Robot : IRobot
{
    bool isPlaced = false;
    public int _x { get; set; }
    public int _y { get; set; }
    public string _direction { get; set; }
    public bool _validDirection = false;
    public bool _inBoundary = false;
    public bool _canMove = false;
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
        ValidateBoundary(x, y);
        ValidateDirectionString(direction);

        if (positions?.Length == 3 && _inBoundary && _validDirection)
        {
            Place(x, y, direction);
        }

        // Reset boundary and direction to false
        _inBoundary = false;
        _validDirection = false;
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
        if (ValidateDirectionIndex(newX))
        {
            _x = newX;
        }

        // Set _y if in boundary
        if (ValidateDirectionIndex(newY))
        {
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
            Console.WriteLine(report);
            return report;
        }

        return null;
    }

    public void ValidateBoundary(int x, int y)
    {
        // Validate boundaries
        if ((x >= 0 && x < 5) && (y >= 0 && y < 5))
        {
            _inBoundary = true;
        }
        else
        {
            _inBoundary = false;
        }
    }

    public void ValidateDirectionString(string direction)
    {
        if (!string.IsNullOrWhiteSpace(direction) && _map.ContainsKey(direction))
        {
            _validDirection = true;
        }
        else 
        {
            _validDirection = false;
        }
    }

    public bool ValidateDirectionIndex(int index)
    {
        if (index >= 0 && index < 5)
        {
            return true;
        }

        return false;
    }
}