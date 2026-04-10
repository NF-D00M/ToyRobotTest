using System;

public class MainMenu
{
    public int _mode { get; private set; } = -1;

    public void SelectMode()
    {
        while (_mode != 0 && _mode != 1)
        {
            PrintMenuOptions();
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result) && (result == 0 || result == 1))
            {
                _mode = result;
                Console.WriteLine($"\nMode set to: {_mode}");
            }
            else
            {
                PrintInvalidInput();
            }
        }
    }

    public void PrintMenuOptions()
    {
        Console.WriteLine("\nPlease Select Mode:");
        Console.WriteLine("-- [0] for Interactive");
        Console.WriteLine("-- [1] for Test");
    }

    public void PrintInvalidInput()
    {
        Console.WriteLine("\nInvalid selection. Please Select [0] for Interactive or [1] for Test");
    }
}