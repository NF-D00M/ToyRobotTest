namespace ToyRobotTest
{
    public class Simulator
    {
        private readonly Robot _robot;

        public Simulator(Robot robot) 
        { 
            _robot = robot;
        }

        public void Execute(string input)
        { 
            // Split string to extract command
            string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = splitInput[0];

            switch (command)
            {
                case "PLACE":
                    break;
                case "MOVE":
                    break;
                case "LEFT":
                    break;
                case "RIGHT":
                    break;
                case "REPORT":
                    break;
                default:
                    //helpers.CommandNotValidMessage();
                    //helpers.CommandMessage();
                    break;
            }
        }
    }
}
