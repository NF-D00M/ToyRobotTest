using ToyRobotTest.App;

class Program
{
    static void Main(string[] args)
    {
        // App is running
        bool appRunning = true;

        // Instantiate Robot with 5 x 5 table dimensions and simulator
        int tableDimensions = 5;
        Robot robot = new Robot(tableDimensions);
        Simulator simulator = new Simulator(robot);

        // Welcome message
        Helpers helpers = new Helpers();
        helpers.WelcomeMessage();
        helpers.CommandMessage();

        // Running task
        while (appRunning)
        {
            // Read user input
            string? input = Console.ReadLine();

            // Ignore null and whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            // Quit
            if (input == "QUIT")
            {
                break;
            }

            // Execute simulator
            simulator.Execute(input ?? string.Empty);
        }
    }
}
