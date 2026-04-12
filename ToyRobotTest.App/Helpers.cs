namespace ToyRobotTest.App
{
    public class Helpers
    {

        public void WelcomeMessage()
        {
            Console.WriteLine("-- Welcome to the ToyRobot Challenge --");
        }

        public void CommandMessage()
        {
            Console.WriteLine("Enter Commands (PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT | QUIT)");
        }

        public void CommandNotValidMessage()
        {
            Console.WriteLine("Command not valid");
        }
    }
}
