namespace ToyRobotTest.App
{
    public class Simulator
    {
        private readonly Robot _robot;
        Helpers helpers = new Helpers();

        public Simulator(Robot robot) 
        { 
            _robot = robot;
        }

        public void Execute(string input)
        { 
            // Split string to extract command and positions
            string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = splitInput[0];
            
            // Menu controls
            switch (command)
            {
                case "PLACE":
                    if (splitInput.Length > 1)
                    {
                        string positions = splitInput[1];
                        _robot.HandlePlacePosition(positions);
                    }
                    break;

                case "MOVE":
                    _robot.Move();
                    break;

                case "LEFT":
                    _robot.Left();
                    break;

                case "RIGHT":
                    _robot.Right();
                    break;

                case "REPORT":
                    Console.WriteLine(_robot.Report());
                    break;

                default:
                    helpers.CommandNotValidMessage();
                    helpers.CommandMessage();
                    break;
            }
        }
    }
}
