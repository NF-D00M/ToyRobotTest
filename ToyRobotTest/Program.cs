// Welcome Message
Console.WriteLine("Welcome to the ToyRobot Challenge");

// Run selection menu
MainMenu menu = new MainMenu();
menu.SelectMode();

// Execute mode from menu selection
if (menu._mode == 0)
{
    InteractiveMode mode = new InteractiveMode();
    mode.PrintInteractiveTitle();
}
else
{
    Console.WriteLine("Run Test Mode");
}
