using ToyRobotTest;

class Program
{
    static void Main(string[] args)
    {
        bool appRunning = true;
        Robot robot = new Robot();
        Simulator simulator = new Simulator(robot);

        Helpers helpers = new Helpers();
        helpers.WelcomeMessage();
        helpers.CommandMessage();

        // Running task
        while (appRunning)
        {
            // Read user input
            string input = Console.ReadLine();
            
            // Quit
            if (input == "QUIT")
            {
                break;
            }

            // Execute simulator
            simulator.Execute(input);
        }
    }
}
